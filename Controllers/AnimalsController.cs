using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Balanovici_Cristina_PrMPA.Data;
using Balanovici_Cristina_PrMPA.Models;
using Balanovici_Cristina_PrMPA.Models.CabinetViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Balanovici_Cristina_PrMPA.Controllers
{
    [Authorize(Policy ="AdminPlat")]
    public class AnimalsController : Controller
    {
        private readonly VeterinarContext _context;

        public AnimalsController(VeterinarContext context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index(int? id, int? clientID)
        {
            var viewModel = new AnimalIndexData();
            viewModel.Animale = await _context.Animale
                .Include(a => a.AnimaleInregistrate)
                .ThenInclude(a => a.Client)
                .ThenInclude(a => a.Programari)
                .ThenInclude(a => a.Veterinar)
                .AsNoTracking()
                .OrderBy(a => a.Nume)
                .ToListAsync();
            if (id!=null)
            {
                ViewData["AnimalID"] = id.Value;
                Animal animal = viewModel.Animale.Where(a => a.ID == id.Value).Single();
                viewModel.Clienti = animal.AnimaleInregistrate.Select(s => s.Client);
            }
            if(clientID !=null)
            {
                ViewData["ClientID"] = clientID.Value;
                viewModel.Programari = viewModel.Clienti.Where(x => x.ID == clientID).Single().Programari;
            }
            return View(viewModel);
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animale == null)
            {
                return NotFound();
            }

            var animal = await _context.Animale
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nume,Rasa,Gen,DataNasterii")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animale == null)
            {
                return NotFound();
            }

            var animal = await _context.Animale
                .Include(a => a.AnimaleInregistrate).ThenInclude(a => a.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (animal == null)
            { return NotFound(); }

            PopulateRegisteredAnimalData(animal);
            return View(animal);
        }

        private void PopulateRegisteredAnimalData(Animal animal)
        {
            var allClients = _context.Clienti;
            var stapaniAnimal = new HashSet<int>(animal.AnimaleInregistrate.Select(a => a.ClientID));
            var viewModel = new List<AnimalInregistratData>();
            foreach (var client in allClients)
            {
                viewModel.Add(new AnimalInregistratData
                {
                    ClientID = client.ID,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    IsRegistered = stapaniAnimal.Contains(client.ID)
                });
            }
            ViewData["Clienti"] = viewModel;
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedClients)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalToUpdate = await _context.Animale
                .Include(a => a.AnimaleInregistrate)
                .ThenInclude(a => a.Client)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (await TryUpdateModelAsync<Animal>(
                animalToUpdate,
                "",
                a => a.Nume, a => a.Rasa, a => a.Gen, a => a.DataNasterii))
            {
                UpdateAnimal(selectedClients, animalToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists, ");
                }
                return RedirectToAction(nameof(Index));
            }
            UpdateAnimal(selectedClients, animalToUpdate);
            PopulateRegisteredAnimalData(animalToUpdate);
            return View(animalToUpdate);
        }

        private void UpdateAnimal(string[] selectedClients, Animal animalToUpdate)
        {
            if(selectedClients==null)
            {
                animalToUpdate.AnimaleInregistrate = new List<AnimalInregistrat>();
                return;
            }

            var selectedClientsHS = new HashSet<string>(selectedClients);
            var registeredClients = new HashSet<int>(animalToUpdate.AnimaleInregistrate.Select(a => a.Client.ID));
            foreach (var client in _context.Clienti)
            {
                if (selectedClientsHS.Contains(client.ID.ToString()))
                {
                    if(!registeredClients.Contains(client.ID))
                    {
                        animalToUpdate.AnimaleInregistrate.Add(new AnimalInregistrat { AnimalID = animalToUpdate.ID, ClientID = client.ID });
                    }
                }
                else
                {
                    if (registeredClients.Contains(client.ID))
                    {
                        AnimalInregistrat animalToRemove = animalToUpdate.AnimaleInregistrate.FirstOrDefault(a=>a.ClientID == client.ID);
                        _context.Remove(animalToRemove);
                    }
                }
            }
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animale == null)
            {
                return NotFound();
            }

            var animal = await _context.Animale
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animale == null)
            {
                return Problem("Entity set 'VeterinarContext.Animale'  is null.");
            }
            var animal = await _context.Animale.FindAsync(id);
            if (animal != null)
            {
                _context.Animale.Remove(animal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
          return _context.Animale.Any(e => e.ID == id);
        }
    }
}

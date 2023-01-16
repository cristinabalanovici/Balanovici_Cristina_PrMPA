using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Balanovici_Cristina_PrMPA.Data;
using Balanovici_Cristina_PrMPA.Models;

namespace Balanovici_Cristina_PrMPA.Controllers
{
    public class VeterinarsController : Controller
    {
        private readonly VeterinarContext _context;

        public VeterinarsController(VeterinarContext context)
        {
            _context = context;
        }

        // GET: Veterinars
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["LastNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var veterinari = from v in _context.Veterinari
                             select v;
            if (!String.IsNullOrEmpty(searchString))
            {
                veterinari = veterinari.Where(s => s.LastName.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    veterinari = veterinari.OrderByDescending(v => v.LastName);
                    break;
                default:
                    veterinari = veterinari.OrderBy(v => v.LastName);
                    break;
            }
            int pageSize = 2;
            return View(await PaginatedList<Veterinar>.CreateAsync(veterinari.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Veterinars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Veterinari == null)
            {
                return NotFound();
            }

            var veterinar = await _context.Veterinari
                .Include (p => p.Programari)
                .ThenInclude(c => c.Client)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (veterinar == null)
            {
                return NotFound();
            }

            return View(veterinar);
        }

        // GET: Veterinars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName")] Veterinar veterinar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(veterinar);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists ");
            }
            return View(veterinar);
        }

        // GET: Veterinars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Veterinari == null)
            {
                return NotFound();
            }

            var veterinar = await _context.Veterinari.FindAsync(id);
            if (veterinar == null)
            {
                return NotFound();
            }
            return View(veterinar);
        }

        // POST: Veterinars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName")] Veterinar veterinar)
        {
            if (id != veterinar.ID)
            {
                return NotFound();
            }

            var veterinarToUpdate = await _context.Veterinari.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Veterinar>(
                veterinarToUpdate,
                "",
                s=>s.FirstName, s=>s.LastName))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists");
                }
            }
            return View(veterinarToUpdate);
        }

        // GET: Veterinars/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Veterinari == null)
            {
                return NotFound();
            }

            var veterinar = await _context.Veterinari
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (veterinar == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again";
            }
            return View(veterinar);
        }

        // POST: Veterinars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinar = await _context.Veterinari.FindAsync(id);
            if (veterinar == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Veterinari.Remove(veterinar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool VeterinarExists(int id)
        {
          return _context.Veterinari.Any(e => e.ID == id);
        }
    }
}

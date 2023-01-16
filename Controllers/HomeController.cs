using Balanovici_Cristina_PrMPA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Balanovici_Cristina_PrMPA.Data;
using Balanovici_Cristina_PrMPA.Models.CabinetViewModels;
namespace Balanovici_Cristina_PrMPA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly VeterinarContext _context;
        public HomeController(VeterinarContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Statistici()
        {
            IQueryable<ProgramareGroup> data =
                from programare in _context.Programari
                group programare by programare.Data into programareGroup
                select new ProgramareGroup()
                {
                    DataProgramare = programareGroup.Key,
                    NrProgramari = programareGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
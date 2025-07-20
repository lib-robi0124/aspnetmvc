using FinanceApp.Data;
using FinanceApp.Data.Service;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpencesController : Controller
    {
        //private readonly FinanceAppContext _context;
        private readonly IExpencesService _expencesService;
        //public ExpencesController(FinanceAppContext context)
        //{
        //    _context = context;
        //}
        public ExpencesController(IExpencesService expencesService)
        {
            _expencesService = expencesService;
        }
        //public IActionResult Index()
        //{
        //    var expences = _context.Expences.ToList();
        //    return View(expences);
        //}
        //public async Task<IActionResult> Index()
        //{
        //    var expences = await _context.Expences.ToListAsync();
        //    return View(expences);
        //}
        public async Task<IActionResult> Index()
        {
            var expences = await _expencesService.GetAll();
            return View(expences);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //public IActionResult Create(Expence expence)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Expences.Add(expence);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(expence);
        //}
        public async Task<IActionResult> Create(Expence expence)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Expences.Add(expence);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            if (ModelState.IsValid)
            {
                await _expencesService.Add(expence);
               
                return RedirectToAction("Index");
            }
            return View(expence);
        }
        public IActionResult GetChart()
        {
            //var data = _context.Expences
            //    .GroupBy(e => e.Category)
            //    .Select(g => new
            //    {
            //        Category = g.Key,
            //        Total = g.Sum(e => e.Amount)
            //    });
            var data = _expencesService.GetChartData();
            return Json(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using News21.Data;
using News21.Models;

namespace News21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsInfos.Include(n => n.Country).Include(n => n.NewsCategory).OrderBy(x => Guid.NewGuid()).ToListAsync());
        }
        public async Task<IActionResult> ViewNewsID(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.NewsInfos
                .Include(b => b.Country)
                .Include(b => b.NewsCategory)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }
        public async Task<IActionResult> ViewComments(int? id)
        {
            var applicationDbContext = _context.NewsComments
           .Include(b => b.News).Where(m => m.NewsID== id);
            return View(await applicationDbContext.ToListAsync());
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

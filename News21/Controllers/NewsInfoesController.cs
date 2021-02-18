using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News21.Data;
using News21.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace News21.Controllers
{
    [Authorize(Roles ="admin")]
    public class NewsInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public NewsInfoesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: NewsInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NewsInfos.Include(n => n.Country).Include(n => n.NewsCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NewsInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsInfo = await _context.NewsInfos
                .Include(n => n.Country)
                .Include(n => n.NewsCategory)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (newsInfo == null)
            {
                return NotFound();
            }

            return View(newsInfo);
        }

        // GET: NewsInfoes/Create
        public IActionResult Create()
        {
            ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryName");
            ViewData["CategoryID"] = new SelectList(_context.NewsCategories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: NewsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsID,NewsTitle,Description,File,CountryID,CategoryID")] NewsInfo newsInfo)
        {
            using (var memoryStream = new MemoryStream())
            {
                await newsInfo.File.FormFile.CopyToAsync(memoryStream);

                string photoname = newsInfo.File.FormFile.FileName;
                newsInfo.Extension = Path.GetExtension(photoname);
                if (!".jpg.jpeg.png.gif.bmp".Contains(newsInfo.Extension.ToLower()))
                {
                    ModelState.AddModelError("File.FormFile", "Invalid Format of Image Given.");
                }
                else
                {
                    ModelState.Remove("Extension");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(newsInfo);
                await _context.SaveChangesAsync();
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "newsphotos");
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                string filename = newsInfo.NewsID + newsInfo.Extension;
                var filePath = Path.Combine(uploadsRootFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newsInfo.File.FormFile.CopyToAsync(fileStream).ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryName", newsInfo.CountryID);
            ViewData["CategoryID"] = new SelectList(_context.NewsCategories, "CategoryID", "CategoryName", newsInfo.CategoryID);
            return View(newsInfo);
        }

        // GET: NewsInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsInfo = await _context.NewsInfos.FindAsync(id);
            if (newsInfo == null)
            {
                return NotFound();
            }
            ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryName", newsInfo.CountryID);
            ViewData["CategoryID"] = new SelectList(_context.NewsCategories, "CategoryID", "CategoryName", newsInfo.CategoryID);
            return View(newsInfo);
        }

        // POST: NewsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsID,NewsTitle,Description,Extension,CountryID,CategoryID")] NewsInfo newsInfo)
        {
            if (id != newsInfo.NewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsInfoExists(newsInfo.NewsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryID"] = new SelectList(_context.Countries, "CountryID", "CountryName", newsInfo.CountryID);
            ViewData["CategoryID"] = new SelectList(_context.NewsCategories, "CategoryID", "CategoryName", newsInfo.CategoryID);
            return View(newsInfo);
        }

        // GET: NewsInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsInfo = await _context.NewsInfos
                .Include(n => n.Country)
                .Include(n => n.NewsCategory)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (newsInfo == null)
            {
                return NotFound();
            }

            return View(newsInfo);
        }

        // POST: NewsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsInfo = await _context.NewsInfos.FindAsync(id);
            _context.NewsInfos.Remove(newsInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsInfoExists(int id)
        {
            return _context.NewsInfos.Any(e => e.NewsID == id);
        }
    }
}

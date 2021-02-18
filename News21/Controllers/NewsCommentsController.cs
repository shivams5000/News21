using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News21.Data;
using News21.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace News21.Controllers
{
    [Authorize]
    public class NewsCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public NewsCommentsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: NewsComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NewsComments.Include(n => n.News);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NewsComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsComment = await _context.NewsComments
                .Include(n => n.News)
                .FirstOrDefaultAsync(m => m.CommentID == id);
            if (newsComment == null)
            {
                return NotFound();
            }

            return View(newsComment);
        }

        // GET: NewsComments/Create
        public IActionResult Create()
        {
            ViewData["NewsID"] = new SelectList(_context.NewsInfos, "NewsID", "NewsTitle");
            return View();
        }

        // POST: NewsComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentID,CommentText,NewsID")] NewsComment newsComment)
        {
            ModelState.Remove("ReviewerName");
            ModelState.Remove("CommentDate");
            if (ModelState.IsValid)
            {
                newsComment.ReviewerName = _userManager.GetUserName(this.User);
                newsComment.CommentDate = DateTime.Now;
                _context.Add(newsComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewsID"] = new SelectList(_context.NewsInfos, "NewsID", "NewsTitle", newsComment.NewsID);
            return View(newsComment);
        }

        // GET: NewsComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsComment = await _context.NewsComments.FindAsync(id);
            if (newsComment == null)
            {
                return NotFound();
            }
            ViewData["NewsID"] = new SelectList(_context.NewsInfos, "NewsID", "NewsTitle", newsComment.NewsID);
            return View(newsComment);
        }

        // POST: NewsComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentID,CommentText,CommentDate,ReviewerName,NewsID")] NewsComment newsComment)
        {
            if (id != newsComment.CommentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsCommentExists(newsComment.CommentID))
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
            ViewData["NewsID"] = new SelectList(_context.NewsInfos, "NewsID", "NewsTitle", newsComment.NewsID);
            return View(newsComment);
        }

        // GET: NewsComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsComment = await _context.NewsComments
                .Include(n => n.News)
                .FirstOrDefaultAsync(m => m.CommentID == id);
            if (newsComment == null)
            {
                return NotFound();
            }

            return View(newsComment);
        }

        // POST: NewsComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsComment = await _context.NewsComments.FindAsync(id);
            _context.NewsComments.Remove(newsComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsCommentExists(int id)
        {
            return _context.NewsComments.Any(e => e.CommentID == id);
        }
    }
}

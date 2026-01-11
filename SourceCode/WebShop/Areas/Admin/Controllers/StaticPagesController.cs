using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaticPagesController : Controller
    {
        private readonly WebshopdbContext _context;

        public StaticPagesController(WebshopdbContext context)
        {
            _context = context;
        }

        // GET: Admin/StaticPages
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaticPages.ToListAsync());
        }

        // GET: Admin/StaticPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticPage = await _context.StaticPages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (staticPage == null)
            {
                return NotFound();
            }

            return View(staticPage);
        }

        // GET: Admin/StaticPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/StaticPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageId,PageTitle,LanguageId,PageContent")] StaticPage staticPage)
        {
            staticPage.CreatedOn = DateTime.Now;
            staticPage.ModifiedOn = DateTime.Now;
            staticPage.LastUpdatedBy = 1; // TODO: Replace with actual user ID

            if (ModelState.IsValid)
            {
                _context.Add(staticPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staticPage);
        }

        // GET: Admin/StaticPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticPage = await _context.StaticPages.FindAsync(id);
            if (staticPage == null)
            {
                return NotFound();
            }
            return View(staticPage);
        }

        // POST: Admin/StaticPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageId,PageTitle,LanguageId,PageContent,CreatedOn,LastUpdatedBy,ModifiedOn")] StaticPage staticPage)
        {
            if (id != staticPage.PageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staticPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaticPageExists(staticPage.PageId))
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
            return View(staticPage);
        }

        // GET: Admin/StaticPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staticPage = await _context.StaticPages
                .FirstOrDefaultAsync(m => m.PageId == id);
            if (staticPage == null)
            {
                return NotFound();
            }

            return View(staticPage);
        }

        // POST: Admin/StaticPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staticPage = await _context.StaticPages.FindAsync(id);
            if (staticPage != null)
            {
                _context.StaticPages.Remove(staticPage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaticPageExists(int id)
        {
            return _context.StaticPages.Any(e => e.PageId == id);
        }
    }
}

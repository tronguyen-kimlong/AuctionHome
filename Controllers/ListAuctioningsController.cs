using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionHome.Data;
using AuctionHome.Models;

namespace AuctionHome.Controllers
{
    public class ListAuctioningsController : Controller
    {
        private readonly AuctionContext _context;

        public ListAuctioningsController(AuctionContext context)
        {
            _context = context;
        }

        // GET: ListAuctionings
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListAuctionings.ToListAsync());
        }

        // GET: ListAuctionings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listAuctioning = await _context.ListAuctionings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listAuctioning == null)
            {
                return NotFound();
            }

            return View(listAuctioning);
        }

        // GET: ListAuctionings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListAuctionings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserArrayString")] ListAuctioning listAuctioning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listAuctioning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listAuctioning);
        }

        // GET: ListAuctionings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listAuctioning = await _context.ListAuctionings.FindAsync(id);
            if (listAuctioning == null)
            {
                return NotFound();
            }
            return View(listAuctioning);
        }

        // POST: ListAuctionings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserArrayString")] ListAuctioning listAuctioning)
        {
            if (id != listAuctioning.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listAuctioning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListAuctioningExists(listAuctioning.Id))
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
            return View(listAuctioning);
        }

        // GET: ListAuctionings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listAuctioning = await _context.ListAuctionings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listAuctioning == null)
            {
                return NotFound();
            }

            return View(listAuctioning);
        }

        // POST: ListAuctionings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listAuctioning = await _context.ListAuctionings.FindAsync(id);
            _context.ListAuctionings.Remove(listAuctioning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListAuctioningExists(int id)
        {
            return _context.ListAuctionings.Any(e => e.Id == id);
        }
    }
}

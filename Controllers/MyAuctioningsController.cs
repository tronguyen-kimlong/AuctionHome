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
    public class MyAuctioningsController : Controller
    {
        private readonly AuctionContext _context;

        public MyAuctioningsController(AuctionContext context)
        {
            _context = context;
        }

        // GET: MyAuctionings
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyAuctionings.ToListAsync());
        }

        // GET: MyAuctionings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myAuctioning = await _context.MyAuctionings
                .FirstOrDefaultAsync(m => m.IdItemAndUsername == id);
            if (myAuctioning == null)
            {
                return NotFound();
            }

            return View(myAuctioning);
        }

        // GET: MyAuctionings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyAuctionings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdItemAndUsername,Cost,IsAuctioning")] MyAuctioning myAuctioning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myAuctioning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myAuctioning);
        }

        // GET: MyAuctionings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myAuctioning = await _context.MyAuctionings.FindAsync(id);
            if (myAuctioning == null)
            {
                return NotFound();
            }
            return View(myAuctioning);
        }

        // POST: MyAuctionings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdItemAndUsername,Cost,IsAuctioning")] MyAuctioning myAuctioning)
        {
            if (id != myAuctioning.IdItemAndUsername)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myAuctioning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyAuctioningExists(myAuctioning.IdItemAndUsername))
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
            return View(myAuctioning);
        }

        // GET: MyAuctionings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myAuctioning = await _context.MyAuctionings
                .FirstOrDefaultAsync(m => m.IdItemAndUsername == id);
            if (myAuctioning == null)
            {
                return NotFound();
            }

            return View(myAuctioning);
        }

        // POST: MyAuctionings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var myAuctioning = await _context.MyAuctionings.FindAsync(id);
            _context.MyAuctionings.Remove(myAuctioning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyAuctioningExists(string id)
        {
            return _context.MyAuctionings.Any(e => e.IdItemAndUsername == id);
        }
    }
}

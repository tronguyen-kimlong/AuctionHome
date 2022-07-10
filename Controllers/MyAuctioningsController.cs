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
            var auctionContext = _context.MyAuctionings.Include(m => m.IdItemNavigation).Include(m => m.IdUserNavigation);
            return View(await auctionContext.ToListAsync());
        }

        // GET: MyAuctionings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myAuctioning = await _context.MyAuctionings
                .Include(m => m.IdItemNavigation)
                .Include(m => m.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myAuctioning == null)
            {
                return NotFound();
            }

            return View(myAuctioning);
        }

        // GET: MyAuctionings/Create
        public IActionResult Create()
        {
            ViewData["IdItem"] = new SelectList(_context.Items, "Id", "IdUser");
            ViewData["IdUser"] = new SelectList(_context.Users, "Username", "Username");
            return View();
        }

        // POST: MyAuctionings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdItem,IdUser,Cost,IsAuctioning")] MyAuctioning myAuctioning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myAuctioning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdItem"] = new SelectList(_context.Items, "Id", "IdUser", myAuctioning.IdItem);
            ViewData["IdUser"] = new SelectList(_context.Users, "Username", "Username", myAuctioning.IdUser);
            return View(myAuctioning);
        }

        // GET: MyAuctionings/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["IdItem"] = new SelectList(_context.Items, "Id", "IdUser", myAuctioning.IdItem);
            ViewData["IdUser"] = new SelectList(_context.Users, "Username", "Username", myAuctioning.IdUser);
            return View(myAuctioning);
        }

        // POST: MyAuctionings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdItem,IdUser,Cost,IsAuctioning")] MyAuctioning myAuctioning)
        {
            if (id != myAuctioning.Id)
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
                    if (!MyAuctioningExists(myAuctioning.Id))
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
            ViewData["IdItem"] = new SelectList(_context.Items, "Id", "IdUser", myAuctioning.IdItem);
            ViewData["IdUser"] = new SelectList(_context.Users, "Username", "Username", myAuctioning.IdUser);
            return View(myAuctioning);
        }

        // GET: MyAuctionings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myAuctioning = await _context.MyAuctionings
                .Include(m => m.IdItemNavigation)
                .Include(m => m.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myAuctioning == null)
            {
                return NotFound();
            }

            return View(myAuctioning);
        }

        // POST: MyAuctionings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myAuctioning = await _context.MyAuctionings.FindAsync(id);
            _context.MyAuctionings.Remove(myAuctioning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyAuctioningExists(int id)
        {
            return _context.MyAuctionings.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionHome.Data;
using AuctionHome.Models;
using AuctionHome.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AuctionHome.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUser  userInterface;

        public UsersController(IUser user)
        {
            userInterface = user;
        }
        private string getUserClaim()
        {

            foreach (var claim in User.Claims)
            {
                var claimType = claim.Type;
                if (claimType == "username") return claim.Value;

            }
            return null;
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await userInterface.getAll());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Profile(string username)
        {
            if (username == null)
            {
                return NotFound();
            }

            var user = await userInterface.getByUsername(username);
            if (user == null)
            {
                return NotFound();
            }
            if(username == getUserClaim())
            {
                ViewBag.editUser = true;
            }

            return View(user);
        }

        // GET: Users/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( User user)
        {
            //[Bind("Username,Password,Gender,Phone,Email,Lockuser,Address,Description,PaypalSandbox,Wallet")]
            //if (ModelState.IsValid)
            //{
               
            //}
            if(user != null)
            {
                user.Wallet = 0;
                await userInterface.create(user);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Login", "Account",user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit()
        {
            string idUser = getUserClaim();
            if (idUser == null)
            {
                return NotFound();
            }

            var user = await userInterface.getByUsername(idUser.Trim());
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( User user)
        {
            string userId = getUserClaim();
            if (userId != user.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await userInterface.update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await userInterface.getByUsername(user.Username) == null)
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
            return View(user);
        }

        
        
       
        
    }
}

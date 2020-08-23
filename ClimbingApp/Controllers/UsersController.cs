using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClimbingApp.Models;
using Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ClimbingApp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ClimbAppContext _context;



        // Gets the user id from session
        //private String UserIDSess => HttpContext.Session.GetString("oic");
        private String UserIDSess = "cb1ee329-650c-4680-ab6c-6240e972e97d";

        public UsersController(ClimbAppContext context)
        {
            _context = context;

        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var id = UserIDSess;
            // id = UserIDSess;
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(User user)
        {
            var id = UserIDSess;
            // id = UserIDSess;
            if (id == null)
            {
                return NotFound();
            }

            user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserID,Weight,Height,ApeIndex,StatID")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
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

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}

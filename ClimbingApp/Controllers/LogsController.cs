using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClimbingApp.Models;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ClimbingApp.Controllers
{
    [Authorize]
    public class LogsController : Controller
    {
        private readonly ClimbAppContext _context;

        private String UserIDSess => HttpContext.Session.GetString("oic");

        public LogsController(ClimbAppContext context)
        {
            _context = context;
        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            var climbAppContext = _context.Logs.Include(l => l.Boulder).Include(l => l.Sport).Include(l => l.User);
            return View(await climbAppContext.ToListAsync());
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.Boulder)
                .Include(l => l.Sport)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // GET: Logs/Create
        public IActionResult Create()
        {
            ViewData["BoulderID"] = new SelectList(_context.Boulders, "BoulderID", "Name");
            ViewData["SportID"] = new SelectList(_context.Sports, "SportID", "Name");
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID");
            return View();
        }

        // POST: Logs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogID,Type,ModifyDate,BoulderID,SportID,UserID")] Log log)
        {
            if (ModelState.IsValid)
            {
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoulderID"] = new SelectList(_context.Boulders, "BoulderID", "Name", log.BoulderID);
            ViewData["SportID"] = new SelectList(_context.Sports, "SportID", "Name", log.SportID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", log.UserID);
            return View(log);
        }

        // GET: Logs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs.FindAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            ViewData["BoulderID"] = new SelectList(_context.Boulders, "BoulderID", "Name", log.BoulderID);
            ViewData["SportID"] = new SelectList(_context.Sports, "SportID", "Name", log.SportID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", log.UserID);
            return View(log);
        }

        // POST: Logs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LogID,Type,ModifyDate,BoulderID,SportID,UserID")] Log log)
        {
            if (id != log.LogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(log);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogExists(log.LogID))
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
            ViewData["BoulderID"] = new SelectList(_context.Boulders, "BoulderID", "Name", log.BoulderID);
            ViewData["SportID"] = new SelectList(_context.Sports, "SportID", "Name", log.SportID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", log.UserID);
            return View(log);
        }

        // GET: Logs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.Boulder)
                .Include(l => l.Sport)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var log = await _context.Logs.FindAsync(id);
            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogExists(string id)
        {
            return _context.Logs.Any(e => e.LogID == id);
        }
    }
}

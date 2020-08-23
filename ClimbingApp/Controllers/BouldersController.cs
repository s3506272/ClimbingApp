using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClimbingApp.Models;
using Data;
using ClimbingApp.MiscUtilities;

namespace ClimbingApp.Controllers
{
    public class BouldersController : Controller
    {
        private readonly ClimbAppContext _context;

        public BouldersController(ClimbAppContext context)
        {
            _context = context;
        }

        // GET: Boulders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boulders.ToListAsync());
        }

        // GET: Boulders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boulder = await _context.Boulders
                .FirstOrDefaultAsync(m => m.BoulderID == id);
            if (boulder == null)
            {
                return NotFound();
            }

            return View(boulder);
        }

        // GET: Boulders/Create
        public IActionResult Create()
        {

            var boulder = from BoulderingClimbingGrade b in Enum.GetValues(typeof(BoulderingClimbingGrade))
                          select new { ID = (int)b, Name = b.GetDescription() };

            ViewData["Boulder"] = new SelectList(boulder, "ID", "Name");

            return View();
        }

        // POST: Boulders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BoulderID,Name,Area,Location,BoulderingClimbingGrade,ConsensusGrade,ModifyDate")] Boulder boulder)
        {

            boulder.ModifyDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(boulder);
                await _context.SaveChangesAsync();
                return Redirect("/Logbook/create");
            }
            return View(boulder);
        }

        // GET: Boulders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boulder = await _context.Boulders.FindAsync(id);
            if (boulder == null)
            {
                return NotFound();
            }
            return View(boulder);
        }

        // POST: Boulders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BoulderID,Name,Area,Location,BoulderingClimbingGrade,ConsensusGrade,ModifyDate")] Boulder boulder)
        {
            if (id != boulder.BoulderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boulder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoulderExists(boulder.BoulderID))
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
            return View(boulder);
        }

        // GET: Boulders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boulder = await _context.Boulders
                .FirstOrDefaultAsync(m => m.BoulderID == id);
            if (boulder == null)
            {
                return NotFound();
            }

            return View(boulder);
        }

        // POST: Boulders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boulder = await _context.Boulders.FindAsync(id);
            _context.Boulders.Remove(boulder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoulderExists(int id)
        {
            return _context.Boulders.Any(e => e.BoulderID == id);
        }
    }
}

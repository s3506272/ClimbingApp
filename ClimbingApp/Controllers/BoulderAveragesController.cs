using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClimbingApp.Models;
using Data;

namespace ClimbingApp.Controllers
{
    public class BoulderAveragesController : Controller
    {
        private readonly ClimbAppContext _context;

        public BoulderAveragesController(ClimbAppContext context)
        {
            _context = context;
        }

        // GET: BoulderAverages
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoulderAverage.ToListAsync());
        }

        // GET: BoulderAverages/Details/5
        public async Task<IActionResult> Details(BoulderingClimbingGrade id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boulderAverage = await _context.BoulderAverage
                .FirstOrDefaultAsync(m => m.BoulderAverageID == id);
            if (boulderAverage == null)
            {
                return NotFound();
            }

            return View(boulderAverage);
        }

        // GET: BoulderAverages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoulderAverages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BoulderAverageID,PullUps,PushUps,HangEdge,HangWeight,RowVersion")] BoulderAverage boulderAverage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boulderAverage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boulderAverage);
        }

        // GET: BoulderAverages/Edit/5
        public async Task<IActionResult> Edit(BoulderingClimbingGrade id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boulderAverage = await _context.BoulderAverage.FindAsync(id);
            if (boulderAverage == null)
            {
                return NotFound();
            }
            return View(boulderAverage);
        }

        // POST: BoulderAverages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BoulderingClimbingGrade id, [Bind("BoulderAverageID,PullUps,PushUps,HangEdge,HangWeight,RowVersion")] BoulderAverage boulderAverage)
        {
            if (id != boulderAverage.BoulderAverageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boulderAverage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoulderAverageExists(boulderAverage.BoulderAverageID))
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
            return View(boulderAverage);
        }

        // GET: BoulderAverages/Delete/5
        public async Task<IActionResult> Delete(BoulderingClimbingGrade id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boulderAverage = await _context.BoulderAverage
                .FirstOrDefaultAsync(m => m.BoulderAverageID == id);
            if (boulderAverage == null)
            {
                return NotFound();
            }

            return View(boulderAverage);
        }

        // POST: BoulderAverages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(BoulderingClimbingGrade id)
        {
            var boulderAverage = await _context.BoulderAverage.FindAsync(id);
            _context.BoulderAverage.Remove(boulderAverage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoulderAverageExists(BoulderingClimbingGrade id)
        {
            return _context.BoulderAverage.Any(e => e.BoulderAverageID == id);
        }
    }
}

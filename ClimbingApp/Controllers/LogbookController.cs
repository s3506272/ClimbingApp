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
using ClimbingApp.MiscUtilities;
using ClimbingApp.ViewModel;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Extensions.Azure;

namespace ClimbingApp.Controllers
{
    [Authorize]
    public class LogBookController : Controller
    {
        private readonly ClimbAppContext _context;


        private String UserIDSess => HttpContext.Session.GetString("oic");
        public LogBookController(ClimbAppContext context)
        {
            _context = context;

        }

        // GET: Stats
        [HttpGet]
        public async Task<IActionResult> Index(LogBookViewModel viewModel)
        {

            var id = UserIDSess;
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);

            viewModel.UserId = user.UserID;
            viewModel.Logs = user.Logs;


            return View(viewModel);
        }

        [HttpGet]
        // GET: Stats/Edit/5
        public async Task<IActionResult> Create()
        {
            CreateLogViewModel viewModel = new CreateLogViewModel();

            viewModel.Boulders = await _context.Boulders.ToListAsync();
            viewModel.SportClimbs = await _context.Sports.ToListAsync();

            var List1 = viewModel.Boulders.Select(
                        c => new
                        {
                            c.Area
                        });

            var List2 = viewModel.SportClimbs.Select(
            c => new
            {
                c.Area
            });

            var aList = List1.Concat(List2).Distinct().ToList();


            ViewData["UserID"] = UserIDSess;

            ViewData["Area"] = new SelectList(aList, "Area", "Area");
            return View(viewModel);
        }




        // POST: Logs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLogViewModel viewModel)
        {

            viewModel.Log.UserID = UserIDSess;
            viewModel.Boulders = await _context.Boulders.ToListAsync();
            viewModel.SportClimbs = await _context.Sports.ToListAsync();


            if (viewModel.Log.Type == ClimbType.Boulder) {
                viewModel.Log.BoulderID = viewModel.climbID;
            }
            else {
                viewModel.Log.SportID = viewModel.climbID;
            }


            Log log = new Log
            {
                Type = viewModel.Log.Type,
                UserID = UserIDSess,
                ModifyDate = viewModel.Log.ModifyDate

            };
            Debug.WriteLine("checking select valuye" + viewModel.climbID);

            if (viewModel.Log.Type == ClimbType.Boulder)
            {
                if (viewModel.climbID == null)
                {
                    ModelState.AddModelError(nameof(viewModel.climbID), "Must select a climb.");
                }
                log.BoulderID = viewModel.climbID;

            }
            else
            {
                if (viewModel.climbID == null)
                {
                    
                    ModelState.AddModelError(nameof(viewModel.climbID), "Must select a climb.");
                }
                log.SportID = viewModel.climbID;
            }


            if (ModelState.IsValid)
            {

                _context.Logs.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            var List1 = viewModel.Boulders.Select(
              c => new
              {
                  c.Area
              });

            var List2 = viewModel.SportClimbs.Select(
            c => new
            {
                c.Area
            });
            Debug.WriteLine(viewModel.SportClimbs);
            Debug.WriteLine(List1.Concat(List2).Distinct().ToList());

            var aList = List1.Concat(List2).Distinct().ToList();

            ViewData["Area"] = new SelectList(aList, "Area", "Area");
            return View(viewModel);

        }

    }
}

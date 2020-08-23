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
    public class StatsController : Controller
    {
        private readonly ClimbAppContext _context;


        //private String UserIDSess => HttpContext.Session.GetString("oic");
        private String UserIDSess = "9de50682-5b08-4dac-b536-2ffac1e6dcb5";


        public StatsController(ClimbAppContext context)
        {
            _context = context;

        }

        // GET: Stats
        [HttpGet]
        public async Task<IActionResult> Index(StatsAverage viewModel)
        {
            //HttpContext.Session.SetString("oic", "cb1ee329-650c-4680-ab6c-6240e972e97d");
            var id = UserIDSess;
            if (id == null)
            {
                return NotFound();
            }

            var stat = await _context.Stats.Where(x => x.UserID == UserIDSess).ToListAsync();


            if (!stat.Any())
            {
                return RedirectToAction(nameof(Create));
            }


            StatsAverage statAvers = new StatsAverage();
            viewModel.UserStat = stat[0];


            List<int> intS = new List<int>();

            viewModel.Blabels = new List<String>();
            viewModel.BPullUps = new List<int>();
            viewModel.BPushUps = new List<int>();
            viewModel.BHangEdge = new List<int>();
            viewModel.BHangWeight = new List<int>();

            viewModel.Slabels = new List<String>();
            viewModel.SPullUps = new List<int>();
            viewModel.SPushUps = new List<int>();
            viewModel.SHangEdge = new List<int>();
            viewModel.SHangWeight = new List<int>();



            var BoulderAverage = await _context.BoulderAverage.ToListAsync();
            var SportAverage = await _context.SportAverage.ToListAsync();

            foreach (var aver in BoulderAverage)
            {
                viewModel.Blabels.Add(aver.BoulderAverageID.GetDescription());
                viewModel.BPullUps.Add(aver.PullUps);
                viewModel.BPushUps.Add(aver.PushUps);
                viewModel.BHangEdge.Add(aver.HangEdge);
                viewModel.BHangWeight.Add(aver.HangWeight);
            }

            foreach (var aver in SportAverage)
            {
                viewModel.Blabels.Add(aver.SportAverageID.ToString());
                viewModel.SPullUps.Add(aver.PullUps);
                viewModel.SPushUps.Add(aver.PushUps);
                viewModel.SHangEdge.Add(aver.HangEdge);
                viewModel.SHangWeight.Add(aver.HangWeight);
            }


            var Json = JsonConvert.SerializeObject(viewModel);


            ViewData["Json"] = Json;
            return View(viewModel);
        }


        // pretty sure these wont get hit
        public IActionResult Create()
        {
            ViewData["UserID"] = UserIDSess;

            var sport = from SportClimbingGrade s in Enum.GetValues(typeof(SportClimbingGrade))
                        select new { ID = (int)s, Name = s.GetDescription() };

            var boulder = from BoulderingClimbingGrade b in Enum.GetValues(typeof(BoulderingClimbingGrade))
                          select new { ID = (int)b, Name = b.GetDescription() };

            ViewData["Sport"] = new SelectList(sport, "ID", "Name");
            ViewData["Boulder"] = new SelectList(boulder, "ID", "Name");

            return View();
        }

        // POST: Stats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatID,PullUp,PushUp,HangEdge,HangWeight,HighestSportGrade,HighestBoulderingGrade,UserID")] Stat stat)
        {

            stat.UserID = UserIDSess;



            _context.PullUps.Add(new PullUp
            {
                NPullUp = stat.PullUp,
                StatID = stat.StatID
            }
            );




            _context.PushUps.Add(new PushUp
            {
                NPushUp = stat.PushUp,
                StatID = stat.StatID
            }
            );


            _context.HangEdges.Add(new HangEdge
            {
                NHangEdge = stat.HangEdge,
                StatID = stat.StatID
            }
            );



            _context.HangWeights.Add(new HangWeight
            {
                NHangWeight = stat.HangWeight,
                StatID = stat.StatID


            }
            );


            if (ModelState.IsValid)
            {
                _context.Update(stat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var sport = from SportClimbingGrade s in Enum.GetValues(typeof(SportClimbingGrade))
                        select new { ID = (int)s, Name = s.GetDescription() };

            var boulder = from BoulderingClimbingGrade b in Enum.GetValues(typeof(BoulderingClimbingGrade))
                          select new { ID = (int)b, Name = b.GetDescription() };

            ViewData["Sport"] = new SelectList(sport, "ID", "Name");
            ViewData["Boulder"] = new SelectList(boulder, "ID", "Name");
            ViewData["UserID"] = UserIDSess;

            return View(stat);
        }

        // GET: Stats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stat = await _context.Stats.FindAsync(id);
            if (stat == null)
            {
                return NotFound();
            }

            var sport = from SportClimbingGrade s in Enum.GetValues(typeof(SportClimbingGrade))
                        select new { ID = (int)s, Name = s.GetDescription() };

            var boulder = from BoulderingClimbingGrade b in Enum.GetValues(typeof(BoulderingClimbingGrade))
                          select new { ID = (int)b, Name = b.GetDescription() };

            ViewData["UserID"] = UserIDSess;
            ViewData["Sport"] = new SelectList(sport, "ID", "Name", stat.HighestSportGrade);
            ViewData["Boulder"] = new SelectList(boulder, "ID", "Name", stat.HighestBoulderingGrade);

            return View(stat);
        }

        // POST: Stats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatID,PullUp,PushUp,HangEdge,HangWeight,HighestSportGrade,HighestBoulderingGrade,UserID,RowVersion")] Stat stat)
        {
            //_db.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            if (id != stat.StatID)
            {
                return NotFound();
            }

            var statDB = await _context.Stats.FindAsync(stat.StatID);

            if (statDB.PullUp != stat.PullUp)
            {
                _context.PullUps.Add(new PullUp
                {
                    NPullUp = stat.PullUp,
                    StatID = stat.StatID
                });

                statDB.PullUp = stat.PullUp;
            }


            if (statDB.PushUp != stat.PushUp)
            {
                _context.PushUps.Add(new PushUp
                {
                    NPushUp = stat.PushUp,
                    StatID = stat.StatID
                });
                statDB.PushUp = stat.PushUp;
            }

            if (statDB.HangEdge != stat.HangEdge)
            {
                _context.HangEdges.Add(new HangEdge
                {
                    NHangEdge = stat.HangEdge,
                    StatID = stat.StatID
                });
                statDB.HangEdge = stat.HangEdge;
            }


            if (statDB.HangWeight != stat.HangWeight)
            {
                _context.HangWeights.Add(new HangWeight
                {
                    NHangWeight = stat.HangWeight,
                    StatID = stat.StatID


                });
                statDB.HangWeight = stat.HangWeight;
            }


            statDB.HighestSportGrade = stat.HighestSportGrade;
            statDB.HighestBoulderingGrade = stat.HighestBoulderingGrade;
            statDB.UserID = stat.UserID;




            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statDB);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatExists(statDB.StatID))
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


            ViewData["UserID"] = UserIDSess;

            var sport = from SportClimbingGrade s in Enum.GetValues(typeof(SportClimbingGrade))
                        select new { ID = (int)s, Name = s.GetDescription() };

            var boulder = from BoulderingClimbingGrade b in Enum.GetValues(typeof(BoulderingClimbingGrade))
                          select new { ID = (int)b, Name = b.GetDescription() };

            ViewData["UserID"] = UserIDSess;
            ViewData["Sport"] = new SelectList(sport, "ID", "Name", stat.HighestSportGrade);
            ViewData["Boulder"] = new SelectList(boulder, "ID", "Name", stat.HighestBoulderingGrade);

            return View(statDB);
        }


        private bool StatExists(int id)
        {
            return _context.Stats.Any(e => e.StatID == id);
        }
    }
}

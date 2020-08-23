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

namespace ClimbingApp.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly ClimbAppContext _context;

        public TestController(ClimbAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult getAreaByType(ClimbType type, String area)
        {

            if (type == ClimbType.Boulder)
            {

                var Boulders = _context.Boulders.ToList();


                var List1 = Boulders.Where(c => c.Area == area).Select(
                            c => new
                            {
                                id = c.BoulderID,
                                name = c.Name
                            });

                foreach (var item in List1)
                {
                    Debug.WriteLine(item);
                }

                return Json(List1);
            }
            else
            {
                var Sports = _context.Sports.ToList();


                var List1 = Sports.Where(c => c.Area == area).Select(
                            c => new
                            {
                                ID = c.SportID,
                                name = c.Name
                            });



                return Json(List1);
            }

        }
    }
}

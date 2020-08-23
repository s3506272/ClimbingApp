using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//add
using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.Components
{
    [ViewComponent(Name = "Compare")]
    public class Compare : ViewComponent
    {

        public Compare()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();


        }

    }
}

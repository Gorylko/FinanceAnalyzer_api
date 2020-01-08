using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAnalyzer.Web.Controllers.Finance
{
    public class FinanceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
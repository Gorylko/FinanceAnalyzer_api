using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAnalyzer.Web.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceController : Controller
    {
        [Authorize]
        [HttpGet("getAllIncomes")]
        public IActionResult GetAllIncomes()
        {
            return Json("get all incomes");
        }
    }
}
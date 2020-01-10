using FinanceAnalyzer.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Web.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceController : Controller
    {
        IFinanceService<decimal> _financeService;

        public FinanceController(IFinanceService<decimal> financeService)
        {
            _financeService = financeService;
        }

        [Authorize]
        [HttpGet("getAllIncomes")]
        public async Task<IEnumerable<decimal>> GetAllIncomes()
        {
            return await _financeService.GetIncomeHistory(int.Parse(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value));
        }
    }
}
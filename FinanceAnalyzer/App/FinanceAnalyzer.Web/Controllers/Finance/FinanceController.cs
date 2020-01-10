using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
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
        IFinanceService _financeService;

        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [Authorize]
        [HttpGet("getAllIncomes")]
        public async Task<IEnumerable<Income>> GetAllIncomes()
        {
            return await _financeService.GetIncomeHistory(
                int.Parse(
                    HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value
                    )
                );
        }

        [Authorize]
        [HttpPost("addNewIncome")]
        public async Task AddNewIncome(decimal value)
        {
            if(value == default)
            {
                BadRequest("invalid income value");
            }

            await _financeService.AddNewIncome(
                new Income
                {
                    UserId = int.Parse(
                    HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value
                    ),
                    Value = value
                });
        }
    }
}
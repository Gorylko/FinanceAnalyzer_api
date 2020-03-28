using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Web.Controllers.Finance
{
    public class IncomeController : Controller
    {
        private readonly IFinanceService _financeService;

        public IncomeController(IFinanceService financeService)
        {
            _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
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
            if (value == default)
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
using FinanceAnalyzer.Business.Services.Interfaces;
using FinanceAnalyzer.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Web.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : Controller
    {
        IFinanceService _financeService;

        public ExpenseController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [Authorize]
        [HttpGet("getAllExpenses")]
        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            return await _financeService.GetExpenseHistory(
                int.Parse(
                    HttpContext.User.Claims.Single(claim => claim.Type == "UserId").Value
                    )
                );
        }

        [Authorize]
        [HttpPost("addNewExpense")]
        public async Task AddNewExpense(decimal value)
        {
            if (value == default)
            {
                BadRequest("invalid income value");
            }

            await _financeService.AddNewExpense(
                new Expense
                {
                    UserId = int.Parse(
                        HttpContext.User.Claims.Single(claim => claim.Type == "UserId").Value
                    ),
                    Value = value
                });
        }
    }
}
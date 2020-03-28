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
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceController : Controller
    {
        private readonly IFinanceService _financeService;

        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
        }

        [Authorize]
        [HttpGet("getFullInfo")]
        public async Task<FinanceInfo> GetFullInfo()
        {
            return await _financeService.GetFullInformation(
                int.Parse(
                    HttpContext.User.Claims.Single(claim => claim.Type == "UserId").Value
                ));
        }
    }
}
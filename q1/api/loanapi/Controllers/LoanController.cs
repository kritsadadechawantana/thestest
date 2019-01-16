using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using loanapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace loanapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly InterestCalculator interestCalculator;

        public LoanController()
        {
            this.interestCalculator = new InterestCalculator();
        }

        [HttpGet]
        public IEnumerable<InterestCalculateResult> Calculate(double interest, double amount, int years)
        {
            return interestCalculator.Calculate(interest, amount, years);
        }
    }
}

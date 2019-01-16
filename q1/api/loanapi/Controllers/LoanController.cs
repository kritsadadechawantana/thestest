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
        public static double interest;
        private readonly InterestCalculator interestCalculator;

        public LoanController()
        {
            this.interestCalculator = new InterestCalculator();
        }

        [HttpGet("{interestValue}")]
        public void SetInterest(double interestValue)
        {
            interest = interestValue;
        }

        [HttpGet("{amount}/{years}")]
        public IEnumerable<InterestCalculateResult> Calculate(double amount, int years)
        {
            return interestCalculator.Calculate(interest, amount, years);
        }
    }
}

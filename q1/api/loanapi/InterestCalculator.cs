using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using loanapi.Models;

namespace loanapi
{
    public class InterestCalculator
    {
        public IEnumerable<InterestCalculateResult> Calculate(double interest, double amount, int years)
        {
            var interestCalculateResult = new List<InterestCalculateResult>();
            var remaining = amount;
            for (int i = 1; i <= years; i++)
            {
                var calculateresult = calculateInterest(interest, remaining);
                remaining = calculateresult.Summary;
                interestCalculateResult.Add(calculateresult);
            }

            return interestCalculateResult;
        }

        private InterestCalculateResult calculateInterest(double interest, double amount)
        {
            var interestAmount = amount * (interest * 0.01);
            return new InterestCalculateResult
            {
                Remaining = amount,
                Interest = interestAmount,
                Summary = amount + interestAmount
            };
        }
    }
}

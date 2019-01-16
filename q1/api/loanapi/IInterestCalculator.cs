using loanapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loanapi
{
    public interface IInterestCalculator
    {
        IEnumerable<InterestCalculateResult> Calculate(double interest, double amount, int years);
    }
}

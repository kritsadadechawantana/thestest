using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loanapi.Models
{
    public class InterestCalculateResult
    {
        public double Remaining { get; set; }
        public double Interest { get; set; }
        public double Summary { get; set; }
    }
}

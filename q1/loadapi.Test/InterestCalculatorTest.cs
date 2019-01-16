using loanapi;
using loanapi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace loadapi.Test
{
    public class InterestCalculatorTest
    {
        [Fact]
        public void InterestCalculator_Test()
        {
            var interestCalculator = new InterestCalculator();
            var result = interestCalculator.Calculate(12, 10000, 3);

            var expected = new List<InterestCalculateResult>()
            {
                new InterestCalculateResult{ Remaining = 10000, Interest = 1200, Summary = 11200},
                new InterestCalculateResult{ Remaining = 11200, Interest = 1344, Summary = 12544},
                new InterestCalculateResult{ Remaining = 12544, Interest = 1505.28, Summary = 14049.28}
            };

            result.Should().BeEquivalentTo(expected);
        }
    }
}

using System;
using TipCalc.Core.Services;
using Xunit;

namespace TipCalc.Core.Tests
{
     public class CalculationServiceShould
    {
        [Theory]
        [InlineData(10.0,13)]
        public void Return_correct_tipamount(double subTotal, int tipPercentage)
        {
            ICalculationService service = new CalculationService();
            var tipAmount = service.TipAmount(subTotal, tipPercentage);
            Assert.Equal(1.3, tipAmount);
        }
    }
}

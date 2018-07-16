using RekenMachineAPI.Domain;
using Xunit;

namespace RekenMachineAPI.Service
{
    public class CalculatorTest
    {
        public class FakeParseService : IParseService
        {

            public Expression Parse(string input)
            {
                return new Expression("1plus1");
            }
        }


        public CalculatorTest()
        {
            
        }

//        [Fact]
//        public void calculation_Of_Addition_of_1_plus_1_equals_2()
//        {
//            decimal expected = 2;
//            CalculationService calculationService = new CalculationService(new FakeParseService(), new CalculatorFactory());
//
//            decimal result = calculationService.Calculate("1plus1");
//            Assert.Equal(expected,result);
//        }

    }
}
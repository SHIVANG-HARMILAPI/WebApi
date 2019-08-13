using System;
using Xunit;
using WebApi;
namespace TestCasesForWebApi
{
    public class UnitTest1
    {
        [Fact]
        public void TestForHi()
        {
            string inputValue = "Hi";
            var valuesController = new WebApi.Controllers.ValuesController();
            var actualResult = valuesController.Get(inputValue).Value;
            var expectedResult = "Hey";
            Assert.Equal(expectedResult, actualResult);
        }


        [Fact]
        public void TestForHey()
        {
            string inputValue = "Hey";
            var valuesController = new WebApi.Controllers.ValuesController();
            var actualResult = valuesController.Get(inputValue).Value;
            var expectedResult = "Hi";
            Assert.Equal(expectedResult, actualResult);


        }
        [Fact]
        public void SecondTestForHi()
        {
            string inputValue = "Hi";
            var valuesController = new WebApi.Controllers.ValuesController();
            var actualResult = valuesController.GetHi(inputValue);
            var expectedResult = "Hey";
            Assert.Equal(expectedResult, actualResult);


        }
    }
}

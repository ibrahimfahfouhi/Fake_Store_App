using FakeStoreApp.EMR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FakeStoreApp.Tests.EMR
{
    public class BMICalculatorTest
    {
        [Fact]
        public void CalculateBmiCorrectly_test()
        {
            //Arrange or Given
            var sut = new BMICalculator();
            //Act ot When
            var result = Math.Round(sut.CalculateBmi(1.75, 90), 2);
            //Assert or Then
            Assert.Equal(29.39, result);
        }
    }
}

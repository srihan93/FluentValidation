using System;
using Xunit;
using FluentValidation.TestHelper;
using fluentVal;

namespace TestProject1
{
    public class UnitTest1
    {
        private WeatherValidator weatherValidator;

        public UnitTest1()
        {
            weatherValidator = new WeatherValidator();
        }

        [Fact]
        public void test1()
        {
            var model = new WeatherForecast1();
            model.age = -1;
            model.customEnum = "Audit";
            var result = weatherValidator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(p => p.age);
            result.ShouldNotHaveValidationErrorFor(p => p.customEnum);
        }
    }
}
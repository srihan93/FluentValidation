using FluentValidation;
using System;

namespace fluentVal
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class WeatherValidator : AbstractValidator<WeatherForecast>
    {
        public WeatherValidator()
        {
            RuleFor(p => p.TemperatureC).LessThanOrEqualTo(100);
            RuleFor(p => p.Date).GreaterThanOrEqualTo(DateTime.Now.AddDays(-10)).WithMessage("Date cannot be greater than current date and Lesser current date-10days").LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be greater than current date and Lesser current date-10days");
        }
    }
}
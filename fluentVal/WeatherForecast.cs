using FluentValidation;
using System;
using System.Text.Json.Serialization;

namespace fluentVal
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class WeatherForecast1
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public string customEnum { get; set; }
        public int age { get; set; }
        public int classes { get; set; }
    }

    public class WeatherValidator : AbstractValidator<WeatherForecast1>
    {
        public WeatherValidator()
        {
            RuleFor(p => p.TemperatureC).LessThanOrEqualTo(100);
            RuleFor(p => p.Date).GreaterThanOrEqualTo(DateTime.Now.AddDays(-1)).WithMessage("Date cannot be greater than current date and Lesser current date-10days").LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be greater than current date and Lesser current date-10days");

            //Enum
            RuleFor(p => p.customEnum).NotEmpty().NotNull().Must(x => Enum.IsDefined(typeof(CustomEnum), x));

            //range
            RuleFor(p => p.age).InclusiveBetween(0, 100);
            RuleFor(p => p.classes).ExclusiveBetween(0, 13);
        }
    }
}
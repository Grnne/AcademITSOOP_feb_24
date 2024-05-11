using System;

namespace TemperatureTask.Model.Scales
{
    internal class Celsius : Scale
    {
        public override string Name { get; set; }

        public override double Difference { get; set; }

        public override double Multiplier { get; set; }

        public Celsius()
        {
            Name = "Celsius";
            Difference = 0.0;
            Multiplier = 1.0;
        }

        public override double ConvertToCelsius(double sourceTemperature) => sourceTemperature;

        public override double ConvertFromCelsius(double celsiusTemperature) => celsiusTemperature;

    }
}

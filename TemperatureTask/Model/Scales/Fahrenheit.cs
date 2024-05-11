using System;

namespace TemperatureTask.Model.Scales
{
    internal class Fahrenheit : Scale
    {
        public override string Name { get; set; }

        public override double Difference { get; set; }

        public override double Multiplier { get; set; }

        public Fahrenheit()
        {
            Name = "Fahrenheit";
            Difference = 32.0;
            Multiplier = 1.8;
        }
    }
}
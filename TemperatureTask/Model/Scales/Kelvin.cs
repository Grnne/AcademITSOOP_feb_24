namespace TemperatureTask.Model.Scales
{
    internal class Kelvin : Scale
    {
        public override string Name { get; set; }

        public override double Difference { get; set; }

        public override double Multiplier { get; set; }

        public Kelvin()
        {
            Name = "Kelvin";
            Difference = 273.15;
            Multiplier = 1.0;
        }
    }
}
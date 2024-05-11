namespace TemperatureTask.Model.Scales
{
    public abstract class Scale
    {
        public abstract string Name { get; set; }

        public abstract double Difference { get; set; }

        public abstract double Multiplier { get; set; }

        public virtual double ConvertFromCelsius(double celsiusTemperature)
        {
            return (celsiusTemperature * Multiplier) + Difference;
        }

        public virtual double ConvertToCelsius(double sourceTemperature)
        {
            return (sourceTemperature - Difference) / Multiplier;
        }
    }
}
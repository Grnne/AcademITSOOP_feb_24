namespace TemperatureTask.Model.Scales
{
    public abstract class IScale
    {
        double Temperature { get; set; }

        double Difference { get; set; }

        double Multiplier { get; set; }

        public abstract double ConvertFromCelsius(int resultTemperatureScale);

        public abstract void ConvertToCelsius(double sourceTemperature, int sourceTemperatureScale);
    }
}
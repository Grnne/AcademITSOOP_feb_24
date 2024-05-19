namespace TemperatureTask.Model.Scales
{
    internal class FahrenheitScale : IScale
    {
        private readonly string _name = "Fahrenheit";

        public double ConvertFromCelsius(double celsiusTemperature)
        {
            return (celsiusTemperature * 1.8) + 32.0;
        }

        public double ConvertToCelsius(double sourceTemperature)
        {
            return (sourceTemperature - 32.0) / 1.8;
        }

        public string GetName() => _name;
    }
}
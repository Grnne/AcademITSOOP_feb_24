namespace TemperatureTask.Model.Scales
{
    internal class KelvinScale : IScale
    {
        private readonly string _name = "Kelvin";

        public double ConvertFromCelsius(double celsiusTemperature)
        {
            return celsiusTemperature + 273.15;
        }

        public double ConvertToCelsius(double sourceTemperature)
        {
            return sourceTemperature - 273.15;
        }

        public string GetName() => _name;
    }
}
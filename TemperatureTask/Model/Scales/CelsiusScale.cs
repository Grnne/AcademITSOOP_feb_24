namespace TemperatureTask.Model.Scales
{
    internal class CelsiusScale : IScale
    {
        private readonly string _name = "Celsius";

        public  double ConvertToCelsius(double sourceTemperature) => sourceTemperature;

        public  double ConvertFromCelsius(double celsiusTemperature) => celsiusTemperature;

        public string GetName() => _name;
    }
}
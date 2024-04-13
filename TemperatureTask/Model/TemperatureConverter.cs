namespace TemperatureTask.Model
{
    internal class TemperatureConverter : IConverter
    {

        public double Convert(double sourceTemperature, int sourceTemperatureScale, int resultTemperatureScale)
        {
            if (sourceTemperatureScale == resultTemperatureScale)
            {
                return sourceTemperature;
            }

            double resultTemperature;

            if (sourceTemperatureScale == 0)
            {
                resultTemperature = sourceTemperature;
            }
            else if (sourceTemperatureScale == 1)
            {
                resultTemperature = ConvertKelvinToCelsius(sourceTemperature);
            }
            else
            {
                resultTemperature = ConvertFahrenheitToCelsius(sourceTemperature);
            }

            if (resultTemperatureScale == 1)
            {
                return ConvertCelsiusToKelvin(resultTemperature);
            }

            if (resultTemperatureScale == 2)
            {
                return ConvertCelsiusToFahrenheit(resultTemperature);
            }

            return resultTemperature;
        }

        private static double ConvertKelvinToCelsius(double sourceTemp)
        {
            return sourceTemp - 273.15;
        }

        private static double ConvertFahrenheitToCelsius(double sourceTemp)
        {
            return (sourceTemp - 32) * (9 / 5);
        }

        private static double ConvertCelsiusToKelvin(double sourceTemp)
        {
            return sourceTemp + 273.15;
        }

        private static double ConvertCelsiusToFahrenheit(double sourceTemp)
        {
            return sourceTemp * (9 / 5) + 32;
        }
    }
}

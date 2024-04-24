using System.Collections.Generic;

namespace TemperatureTask.Model
{
    internal class TemperatureConverter : IConverter
    {
        public static List<Scale> Scales { get; set; }
        public static double DeltaTemperature { get; set; }

        static TemperatureConverter()
        {
            DeltaTemperature = 0;
            Scales = new List<Scale>() { new Scale(0, 1), new Scale(32, 1.8), new Scale(273.15, 1) };
        }

        // TODO Методы разделены глупо, но я подумал мб нужны проверки если температура оказывается ниже возможной, но в целом, кажется, лучше все в 1 метод; Спросить про имя для дельты и модификатора
        public void ConvertToCelsius(double sourceTemperature, int sourceTemperatureScale)
        {
            DeltaTemperature = (sourceTemperature - Scales[sourceTemperatureScale].Delta) / Scales[sourceTemperatureScale].Modifier;
        }

        public double ConvertFromCelsius(int resultTemperatureScale)
        {
            return (DeltaTemperature * Scales[resultTemperatureScale].Modifier) + Scales[resultTemperatureScale].Delta;
        }

        public double Convert(double sourceTemperature, int sourceTemperatureScale, int resultTemperatureScale)
        {
            ConvertToCelsius(sourceTemperature, sourceTemperatureScale);

            return ConvertFromCelsius(resultTemperatureScale);
        }
    }
}
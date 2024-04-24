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

        // TODO  Спросить про имя для дельты и модификатора;
        // И в целом помоему плохое решение, если у каких-то других шкал будет другое поведение конвертации, придется делать костыль
        // мб стоит сделать папку со шкалами, интерфейс iscale с методами convert to celsius, convert from celsius и в каждой шкале реализовать конвертацию
        // а потом тут сделать лист iscale и оттуда дергать методы?
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
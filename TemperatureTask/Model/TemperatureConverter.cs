using System.Collections.Generic;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model
{
    internal class TemperatureConverter : ITemperatureConverter
    {
        public  List<Scale> Scales { get; set; }

        public TemperatureConverter(List<Scale> scales)
        {
            Scales = scales;
        }

        public double Convert(double sourceTemperature, Scale sourceScale, Scale resultScale)
        {
            return resultScale.ConvertFromCelsius(sourceScale.ConvertToCelsius(sourceTemperature));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model
{
    internal class TemperatureConverter : ITemperatureConverter
    {
        public List<Scale> Scales { get; set; }

        public TemperatureConverter(List<Scale> scales)
        {
            if (!scales.Any())
            {
                throw new ArgumentException("Scale list cant be empty", nameof(scales));
            }
            
            Scales = scales;
        }

        public double Convert(double sourceTemperature, Scale sourceScale, Scale resultScale)
        {
            return resultScale.ConvertFromCelsius(sourceScale.ConvertToCelsius(sourceTemperature));
        }

        public List<Scale> GetScales()
        {
            return Scales;
        }
    }
}
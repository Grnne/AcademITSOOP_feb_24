using System;
using System.Collections.Generic;
using System.Linq;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model
{
    internal class TemperatureConverter : ITemperatureConverter
    {
        public List<IScale> Scales { get; set; }

        public TemperatureConverter(List<IScale> scales)
        {
            if (!scales.Any())
            {
                throw new ArgumentException("Scales list can't be empty", nameof(scales));
            }
            
            Scales = scales;
        }

        public double Convert(double sourceTemperature, IScale sourceScale, IScale resultScale)
        {
            return resultScale.ConvertFromCelsius(sourceScale.ConvertToCelsius(sourceTemperature));
        }

        public List<IScale> GetScales()
        {
            return Scales;
        }
    }
}
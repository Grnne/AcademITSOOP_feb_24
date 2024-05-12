using System.Collections.Generic;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model
{
    public interface ITemperatureConverter
    {
        double Convert(double sourceTemperature, Scale sourceScale, Scale resultScale);

        List<Scale> GetScales();
    }
}
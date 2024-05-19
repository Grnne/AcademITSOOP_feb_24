using System.Collections.Generic;
using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model
{
    public interface ITemperatureConverter
    {
        double Convert(double sourceTemperature, IScale sourceScale, IScale resultScale);

        List<IScale> GetScales();
    }
}
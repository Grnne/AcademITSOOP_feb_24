using System.Collections.Generic;
using TemperatureTask.Model.Scales;
using TemperatureTask.Presenter;

namespace TemperatureTask.View
{
    public interface IConverterView
    {
        void Start();

        void SetPresenter(TemperaturePresenter presenter);

        void SetScales(List<IScale> scales);

        void ShowResultTemperature(double resultTemperature);
    }
}

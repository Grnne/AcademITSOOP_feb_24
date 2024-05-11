using TemperatureTask.Model;
using TemperatureTask.Model.Scales;
using TemperatureTask.View;

namespace TemperatureTask.Presenter
{
    public class TemperaturePresenter
    {
        public ITemperatureConverter Model { get; set; }

        public IConverterView View { get; set; }

        public TemperaturePresenter(ITemperatureConverter converter, IConverterView view)
        {
            Model = converter;
            View = view;
        }

        public void GetConvertedTemperature(double sourceTemperature, Scale sourceScale, Scale resultScale)
        {
            View.ShowResultTemperature(Model.Convert(sourceTemperature, sourceScale, resultScale));
        }
    }
}
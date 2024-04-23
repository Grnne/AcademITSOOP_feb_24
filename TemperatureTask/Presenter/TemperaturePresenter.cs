using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask.Presenter
{
    public class TemperaturePresenter
    {
        public IConverter Model { get; set; }

        public IView View { get; set; }

        public TemperaturePresenter(IConverter converter, IView view)
        {
            Model = converter;
            View = view;
        }

        public void GetConvertedTemperature(double sourceTemperature, int sourceScale, int resultScale)
        {
            View.ShowResultTemperature(Model.Convert(sourceTemperature, sourceScale, resultScale));
        }
    }
}
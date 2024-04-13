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

        public double GetConvertedTemperature(double sourceTemperature, (int,int) TemperatureScales)
        {
            return Model.Convert(sourceTemperature, TemperatureScales.Item1, TemperatureScales.Item2);
        }
    }
}

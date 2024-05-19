using TemperatureTask.Model;
using TemperatureTask.View;

namespace TemperatureTask.Presenter
{
    public class TemperaturePresenter
    {
        private ITemperatureConverter Model { get; set; }

        private IConverterView View { get; set; }

        public TemperaturePresenter(ITemperatureConverter converter, IConverterView view)
        {
            Model = converter;
            View = view;
            view.SetPresenter(this);
            view.SetScales(Model.GetScales());
        }

        public void ConvertTemperature(double sourceTemperature, string sourceScaleName, string resultScaleName)
        {
            View.ShowResultTemperature(Model.Convert(sourceTemperature
                , Model.GetScales().Find(x => x.GetName() == sourceScaleName)
                , Model.GetScales().Find(x => x.GetName() == resultScaleName)));
        }
    }
}
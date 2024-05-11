using TemperatureTask.Presenter;

namespace TemperatureTask.View
{
    public interface IConverterView
    {
        void Start();

        void SetPresenter(TemperaturePresenter presenter);

        void ShowResultTemperature(double resultTemperature);
    }
}

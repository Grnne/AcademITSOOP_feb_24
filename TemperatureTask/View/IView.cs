using TemperatureTask.Presenter;

namespace TemperatureTask.View
{
    public interface IView
    {
        void Start();

        void SetPresenter(TemperaturePresenter controller);

        void ShowResultTemperature(double resultTemperature);
    }
}

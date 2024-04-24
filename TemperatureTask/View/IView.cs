using TemperatureTask.Presenter;

namespace TemperatureTask.View
{
    public interface IView
    {
        void Start();

        void SetPresenter(TemperaturePresenter presenter);

        void ShowResultTemperature(double resultTemperature);
    }
}

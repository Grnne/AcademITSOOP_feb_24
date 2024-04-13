using TemperatureTask.Presenter;

namespace TemperatureTask.View
{
    public interface IView
    {
        void Start();
        void SetController(TemperaturePresenter controller);
    }
}

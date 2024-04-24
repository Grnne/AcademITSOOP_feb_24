using MinesweeperTask.Presenter;

namespace MinesweeperTask.View
{
    public interface IMainWindow
    {
        void SetPresenter(MainPresenter presenter);

        void Start();
    }
}

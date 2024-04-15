using MinesweeperTask.Presenter;

namespace MinesweeperTask.View
{
    internal interface IMainWindow
    {
        MainPresenter Presenter { get; set; }
    }
}

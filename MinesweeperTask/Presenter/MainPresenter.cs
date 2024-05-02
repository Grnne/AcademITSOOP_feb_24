using MinesweeperTask.Model;
using MinesweeperTask.View;

namespace MinesweeperTask.Presenter
{
    public class MainPresenter
    {
        public IView _view { get; set; }
        public IBoard _model { get; set; }

        public MainPresenter(IView view, IBoard model)
        {
            _model = model;
            _view = view;

            view.SetPresenter(this);
        }
    }
}
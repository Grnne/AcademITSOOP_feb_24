using MinesweeperTask.Model;
using MinesweeperTask.View;

namespace MinesweeperTask.Presenter

{
    public class MainPresenter
    {
        private readonly IModel _model;
        private readonly IMainWindow _mainWindow;

        public MainPresenter(IMainWindow view, IModel model)
        {
            _model = model;
            _mainWindow = view;
        }

        public void ResetMinefield()
        {
            
        }
    }
}

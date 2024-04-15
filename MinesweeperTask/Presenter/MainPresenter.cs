using MinesweeperTask.Model;
using MinesweeperTask.View;

namespace MinesweeperTask.Presenter

{
    public class MainPresenter
    {
        private readonly IModel _model;
        private readonly IMainWindow _mainWindow;

        public MainPresenter(MainWindow view)
        {
            _mainWindow = new MainWindow();
            _mainWindow.Presenter = this;
            _model = new Board();

        }

        public void ResetMinefield()
        {
            
        }
    }
}

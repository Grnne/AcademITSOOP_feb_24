using System;
using System.Windows.Forms;
using MinesweeperTask.Model;
using MinesweeperTask.View;

namespace MinesweeperTask.Presenter

{
    public class MainPresenter
    {
        public readonly Board _model;
        private readonly IMainWindow _mainWindow;

        public MainPresenter(IMainWindow view, Board model)
        {
            _model = model;
            _mainWindow = view;
        }

        public void Show(int rowsAmount, int columnsAmount, int bombsAmount)
        {
            _model.InitBoard(rowsAmount, columnsAmount, bombsAmount);


        }

        public void ResetMinefield()
        {

        }
    }
}

using MinesweeperTask.Model;
using MinesweeperTask.View;

namespace MinesweeperTask.Presenter
{
    public class MainPresenter
    {
        private IView _view;

        private IBoard _model;

        //TODO переделать рестарт игры
        
        public MainPresenter(IView view, IBoard model)
        {
            _model = model;
            _view = view;

            view.SetPresenter(this);
            
            ResetField();
        }

        public void OpenCell(int y, int x)
        {
            _model.OpenCell(y, x);

            if (_model.GameOver == 1)
            {
                _view.Fiasko(false);
                _model.InitBoard(_model.Difficulty);
                _view.DrawField(_model.Minefield.RowsAmount, _model.Minefield.ColumnsAmount);

            }

            RedrawField();
        }

        public void MarkCell(int y, int x)
        {
            _model.MarkCell(y, x);
            _view.SetBombCounterValue(_model.BombsCountTable);
            
            if (_model.GameOver == 2)
            {
                _view.Fiasko(true);
                _model.InitBoard(_model.Difficulty);
                _view.DrawField(_model.Minefield.RowsAmount, _model.Minefield.ColumnsAmount);
            }

            RedrawField();
        }

        public void RedrawField()
        {
            _view.RedrawField(_model.Minefield.Cells); //TODO инкапсуляция
        }

        public void ResetField()
        {
            _model.InitBoard(_model.Difficulty);
            _view.DrawField(_model.Minefield.RowsAmount, _model.Minefield.ColumnsAmount);
            _view.SetBombCounterValue(_model.BombsCountTable);
        }

        public void SetDifficulty(int difficulty)
        {
            _model.Difficulty = difficulty;
        }
    }
}
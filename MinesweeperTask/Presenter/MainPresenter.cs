using MinesweeperTask.Model;
using MinesweeperTask.View;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

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
            _model.InitTimer();
            _model.Timer_Ticked += SetTimerValue;
        }

        private void SetTimerValue() // TODO timer stop at gameover
        {
            _view.SetTimerValue(_model.Time);
        } 

        public void OpenCell(int y, int x)
        {
            _model.OpenCell(y, x);

            if (_model.GameOver == 1)
            {
                DrawBombsWhenGameOver(y, x);
                _view.Fiasko(false);
                ResetField();
            }

            RedrawField();
        }

        public void MarkCell(int y, int x)
        {
            _model.MarkCell(y, x);
            _view.SetBombCounterValue(_model.BombsCountTable);
            
            if (_model.GameOver == 2)
            {
                DrawBombsWhenGameOver(y, x);
                _view.Fiasko(true);
                ResetField();
            }

            RedrawField();
        }

        public void RedrawField()
        {
            _view.RedrawField(); //TODO инкапсуляция
        }

        public void ResetField()
        {
            _model.InitBoard(_model.Difficulty);
            _view.SetMinefield(_model.Minefield.Cells);
            _view.DrawField(_model.Minefield.RowsAmount, _model.Minefield.ColumnsAmount);
            _view.SetBombCounterValue(_model.BombsCountTable);
        }

        public void DrawBombsWhenGameOver(int y, int x)
        {
            if (_model.GameOver == 1)
            {
                _view.DrawBombsWhenGameOver(y, x, true);
            }
            else
            {
                _view.DrawBombsWhenGameOver(y, x, false);
            }
        }

        public void SetDifficulty(int difficulty)
        {
            _model.Difficulty = difficulty;
        }
    }
}
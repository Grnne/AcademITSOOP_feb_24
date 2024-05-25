using MinesweeperTask.Model;
using MinesweeperTask.Presenter;
using System.Windows.Forms;

namespace MinesweeperTask.View
{
    public interface IView
    {
        void SetPresenter(MainPresenter presenter);

        void SetMinefield(Cell[,] cells);

        void DrawField(int rowsAmount, int columnsAmount);

        void RedrawField();

        void SetBombCounterValue(int value);

        void SetTimerValue(int value);

        void Fiasko(bool condition);

        void DrawBombsWhenGameOver(int y, int x, bool exploded);
    }
}

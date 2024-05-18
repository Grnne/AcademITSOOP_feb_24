using MinesweeperTask.Model;
using MinesweeperTask.Presenter;

namespace MinesweeperTask.View
{
    public interface IView
    {
        void SetPresenter (MainPresenter presenter);

        void DrawField(int rowsAmount, int columnsAmount);

        void DrawFieldTest(Cell[,] minefield);

        void RedrawField(Cell[,] CellIconCodes);

        void RightClickOnCell(int x, int y);

        void LeftClickOnCell(int x, int y);

        void MarkCell(int x, int y);

        void SetBombCounterValue(int value);

        void Fiasko(string message);
    }
}

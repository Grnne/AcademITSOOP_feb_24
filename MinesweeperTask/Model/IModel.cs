namespace MinesweeperTask.Model
{
    public interface IModel
    {
        Minefield Minefield { get; set; }

        void InitBoard(int rowsAmount, int columnsAmount);
    }
}
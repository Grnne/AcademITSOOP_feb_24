namespace MinesweeperTask.Model
{
    public interface IBoard
    {
        Minefield Minefield { get; set; }

        void InitBoard(int difficulty);
    }
}
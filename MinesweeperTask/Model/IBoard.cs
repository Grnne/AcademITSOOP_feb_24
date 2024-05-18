namespace MinesweeperTask.Model
{
    public interface IBoard
    {
        Minefield Minefield { get; set; }

        int BombsCountTable { get; set; }

        int GameOver { get; set; }

        int Difficulty { get; set; }

        void InitBoard(int difficulty);

        void InitMinefield(int difficulty);

        void MarkCell(int y, int x);

        int OpenCell(int y, int x);
    }
}
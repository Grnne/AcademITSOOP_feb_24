using System;

namespace MinesweeperTask.Model
{
    public interface IBoard
    {
        Minefield Minefield { get; set; }

        event Action Timer_Ticked;

        int BombsCountTable { get; set; }

        int GameOver { get; set; }

        int Difficulty { get; set; }

        int Time { get; set; }

        void InitBoard(int difficulty);

        void InitMinefield(int difficulty);

        void MarkCell(int y, int x);

        int OpenCell(int y, int x);
    }
}
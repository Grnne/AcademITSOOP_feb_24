using System.Threading;

namespace MinesweeperTask.Model
{
    public class Board : IModel
    {
        public Minefield Minefield { get; set; }

        public int Size { get; set; }

        public int BombsCount { get; set; }

        public int Timer { get; set; }

        public void InitMinefield() { }

        public void ModifyBombsScoreboard() { }

        public void InitBoard(int rowsAmount, int columnsAmount, int bombsAmount)
        {
            Minefield = new Minefield(rowsAmount, columnsAmount, bombsAmount);

        }

        public Board()
        {
            
        }

    }


}

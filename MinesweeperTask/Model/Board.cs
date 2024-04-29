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

        public void InitBoard(int rowsAmount, int columnsAmount)
        {
            Board board = new Board();
            
        }

        public Board()
        {
            Size = 10;
            Minefield = new Minefield(Size, Size, 10);
        }

    }


}

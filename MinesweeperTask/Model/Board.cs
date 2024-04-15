namespace MinesweeperTask.Model
{
    internal class Board : IModel
    {
        public Minefield Minefield { get; set; }

        public int BombsCount { get; set; }

        public int Timer { get; set; }
    }
}

using System.Threading;

namespace MinesweeperTask.Model
{
    internal class Board : IModel
    {
        public Minefield Minefield { get; set; }

        public int BombsCount { get; set; }

        public int Timer { get; set; }

        public void ResetMinefield() { }

        public void ModifyBombsScoreboard() { }
    }
}

namespace MinesweeperTask.Model
{
    public class Board : IBoard
    {
        public Minefield Minefield { get; set; }

        public int Difficulty { get; set; }

        public int BombsCount { get; set; }

        public int Timer { get; set; }

        public void InitMinefield() { }

        public void ModifyBombsScoreboard() { }

        public void InitBoard(int difficulty)
        {
            Minefield = new Minefield(difficulty);
        }
    }
}
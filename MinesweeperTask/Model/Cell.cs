namespace MinesweeperTask.Model
{
    internal class Cell
    {
        public State State { get; set; }

        public CellIcon Icon { get; set; }

        public Cell(State state)
        {
            State = state;
        }
    }
}
namespace MinesweeperTask.Model
{
    public class Cell
    {
        public CellIcon CellIcon { get; set; }

        public bool BombState { get; set; }

        public int NearbyBombsAmount { get; set; }

        public Cell()
        {
        }
    }

    public enum CellIcon
    {
        Closed = 0,
        OpenEmpty = 1,
        OpenDigit = 2,
        OpenBomb = 3,
        Flag = 4
    }
}
namespace MinesweeperTask.Model
{
    public class Cell
    {
        public CellIcon CellIcon { get; set; }

        public bool BombState { get; set; }

        public int NearbyBombsAmount { get; set; }

        public Cell()
        {
            CellIcon = CellIcon.Closed;
            BombState = false;
        }
    }
}
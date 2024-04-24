namespace MinesweeperTask.Model
{
    internal class CellIcon
    {
        public IconState IconState { get; set; }

        public CellIcon()
        {
            IconState = IconState.Closed;
        }
    }
}

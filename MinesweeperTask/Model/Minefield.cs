using System.Collections.Generic;

namespace MinesweeperTask.Model
{
    internal class Minefield
    {
        public List<Cell> Cells { get; set; }

        public Minefield()
        {
            Cells = new List<Cell>() { new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell() };
        }
    }
}

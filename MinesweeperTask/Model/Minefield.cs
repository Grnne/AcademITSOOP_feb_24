using System;
using System.Collections.Generic;

namespace MinesweeperTask.Model
{
    public class Minefield
    {
        public Cell[,] Cells { get; set; }

        public int RowsAmount { get; set; }

        public int ColumnsAmount { get; set; }

        public Minefield(int rowsAmount, int columnsAmount, int bombsAmount)
        {
            RowsAmount = rowsAmount;
            ColumnsAmount = columnsAmount;

            Cells = new Cell[rowsAmount, columnsAmount];

            for (int i = 0; i < rowsAmount; i++)
            {
                for (int j = 0; j < columnsAmount; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }

            PlaceBombos(bombsAmount);
        }

        public Minefield(int difficulty)
        {
            switch (difficulty)
            {
                case 0:
                    new Minefield(8, 8, 10);
                    break;
                case 1:
                    new Minefield(15, 15, 30);
                    break;
                case 2:
                    new Minefield(20, 25, 60);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void PlaceBombos(int bombsAmount) //TODO First apply
        {
            HashSet<(int x, int y)> bombs = new HashSet<(int x, int y)>();
            Random random = new Random();

            while (bombs.Count < bombsAmount)
            {
                bombs.Add((random.Next(RowsAmount), random.Next(ColumnsAmount)));
            }

            foreach (var bomb in bombs)
            {
                Cells[bomb.x, bomb.y].BombState = true;
            }

            foreach (var bomb in bombs)
            {
                DrawBombsAmount(bomb.x, bomb.y);
            }
        }

        private void DrawBombsAmount(int x, int y) //TODO Переставить х и у где надо
        {
            if (Cells[x, y].BombState)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if ((x + i >= 0 && y + j >= 0) && (x + i < RowsAmount && y + j < ColumnsAmount)
                            && Cells[x + i, y + j].BombState == false)

                        {
                            Cells[x + i, y + j].NearbyBombsAmount++;
                        }
                    }

                }
            }
        }

        public void RevealEmptySpaces(int x, int y)
        {
            bool[,] visited = new bool[RowsAmount, ColumnsAmount];

            RevealEmptySpaces(x, y, visited);
        }

        private void RevealEmptySpaces(int y, int x, bool[,] visited) // TODO доделать как просплюсь
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int current_y = y + i;
                    int current_x = x + j;

                    if ((current_y >= 0 && current_x >= 0) && (current_y < RowsAmount && current_x < ColumnsAmount))
                    {
                        if (Cells[current_y, current_x].NearbyBombsAmount == 0)
                        {
                            Cells[current_y, current_x].CellIcon = CellIcon.Open_empty;
                        }

                        if (!visited[current_y, current_x] && Cells[current_y, current_x].NearbyBombsAmount == 0)
                        {
                            visited[current_y, current_x] = true;
                            RevealEmptySpaces(current_y, current_x, visited);
                        }
                    }
                }
            }
        }
    }
}
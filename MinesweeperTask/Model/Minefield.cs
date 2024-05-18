using System;
using System.Collections.Generic;

namespace MinesweeperTask.Model
{
    public class Minefield
    {
        public Cell[,] Cells { get; private set; }

        public int RowsAmount { get; private set; }

        public int ColumnsAmount { get; private set; }

        public int BombsAmount { get; private set; }

        public Minefield(int difficulty)
        {
            switch (difficulty)
            {
                case 0:
                    RowsAmount = 5;
                    ColumnsAmount = 5;
                    BombsAmount = 5;

                    break;
                case 1:
                    RowsAmount = 8;
                    ColumnsAmount = 16;
                    BombsAmount = 20;

                    break;
                case 2:
                    RowsAmount = 12;
                    ColumnsAmount = 24;
                    BombsAmount = 60;

                    break;
                default:
                    throw new NotImplementedException();
            }

            Cells = new Cell[RowsAmount, ColumnsAmount];

            for (int i = 0; i < RowsAmount; i++)
            {
                for (int j = 0; j < ColumnsAmount; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }

            PlaceBombs(BombsAmount, 3, 3);
        }

        public void PlaceBombs(int bombsAmount, int senderPosY, int senderPosX) //TODO First click apply
        {
            HashSet<(int y, int x)> bombs = new HashSet<(int y, int x)>();
            Random random = new Random();

            while (bombs.Count < bombsAmount)
            {
                bombs.Add((random.Next(RowsAmount), random.Next(ColumnsAmount)));
            }

            foreach (var bomb in bombs)
            {
                Cells[bomb.y, bomb.x].BombState = true;
            }

            foreach (var bomb in bombs)
            {
                DrawBombsAmount(bomb.y, bomb.x);
            }
        }

        private void DrawBombsAmount(int y, int x)
        {
            if (Cells[y, x].BombState)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if ((y + i >= 0 && x + j >= 0) && (y + i < RowsAmount && x + j < ColumnsAmount)
                            && Cells[y + i, x + j].BombState == false)

                        {
                            Cells[y + i, x + j].NearbyBombsAmount++;
                        }
                    }
                }
            }
        }

        public int RevealEmptySpaces(int y, int x)
        {
            if (Cells[y, x].BombState)
            {
                return 1;
            }

            if (Cells[y, x].NearbyBombsAmount > 0)
            {
                Cells[y, x].CellIcon = CellIcon.OpenDigit;

                return 0;
            }

            bool[,] visited = new bool[RowsAmount, ColumnsAmount];

            RevealEmptySpaces(y, x, visited);

            return 0;
        }

        private void RevealEmptySpaces(int y, int x, bool[,] visited)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int currentY = y + i;
                    int currentX = x + j;

                    if ((currentY >= 0 && currentX >= 0) && (currentY < RowsAmount && currentX < ColumnsAmount) && (!Cells[currentY, currentX].BombState))
                    {
                        if (Cells[currentY, currentX].NearbyBombsAmount == 0)
                        {
                            Cells[currentY, currentX].CellIcon = CellIcon.OpenEmpty;
                        }

                        if (Cells[currentY, currentX].NearbyBombsAmount > 0)
                        {
                            Cells[currentY, currentX].CellIcon = CellIcon.OpenDigit;
                        }

                        if (!visited[currentY, currentX] && Cells[currentY, currentX].NearbyBombsAmount == 0)
                        {
                            visited[currentY, currentX] = true;
                            RevealEmptySpaces(currentY, currentX, visited);
                        }
                    }
                }
            }
        }
    }
}
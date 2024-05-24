﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MinesweeperTask.Model
{
    public class Board : IBoard //TODO конструктор
    {
        public Minefield Minefield { get; set; }

        public event Action Timer_Ticked;

        public int Difficulty { get; set; } // TODO enum

        public int GameOver { get; set; } // TODO нормальные кондиции для конца игры,  сделать енум для win\lose, возможно сделать эвент на достижение 1 или 2

        public int BombsCountTable { get; set; }

        public int DefusedBombsCount { get; set; }// TODO возможно впихнуть сюда кастом сеттер, чтоб при достижении 0 давало геймовер 2

        public int Time { get; set; } // TODO спросить

        public void InitMinefield(int difficulty)
        {

            Minefield = new Minefield(difficulty);
        }

        public int OpenCell(int y, int x)
        {
            if (Minefield.Cells[y, x].CellIcon == CellIcon.Closed)
            {
                GameOver = Minefield.RevealEmptySpaces(y, x);
            }

            return GameOver;
        }

        public void MarkCell(int y, int x)
        {
            var currentCell = Minefield.Cells[y, x];

            switch (currentCell.CellIcon)
            {
                case CellIcon.Closed:
                    currentCell.CellIcon = CellIcon.Flag;
                    BombsCountTable--;

                    if (currentCell.BombState)
                    {
                        DefusedBombsCount--;

                        if (DefusedBombsCount == 0 && BombsCountTable == 0)
                        {
                            GameOver = 2;
                        }
                    }

                    break;
                case CellIcon.Flag:
                    currentCell.CellIcon = CellIcon.Closed;
                    BombsCountTable++;

                    if (currentCell.BombState)
                    {
                        DefusedBombsCount++;
                    }

                    break;

                default:
                    break;
            }
        }

        public void InitBoard(int difficulty)
        {
            InitMinefield(difficulty);
            InitTimer();
            BombsCountTable = Minefield.BombsAmount;
            DefusedBombsCount = Minefield.BombsAmount;
            GameOver = 0;
            Time = 0;
        }

        //Полный хаос с попытками сделать перенести тики таймера во вьюху, подумать\погуглить
        public void InitTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_tick;
            timer.Start();
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            Time++;
            Timer_Ticked?.Invoke();
        }
    }
}
using MinesweeperTask.Model; // TODO спросить
using MinesweeperTask.Presenter;
using MinesweeperTask.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MinesweeperTask
{
    public partial class MainWindow : Form, IView
    {
        private readonly Color[] _mineNumberColor =
        {
            Color.Empty, Color.Blue, Color.Green, Color.Red, Color.DarkBlue,
            Color.Maroon, Color.Cyan, Color.Black, Color.Gray
        };

        private readonly Image[] CellIconImages =
        { Image.FromFile("..\\..\\content\\bomb.png"), Image.FromFile("..\\..\\content\\bomb_exploded.png"),
            Image.FromFile("..\\..\\content\\cell_closed.png"),Image.FromFile("..\\..\\content\\face_idle.png"),
            Image.FromFile("..\\..\\content\\red_flag.png"),Image.FromFile("..\\..\\content\\smile_lose.png"),
            Image.FromFile("..\\..\\content\\smile_start.png"),Image.FromFile("..\\..\\content\\smile_win.png")
        };

        private Cell[,] _cells;

        private MainPresenter _presenter;

        public MainWindow()
        {

            MaximizeBox = false;
            InitializeComponent();
        }

        public void SetPresenter(MainPresenter presenter)
        {
            _presenter = presenter;
        }

        public void SetMinefield(Cell[,] cells)
        {
            _cells = cells;
        }

        public void DrawField(int rowsAmount, int columnsAmount)
        {
            tableLayoutPanel1.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(tableLayoutPanel1, true, null);

            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();
            
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.RowCount = rowsAmount;
            tableLayoutPanel1.ColumnCount = columnsAmount;


            for (int i = 0; i < rowsAmount; i++)
            {
                for (int j = 0; j < columnsAmount; j++)
                {
                    Button cellButton = new Button
                    {
                        Size = new System.Drawing.Size(64, 64),
                        Text = "",
                        FlatStyle = FlatStyle.Flat,
                        Tag = (i, j),
                        Font = new System.Drawing.Font("Arial Narrow", 20.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))

                    };

                    //cellButton.FlatAppearance.BorderSize = 0;
                    cellButton.Image = CellIconImages[2];
                    cellButton.MouseDown += new MouseEventHandler(cellButton_Click);
                    tableLayoutPanel1.Controls.Add(cellButton, j, i);
                }
            }

            tableLayoutPanel1.ResumeLayout();
        }

        public void RedrawField()
        {
            int rowsAmount = _cells.GetLength(0);
            int columnsAmount = _cells.GetLength(1);

            tableLayoutPanel1.SuspendLayout();

            for (int i = 0; i < rowsAmount; i++)
            {
                for (int j = 0; j < columnsAmount; j++)
                {
                    Button currentButton = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                    switch (_cells[i, j].CellIcon)
                    {
                        case CellIcon.Closed:
                            currentButton.Text = "";
                            currentButton.Image = CellIconImages[2];
                            break;
                        case CellIcon.OpenEmpty:
                            currentButton.Text = "";
                            currentButton.Image = null;
                            break;
                        case CellIcon.OpenDigit:
                            currentButton.Image = null;
                            currentButton.Text = _cells[i, j].NearbyBombsAmount.ToString();
                            currentButton.ForeColor = _mineNumberColor[_cells[i, j].NearbyBombsAmount];
                            break;
                        case CellIcon.Flag:
                            currentButton.Image = CellIconImages[4];
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            }

            tableLayoutPanel1.ResumeLayout();
        }

        public void DrawBombsWhenGameOver(int y, int x, bool exploded)
        {
            var rowsAmount = tableLayoutPanel1.RowCount;
            var columnsAmount = tableLayoutPanel1.ColumnCount;

            for (int i = 0; i < rowsAmount; i++)
            {
                for (int j = 0; j < columnsAmount; j++)
                {
                    if (i == y && j == x && exploded)
                    {
                        Button currentButton = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                        currentButton.Image = CellIconImages[1];
                    }
                    else if (_cells[i, j].BombState)
                    {
                        Button currentButton = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                        currentButton.Image = CellIconImages[0];
                    }
                }
            }
        }

        public void Fiasko(bool condition)
        {
            if (condition)
            {
                resetButton.Image = CellIconImages[7];
                MessageBox.Show("Это победа, братан!");

            }
            else
            {
                resetButton.Image = CellIconImages[5];
                MessageBox.Show("Это фиаско, братан!");
            }

        }

        public void SetBombCounterValue(int value)
        {
            bombCounter.Text = value.ToString();
        }

        public void SetTimerValue(int value)
        {
            timerLabel.Invoke(new Action(() => timerLabel.Text = value.ToString()));
        }

        private void cellButton_Click(object sender, MouseEventArgs e)
        {
            (int x, int y) = (ValueTuple<int, int>)((Button)sender).Tag;

            if (e.Button == MouseButtons.Left)
            {
                _presenter.OpenCell(x, y);
            }

            if (e.Button == MouseButtons.Right)
            {
                _presenter.MarkCell(x, y);
            }
        }

        private void resetButton_Click(object sender, System.EventArgs e)
        {
            _presenter.ResetField();
        }

        //TODO "there's no native support for a RadioButton MenueItem" 

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.SetDifficulty(0);
            _presenter.ResetField();
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.SetDifficulty(1);
            _presenter.ResetField();
        }

        private void bigHardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.SetDifficulty(2);
            _presenter.ResetField();
        }
    }
}
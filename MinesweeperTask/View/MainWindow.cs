using MinesweeperTask.Model; // TODO спросить
using MinesweeperTask.Presenter;
using MinesweeperTask.View;
using System;
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

            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            //TODO Почему тут суспенд лэйаут не работает? Будто быстрее будет новое поле создать, чем это редактировать
            tableLayoutPanel1.AutoSize = true;
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
                    cellButton.FlatAppearance.BorderSize = 0;
                    cellButton.Image = Image.FromFile("..\\..\\content\\cell_closed.jpg");
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
                            currentButton.Image = Image.FromFile("..\\..\\content\\cell_closed.jpg");
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
                            currentButton.Image = Image.FromFile("..\\..\\content\\red_flag.jpg");
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
                        currentButton.Image = Image.FromFile("..\\..\\content\\bomb_exploded.png");
                    }
                    else if (_cells[i,j].BombState)
                    {
                        Button currentButton = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                        currentButton.Image = Image.FromFile("..\\..\\content\\bomb.png"); 
                    }
                }
            }
        }

        public void Fiasko(bool condition)
        {
            if (condition)
            {
                resetButton.Image = Image.FromFile("..\\..\\content\\smile_win.png");
                MessageBox.Show("Это победа, братан!");

            }
            else
            {
                resetButton.Image = Image.FromFile("..\\..\\content\\smile_lose.png");
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
using MinesweeperTask.Presenter;
using MinesweeperTask.View;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace MinesweeperTask
{
    public partial class MainWindow : Form, IMainWindow
    {
        private MainPresenter _presenter;
        public int Time { get; set; } = 0;

        public MainWindow()
        {
            Start();

            label1.Text = $"{Time:d2}";
            timer1.Tick += timer1_Tick;
        }

        public void ResetMinefield(int rowsAmount, int columnsAmount)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            tableLayoutPanel1.RowCount = rowsAmount;
            tableLayoutPanel1.ColumnCount = columnsAmount;
            _presenter.Show(rowsAmount, columnsAmount, 10);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button btn = new Button()
                    {
                        Width = 64,
                        Height = 64,
                        BackgroundImage = Image.FromFile("..\\..\\closed_tile.jpg"),
                        Tag = new int[] { i, j }
                    };

                    btn.Click += btn_Click;
                    tableLayoutPanel1.Controls.Add(btn, j, i);
                }
            }
        }


        public void SetPresenter(MainPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetMinefield(10,10);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ResetMinefield(10, 10);
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int[] coordinates = (int[])btn.Tag;
            btn.BackgroundImage = null;
            _presenter._model.Minefield.Cells[coordinates[0], coordinates[1]].BombState.ToString();
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            Time++;
            label1.Text = $"{Time:d2}";
        }
    }
}

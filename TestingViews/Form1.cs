using System;
using System.Windows.Forms;

namespace TestingViews
{
    public partial class Form1 : Form
    {
        public Cell[,] Cells { get; set; }

        public Form1()
        {
            int rowsAmont = 5;
            int colsAmount = 5;
            
            Cells = new Cell[rowsAmont, colsAmount];

            for (int i = 0; i < rowsAmont; i++)
            {
                for (int j = 0; j < colsAmount; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }
            

            InitializeComponent();

            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.RowCount = rowsAmont;
            tableLayoutPanel1.ColumnCount = colsAmount;

            for (int k = 0; k < rowsAmont; k++)
            {
                for (int m = 0; m < colsAmount; m++)
                {
                    Button cellButton = new Button
                    {
                        Size = new System.Drawing.Size(64, 64),
                        Text = $"{k},{m}",
                        FlatStyle = FlatStyle.Flat,
                        Tag = Cells[k, m],
                        Font = new System.Drawing.Font("Arial Narrow", 20.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))

                };
                    cellButton.FlatAppearance.BorderSize = 10;
                    cellButton.Click += new EventHandler(cellButton_Click);
                    tableLayoutPanel1.Controls.Add(cellButton, k, m);
                }
            }


            Cells[1, 1].Bomb = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void cellButton_Click(object sender, EventArgs e)
        {
            Cell cell = (Cell)((Button)sender).Tag;

            if (cell.Bomb)
            {
                MessageBox.Show("Фиаско!");
            }

            ((Button)sender).Text = $"1";
        }
    }

    public class Cell
    {
        public int NearbyBombs { get; set; }
        public bool Bomb { get; set; }
        public Cell_Icon_State CellIcon { get; set; }

        public Cell()
        {
            
        }
    }

    public enum Cell_Icon_State
    {
        closed = 0, empty = 1, digit = 2, flag = 3, boom = 4, noBoom = 5
    }
}

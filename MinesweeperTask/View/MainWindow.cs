using MinesweeperTask.Presenter;
using MinesweeperTask.View;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinesweeperTask
{
    public partial class MainWindow : Form, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        MainPresenter IMainWindow.Presenter { get; set; }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Button btn = new Button();
            btn.AutoSize = true;

            int amount = tableLayoutPanel1.ColumnCount * tableLayoutPanel1.RowCount;
            Button[] butts = new Button[amount];

            for (int i = 0; i < amount; i++)
            {
                tableLayoutPanel1.Controls.Add(btn);
            }

            

        }
    }
}

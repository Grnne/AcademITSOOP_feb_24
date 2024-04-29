using MinesweeperTask.Presenter;
using MinesweeperTask.View;
using MinesweeperTask.Model;
using System.Windows.Forms;

namespace MinesweeperTask
{
    public partial class MainWindow : Form, IMainWindow
    {
        private MainPresenter _presenter;

        public MainWindow()
        {
            Start();
        }

        public void SetPresenter(MainPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            _presenter.Show(9);
            Cell[,] test = _presenter._model.Minefield.Cells;
            Button[] btestRow = new Button[]  { new Button(), new Button(), new Button() };

            flowLayoutPanel1.Controls.AddRange(btestRow);
        }
    }
}

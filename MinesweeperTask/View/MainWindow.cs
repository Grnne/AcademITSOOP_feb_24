using MinesweeperTask.Presenter;
using MinesweeperTask.View;
using System.Windows.Forms;

namespace MinesweeperTask
{
    public partial class MainWindow : Form, IView
    {
        private MainPresenter _presenter;
        public int Difficulty { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _presenter._model.InitBoard(0);
        }

        public void SetPresenter(MainPresenter presenter)
        {
            _presenter = presenter;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
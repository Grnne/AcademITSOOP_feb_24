using MinesweeperTask.Presenter;
using MinesweeperTask.View;
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
    }
}

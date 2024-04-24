using MinesweeperTask.Presenter;
using System;
using System.Windows.Forms;

namespace MinesweeperTask
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow view = new MainWindow();
            MainPresenter presenter = new MainPresenter(view);

            Application.Run(view);
        }
    }
}

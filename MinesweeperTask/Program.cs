using MinesweeperTask.Model;
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

            var view = new MainWindow();
            var model = new Board();
            _ = new MainPresenter(view, model);

            Application.Run(view);
        }
    }
}
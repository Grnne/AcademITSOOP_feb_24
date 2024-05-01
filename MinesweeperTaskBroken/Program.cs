using MinesweeperTask.Model;
using MinesweeperTask.Presenter;
using System;
using System.Net;
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
            Console.WriteLine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new MainWindow();
            var model = new Board();
            var presenter = new MainPresenter(view, model);

            view.SetPresenter(presenter);

            Application.Run(view);

            

        }
    }

    public enum CellIcon
    {
        Closed,
        Open_empty,
        Open_digit,
        Open_bomb,
        Marked
    }
}



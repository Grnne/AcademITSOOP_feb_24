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

    enum State
    {
        Empty,
        Bomb
    }

    enum IconState
    {
        Closed,
        Open,
        Flagged,
        Question,
        Bomb,
        BombExploded
    }
}



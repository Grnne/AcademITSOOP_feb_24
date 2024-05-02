using MinesweeperTask.Model;
using MinesweeperTask.Presenter;
using MinesweeperTask.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var presenter = new MainPresenter(view, model);

            Application.Run(view);
        }
    }
}
using System;
using System.Windows.Forms;
using TemperatureTask.Model;
using TemperatureTask.Presenter;

// TODO Биндинги, структура, узнать про мвп

namespace TemperatureTask
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

            IConverter converter = new TemperatureConverter();
            var view = new ConverterView();
            TemperaturePresenter controller = new TemperaturePresenter(converter, view);
            view.SetController(controller);
            
            Application.Run(view);
        }
    }
}

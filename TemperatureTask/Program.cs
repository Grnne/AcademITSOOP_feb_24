using System;
using System.Windows.Forms;
using TemperatureTask.Model;
using TemperatureTask.Presenter;

namespace TemperatureTask
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IConverter converter = new TemperatureConverter();
            var view = new ConverterView();
            TemperaturePresenter presenter = new TemperaturePresenter(converter, view);
            view.SetPresenter(presenter);
            
            Application.Run(view);
        }
    }
}
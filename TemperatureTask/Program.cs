using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemperatureTask.Model;
using TemperatureTask.Model.Scales;
using TemperatureTask.Presenter;

namespace TemperatureTask
{
    internal static class Program
    {
        // TODO спросить про где делать обработку ошибок
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var converter = new TemperatureConverter(new List<IScale>()
            {
                new CelsiusScale(),
                new FahrenheitScale(),
                new KelvinScale()
            });

            var view = new ConverterView();
            _ = new TemperaturePresenter(converter, view);

            Application.Run(view);
        }
    }
}
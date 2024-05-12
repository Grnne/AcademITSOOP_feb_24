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

            ITemperatureConverter converter = new TemperatureConverter(new List<Scale>()
            {   new Celsius(),
                new Fahrenheit(),
                new Kelvin()
            });

            var view = new converterView();
            TemperaturePresenter presenter = new TemperaturePresenter(converter, view);


            Application.Run(view);
        }
    }
}
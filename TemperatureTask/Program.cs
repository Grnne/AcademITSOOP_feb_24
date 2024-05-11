using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemperatureTask.Model;
using TemperatureTask.Model.Scales;
using TemperatureTask.Presenter;
using TemperatureTask.View;

namespace TemperatureTask
{
    internal static class Program
    {
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

            var view = new ConverterView();
            TemperaturePresenter presenter = new TemperaturePresenter(converter, view);
            view.SetPresenter(presenter);

            Application.Run(view);
        }
    }
}
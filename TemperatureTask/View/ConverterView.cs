using System;
using System.Windows.Forms;
using TemperatureTask.Presenter;
using TemperatureTask.View;

namespace TemperatureTask
{
    public partial class ConverterView : Form, IView
    {
        private TemperaturePresenter _controller;
        
        public ConverterView()
        {
            Start();
        }

        public void SetController(TemperaturePresenter controller)
        { 
            _controller = controller;
        }

        public void Start()
        {
            InitializeComponent();
        }

        public (int, int) GetScalesAsInt(Control.ControlCollection sourceScales, Control.ControlCollection resultScales)
        {
            (int, int) scales = (0, 0);

            foreach (RadioButton radioButton in sourceScales)
            {
                if (radioButton.Checked == true)
                {
                    scales.Item1 = Convert.ToInt32(radioButton.Name);
                }
            }

            foreach (RadioButton radioButton in resultScales)
            {
                if (radioButton.Checked == true)
                {
                    scales.Item2 = Convert.ToInt32(radioButton.Name);
                }
            }

            return scales;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var sourceTemperature = double.Parse(sourceTemperatureTextBox.Text);
                var temperatureScales = GetScalesAsInt(sourceScaleBox.Controls, resultScaleBox.Controls);

                resultTemperatureTextBox.Text = $"{_controller.GetConvertedTemperature(sourceTemperature, temperatureScales)}";
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

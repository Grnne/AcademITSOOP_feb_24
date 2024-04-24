using System;
using System.Windows.Forms;
using TemperatureTask.Presenter;
using TemperatureTask.View;

namespace TemperatureTask
{
    public partial class ConverterView : Form, IView //TODO спросить про нейминг контролов
    {
        private TemperaturePresenter _presenter;

        public ConverterView()
        {
            Start();
        }

        public void SetPresenter(TemperaturePresenter presenter)
        {
            _presenter = presenter;
        }

        public void Start()
        {
            InitializeComponent();
        }

        public void ShowResultTemperature(double resultTemperature)
        {
            resultTemperatureTextBox.Text = $"{resultTemperature}";
        }

        private int GetScaleAsInt(GroupBox.ControlCollection scales)
        {
            int scale = 0;

            foreach (RadioButton radioButton in scales) // TODO Нету итератора в GroupBox, спросить; Тут ли делать преобразование в инты
            {
                if (radioButton.Checked)
                {
                    switch (radioButton.Text)
                    {
                        case "Celsius":
                            scale = 0;
                            break;
                        case "Fahrenheit":
                            scale = 1;
                            break;
                        default:
                            scale = 2;
                            break;
                    }

                    break;
                }
            }

            return scale;
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                var sourceTemperature = double.Parse(sourceTemperatureTextBox.Text);
                var sourceScale = GetScaleAsInt(sourceScaleBox.Controls);
                var resultScale = GetScaleAsInt(resultScaleBox.Controls);

                _presenter.GetConvertedTemperature(sourceTemperature, sourceScale, resultScale); // Имя метода тогда show а не гет?
            }
            catch (FormatException)
            {
                MessageBox.Show("Input value must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //TODO Спросить про возможность центровки без создания экземпляра вручную
            }
        }
    }
}
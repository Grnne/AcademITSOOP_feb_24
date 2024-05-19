using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TemperatureTask.Model.Scales;
using TemperatureTask.Presenter;
using TemperatureTask.View;

namespace TemperatureTask
{
    public partial class ConverterView : Form, IConverterView
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
        
        public void SetScales(List<IScale> scales)
        {
            var i = 20;

            foreach (var scale in scales)
            {
                var radioButton = new RadioButton
                {
                    Name = $"test{i}",
                    Text = scale.GetName(),
                    Location = new Point(10, i)
                };
                sourceScaleBox.Controls.Add(radioButton);
                i += 20;
            }

            ((RadioButton)sourceScaleBox.Controls[0]).Checked = true;
            i = 20;

            foreach (var scale in scales)
            {
                var radioButton = new RadioButton
                {
                    Name = $"test{i}",
                    Text = scale.GetName(),
                    Location = new Point(10, i)
                };
                resultScaleBox.Controls.Add(radioButton);
                i += 20;
            }

            ((RadioButton)resultScaleBox.Controls[0]).Checked = true;
        } 

        public void Start()
        {
            InitializeComponent();
        }

        public string GetScaleName(GroupBox scaleBox)
        {
            foreach (RadioButton radioButton in scaleBox.Controls)
            {
                if (radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }

            return ""; //TODO я вроде бы в интерфейсе поставил галочку по умолчанию, но нужно ли тут что-либо делать, на случай, если пользователь сможет убрать?
        }

        public void ShowResultTemperature(double resultTemperature)
        {
            resultTemperatureTextBox.Text = $"{resultTemperature}";
        }

        public void ConvertTemperature()
        {
            try
            {
                var sourceTemperature = double.Parse(sourceTemperatureTextBox.Text);
                var sourceScaleName = GetScaleName(sourceScaleBox);
                var resultScaleName = GetScaleName(resultScaleBox);
                _presenter.ConvertTemperature(sourceTemperature, sourceScaleName, resultScaleName);

            }
            catch (FormatException)
            {
                MessageBox.Show("Input value must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            ConvertTemperature();
        }

        private void SourceTemperatureTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConvertTemperature();
            }
        }

        private void ConverterView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // TODO  Спросить как сделать, чтоб при нажатии энтер без курсора в поле ввода работало
            {
                ConvertTemperature();
            }
        }
    }
}
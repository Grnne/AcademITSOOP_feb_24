using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TemperatureTask.Model.Scales;
using TemperatureTask.Presenter;
using TemperatureTask.View;

namespace TemperatureTask
{
    public partial class converterView : Form, IConverterView
    {
        private TemperaturePresenter _presenter;

        public converterView()
        {
            Start();
        }

        public void SetPresenter(TemperaturePresenter presenter)
        {
            _presenter = presenter;
        }
        
        // TODO Спросить про то, должен ли тут быть список имен, а вьюха должна знать только про презентер?
        public void SetScales(List<Scale> scales)
        {
            int i = 20;

            foreach (Scale scale in scales)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Name = $"test{i}";
                radioButton.Text = scale.Name;
                radioButton.Location = new Point(10, i);
                sourceScaleBox.Controls.Add(radioButton);
                i += 20;
            }

            // TODO спросить Чего-то я не не совсем понимаю логику винформс, просто sourceScaleBox.Controls[0].Checked не работает. 
            RadioButton firstButton = (RadioButton)sourceScaleBox.Controls[0];
            firstButton.Checked = true;

            i = 20;

            foreach (Scale scale in scales)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Name = $"test{i}";
                radioButton.Text = scale.Name;
                radioButton.Location = new Point(10, i);
                resultScaleBox.Controls.Add(radioButton);
                i += 20;
            }

            firstButton = (RadioButton)resultScaleBox.Controls[0];
            firstButton.Checked = true;
        } 

        public void Start()
        {
            InitializeComponent();
        }

        public string GetScaleName(GroupBox scaleBox)
        {
            string scaleName = "";

            foreach (RadioButton radioButton in scaleBox.Controls)
            {
                if (radioButton.Checked)
                {
                    scaleName = radioButton.Text;
                }
            }

            return scaleName;
        }

        public void ShowResultTemperature(double resultTemperature)
        {
            resultTemperatureTextBox.Text = $"{resultTemperature}";
        }

        private void convertButton_Click(object sender, EventArgs e)
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
    }
}
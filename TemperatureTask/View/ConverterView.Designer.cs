namespace TemperatureTask
{
    partial class ConverterView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConvertButton = new System.Windows.Forms.Button();
            this.sourceTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.resultTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.sourceRadioButtonCelsius = new System.Windows.Forms.RadioButton();
            this.sourceRadioButtonFahrenheit = new System.Windows.Forms.RadioButton();
            this.sourceRadioButtonKelvin = new System.Windows.Forms.RadioButton();
            this.sourceScaleBox = new System.Windows.Forms.GroupBox();
            this.resultScaleBox = new System.Windows.Forms.GroupBox();
            this.resultRadioButtonCelsius = new System.Windows.Forms.RadioButton();
            this.resultRadioButtonFahrenheit = new System.Windows.Forms.RadioButton();
            this.resultRadioButtonKelvin = new System.Windows.Forms.RadioButton();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.DestinationLabel = new System.Windows.Forms.Label();
            this.sourceScaleBox.SuspendLayout();
            this.resultScaleBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvertButton
            // 
            this.ConvertButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ConvertButton.Location = new System.Drawing.Point(171, 129);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(169, 37);
            this.ConvertButton.TabIndex = 0;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // sourceTemperatureTextBox
            // 
            this.sourceTemperatureTextBox.Location = new System.Drawing.Point(171, 54);
            this.sourceTemperatureTextBox.Name = "sourceTemperatureTextBox";
            this.sourceTemperatureTextBox.Size = new System.Drawing.Size(169, 20);
            this.sourceTemperatureTextBox.TabIndex = 1;
            // 
            // resultTemperatureTextBox
            // 
            this.resultTemperatureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTemperatureTextBox.Location = new System.Drawing.Point(171, 102);
            this.resultTemperatureTextBox.Name = "resultTemperatureTextBox";
            this.resultTemperatureTextBox.ReadOnly = true;
            this.resultTemperatureTextBox.Size = new System.Drawing.Size(169, 20);
            this.resultTemperatureTextBox.TabIndex = 5;
            // 
            // sourceRadioButtonCelsius
            // 
            this.sourceRadioButtonCelsius.AutoSize = true;
            this.sourceRadioButtonCelsius.Checked = true;
            this.sourceRadioButtonCelsius.Location = new System.Drawing.Point(13, 19);
            this.sourceRadioButtonCelsius.Name = "sourceRadioButtonCelsius";
            this.sourceRadioButtonCelsius.Size = new System.Drawing.Size(58, 17);
            this.sourceRadioButtonCelsius.TabIndex = 6;
            this.sourceRadioButtonCelsius.TabStop = true;
            this.sourceRadioButtonCelsius.Text = "Celsius";
            this.sourceRadioButtonCelsius.UseVisualStyleBackColor = true;
            // 
            // sourceRadioButtonFahrenheit
            // 
            this.sourceRadioButtonFahrenheit.AutoSize = true;
            this.sourceRadioButtonFahrenheit.Location = new System.Drawing.Point(13, 42);
            this.sourceRadioButtonFahrenheit.Name = "sourceRadioButtonFahrenheit";
            this.sourceRadioButtonFahrenheit.Size = new System.Drawing.Size(75, 17);
            this.sourceRadioButtonFahrenheit.TabIndex = 7;
            this.sourceRadioButtonFahrenheit.TabStop = true;
            this.sourceRadioButtonFahrenheit.Text = "Fahrenheit";
            this.sourceRadioButtonFahrenheit.UseVisualStyleBackColor = true;
            // 
            // sourceRadioButtonKelvin
            // 
            this.sourceRadioButtonKelvin.AutoSize = true;
            this.sourceRadioButtonKelvin.Location = new System.Drawing.Point(13, 65);
            this.sourceRadioButtonKelvin.Name = "sourceRadioButtonKelvin";
            this.sourceRadioButtonKelvin.Size = new System.Drawing.Size(54, 17);
            this.sourceRadioButtonKelvin.TabIndex = 8;
            this.sourceRadioButtonKelvin.TabStop = true;
            this.sourceRadioButtonKelvin.Text = "Kelvin";
            this.sourceRadioButtonKelvin.UseVisualStyleBackColor = true;
            // 
            // sourceScaleBox
            // 
            this.sourceScaleBox.Controls.Add(this.sourceRadioButtonCelsius);
            this.sourceScaleBox.Controls.Add(this.sourceRadioButtonFahrenheit);
            this.sourceScaleBox.Controls.Add(this.sourceRadioButtonKelvin);
            this.sourceScaleBox.Location = new System.Drawing.Point(19, 83);
            this.sourceScaleBox.Name = "sourceScaleBox";
            this.sourceScaleBox.Size = new System.Drawing.Size(115, 105);
            this.sourceScaleBox.TabIndex = 12;
            this.sourceScaleBox.TabStop = false;
            this.sourceScaleBox.Text = "Source Scale";
            // 
            // resultScaleBox
            // 
            this.resultScaleBox.Controls.Add(this.resultRadioButtonCelsius);
            this.resultScaleBox.Controls.Add(this.resultRadioButtonFahrenheit);
            this.resultScaleBox.Controls.Add(this.resultRadioButtonKelvin);
            this.resultScaleBox.Location = new System.Drawing.Point(380, 83);
            this.resultScaleBox.Name = "resultScaleBox";
            this.resultScaleBox.Size = new System.Drawing.Size(115, 105);
            this.resultScaleBox.TabIndex = 13;
            this.resultScaleBox.TabStop = false;
            this.resultScaleBox.Text = "Result Scale";
            // 
            // resultRadioButtonCelsius
            // 
            this.resultRadioButtonCelsius.AutoSize = true;
            this.resultRadioButtonCelsius.Checked = true;
            this.resultRadioButtonCelsius.Location = new System.Drawing.Point(13, 19);
            this.resultRadioButtonCelsius.Name = "resultRadioButtonCelsius";
            this.resultRadioButtonCelsius.Size = new System.Drawing.Size(58, 17);
            this.resultRadioButtonCelsius.TabIndex = 6;
            this.resultRadioButtonCelsius.TabStop = true;
            this.resultRadioButtonCelsius.Text = "Celsius";
            this.resultRadioButtonCelsius.UseVisualStyleBackColor = true;
            // 
            // resultRadioButtonFahrenheit
            // 
            this.resultRadioButtonFahrenheit.AutoSize = true;
            this.resultRadioButtonFahrenheit.Location = new System.Drawing.Point(13, 42);
            this.resultRadioButtonFahrenheit.Name = "resultRadioButtonFahrenheit";
            this.resultRadioButtonFahrenheit.Size = new System.Drawing.Size(75, 17);
            this.resultRadioButtonFahrenheit.TabIndex = 7;
            this.resultRadioButtonFahrenheit.TabStop = true;
            this.resultRadioButtonFahrenheit.Text = "Fahrenheit";
            this.resultRadioButtonFahrenheit.UseVisualStyleBackColor = true;
            // 
            // resultRadioButtonKelvin
            // 
            this.resultRadioButtonKelvin.AutoSize = true;
            this.resultRadioButtonKelvin.Location = new System.Drawing.Point(13, 65);
            this.resultRadioButtonKelvin.Name = "resultRadioButtonKelvin";
            this.resultRadioButtonKelvin.Size = new System.Drawing.Size(54, 17);
            this.resultRadioButtonKelvin.TabIndex = 8;
            this.resultRadioButtonKelvin.TabStop = true;
            this.resultRadioButtonKelvin.Text = "Kelvin";
            this.resultRadioButtonKelvin.UseVisualStyleBackColor = true;
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Location = new System.Drawing.Point(168, 38);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(100, 13);
            this.SourceLabel.TabIndex = 14;
            this.SourceLabel.Text = "Source temperature";
            // 
            // DestinationLabel
            // 
            this.DestinationLabel.AutoSize = true;
            this.DestinationLabel.Location = new System.Drawing.Point(168, 86);
            this.DestinationLabel.Name = "DestinationLabel";
            this.DestinationLabel.Size = new System.Drawing.Size(96, 13);
            this.DestinationLabel.TabIndex = 15;
            this.DestinationLabel.Text = "Result temperature";
            // 
            // ConverterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 202);
            this.Controls.Add(this.DestinationLabel);
            this.Controls.Add(this.SourceLabel);
            this.Controls.Add(this.resultScaleBox);
            this.Controls.Add(this.sourceScaleBox);
            this.Controls.Add(this.resultTemperatureTextBox);
            this.Controls.Add(this.sourceTemperatureTextBox);
            this.Controls.Add(this.ConvertButton);
            this.MaximumSize = new System.Drawing.Size(529, 241);
            this.MinimumSize = new System.Drawing.Size(529, 241);
            this.Name = "ConverterView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature converter";
            this.sourceScaleBox.ResumeLayout(false);
            this.sourceScaleBox.PerformLayout();
            this.resultScaleBox.ResumeLayout(false);
            this.resultScaleBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.TextBox sourceTemperatureTextBox;
        private System.Windows.Forms.TextBox resultTemperatureTextBox;
        private System.Windows.Forms.RadioButton sourceRadioButtonCelsius;
        private System.Windows.Forms.RadioButton sourceRadioButtonFahrenheit;
        private System.Windows.Forms.RadioButton sourceRadioButtonKelvin;
        private System.Windows.Forms.GroupBox sourceScaleBox;
        private System.Windows.Forms.GroupBox resultScaleBox;
        private System.Windows.Forms.RadioButton resultRadioButtonCelsius;
        private System.Windows.Forms.RadioButton resultRadioButtonFahrenheit;
        private System.Windows.Forms.RadioButton resultRadioButtonKelvin;
        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.Label DestinationLabel;
    }
}


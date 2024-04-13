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
            this.button1 = new System.Windows.Forms.Button();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceScaleBox.SuspendLayout();
            this.resultScaleBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(165, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // sourceTemperatureTextBox
            // 
            this.sourceTemperatureTextBox.Location = new System.Drawing.Point(140, 83);
            this.sourceTemperatureTextBox.Name = "sourceTemperatureTextBox";
            this.sourceTemperatureTextBox.Size = new System.Drawing.Size(217, 20);
            this.sourceTemperatureTextBox.TabIndex = 1;
            // 
            // resultTemperatureTextBox
            // 
            this.resultTemperatureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTemperatureTextBox.Location = new System.Drawing.Point(139, 25);
            this.resultTemperatureTextBox.Name = "resultTemperatureTextBox";
            this.resultTemperatureTextBox.ReadOnly = true;
            this.resultTemperatureTextBox.Size = new System.Drawing.Size(217, 20);
            this.resultTemperatureTextBox.TabIndex = 5;
            // 
            // sourceRadioButtonCelsius
            // 
            this.sourceRadioButtonCelsius.AutoSize = true;
            this.sourceRadioButtonCelsius.Checked = true;
            this.sourceRadioButtonCelsius.Location = new System.Drawing.Point(13, 19);
            this.sourceRadioButtonCelsius.Name = "0";
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
            this.sourceRadioButtonFahrenheit.Name = "1";
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
            this.sourceRadioButtonKelvin.Name = "2";
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
            this.resultRadioButtonCelsius.Name = "0";
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
            this.resultRadioButtonFahrenheit.Name = "1";
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
            this.resultRadioButtonKelvin.Name = "2";
            this.resultRadioButtonKelvin.Size = new System.Drawing.Size(54, 17);
            this.resultRadioButtonKelvin.TabIndex = 8;
            this.resultRadioButtonKelvin.TabStop = true;
            this.resultRadioButtonKelvin.Text = "Kelvin";
            this.resultRadioButtonKelvin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Source temperature";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Result temperature";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 202);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultScaleBox);
            this.Controls.Add(this.sourceScaleBox);
            this.Controls.Add(this.resultTemperatureTextBox);
            this.Controls.Add(this.sourceTemperatureTextBox);
            this.Controls.Add(this.button1);
            this.Name = "MainWindow";
            this.Text = "Temperature converter";
            this.sourceScaleBox.ResumeLayout(false);
            this.sourceScaleBox.PerformLayout();
            this.resultScaleBox.ResumeLayout(false);
            this.resultScaleBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


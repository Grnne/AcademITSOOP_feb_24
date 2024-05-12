namespace TemperatureTask
{
    partial class converterView
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
            this.convertButton = new System.Windows.Forms.Button();
            this.sourceTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.resultTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.sourceScaleBox = new System.Windows.Forms.GroupBox();
            this.resultScaleBox = new System.Windows.Forms.GroupBox();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // convertButton
            // 
            this.convertButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.convertButton.Location = new System.Drawing.Point(171, 141);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(169, 37);
            this.convertButton.TabIndex = 0;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // sourceTemperatureTextBox
            // 
            this.sourceTemperatureTextBox.Location = new System.Drawing.Point(171, 54);
            this.sourceTemperatureTextBox.Name = "sourceTemperatureTextBox";
            this.sourceTemperatureTextBox.Size = new System.Drawing.Size(169, 20);
            this.sourceTemperatureTextBox.TabIndex = 1;
            this.sourceTemperatureTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sourceTemperatureTextBox_KeyDown);
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
            // sourceScaleBox
            // 
            this.sourceScaleBox.Location = new System.Drawing.Point(22, 28);
            this.sourceScaleBox.Name = "sourceScaleBox";
            this.sourceScaleBox.Size = new System.Drawing.Size(115, 150);
            this.sourceScaleBox.TabIndex = 12;
            this.sourceScaleBox.TabStop = false;
            this.sourceScaleBox.Text = "Source Scale";
            // 
            // resultScaleBox
            // 
            this.resultScaleBox.Location = new System.Drawing.Point(377, 28);
            this.resultScaleBox.Name = "resultScaleBox";
            this.resultScaleBox.Size = new System.Drawing.Size(115, 150);
            this.resultScaleBox.TabIndex = 13;
            this.resultScaleBox.TabStop = false;
            this.resultScaleBox.Text = "Result Scale";
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(168, 38);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(100, 13);
            this.sourceLabel.TabIndex = 14;
            this.sourceLabel.Text = "Source temperature";
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Location = new System.Drawing.Point(168, 86);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(96, 13);
            this.destinationLabel.TabIndex = 15;
            this.destinationLabel.Text = "Result temperature";
            // 
            // converterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 202);
            this.Controls.Add(this.destinationLabel);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.resultScaleBox);
            this.Controls.Add(this.sourceScaleBox);
            this.Controls.Add(this.resultTemperatureTextBox);
            this.Controls.Add(this.sourceTemperatureTextBox);
            this.Controls.Add(this.convertButton);
            this.MaximumSize = new System.Drawing.Size(529, 241);
            this.MinimumSize = new System.Drawing.Size(529, 241);
            this.Name = "converterView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature converter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.converterView_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.TextBox sourceTemperatureTextBox;
        private System.Windows.Forms.TextBox resultTemperatureTextBox;
        private System.Windows.Forms.GroupBox sourceScaleBox;
        private System.Windows.Forms.GroupBox resultScaleBox;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label destinationLabel;
    }
}


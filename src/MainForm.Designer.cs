namespace SortingVisualizer
{
    partial class MainForm
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
            this.VisualizerPanel = new System.Windows.Forms.Panel();
            this.SortButton = new System.Windows.Forms.Button();
            this.AlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.AlgorithmLabel = new System.Windows.Forms.Label();
            this.SizeTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // VisualizerPanel
            // 
            this.VisualizerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisualizerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.VisualizerPanel.Location = new System.Drawing.Point(12, 173);
            this.VisualizerPanel.Name = "VisualizerPanel";
            this.VisualizerPanel.Size = new System.Drawing.Size(982, 453);
            this.VisualizerPanel.TabIndex = 0;
            this.VisualizerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.VisualizerPanel_Paint);
            // 
            // SortButton
            // 
            this.SortButton.BackColor = System.Drawing.Color.White;
            this.SortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SortButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SortButton.Font = new System.Drawing.Font("Nineteen Ninety Seven", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortButton.Location = new System.Drawing.Point(483, 29);
            this.SortButton.MaximumSize = new System.Drawing.Size(250, 50);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(215, 50);
            this.SortButton.TabIndex = 1;
            this.SortButton.Text = "Sort";
            this.SortButton.UseVisualStyleBackColor = false;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // AlgorithmComboBox
            // 
            this.AlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmComboBox.Font = new System.Drawing.Font("Nineteen Ninety Seven", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmComboBox.FormattingEnabled = true;
            this.AlgorithmComboBox.Items.AddRange(new object[] {
            "Quicksort",
            "Bubble sort"});
            this.AlgorithmComboBox.Location = new System.Drawing.Point(216, 41);
            this.AlgorithmComboBox.Name = "AlgorithmComboBox";
            this.AlgorithmComboBox.Size = new System.Drawing.Size(208, 31);
            this.AlgorithmComboBox.TabIndex = 2;
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.White;
            this.ResetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ResetButton.Font = new System.Drawing.Font("Nineteen Ninety Seven", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new System.Drawing.Point(732, 29);
            this.ResetButton.MaximumSize = new System.Drawing.Size(250, 50);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(215, 50);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // AlgorithmLabel
            // 
            this.AlgorithmLabel.AutoSize = true;
            this.AlgorithmLabel.Font = new System.Drawing.Font("Nineteen Ninety Seven", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmLabel.ForeColor = System.Drawing.Color.White;
            this.AlgorithmLabel.Location = new System.Drawing.Point(51, 43);
            this.AlgorithmLabel.Name = "AlgorithmLabel";
            this.AlgorithmLabel.Size = new System.Drawing.Size(150, 26);
            this.AlgorithmLabel.TabIndex = 4;
            this.AlgorithmLabel.Text = "Algorithm:";
            // 
            // SizeTrackBar
            // 
            this.SizeTrackBar.Location = new System.Drawing.Point(135, 111);
            this.SizeTrackBar.Maximum = 738;
            this.SizeTrackBar.Minimum = 1;
            this.SizeTrackBar.Name = "SizeTrackBar";
            this.SizeTrackBar.Size = new System.Drawing.Size(289, 56);
            this.SizeTrackBar.TabIndex = 0;
            this.SizeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SizeTrackBar.Value = 200;
            this.SizeTrackBar.ValueChanged += new System.EventHandler(this.SizeTrackBar_ValueChanged);
            // 
            // SpeedTrackBar
            // 
            this.SpeedTrackBar.Location = new System.Drawing.Point(651, 111);
            this.SpeedTrackBar.Maximum = 4;
            this.SpeedTrackBar.Name = "SpeedTrackBar";
            this.SpeedTrackBar.Size = new System.Drawing.Size(260, 56);
            this.SpeedTrackBar.TabIndex = 5;
            this.SpeedTrackBar.Value = 2;
            this.SpeedTrackBar.ValueChanged += new System.EventHandler(this.SpeedTrackBar_ValueChanged);
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Font = new System.Drawing.Font("Nineteen Ninety Seven", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedLabel.ForeColor = System.Drawing.Color.White;
            this.SpeedLabel.Location = new System.Drawing.Point(533, 111);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(103, 26);
            this.SpeedLabel.TabIndex = 6;
            this.SpeedLabel.Text = "Speed:";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Font = new System.Drawing.Font("Nineteen Ninety Seven", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizeLabel.ForeColor = System.Drawing.Color.White;
            this.SizeLabel.Location = new System.Drawing.Point(51, 111);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(78, 26);
            this.SizeLabel.TabIndex = 7;
            this.SizeLabel.Text = "Size:";
            // 
            // SizeLabel2
            // 
            this.SizeLabel2.AutoSize = true;
            this.SizeLabel2.Font = new System.Drawing.Font("Nineteen Ninety Seven", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizeLabel2.ForeColor = System.Drawing.Color.White;
            this.SizeLabel2.Location = new System.Drawing.Point(254, 141);
            this.SizeLabel2.Name = "SizeLabel2";
            this.SizeLabel2.Size = new System.Drawing.Size(47, 17);
            this.SizeLabel2.TabIndex = 8;
            this.SizeLabel2.Text = "200";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1006, 638);
            this.Controls.Add(this.SizeLabel2);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.SpeedTrackBar);
            this.Controls.Add(this.SizeTrackBar);
            this.Controls.Add(this.AlgorithmLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.AlgorithmComboBox);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.VisualizerPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sorting Visualizer";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel VisualizerPanel;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.ComboBox AlgorithmComboBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label AlgorithmLabel;
        private System.Windows.Forms.TrackBar SizeTrackBar;
        private System.Windows.Forms.TrackBar SpeedTrackBar;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label SizeLabel2;
    }
}


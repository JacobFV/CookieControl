namespace CookieControl
{
    partial class CookieWare
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CookieWare));
            this.openButton = new System.Windows.Forms.Button();
            this.cutButton = new System.Windows.Forms.Button();
            this.viewer = new System.Windows.Forms.WebBrowser();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.thicknessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.thickness = new System.Windows.Forms.Label();
            this.Material = new System.Windows.Forms.ComboBox();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.openButton.Location = new System.Drawing.Point(3, 4);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // cutButton
            // 
            this.cutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cutButton.Location = new System.Drawing.Point(365, 4);
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(75, 23);
            this.cutButton.TabIndex = 1;
            this.cutButton.Text = "Cut";
            this.cutButton.UseVisualStyleBackColor = true;
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // viewer
            // 
            this.viewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewer.Location = new System.Drawing.Point(12, -355);
            this.viewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.viewer.Name = "viewer";
            this.viewer.Size = new System.Drawing.Size(419, 351);
            this.viewer.TabIndex = 2;
            this.viewer.Visible = false;
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.controlPanel.Controls.Add(this.portComboBox);
            this.controlPanel.Controls.Add(this.thicknessNumericUpDown);
            this.controlPanel.Controls.Add(this.thickness);
            this.controlPanel.Controls.Add(this.Material);
            this.controlPanel.Controls.Add(this.openButton);
            this.controlPanel.Controls.Add(this.cutButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.Location = new System.Drawing.Point(0, 374);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(443, 31);
            this.controlPanel.TabIndex = 4;
            // 
            // portComboBox
            // 
            this.portComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Items.AddRange(new object[] {
            "COM0",
            "COM1",
            "COM2",
            "COM3"});
            this.portComboBox.Location = new System.Drawing.Point(300, 5);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(60, 21);
            this.portComboBox.TabIndex = 5;
            // 
            // thicknessNumericUpDown
            // 
            this.thicknessNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thicknessNumericUpDown.DecimalPlaces = 2;
            this.thicknessNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.thicknessNumericUpDown.Location = new System.Drawing.Point(245, 6);
            this.thicknessNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.thicknessNumericUpDown.Name = "thicknessNumericUpDown";
            this.thicknessNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.thicknessNumericUpDown.TabIndex = 4;
            this.thicknessNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // thickness
            // 
            this.thickness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thickness.AutoSize = true;
            this.thickness.Location = new System.Drawing.Point(184, 9);
            this.thickness.Name = "thickness";
            this.thickness.Size = new System.Drawing.Size(55, 13);
            this.thickness.TabIndex = 3;
            this.thickness.Text = "thickness:";
            // 
            // Material
            // 
            this.Material.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Material.BackColor = System.Drawing.SystemColors.Menu;
            this.Material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Material.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Material.FormattingEnabled = true;
            this.Material.Items.AddRange(new object[] {
            "Zinc",
            "Steel",
            "Brass",
            "Aluminium"});
            this.Material.Location = new System.Drawing.Point(84, 5);
            this.Material.Name = "Material";
            this.Material.Size = new System.Drawing.Size(94, 21);
            this.Material.TabIndex = 2;
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 10;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // CookieWare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(443, 405);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.viewer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CookieWare";
            this.Text = "CookieWare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CookieWare_FormClosing);
            this.Load += new System.EventHandler(this.CookieWare_load);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button cutButton;
        private System.Windows.Forms.WebBrowser viewer;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.ComboBox Material;
        private System.Windows.Forms.NumericUpDown thicknessNumericUpDown;
        private System.Windows.Forms.Label thickness;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.ComboBox portComboBox;



    }
}


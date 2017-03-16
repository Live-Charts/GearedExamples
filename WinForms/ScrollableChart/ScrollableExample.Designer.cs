﻿namespace Geared.Winforms.ScrollableChart
{
    partial class ScrollableExample
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
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.scrollerChart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.White;
            this.cartesianChart1.Location = new System.Drawing.Point(12, 12);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(611, 285);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // scrollerChart
            // 
            this.scrollerChart.BackColor = System.Drawing.Color.White;
            this.scrollerChart.Location = new System.Drawing.Point(12, 303);
            this.scrollerChart.Name = "scrollerChart";
            this.scrollerChart.Size = new System.Drawing.Size(611, 58);
            this.scrollerChart.TabIndex = 1;
            this.scrollerChart.Text = "cartesianChart2";
            // 
            // ScrollableExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 373);
            this.Controls.Add(this.scrollerChart);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "ScrollableExample";
            this.Text = "ScrollableExample";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart scrollerChart;
    }
}
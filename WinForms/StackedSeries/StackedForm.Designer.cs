namespace Geared.Winforms.StackedSeries
{
    partial class StackedForm
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
            System.Windows.Media.SolidColorBrush solidColorBrush9 = new System.Windows.Media.SolidColorBrush();
            System.Windows.Media.SolidColorBrush solidColorBrush10 = new System.Windows.Media.SolidColorBrush();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.scrollerchart = new LiveCharts.WinForms.CartesianChart();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Hoverable = true;
            this.cartesianChart1.Location = new System.Drawing.Point(13, 12);
            this.cartesianChart1.Name = "cartesianChart1";
            solidColorBrush9.Color = System.Windows.Media.Color.FromArgb(((byte)(30)), ((byte)(30)), ((byte)(30)), ((byte)(30)));
            this.cartesianChart1.ScrollBarFill = solidColorBrush9;
            this.cartesianChart1.ScrollHorizontalFrom = 0D;
            this.cartesianChart1.ScrollHorizontalTo = 0D;
            this.cartesianChart1.ScrollMode = LiveCharts.ScrollMode.None;
            this.cartesianChart1.ScrollVerticalFrom = 0D;
            this.cartesianChart1.ScrollVerticalTo = 0D;
            this.cartesianChart1.Size = new System.Drawing.Size(705, 377);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // scrollerchart
            // 
            this.scrollerchart.Hoverable = true;
            this.scrollerchart.Location = new System.Drawing.Point(13, 395);
            this.scrollerchart.Name = "scrollerchart";
            solidColorBrush10.Color = System.Windows.Media.Color.FromArgb(((byte)(30)), ((byte)(30)), ((byte)(30)), ((byte)(30)));
            this.scrollerchart.ScrollBarFill = solidColorBrush10;
            this.scrollerchart.ScrollHorizontalFrom = 0D;
            this.scrollerchart.ScrollHorizontalTo = 0D;
            this.scrollerchart.ScrollMode = LiveCharts.ScrollMode.None;
            this.scrollerchart.ScrollVerticalFrom = 0D;
            this.scrollerchart.ScrollVerticalTo = 0D;
            this.scrollerchart.Size = new System.Drawing.Size(705, 87);
            this.scrollerchart.TabIndex = 1;
            this.scrollerchart.Text = "cartesianChart2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start/Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Picture last 10 secs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(268, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "RealTime";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // StackedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 494);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scrollerchart);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "StackedForm";
            this.Text = "StackedForm";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart scrollerchart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
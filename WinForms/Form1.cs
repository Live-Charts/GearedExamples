using System;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Wpf;
using WinForms.DynamicAxis;
using WinForms.MultipleSeries;
using WinForms.ScrollableChart;
using WinForms.SpeedTest;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new DynamicAxisExample().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MultipleSeriesExample().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ScrollableExample().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new SpeedTest.SpeedTest().ShowDialog();
        }
    }
}

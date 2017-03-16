using System;
using System.Windows.Forms;
using Geared.Winforms.FinancialSeries;
using Geared.Winforms.Histogram;
using Geared.Winforms.Scatter;
using Geared.Winforms.ScrollableChart;
using Geared.Winforms.StackedSeries;
using WinForms.DynamicAxis;
using WinForms.MultipleSeries;

namespace Geared.Winforms
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
            new WinForms.SpeedTest.SpeedTest().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FinancialSeriesForm().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new HistogramForm().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Scatterform().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new StackedForm().ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace WindowsFormsApp2
{
    public partial class DisplayCleints : Form
    {
        Thread th;
        ReportOfCleints C1;
        public DisplayCleints()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            C1 = new ReportOfCleints();
            foreach (ParameterDiscreteValue v in C1.ParameterFields[0].DefaultValues)
            comboBox1.Items.Add(v.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            C1.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = C1;
        }

        private void butt_Back_Click(object sender, EventArgs e)
        {
            th = new Thread(openMenu);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openMenu()
        {
            Application.Run(new Menu());
        }
    }
}

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
    public partial class RoomsReport : Form
    {
        Thread th;
        ReportOfRooms C1;
        public RoomsReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            C1 = new ReportOfRooms();
            foreach (ParameterDiscreteValue v in C1.ParameterFields[0].DefaultValues)
                room_type_comb.Items.Add(v.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           C1.SetParameterValue(0,room_type_comb.Text);
            crystalReportViewer1.ReportSource = C1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void room_type_comb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butt_Back_Click(object sender, EventArgs e)
        {
            th = new Thread(openMenu);
            //th.SetApartmentState(ApartmentState.STA);
            this.Close();
            th.Start();
           
        }
        
        private void openMenu()
        {
            Application.Run(new Menu());
        }
    }
}

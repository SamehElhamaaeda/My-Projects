using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client; // link between database SQL and C#
using Oracle.DataAccess.Types;
using System.Threading;
namespace WindowsFormsApp2
{
    public partial class Dis1 : Form
    {
        Thread th;

        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds= new DataSet();

        public Dis1()
        {
            InitializeComponent();
        }

        private void Dis1_Load(object sender, EventArgs e)
        {

        }

        private void radio_Reserved_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radio_Available_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void groupBox_showRooms_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Load_infomation_Click(object sender, EventArgs e)
        {
            string cmdstr = "";
            string Constr = "Data source=orcl;User Id=scott;Password = tiger; ";

            //         dataGridView1.Rows.Clear();
            //   dataGridView1.Refresh();
             ds = new DataSet();
            if (radio_Available.Checked)
            { cmdstr = "SELECT * from rooms1 where status=0"; }
            else if (radio_Reserved.Checked)
            { cmdstr = "SELECT * from rooms1 where status=1"; }
            adapter = new OracleDataAdapter(cmdstr, Constr);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

             builder = new OracleCommandBuilder(adapter);
                adapter.Update(ds.Tables[0]); //1st:see all chnges u made and convert it to update & delete
            //2nd: excute changes to affect a
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(openMenu);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
    }
}

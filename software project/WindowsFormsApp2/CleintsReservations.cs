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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace WindowsFormsApp2
{
    public partial class CleintsReservations : Form
    {
        Thread th;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public CleintsReservations()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String constr = "Data Source=orcl; User Id=scott;Password=tiger;";
            String cmdr = "Select * from Reservstion1 where ClientID = :id ";
            adapter = new OracleDataAdapter(cmdr, constr);
            adapter.SelectCommand.Parameters.Add("id", text_id.Text);

            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

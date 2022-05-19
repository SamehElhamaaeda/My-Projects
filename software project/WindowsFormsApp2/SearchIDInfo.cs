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
    public partial class SearchIDInfo : Form
    {
        Thread th;
        string ordb = "Data source=orcl;User Id=scott;Password = tiger;";
        OracleConnection conn;
        public SearchIDInfo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Inquire_Click(object sender, EventArgs e)
        {

        }

        private void SearchIDInfo_Load(object sender, EventArgs e)
        {
          //  conn = new OracleConnection(ordb);
         //   conn.Open();
            conn = new OracleConnection(ordb);
            conn.Open();
            rich_InfoID.AppendText("Client Information ... ... .. \n");
            rich_FilterByPrice.AppendText("Filtering Rooms  ... ..");
            //############################################################################

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "CHEAPESTROOM";
            cmd.CommandType = CommandType.StoredProcedure; // ازاى اخد رقم واحطه ف تيكست ويفضل رقم
            //what output i want to show is IDs of copy i want 
            cmd.Parameters.Add("out", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            try
            {
                lbl_cheapestRoom.Text = cmd.Parameters["out"].Value.ToString();

               // txt_cheapestRoom.Text = cmd.Parameters["out"].Value.ToString();
            }
            finally { }
            //############################################################################
            

            txt_FoundID.Tag = "Your ID ";
            txt_FoundID.Text = (string)txt_FoundID.Tag;
            
            
            /*
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            //select ClientID  from ClientAccount1
            cmd.CommandText = "select ClientID  from ClientAccount1";
            cmd.CommandType = CommandType.Text;
            rich_InfoID.AppendText("BOOOOOOM");

            OracleDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    lbl_Info1.Text = dr[0].ToString();
                    //         rich_InfoID.AppendText(dr[0].ToString());
                    //       rich_InfoID.AppendText(dr[1].ToString());

                }
            }
            finally
            {
                dr.Close();
            }
*/
        }

        private void btn_Inquire_Click_1(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Rooms1  where ClientID=:id ";

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id",txt_Inquire.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            try
            {
                rich_InfoID.Clear();

                while (dr.Read())
                {
                 //   lbl_Info1.Text = dr[0].ToString();
                    rich_InfoID.AppendText(dr[0].ToString() + "  ");
                    rich_InfoID.AppendText(dr[1].ToString() + "  ");
                    rich_InfoID.AppendText(dr[2].ToString() + "  ");
                    rich_InfoID.AppendText(dr[3].ToString() + "  ");
                    rich_InfoID.AppendText(dr[4].ToString() + " ");
                    rich_InfoID.AppendText(dr[5].ToString() + "\n");

                }
            }
            finally
            {
                dr.Close();
            }

            //   rich_InfoID.AppendText("------------------------------------------------------------------------\n");

        }

        private void btn_filter_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            if (radio_more.Checked) { cmd.CommandText = "PRICEFILTER"; }
            else if (radio_less.Checked) { cmd.CommandText = "PRICEFILTER2"; }
           
            cmd.CommandType = CommandType.StoredProcedure; // ازاى اخد رقم واحطه ف تيكست ويفضل رقم
            cmd.Parameters.Add("price", txt_filter.Text); // what will we put in textbox
            //what output i want to show is IDs of copy i want 
            cmd.Parameters.Add("id", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader dr = cmd.ExecuteReader();
            try
            {
                rich_FilterByPrice.Clear();
                while (dr.Read())
                {

                    rich_FilterByPrice.AppendText(dr[0].ToString() + ",  ");
                    rich_FilterByPrice.AppendText(dr[1].ToString() + ",  ");
                    rich_FilterByPrice.AppendText(dr[2].ToString() + ",  ");
                    rich_FilterByPrice.AppendText(dr[3].ToString() + ",  ");
                    rich_FilterByPrice.AppendText(dr[4].ToString() + "  ");
                    rich_FilterByPrice.AppendText(dr[5].ToString() + "  \n");
                }

            }
            catch (Exception e2)
            { MessageBox.Show("Data is Missing"); }
            finally { dr.Close(); }
            
            
        }

        private void btn_cheapest_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ClientID  from ClientAccount1  where FirstName   =:F and LastName =:L ";

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("F", txt_FName.Text);
            cmd.Parameters.Add("L", txt_LName.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                try { txt_FoundID.Text = dr[0].ToString(); } finally { }
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
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

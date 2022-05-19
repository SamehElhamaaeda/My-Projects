using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace WindowsFormsApp2
{
    public partial class Register : Form
    {
        OracleConnection conn;
        String constr = "Data Source=orcl; User Id=scott;Password=tiger;";
        DateTime time;
        int cleint_id;
        OracleCommand cmd;
        public Register()
        {
            InitializeComponent();
           /* time = DateTime.Now;
            string f_com = "Select count(*) from ClientAccount1";
            conn = new OracleConnection(constr);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = f_com;
            cmd.CommandType = CommandType.Text;
            int rd = cmd.ExecuteNonQuery();
            cleint_id = Convert.ToInt32(rd.ToString());*/
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string dash = "10";
            string cmdr = "insert into ClientAccount1 values (:id,:Fn,:Ln,:city,:phone,:email,:pass,:reserved_room_number,'time')";
            conn = new OracleConnection(constr);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = cmdr;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("id", Convert.ToInt64(dash));
            cmd.Parameters.Add("Fn", text_first_name.Text);
            cmd.Parameters.Add("Ln", text_last_name.Text);
            cmd.Parameters.Add("city", text_city.Text);
            cmd.Parameters.Add("phone", text_phone.Text);
            cmd.Parameters.Add("email", text_email.Text);
            cmd.Parameters.Add("pass", text_password.Text);
            cmd.Parameters.Add("reserved_room_number", Convert.ToInt64(dash));

        }

        private void button1_Click(object sender, EventArgs e)
        {
                cmd.ExecuteNonQuery();
            
                MessageBox.Show("Account created successfully");
                text_first_name.Text = "";
                text_last_name.Text = "";
                text_city.Text = "";
                text_phone.Text = "";
                text_email.Text = "";
                text_password.Text = "";


         
        }
    }
}

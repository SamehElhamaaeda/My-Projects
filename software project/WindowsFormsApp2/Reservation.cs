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
    public partial class Reservation : Form
    {
        Thread th;

        string ordb = "Data source=orcl;User Id=scott;Password = tiger;";
        OracleConnection conn;
        public Reservation()
        {
            InitializeComponent();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            lbl_today.Text = DateTime.Now.ToString();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT MAX(ReservationID ) FROM reservstion1";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    lbl_resrvationID.Text = dr[0].ToString();
                    //comboBox1.Items.Add(dr[4]);
                }
            }
            finally
            {
                dr.Close();
            }


            //           lbl_resrvationID.Text=
            //           double s = Convert.ToInt32(txt_HowManyDays);
            //           txt_End_Date.Text = DateTime.Now.AddDays(s).ToString();

            /*
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Actors";
            cmd.CommandType = CommandType.Text;
            // then excute
            //note oracle data set is what in already in C# application
            // note oracle data reader is the container u use to 
            // to store the result which u get from sql statemt
            // fetch only 1 row act in time so if want to get multiple row as result u must use FOR LOOP

            OracleDataReader dr = cmd.ExecuteReader();  // dr is the container store the result form excuting sql stamet

            try
            {
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0]);
                    comboBox1.Items.Add(dr[1]);
                    comboBox1.Items.Add(dr[2]);
                    Console.WriteLine("--------------");
                    //comboBox1.Items.Add(dr[4]);
                }
            }
            finally
            {
                dr.Close();
            }
            */
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_resrvationID_Click(object sender, EventArgs e)
        {

        }

        private void txt_reservationID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void openMenu()
        {
            Application.Run(new Menu());
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            th = new Thread(openMenu);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void btn_Submit_Click_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO Reservstion1 (ReservationID,RoomPrice,Start_Date   ,HowManyDays ,End_Date   ,    Created_Invoice   ,Discount_percentage ,ClientID,RoomID) 
                                           VALUES(    :r_id        ,:r_RoomPrice     ,:r_Start_Date   ,     :r_HowManyDays ,:r_End_Date ,CURRENT_TIMESTAMP ,           0     ,:r_ClientID   , :r_RoomID )";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("r_id  ", txt_reservationID.Text.ToString());//
            cmd.Parameters.Add("r_RoomPrice  ", txt_Room_price.Text);
            cmd.Parameters.Add("r_Start_Date", txt_StartDate.Text);
            cmd.Parameters.Add("r_HowManyDays", txt_HowManyDays2.Text);
            cmd.Parameters.Add("r_End_Date", txt_End_Date.Text);
            cmd.Parameters.Add("r_ClientID  ", txt_ClientID2.Text.ToString());//
            cmd.Parameters.Add("r_RoomID ", txt_RoomID2.Text);
            int r = cmd.ExecuteNonQuery();
            if (r != -1) // -1 if no row is affected
            {
                MessageBox.Show(" Success Submit !!");
            }
        }
    }
}

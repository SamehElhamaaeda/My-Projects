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
    public partial class Menu : Form
    {
        Thread th;
        string ordb = "Data source=orcl;User Id=scott;Password = tiger;";
        OracleConnection conn;
        public Menu()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hope U Find Your Self , Your Existence Matter , Do Your Best ,Dont Waste More Time, Value Yourself.  (っ◔◡◔)っ ❤", "Message From Creator");
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            //pictureBox1.Image = Image.FromFile(@"C:\Users\dell\Downloads\عادل امام مختلف\balooza150px\1.jpeg");


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //pictureBox1.Image = Image.FromFile(@"C:\Users\dell\Downloads\عادل امام مختلف\balooza150px\1.jpeg");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                //pictureBox1.Image = Image.FromFile(@"C:\Users\dell\Downloads\عادل امام مختلف\balooza150px\2.jpeg");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                //pictureBox1.Image = Image.FromFile(@"C:\Users\dell\Downloads\عادل امام مختلف\balooza150px\3.jpeg");
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                // pictureBox1.Image = Image.FromFile(@"C:\Users\dell\Downloads\عادل امام مختلف\balooza150px\4.jpeg");
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                //pictureBox1.Image = Image.FromFile(@"C:\Users\dell\Downloads\عادل امام مختلف\balooza150px\5.jpeg");
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                //pictureBox1.Image = Image.FromFile(@"C:\Users\dell\Downloads\عادل امام مختلف\balooza150px\6.jpeg");
            }
        }

        private void btn_reserv_Click(object sender, EventArgs e)
        {
            //          this.Hide();
            //        Reservation f3 = new Reservation();
            //      f3.Show();

            th = new Thread(openReservation);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void btn_inquire_Click(object sender, EventArgs e)
        {
            //           this.Hide();
            //         SearchIDInfo f2 = new SearchIDInfo();
            //       f2.Show();

            th = new Thread(openSearchIDInfo);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //          this.Hide();
            //        Dis1 f1 = new Dis1();
            //      f1.Show();

            th = new Thread(openDis1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();


        }
        private void generete_Report__Cleints_Click(object sender, EventArgs e)
        {
            th = new Thread(openReportOfcleint);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();


        }
        private void Generate_Report_Of_rooms_Click(object sender, EventArgs e)
        {
            th = new Thread(openReportOfrooms);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();

            //CleintsReservations
        }
        private void Specific_cleint_reservations_Click(object sender, EventArgs e)
        {
            th = new Thread(openCleintReservation);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
        private void openCleintReservation()
        {
            Application.Run(new CleintsReservations());
        }
        private void openReportOfrooms()
        {
            Application.Run(new RoomsReport());
        }
        private void openReportOfcleint()
        {
            Application.Run(new DisplayCleints());
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openDis1()
        {
            Application.Run(new Dis1());
        }
        private void openSearchIDInfo()
        {
            Application.Run(new SearchIDInfo());
        }
        private void openReservation()
        {
            Application.Run(new Reservation());
        }


    }
}

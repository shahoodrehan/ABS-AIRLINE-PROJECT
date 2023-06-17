using Bunifu.UI.WinForms.BunifuTextbox;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;

namespace DBMSProject
{
    public partial class Flights : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=IRFAN\RAZRIZ;Initial Catalog=AMS;Persist Security Info=True;User ID=admin;Password=Zxc121216");
        public static string user_id, seat, otp_code, acc_no;
        bool verify = false, availbale = true;

        public Flights()
        {

            InitializeComponent();

            guna2Panel8.Hide();
            panel4.Hide();


        }

        System.Timers.Timer t;
        int h, s, m;
        public void time()
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            t.Start();

        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            ConfirmPayment c = new ConfirmPayment();
            Invoke(new Action(() =>
            {
                s++;
                if (s == 60)
                {

                    t.Stop();
                    c.btn_resend.ForeColor = Color.Black;
                    c.btn_resend.Enabled = true;
                    c.btn_verify.Enabled = false;

                }
                c.lbl_time.Text = m.ToString().PadLeft(2, '0') + ":" + s.ToString().PadLeft(2, '0');

            }));
            t.AutoReset = true;

        }

        public string otp()
        {
            int len = 4;
            const string ValidChar = "1234567890";
            StringBuilder result = new StringBuilder();
            Random rand = new Random();
            while (0 < len--)
            {
                result.Append(ValidChar[rand.Next(ValidChar.Length)]);

            }
            return result.ToString();
        }
        public string pnr_generator()
        {
            int len = 3;
            const string ValidChar = "1234567890";
            StringBuilder result = new StringBuilder();
            Random rand = new Random();
            while (0 < len--)
            {
                result.Append(ValidChar[rand.Next(ValidChar.Length)]);

            }
            return result.ToString();
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void Flights_Load(object sender, EventArgs e)
        {



        }

        private bool LoadButtonAvailability(string seat_no)
        {
            con.Open();
            if (user.air_id == 1)
            {
                string query = "Select * from ticket where flight_nump='" + user.flight_num + "'and seat_no='" + seat_no + "'";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("seat is already booked");
                    availbale = false;
                }

                reader.Close();
            }
            else if (user.air_id == 2)
            {
                string query = "Select * from ticket where flight_numf='" + user.flight_num + "'and seat_no='" + seat_no + "'";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("seat is already booked");
                    availbale = false;
                }
                reader.Close();

            }
            con.Close();
            return availbale;
        }
        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel24_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void roundedButton4_Click_1(object sender, EventArgs e)
        {

        }

        private void lbl_totfare_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton4_Click_2(object sender, EventArgs e)
        {


        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            if (user.Isroundtrip == true)
            {
                tabControl1.SelectedIndex = 1;
                guna2Panel8.Show();
                lbl_totfare.Text = "PKR " + user.grandtot;

            }
            else
            {
                tabControl1.SelectedIndex = 2;
                guna2Panel8.Hide();
                if (Login.login_status == false)
                {
                    Login login = new Login();
                    login.ShowDialog();
                }
                if (Login.login_status == true)
                {
                    con.Open();
                    string query = "select * from users where username='" + Login.admin + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txt_fname_p.Text = Convert.ToString(reader["f_name"]);
                        lbl_lname_p.Text = Convert.ToString(reader["l_name"]);
                        txt_dob_p.Text = Convert.ToString(reader["dob"]);
                        txt_nationality_p.Text = Convert.ToString(reader["nationality"]);
                        txt_passportno_p.Text = Convert.ToString(reader["passport_no"]);
                        txt_exp_p.Text = Convert.ToString(reader["pass_exp"]);
                        txt_pno_p.Text = Convert.ToString(reader["phone_num"]);
                        txt_email_p.Text = Convert.ToString(reader["email"]);
                    }
                    reader.Close();
                    con.Close();
                }
            }
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "select * from users   where f_name='" + txt_fname_p.Text + "' and l_name='" + lbl_lname_p.Text + "'and dob='" + txt_dob_p.Text + "'and nationality='" + txt_nationality_p.Text + "'and passport_no='" + txt_passportno_p.Text + "'and pass_exp='" + txt_exp_p.Text + "'and phone_num='" + txt_pno_p.Text + "'and email='" + txt_email_p.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lbl_dob_t.Text = txt_dob_p.Text;
                user_id = Convert.ToString(reader["user_id"]);
                tabControl1.SelectedIndex = 3;

            }

            con.Close();
            reader.Close();

        }
        private void CheckButtonAndSetColor(string buttonText)
        {
            // Iterate through all the buttons on the form
            foreach (var control in Controls)
            {
                if (control is DBMSProject.RoundedButton button)
                {
                    // Check if the button text matches the text in the database
                    if (button.Text.Equals(buttonText))
                    {
                        // Change the button color to red
                        button.BackColor = Color.Red;
                        button.Normalcolor = Color.Red;
                        break; // Exit the loop since the button is already found
                    }
                }
            }
        }
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            //con.Open();
            //string query = "Select * from ticket where seat_no='" + bunifuTextBox1.Text + "'";
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    MessageBox.Show("This seat is already booked");
            //}
            //else
            //{

        
        
            tabControl1.SelectedIndex = 4;
            lbl_fname_t.Text = txt_fname_p.Text;
            lbl_lname_t.Text = lbl_lname_p.Text;
            lbl_dob_t.Text = txt_dob_p.Text;
            lbl_nationality_t.Text = txt_nationality_p.Text;
            lbl_ppt_t.Text = txt_passportno_p.Text;
            lbl_exp_t.Text = txt_exp_p.Text
            lbl_seat_t.Text = seat;

        
        }

    private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedButton2_Click_2(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void guna2Panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roundedPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void current3_Click(object sender, EventArgs e)
        {

        }

        private void current2_Click(object sender, EventArgs e)
        {

        }

        private void current4_Click(object sender, EventArgs e)
        {

        }

        private void current5_Click(object sender, EventArgs e)
        {

        }

        private void current6_Click(object sender, EventArgs e)
        {

        }

        private void current1_Click(object sender, EventArgs e)
        {

        }

        private void current_Click(object sender, EventArgs e)
        {

        }

        private void showflight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void currentr4_Click(object sender, EventArgs e)
        {

        }

        private void currentr3_Click(object sender, EventArgs e)
        {

        }

        private void currentr6_Click(object sender, EventArgs e)
        {

        }

        private void currentr7_Click(object sender, EventArgs e)
        {

        }

        private void currentr8_Click(object sender, EventArgs e)
        {

        }

        private void currentr2_Click(object sender, EventArgs e)
        {

        }

        private void currentr1_Click(object sender, EventArgs e)
        {

        }

        private void showflights1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void txt_email_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_pno_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_exp_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void txt_passportno_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator2_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_nationality_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void txt_dob_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_lname_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txt_fname_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel20_Click(object sender, EventArgs e)
        {

        }

        private void txt_disc_Click(object sender, EventArgs e)
        {

        }

        private void lbl_seat_t_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel18_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void seat_tr_Click(object sender, EventArgs e)
        {

        }

        private void lbl_seat_tr_Click(object sender, EventArgs e)
        {

        }

        private void lbl_dest_tr_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel40_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel43_Click(object sender, EventArgs e)
        {

        }

        private void lbl_src_tr_Click(object sender, EventArgs e)
        {

        }

        private void lbl_arr_tr_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel46_Click(object sender, EventArgs e)
        {

        }

        private void lbl_dep_tr_Click(object sender, EventArgs e)
        {

        }

        private void lbl_fdate_tr_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel49_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel50_Click(object sender, EventArgs e)
        {

        }

        private void txt_dest_t_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel32_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel33_Click(object sender, EventArgs e)
        {

        }

        private void txt_src_t_Click(object sender, EventArgs e)
        {

        }

        private void lbl_arr_t_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel36_Click(object sender, EventArgs e)
        {

        }

        private void lbl_deptime_t_Click(object sender, EventArgs e)
        {

        }

        private void lbl_fldate_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel41_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel42_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator5_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel29_Click(object sender, EventArgs e)
        {

        }

        private void lbl_grandtot_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel23_Click(object sender, EventArgs e)
        {

        }

        private void lbl_tax_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

        }

        private void lbl_tot_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator4_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel27_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Air_name_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel25_Click(object sender, EventArgs e)
        {

        }

        private void lbl_fno_Click(object sender, EventArgs e)
        {

        }

        private void lbl_exp_t_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel21_Click(object sender, EventArgs e)
        {

        }

        private void lbl_ppt_t_Click(object sender, EventArgs e)
        {

        }

        private void lbl_nationality_t_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel13_Click(object sender, EventArgs e)
        {

        }

        private void lbl_dob_t_Click(object sender, EventArgs e)
        {

        }

        private void lbl_lname_t_Click(object sender, EventArgs e)
        {

        }

        private void lbl_fname_t_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel15_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel16_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txt_cvv_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel24_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_exp_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel12_Click(object sender, EventArgs e)
        {

        }

        private void txt_cardname_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel17_Click(object sender, EventArgs e)
        {

        }

        private void txt_Cardno_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel19_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lbl_dest_Click(object sender, EventArgs e)
        {

        }

        private void lbl_src_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lbl_dest_r_Click(object sender, EventArgs e)
        {

        }

        private void lbl_src_r_Click(object sender, EventArgs e)
        {

        }

        private void lbl_totfare_Click_1(object sender, EventArgs e)
        {

        }

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void roundedPanel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton14_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_1e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_1e.Text) == true)
            {

                seat = btn_1e.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton10_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_1d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_1d.Text) == true)
            {

                seat = btn_1d.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton9_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_1c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_1c.Text) == true)
            {

                seat = btn_1c.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton8_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_1b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_1b.Text) == true)
            {

                seat = btn_1b.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton7_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_1a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_1a.Text) == true)
            {

                seat = btn_1a.Text;
                MessageBox.Show(seat + " is confirmed");

            }

        }

        private void roundedButton11_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_1f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_1f.Text) == true)
            {

                seat = btn_1f.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton12_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_2f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_2f.Text) == true)
            {

                seat = btn_2f.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton13_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton15_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_2e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_2e.Text) == true)
            {

                seat = btn_2e.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton16_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_2c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_2c.Text) == true)
            {

                seat = btn_2c.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton17_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_2b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_2b.Text) == true)
            {

                seat = btn_2b.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton18_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_2a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_2a.Text) == true)
            {

                seat = btn_2a.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton19_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_3f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_3f.Text) == true)
            {

                seat = btn_3f.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton20_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_3e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_3e.Text) == true)
            {

                seat = btn_3e.Text;
                MessageBox.Show(seat + " is confirmed");


            }
        }

        private void roundedButton21_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_3d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_3d.Text) == true)
            {

                seat = btn_3d.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton22_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_3c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_3c.Text) == true)
            {

                seat = btn_3c.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton23_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_3b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_3b.Text) == true)
            {

                seat = btn_3b.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton24_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_3a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_3a.Text) == true)
            {

                seat = btn_3a.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton25_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_4f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_4f.Text) == true)
            {

                seat = btn_4f.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton26_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_4e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_4e.Text) == true)
            {

                seat = btn_4e.Text;
                MessageBox.Show(seat + " is confirmed");

            }

        }

        private void roundedButton27_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_4d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_4d.Text) == true)
            {

                seat = btn_4d.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton28_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_4c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_4c.Text) == true)
            {

                seat = btn_4c.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton29_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_4b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_4b.Text) == true)
            {

                seat = btn_4b.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton30_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_4a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_4a.Text) == true)
            {

                seat = btn_4a.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton31_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_5f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_5f.Text) == true)
            {

                seat = btn_5f.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton32_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_5e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_5e.Text) == true)
            {

                seat = btn_5e.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton33_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_5d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_5d.Text) == true)
            {

                seat = btn_5d.Text;
                MessageBox.Show(seat + " is confirmed");

            }
        }

        private void roundedButton34_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_5c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_5c.Text) == true)
            {

                seat = btn_5c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton35_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_5b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_5b.Text) == true)
            {

                seat = btn_5b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton36_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_5a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_5a.Text) == true)
            {

                seat = btn_5a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton37_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_6f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_6f.Text) == true)
            {

                seat = btn_6f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton38_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_6e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_6e.Text) == true)
            {

                seat = btn_6e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton39_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_6d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_6d.Text) == true)
            {

                seat = btn_6d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton40_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_6c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_6c.Text) == true)
            {

                seat = btn_6c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton41_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_6b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_6b.Text) == true)
            {

                seat = btn_6b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton42_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_6a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_6a.Text) == true)
            {

                seat = btn_6a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton43_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_7f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_7f.Text) == true)
            {

                seat = btn_7f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton44_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_7e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_7e.Text) == true)
            {

                seat = btn_7e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton45_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_7d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_7d.Text) == true)
            {

                seat = btn_7d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton46_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_7c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_7c.Text) == true)
            {

                seat = btn_7c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton47_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_7b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_7b.Text) == true)
            {

                seat = btn_7b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton48_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_7a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_7a.Text) == true)
            {

                seat = btn_7a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton49_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_8f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_8f.Text) == true)
            {

                seat = btn_8f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton50_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_8e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_8e.Text) == true)
            {

                seat = btn_8e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton51_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_8d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_8d.Text) == true)
            {

                seat = btn_8d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton52_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_8c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_8c.Text) == true)
            {

                seat = btn_8c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton53_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_8b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_8b.Text) == true)
            {

                seat = btn_8b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton54_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_8a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_8a.Text) == true)
            {

                seat = btn_8a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton55_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_9f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_9f.Text) == true)
            {

                seat = btn_9f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton56_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_9e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_9e.Text) == true)
            {

                seat = btn_9e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton57_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_9d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_9d.Text) == true)
            {

                seat = btn_9d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton58_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_9c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_9c.Text) == true)
            {

                seat = btn_9c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton59_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_9b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_9b.Text) == true)
            {

                seat = btn_9b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton60_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_9a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_9a.Text) == true)
            {

                seat = btn_9a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton61_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_10f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_10f.Text) == true)
            {

                seat = btn_10f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton62_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_10e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_10e.Text) == true)
            {

                seat = btn_10e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton63_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_10d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_10d.Text) == true)
            {

                seat = btn_10d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton64_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_10c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_10c.Text) == true)
            {

                seat = btn_10c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton65_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_10b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_10b.Text) == true)
            {

                seat = btn_10b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton66_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_10a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_10a.Text) == true)
            {

                seat = btn_10a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton67_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_11f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_11f.Text) == true)
            {

                seat = btn_11f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton68_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_11e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_11e.Text) == true)
            {

                seat = btn_11e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton69_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_11d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_11d.Text) == true)
            {

                seat = btn_11d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton70_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_11c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_11c.Text) == true)
            {

                seat = btn_11c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton71_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_11b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_11b.Text) == true)
            {

                seat = btn_11b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton72_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_11a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_11a.Text) == true)
            {

                seat = btn_11a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton73_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_12f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_12f.Text) == true)
            {

                seat = btn_12f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton74_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_12e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_12e.Text) == true)
            {

                seat = btn_12e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton75_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_12d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_12d.Text) == true)
            {

                seat = btn_12d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton76_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_12c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_12c.Text) == true)
            {

                seat = btn_12c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton77_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_12b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_12b.Text) == true)
            {

                seat = btn_12b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton78_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_12a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_12a.Text) == true)
            {

                seat = btn_12a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton79_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_13f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_13f.Text) == true)
            {

                seat = btn_13f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton80_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_13e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_13e.Text) == true)
            {

                seat = btn_13e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton81_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_13d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_13d.Text) == true)
            {

                seat = btn_13d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton82_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_13c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_13c.Text) == true)
            {

                seat = btn_13c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton83_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_13b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_13b.Text) == true)
            {

                seat = btn_13b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton84_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_13a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_13a.Text) == true)
            {

                seat = btn_13a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton85_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_14f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_14f.Text) == true)
            {

                seat = btn_14f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton86_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_14e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_14e.Text) == true)
            {

                seat = btn_14e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton87_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_14d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_14d.Text) == true)
            {

                seat = btn_14d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton88_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_14c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_14c.Text) == true)
            {

                seat = btn_14c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton89_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_14b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_14b.Text) == true)
            {

                seat = btn_14b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton90_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_14a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_14a.Text) == true)
            {

                seat = btn_14a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton91_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_15f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_15f.Text) == true)
            {

                seat = btn_15f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton92_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_15e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_15e.Text) == true)
            {

                seat = btn_15e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton93_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_15d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_15d.Text) == true)
            {

                seat = btn_15d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton94_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_15c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_15c.Text) == true)
            {

                seat = btn_15c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton95_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_15b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_15b.Text) == true)
            {

                seat = btn_15b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton96_Click(object sender, EventArgs e)
        {
            if (LoadButtonAvailability(btn_15a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_15a.Text) == true)
            {

                seat = btn_15a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton97_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_16f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_16f.Text) == true)
            {
                seat = btn_16f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton98_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_16e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_16e.Text) == true)
            {
                seat = btn_16e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton99_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_16d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_16d.Text) == true)
            {
                seat = btn_16d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton100_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_16c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_16c.Text) == true)
            {
                seat = btn_16c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton101_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_16b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_16b.Text) == true)
            {
                seat = btn_16b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton102_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_16a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_16a.Text) == true)
            {
                seat = btn_16a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton103_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_17f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_17f.Text) == true)
            {
                seat = btn_17f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton104_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_17e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_17e.Text) == true)
            {
                seat = btn_17e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton105_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_17d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_17d.Text) == true)
            {
                seat = btn_17d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton106_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_17c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_17c.Text) == true)
            {
                seat = btn_17c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton107_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_17b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_17b.Text) == true)
            {
                seat = btn_17b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton108_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_17a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_17a.Text) == true)
            {
                seat = btn_17a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton109_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_18f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_18f.Text) == true)
            {
                seat = btn_18f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton110_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_18e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_18e.Text) == true)
            {
                seat = btn_18e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton111_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_18d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_18d.Text) == true)
            {
                seat = btn_18d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton112_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_18c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_18c.Text) == true)
            {
                seat = btn_18c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton113_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_18b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_18b.Text) == true)
            {
                seat = btn_18b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton114_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_18a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_18a.Text) == true)
            {
                seat = btn_18a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton115_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_19f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_19f.Text) == true)
            {
                seat = btn_19f.Text;
                MessageBox.Show(seat + " is confirmed");
            }

        }

        private void roundedButton116_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_19e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_19e.Text) == true)
            {
                seat = btn_19e.Text;
                MessageBox.Show(seat + " is confirmed");
            }

        }

        private void roundedButton117_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_19d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_19d.Text) == true)
            {
                seat = btn_19d.Text;
                MessageBox.Show(seat + " is confirmed");
            }

        }

        private void roundedButton118_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_19c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_19c.Text) == true)
            {
                seat = btn_19c.Text;
                MessageBox.Show(seat + " is confirmed");
            }

        }

        private void roundedButton119_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_19b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_19b.Text) == true)
            {
                seat = btn_19b.Text;
                MessageBox.Show(seat + " is confirmed");
            }

        }

        private void roundedButton120_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_19a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_19a.Text) == true)
            {
                seat = btn_19a.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton121_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_20f.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_20f.Text) == true)
            {
                seat = btn_20f.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton122_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_20e.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_20e.Text) == true)
            {
                seat = btn_20e.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton123_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_20d.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_20d.Text) == true)
            {
                seat = btn_20d.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton124_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_20c.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_20c.Text) == true)
            {
                seat = btn_20c.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton125_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_20b.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_20b.Text) == true)
            {
                seat = btn_20b.Text;
                MessageBox.Show(seat + " is confirmed");
            }
        }

        private void roundedButton126_Click(object sender, EventArgs e)
        {

            if (LoadButtonAvailability(btn_20a.Text) == false)
            {
                MessageBox.Show("seat is already booked!!");
            }
            else if (LoadButtonAvailability(btn_20a.Text) == true)
            {
                seat = btn_20a.Text;
                MessageBox.Show(seat + " is confirmed");
            }

        }

        private void roundedButton2_Click_1(object sender, EventArgs e)
        {


        }

        private void roundedButton6_Click(object sender, EventArgs e)
        {
            //directed to passenger info
            tabControl1.SelectedIndex = 2;
            panel4.Show();
            Login login = new Login();

            if (Login.login_status == false)
            {
                login.ShowDialog();
            }
            if (Login.login_status == true)
            {
                con.Open();
                string query = "select * from users where username='" + login.txtUsername.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user_id = Convert.ToString(reader["user_id"]);
                    txt_fname_p.Text = Convert.ToString(reader["f_name"]);
                    lbl_lname_p.Text = Convert.ToString(reader["l_name"]);
                    txt_dob_p.Text = Convert.ToString(reader["dob"]);
                    txt_nationality_p.Text = Convert.ToString(reader["nationality"]);
                    txt_passportno_p.Text = Convert.ToString(reader["passport_no"]);
                    txt_exp_p.Text = Convert.ToString(reader["pass_exp"]);
                    txt_pno_p.Text = Convert.ToString(reader["phone_num"]);
                    txt_email_p.Text = Convert.ToString(reader["email"]);
                }
                con.Close();
                reader.Close();
            }

        }

        private async void roundedButton5_Click(object sender, EventArgs e)
        {
            //code
            String PNR = "PK" + pnr_generator();

            user u = new user();
            con.Open();
            string query = "select * from account_details a inner join users u on a.user_id=u.user_id where a.card_no='" + Convert.ToInt64(txt_Cardno.Text) + "'and a.account_title='" + txt_cardname.Text + "' and a.cvv='" + Convert.ToInt32(txt_cvv.Text) + "' and '" + Convert.ToInt64(user.grandtot) + "'<=a.balance";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string emailaddress = Convert.ToString(reader["email"]);
                string pno = "+92" + Convert.ToString(reader["phone_num"]).Trim();
                acc_no = Convert.ToString(reader["account_id"]);
                Whatsapp w = new Whatsapp();
                Email em = new Email();
                otp_code = otp();
                Wait waa = new Wait();

                waa.Show();
                await Task.Run(() => em.sendemail(emailaddress, otp_code));
                await Task.Run(() => w.send(otp_code, pno));
                waa.Hide();
                waa.Close();


            }
            con.Close();
            reader.Close();

            ConfirmPayment cp = new ConfirmPayment();
            cp.ShowDialog();
            MessageBox.Show(ConfirmPayment.IsSuccess.ToString());
            if (ConfirmPayment.IsSuccess == true)
            {
                try
                {

                    con.Open();
                    if (user.air_id == 1)
                    {
                        try
                        {
                            string query2 = " EXEC create_ticket_p '" + PNR + "','" + lbl_fno.Text + "','" + user.class_id + "','" + user.src_id + "','" + user.dest_id + "','" + seat + "','" + user_id + "'";
                            string query3 = " EXEC create_transaction '" + user.grandtot + "','" + acc_no + "','" + PNR + "','" + user_id + "'";
                            cmd = new SqlCommand(query2, con);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand(query3, con);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("pia ticket add");
                        }

                    }
                    else if (user.air_id == 2)
                    {
                        try
                        {
                            string query1 = " EXEC create_ticket_f '" + PNR + "','" + lbl_fno.Text + "','" + user.class_id + "','" + user.src_id + "','" + user.dest_id + "','" + seat + "','" + user_id + "'";
                            string query3 = " EXEC create_transaction '" + user.grandtot + "','" + acc_no + "','" + PNR + "','" + user_id + "'";

                            cmd = new SqlCommand(query1, con);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand(query3, con);
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception)
                        {

                            MessageBox.Show("fj ticket add");
                        }

                    }
                    con.Close();
                    Ticketing t = new Ticketing();
                    t.lbl_pnr.Text = PNR.ToUpper();
                    t.lbl_name.Text = user.name;
                    t.lbl_pname.Text = user.name;
                    t.lbl_ticket.Text = PNR.ToUpper();
                    t.lbl_arr.Text = lbl_arr_t.Text;
                    t.lbl_dep.Text = lbl_deptime_t.Text;
                    t.lbl_fno.Text = lbl_fno.Text;
                    t.lbl_to.Text = txt_src_t.Text;
                    t.lbl_from.Text = txt_dest_t.Text;
                    t.lbl_class.Text = user.class_id.ToString();
                    t.lbl_current.Text = DateTime.Now.ToString();
                    t.lbl_note.Text = "We confirm the ticket issuance for your reservation " + PNR.ToUpper() + ". Please find details below";
                    t.ShowDialog();
                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee.Message);
                }



            }
            else
            {
                MessageBox.Show("payment failed!! insufficient Amount");
            }
            con.Close();
            reader.Close();
        }

        private void roundedButton3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from users u inner join passport_details p on p.user_id=u.user_id where u.f_name='" + txt_fname_p.Text + "' and u.l_name='" + lbl_lname_p.Text + "'and u.dob='" + txt_dob_p.Text + "'and p.nationality='" + txt_nationality_p.Text + "'and p.pass_no='" + txt_passportno_p.Text + "'and p.pass_exp='" + txt_exp_p.Text + "'and u.phone_num='" + txt_pno_p.Text + "'and u.email='" + txt_email_p.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lbl_dob_t.Text = txt_dob_p.Text;
                user_id = Convert.ToString(reader["user_id"]);
                tabControl1.SelectedIndex = 2;

            }
            con.Close();
            reader.Close();
        }




        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            //con.Open();
            //string query = "Select * from tickets where seat_num='" + bunifuTextBox1.Text + "'";
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    MessageBox.Show("This seat is already booked");
            //}
            //else
            //{
            //    MessageBox.Show("The seat has been confirmed");
            //}
            //con.Close();
            //reader.Close();
            //seat = bunifuTextBox1.Text;
            //tabControl1.SelectedIndex = 3;
            //lbl_fname_t.Text = txt_fname_p.Text;
            //lbl_lname_t.Text = lbl_lname_p.Text;
            //lbl_dob_t.Text = txt_dob_p.Text;
            //lbl_nationality_t.Text = txt_nationality_p.Text;
            //lbl_ppt_t.Text = txt_passportno_p.Text;
            //lbl_exp_t.Text = txt_exp_p.Text;

            //lbl_seat_t.Text = seat;
        }


    }
}

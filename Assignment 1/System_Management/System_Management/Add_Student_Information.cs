using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Management
{
    public partial class Add_Std_Inf : Form
    {
        public Add_Std_Inf()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-S39PV0K7;Initial Catalog=Student_Details_DB;Integrated Security=True;Pooling=False");
        void con_open()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }
        void Clear_Contrels()
        {
            tb_Roll_No.Clear();
            tb_Student_Name.Clear();
            dtp_DOB.ResetText();
            cmb_Course.SelectedIndex = -1;
        }
        
       

        private void button1_Click(object sender, EventArgs e)
        {
            Student_List obj = new Student_List();
            obj.Show();
            this.Hide();

        }

        private void lbl_Logout_Click(object sender, EventArgs e)
        {
            Login_Form obj = new Login_Form();
            obj.Show();
            this.Hide();

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear_Contrels();
        }

        

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if(tb_Student_Name.Text != "" && tb_Roll_No.Text!=""&&  tb_Mobile_No.Text!="" && cmb_Course.Text!="")
            {
                con_open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection= con;
                cmd.CommandText = "Insert Into student_details values (@NA,@RNO,@MNO,@DOB,@Course)";

                cmd.Parameters.Add("NA", SqlDbType.VarChar).Value = tb_Student_Name.Text;
                cmd.Parameters.Add("RNO", SqlDbType.Int).Value = tb_Roll_No.Text;
                cmd.Parameters.Add("MNO", SqlDbType.Decimal).Value = tb_Mobile_No.Text;
                cmd.Parameters.Add("DOB", SqlDbType.Date).Value = dtp_DOB .Text;
                cmd.Parameters.Add("Course", SqlDbType.NVarChar).Value = cmb_Course.Text;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Saved");

                Clear_Contrels();

                con.Close();

            }
            else
            { 
                MessageBox.Show("Fill All Fields Correctly");
            }

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select* from student_Deatils where Roll_No=@RNO";

            SqlDataReader Dr= cmd.ExecuteReader();
            if (Dr.Read())
            {
                tb_Student_Name.Text = Dr.GetString(Dr.GetOrdinal("Nmae"));
                tb_Mobile_No.Text = (Dr["M0b_No"].ToString());
                dtp_DOB.Text = (Dr["DOB"]).ToString();
                cmb_Course.Text = Dr.GetString(Dr.GetOrdinal("Course"));
            }
            else
            {
                MessageBox.Show("Invalid Roll NO");
                tb_Roll_No.Clear();
            }
                 con.Close();
        }
    }
    }


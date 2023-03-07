using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Management
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if ((tb_User_Name.Text == "Admin" && tb_Password.Text == "123") || (tb_User_Name.Text == "Manager" && tb_Password.Text == "123"))
            {
                MessageBox.Show("Login Successful", "Welcome");
                Add_Std_Inf obj = new Add_Std_Inf();
                obj.Show();
                this.Hide();
            }
            else
            {
                lbl_EVUAP.ForeColor=Color.Red;
                lbl_EVUAP.Text = "Login Failed ,Invalid Details";

            }


        }

        private void Only_Text(object sender, KeyPressEventArgs e)
        {
            if(!char .IsControl(e.KeyChar)&& !char.IsLetter(e.KeyChar)&&e.KeyChar != ' ') 
            { 
                e.Handled = true;
            
            }
        }

        private void Only_Numric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

        }

       

        private void Login_Form_Load(object sender, EventArgs e)
        {
            lbl_EVUAP.Text = "Invalid Username or password ";
        }

       
    }
}

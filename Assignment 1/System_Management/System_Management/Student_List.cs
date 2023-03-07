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
    public partial class Student_List : Form
    {
        public Student_List()
        {
            InitializeComponent();
        }

        private void lbl_Logout_Click(object sender, EventArgs e)
        {
            Login_Form obj= new Login_Form();
            obj.Show();
            this.Hide();

        }

        private void btn_Add_Std_Click(object sender, EventArgs e)
        {
            Add_Std_Inf obj=new Add_Std_Inf();
            obj.Show();
            this.Hide();

        }

        private void Student_List_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student_Details_DBDataSet.Student_Details' table. You can move, or remove it, as needed.
            this.student_DetailsTableAdapter.Fill(this.student_Details_DBDataSet.Student_Details);

        }
    }
}

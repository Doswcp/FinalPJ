using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
//6403611 วิชญ์ภาส นารถสกุล
namespace FinalPJ
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dos28\Desktop\C#_LAB\after_termbreak\FinalPJ\Database\Database1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPwe.Text == "" || txtConfirm.Text == "")
            {
                MessageBox.Show("Please fill your User or Password.");
            }
            else if (txtPwe.Text == txtConfirm.Text)
            {
                try
                {
                    con.Open();
                    string register = "INSERT INTO tbl_user (userID, [password]) VALUES ('" + txtUser.Text + "','" + txtPwe.Text + "')";
                    cmd = new OleDbCommand(register, con);
                    cmd.ExecuteNonQuery(); //ประมวลผลคำสั่งแล้วเพิ่มข้อมูลเข้าไปใน DB
                    MessageBox.Show("Register Success");

                    txtUser.Text = "";
                    txtPwe.Text = "";
                    txtConfirm.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally //ปิดการเชื่อมต่อกับฐานข้อมูลอย่างถูกต้อง โดยตรวจสอบสถานะของการเชื่อมต่อก่อน หากเปิดอยู่จะทำการปิด
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Password does not match, Please try again");
                txtPwe.Text = "";
                txtConfirm.Text = "";
                txtPwe.Focus();
            }
            this.Hide();
            new Form1().Show();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Enter Your UserID")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Enter Your UserID";
                txtUser.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtPwe_Enter(object sender, EventArgs e)
        {
            if (txtPwe.Text == "Enter Your UserID")
            {
                txtPwe.Text = "";
                txtPwe.ForeColor = Color.Black;
            }
        }

        private void txtPwe_Leave(object sender, EventArgs e)
        {
            if (txtPwe  .Text == "")
            {
                txtPwe.Text = "Enter Your UserID";
                txtPwe.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtConfirm_Enter(object sender, EventArgs e)
        {
            if (txtConfirm.Text == "Enter Your UserID")
            {
                txtConfirm.Text = "";
                txtConfirm.ForeColor = Color.Black;
            }
        }

        private void txtConfirm_Leave(object sender, EventArgs e)
        {
            if (txtConfirm.Text == "")
            {
                txtConfirm.Text = "Enter Your UserID";
                txtConfirm.ForeColor = Color.WhiteSmoke;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPwe.PasswordChar = '\0';
                txtConfirm.PasswordChar = '\0';
            }
            else
            {
                txtPwe.PasswordChar = '•';
                txtConfirm.PasswordChar = '•';
            }
        }
    }
}

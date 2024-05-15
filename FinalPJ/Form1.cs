using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
//6403611 วิชญ์ภาส นารถสกุล
namespace FinalPJ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dos28\Desktop\C#_LAB\after_termbreak\FinalPJ\Database\Database1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dos28\Desktop\C#_LAB\after_termbreak\FinalPJ\Database\Database1.mdb"))
                {
                    con.Open();
                    string login = "SELECT * FROM tbl_user WHERE userID = ? AND password = ?";
                    using (OleDbCommand cmd = new OleDbCommand(login, con))
                    {
                        cmd.Parameters.AddWithValue("?", txtUser.Text);
                        cmd.Parameters.AddWithValue("?", txtPwe.Text);
                        using (OleDbDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                new MainContent().Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password, Please Try Again");
                                txtUser.Text = "";
                                txtPwe.Text = "";
                                txtUser.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
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
            if (txtPwe.Text == "Enter Your Password")
            {
                txtPwe.Text = "";
                txtPwe.ForeColor = Color.Black;
            }
        }

        private void txtPwe_Leave(object sender, EventArgs e)
        {
            if (txtPwe.Text == "")
            {
                txtPwe.Text = "Enter Your Password";
                txtPwe.ForeColor = Color.WhiteSmoke;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPwe.PasswordChar = '\0';
            }
            else
            {
                txtPwe.PasswordChar = '*';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new FormRegister().Show();
            this.Hide();
        }
    }
}
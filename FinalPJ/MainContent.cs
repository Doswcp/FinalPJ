using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
//6403611 วิชญ์ภาส นารถสกุล
namespace FinalPJ
{
    public partial class MainContent : Form
    {
        OleDbConnection conn; 
        OleDbCommand cmd; 
        OleDbDataAdapter adapter; 
        DataTable dt; 

        public MainContent()
        {
            InitializeComponent();
        }

        private void MainContent_Load(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dos28\Desktop\C#_LAB\after_termbreak\FinalPJ\Database\Database1.mdb";
            conn = new OleDbConnection(connectionString);
            LoadData(); 
        }

        private void LoadData()
        {
            try
            {
                
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dos28\Desktop\C#_LAB\after_termbreak\FinalPJ\Database\Database1.mdb"))
                {
                    conn.Open(); 
                    string query = "SELECT * FROM tbl_book"; 
                    using (OleDbCommand cmd = new OleDbCommand(query, conn)) 

                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd); 
                        dt = new DataTable(); 
                        adapter.Fill(dt); 
                        dgvProduct.DataSource = dt; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message); 
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dos28\Desktop\C#_LAB\after_termbreak\FinalPJ\Database\Database1.mdb"))
                {
                    conn.Open();
                    //กำหนดคำสั่ง SQL ในการเพิ่มข้อมูลลงในตาราง tbl_book โดยระบุชื่อฟิลด์และตำแหน่งของพารามิเตอร์ใน VALUES ด้วยเครื่องหมาย ? สำหรับ parameterized query
                    string query = "INSERT INTO tbl_book (Title, GenreID, Price, [Language], Summary) VALUES (?, ?, ?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn)) //สร้าง OleDbCommand เพื่อรันคำสั่ง SQL ที่กำหนดไว้ในตัวแปร query
                    {
                        cmd.Parameters.AddWithValue("?", txtTitle.Text); 
                        cmd.Parameters.AddWithValue("?", txtGenreID.Text);
                        cmd.Parameters.AddWithValue("?", txtPrice.Text);
                        cmd.Parameters.AddWithValue("?", txtLang.Text);
                        cmd.Parameters.AddWithValue("?", txtSummary.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record inserted successfully");
                    }
                }
                LoadData(); // Reload data to refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dos28\Desktop\C#_LAB\after_termbreak\FinalPJ\Database\Database1.mdb"))
                {
                    conn.Open();
                    string query = "UPDATE tbl_book SET Title = ?, GenreID = ?, Price = ?, [Language] = ?, Summary = ? WHERE BookID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", txtTitle.Text);
                        cmd.Parameters.AddWithValue("?", txtGenreID.Text);
                        cmd.Parameters.AddWithValue("?", txtPrice.Text);
                        cmd.Parameters.AddWithValue("?", txtLang.Text);
                        cmd.Parameters.AddWithValue("?", txtSummary.Text);
                        cmd.Parameters.AddWithValue("?", txtID.Text); // BookID should be an identifier in your TextBox

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record updated successfully");
                    }
                }
                LoadData(); // Reload data to refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnDe_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "DELETE FROM tbl_book WHERE BookID = ?";
                cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("?", txtID.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record deleted successfully");

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // การเลือกข้อมูลใน DataGridView
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // กำหนดข้อมูลใน TextBox ต่างๆ จากข้อมูลที่ถูกเลือกใน DataGridView
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                txtID.Text = row.Cells["BookID"].Value.ToString();
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtGenreID.Text = row.Cells["GenreID"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtLang.Text = row.Cells["Language"].Value.ToString();
                txtSummary.Text = row.Cells["Summary"].Value.ToString();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
  
        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGenreID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSummary_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

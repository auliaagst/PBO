using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PBO_FINAL
{
    public partial class Form_Login : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-3J37RM8B\ERLINNN;Initial Catalog=dbo.Login;Integrated Security=True");
        public Form_Login()
        {
            InitializeComponent();
        }

        private void Username_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Login where Username='" + txtuser.Text + "' and Password='" + txtpass.Text + "'", koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbItemValue = comboBox1.SelectedItem.ToString();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Profesi"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("Anda Masuk Sebagai" + dt.Rows[i][2]);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            Admin f = new Admin();
                            f.Show();
                            this.Hide();
                        }
                        else if (comboBox1.SelectedIndex == 1)
                        {
                            Mahasiswa1 ff = new Mahasiswa1();
                            ff.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("error");
            }
            koneksi.Close();
            

        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

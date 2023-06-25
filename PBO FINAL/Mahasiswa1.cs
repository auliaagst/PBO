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
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace PBO_FINAL
{
    public partial class Mahasiswa1 : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=LAPTOP-3J37RM8B\ERLINNN;Initial Catalog=Tugas Akhir PBO;Integrated Security=True");
        public Mahasiswa1()
        {
            InitializeComponent();
        }
        string Jenis_Kelamin;
        string imgLocation = "";
        SqlCommand cmd;

        private void NIM_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Mahasiswa] (NIM, Nama, Fakultas, Prodi, Tempat_lahir, Tanggal_lahir, Jenis_kelamin, Alamat, Foto) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + Jenis_Kelamin + "','" + textBox5.Text + "',@images) ";
            cmd.Parameters.Add(new SqlParameter(@"images", images));
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.ImageLocation = null;
            MessageBox.Show("Data Insert Successfully");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Jenis_Kelamin = "Pria";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Jenis_Kelamin = "Wanita";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mahasiswa1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Mahasiswa] set NIM='" + this.textBox1.Text + "',  Nama='" + this.textBox2.Text + "',  Fakultas='" + this.textBox3.Text + "',  Prodi='" + this.textBox6.Text + "',  Tempat_lahir='" + this.textBox4.Text + "',  Tanggal_lahir='" + dateTimePicker1.Text + "', Jenis_kelamin='" + Jenis_Kelamin + "', Alamat ='" + this.textBox5.Text + "',Foto=@images where NIM='" + this.textBox1.Text + "'";
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.ImageLocation = null;
            MessageBox.Show("Data Updated Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

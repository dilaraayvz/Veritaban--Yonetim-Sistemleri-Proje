using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyonu
{
    public partial class FormFilm : Form
    {
        private string username;
        public FormFilm(string username)
        {
            this.username = username;
            InitializeComponent();
        }
        public FormFilm()
        {
            InitializeComponent();
        }
        NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SinemaOtomasyonu; user ID=postgres; password=12345");

        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("insert into \"Sinema\".\"Film\" (\"adi\",\"turAdi\",\"yayinTarihi\",\"sure\") values (@p1,@p2,@p3,@p5)", conn);
           
            cmd1.Parameters.AddWithValue("@p1", txtFilmAdi.Text);
            cmd1.Parameters.AddWithValue("@p2", int.Parse(comboBox1.SelectedValue.ToString()));
            cmd1.Parameters.AddWithValue("@p3", DateTime.Parse( txtYayinTarih.Text));
            cmd1.Parameters.AddWithValue("@p5", int.Parse(txtSure.Text));
            cmd1.ExecuteNonQuery();//degisiklikleri veritabanına uygular
            conn.Close();
            MessageBox.Show("Film ekleme işlemi başarı ile gerçekleştirildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

       

        private void FormFilm_Load(object sender, EventArgs e)
        {

            lblUser.Text = lblUser.Text + username;

            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select*from \"Sinema\".\"Kategori\"", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "adi";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;

            conn.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
           

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            string query = "select*from \"Sinema\".\"Film\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {

            this.Hide();
            new FormAdmin(username).Show();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd2 = new NpgsqlCommand("delete from \"Sinema\".\"Film\" where \"id\"=@p1 ",conn);
            cmd2.Parameters.AddWithValue("@p1", int.Parse(txtFilmId.Text));
            cmd2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Film silme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd3 = new NpgsqlCommand("update \"Sinema\".\"Film\" set \"adi\"=@p1,\"turAdi\"=@p2,\"yayinTarihi\"=@p3,\"fiyat\"=@p4,\"sure\"=@p5 where \"id\"=@p7", conn);
            cmd3.Parameters.AddWithValue("@p1",txtFilmAdi.Text);
            cmd3.Parameters.AddWithValue("@p2", int.Parse(comboBox1.SelectedValue.ToString()));
            cmd3.Parameters.AddWithValue("@p3", DateTime.Parse(txtYayinTarih.Text));
            cmd3.Parameters.AddWithValue("@p4", decimal.Parse(txtFiyat.Text));
            cmd3.Parameters.AddWithValue("@p5", int.Parse(txtSure.Text));
            cmd3.Parameters.AddWithValue("@p7", int.Parse(txtFilmId.Text));
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Film güncelleme işlemi başarı ile gerçekleşti.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning );
            conn.Close();
        }

        private void txtFilmAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            string query="select * from \"Sinema\".\"Film\" where \"adi\" like '%"+ txtAra.Text+"%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void btnExitt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

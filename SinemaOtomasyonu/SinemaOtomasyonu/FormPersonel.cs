using Npgsql;
using System;
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
    public partial class FormPersonel : Form
    {
        private string username;
        public FormPersonel(string username)
        {
            this.username = username;
            InitializeComponent();
        }
        public FormPersonel()
        {
            InitializeComponent();
        }
        NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SinemaOtomasyonu; user ID=postgres; password=12345");
        private NpgsqlCommand cmd;
        private string sqlFindId = null;
        private void btnGeri_Click(object sender, EventArgs e)
        {

            this.Hide();
            new FormAdmin(username).Show();

        }

        private void FormPersonel_Load(object sender, EventArgs e)
        {

            lblUser.Text = lblUser.Text + username;

            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select*from \"Sinema\".\"PersonelTuru\"", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "ad";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;

            conn.Close();
        }
    

        private void btnExitt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select * from \"Kisi\".\"Kisi\" join \"Kisi\".\"Personel\" on \"Kisi\".\"Kisi\".\"id\"=\"Kisi\".\"Personel\".\"id\" where \"adi\" like '%" + txtAra.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            string query = "select * from \"Kisi\".\"Kisi\" join \"Kisi\".\"Personel\" on \"Kisi\".\"Kisi\".\"id\"=\"Kisi\".\"Personel\".\"id\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("insert into \"Kisi\".\"Kisi\" (\"adi\",\"soyadi\",\"kisiTuru\",\"telefon\",\"email\") values (@p1,@p2,@p3,@p4,@p5)", conn);

            cmd1.Parameters.AddWithValue("@p1", txtPersonelAdi.Text);
            cmd1.Parameters.AddWithValue("@p2", txtPersonelSoyadi.Text);
            cmd1.Parameters.AddWithValue("@p3", true);
            cmd1.Parameters.AddWithValue("@p4", txtTelefon.Text);
            cmd1.Parameters.AddWithValue("@p5", txtMail.Text);
            //"select * from \"Kisi\".\"Kisi\".\"kisiIdBul\"("+txtPersonelAdi+")"
            //select count(*) from \"Kisi\".\"Kisi\".\"kisiIdBul\"("+txtPersonelAdi.Text+
            cmd1.ExecuteNonQuery();

            NpgsqlCommand cmd2 = new NpgsqlCommand("insert into \"Kisi\".\"Personel\" (\"id\",\"kullaniciAdi\",\"sifre\",\"personelTuruId\") values (@p1,@p2,@p3,@p4)", conn);
            sqlFindId = @"select * from ""Sinema"".""kisiIdBul""(:username)";
            cmd = new NpgsqlCommand(sqlFindId, conn);
            cmd.Parameters.AddWithValue("username", txtPersonelAdi.Text);
            int result = (int)cmd.ExecuteScalar();
            cmd2.Parameters.AddWithValue("@p1", result);
            cmd2.Parameters.AddWithValue("@p2", txtKullaniciAdi.Text);
            cmd2.Parameters.AddWithValue("@p3", txtSifre.Text);
            cmd2.Parameters.AddWithValue("@p4", int.Parse(comboBox1.SelectedValue.ToString()));
            cmd2.ExecuteNonQuery();//degisiklikleri veritabanına uygular
            conn.Close();
            MessageBox.Show("Personel ekleme işlemi başarı ile gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd3 = new NpgsqlCommand("update \"Kisi\".\"Kisi\" set \"adi\"=@p1,\"soyadi\"=@p2,\"telefon\"=@p3,\"email\"=@p4 where \"id\"=@p5", conn);
            cmd3.Parameters.AddWithValue("@p1", txtPersonelAdi.Text);
            cmd3.Parameters.AddWithValue("@p2", txtPersonelSoyadi.Text);
            cmd3.Parameters.AddWithValue("@p3", txtTelefon.Text);
            cmd3.Parameters.AddWithValue("@p4", txtMail.Text);
            cmd3.Parameters.AddWithValue("@p5", int.Parse(txtPersonelId.Text));
            cmd3.ExecuteNonQuery();
            NpgsqlCommand cmd4 = new NpgsqlCommand("update \"Kisi\".\"Personel\" set \"kullaniciAdi\"=@p1,\"sifre\"=@p2,\"personelTuruId\"=@p3 where \"id\"=@p4", conn);
            cmd4.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            cmd4.Parameters.AddWithValue("@p2", txtSifre.Text);
            cmd4.Parameters.AddWithValue("@p3", int.Parse(comboBox1.SelectedValue.ToString()));
            cmd4.Parameters.AddWithValue("@p4", int.Parse(txtPersonelId.Text));
            cmd4.ExecuteNonQuery();
            MessageBox.Show("Personel güncelleme işlemi başarı ile gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            conn.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            conn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("delete from \"Kisi\".\"Kisi\" where \"id\"=@p1 ", conn);
            cmd1.Parameters.AddWithValue("@p1", int.Parse(txtPersonelId.Text));
            cmd1.ExecuteNonQuery();
            NpgsqlCommand cmd2 = new NpgsqlCommand("delete from \"Kisi\".\"Personel\" where \"id\"=@p1 ", conn);
            cmd2.Parameters.AddWithValue("@p1", int.Parse(txtPersonelId.Text));
            cmd2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Personel silme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

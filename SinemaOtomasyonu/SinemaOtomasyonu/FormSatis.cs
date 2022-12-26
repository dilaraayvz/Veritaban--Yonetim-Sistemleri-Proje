using Npgsql;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SinemaOtomasyonu
{
    public partial class FormSatis : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SinemaOtomasyonu; user ID=postgres; password=12345");
        private string username;
        //private NpgsqlCommand cmd =new NpgsqlCommand();
        

        public FormSatis()
        {
            InitializeComponent();
        }
        public FormSatis(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void FormSatis_Load(object sender, EventArgs e)
        {


            lblUser.Text = lblUser.Text + username;
            conn.Open();
            string sqlSorgu = @"select * from ""Sinema"".""yoneticiMi""(:username)";
            NpgsqlCommand cmd = new NpgsqlCommand(sqlSorgu, conn);
            cmd.Parameters.AddWithValue("username", username);
            int result = (int)cmd.ExecuteScalar();
            if (result == 1)
            {
                btnGeri.Enabled = true;
            }
            else
            {
                btnGeri.Enabled = false;
            }
            conn.Close();

            conn.Open();
            NpgsqlDataAdapter daOdeme = new NpgsqlDataAdapter("select*from \"Sinema\".\"OdemeYontemi\"", conn);
            DataTable dtOdeme = new DataTable();
            daOdeme.Fill(dtOdeme);
            cmbOdeme.DisplayMember = "adi";
            cmbOdeme.ValueMember = "id";
            cmbOdeme.DataSource = dtOdeme;

            NpgsqlDataAdapter daYiyecek = new NpgsqlDataAdapter("select*from \"Sinema\".\"Yiyecek\"", conn);
            DataTable dtYiyecek = new DataTable();
            daYiyecek.Fill(dtYiyecek);
            cmbYiyecek.DisplayMember = "adi";
            cmbYiyecek.ValueMember = "id";
            cmbYiyecek.DataSource = dtYiyecek;
            //lblYiyecekFiyat.Text = lblYiyecekFiyat.Text + username;

            NpgsqlDataAdapter daFilm = new NpgsqlDataAdapter("select*from \"Sinema\".\"Film\"", conn);
            DataTable dtFilm = new DataTable();
            daFilm.Fill(dtFilm);
            cmbFilmAdi.DisplayMember = "adi";
            cmbFilmAdi.ValueMember = "id";
            cmbFilmAdi.DataSource = dtFilm;

            NpgsqlDataAdapter daSeans = new NpgsqlDataAdapter("select*from \"Sinema\".\"Seans\"", conn);
            DataTable dtSeans = new DataTable();
            daSeans.Fill(dtSeans);
            cmbSeans.DisplayMember = "saat";
            cmbSeans.ValueMember = "id";
            cmbSeans.DataSource = dtSeans;

            NpgsqlDataAdapter daSalon = new NpgsqlDataAdapter("select*from \"Sinema\".\"Salon\"", conn);
            DataTable dtSalon = new DataTable();
            daSalon.Fill(dtSalon);
            cmbSalon.DisplayMember = "adi";
            cmbSalon.ValueMember = "id";
            cmbSalon.DataSource = dtSalon;

            NpgsqlDataAdapter daKoltuk = new NpgsqlDataAdapter("select*from \"Sinema\".\"Koltuk\" where \"salonId\"= \'" + cmbSalon.SelectedValue.ToString() + "\'", conn);
            DataTable dtKoltuk = new DataTable();
            daKoltuk.Fill(dtKoltuk);
            cmbKoltuk.DisplayMember = "adi";
            cmbKoltuk.ValueMember = "id";
            cmbKoltuk.DataSource = dtKoltuk;

            string query = "select \"salonId\", \"adi\",\"doluMu\" from \"Sinema\".\"Koltuk\" where \"salonId\"= \'" + cmbSalon.SelectedValue.ToString() + "\'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


            NpgsqlDataAdapter daMusteriTuru = new NpgsqlDataAdapter("select*from \"Sinema\".\"MusteriTuru\"", conn);
            DataTable dtMusteriTuru = new DataTable();
            daMusteriTuru.Fill(dtMusteriTuru);
            cmbMusteriTuru.DisplayMember = "adi";
            cmbMusteriTuru.ValueMember = "id";
            cmbMusteriTuru.DataSource = dtMusteriTuru;
            conn.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            
            
                this.Hide();
                new FormAdmin(username).Show();
            

               
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExitt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void cmbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {

            string query = "select \"salonId\", \"adi\",\"doluMu\" from \"Sinema\".\"Koltuk\" where \"salonId\"= \'" + cmbSalon.SelectedValue.ToString() + "\'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            NpgsqlDataAdapter daKoltuk = new NpgsqlDataAdapter("select*from \"Sinema\".\"Koltuk\" where \"salonId\"= \'" + cmbSalon.SelectedValue.ToString() + "\'", conn);
            DataTable dtKoltuk = new DataTable();
            daKoltuk.Fill(dtKoltuk);
            cmbKoltuk.DisplayMember = "adi";
            cmbKoltuk.ValueMember = "id";
            cmbKoltuk.DataSource = dtKoltuk;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MÜŞTERİ EKLEME 
            conn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand("insert into \"Kisi\".\"Kisi\" (\"adi\",\"soyadi\",\"email\",\"telefon\",\"kisiTuru\") values (@p1,@p2,@p3,@p4,@p5)", conn);
            cmd1.Parameters.AddWithValue("@p1", txtMusteriAd.Text);
            cmd1.Parameters.AddWithValue("@p2", txtMusteriSoyad.Text);
            cmd1.Parameters.AddWithValue("@p3", txtMail.Text);
            cmd1.Parameters.AddWithValue("@p4", txtTelefon.Text);
            cmd1.Parameters.AddWithValue("@p5", false);
            cmd1.ExecuteNonQuery();

            NpgsqlCommand cmd2 = new NpgsqlCommand("insert into \"Kisi\".\"Musteri\" (\"id\",\"musteriTuruId\") values (@p1,@p2)", conn);
            string sqlFindMusteri = @"select * from ""Sinema"".""kisiIdBul""(:username)";
            NpgsqlCommand cmdMusteri = new NpgsqlCommand(sqlFindMusteri, conn);
            cmdMusteri.Parameters.AddWithValue("username", txtMusteriAd.Text);
            int result1  = (int)cmdMusteri.ExecuteScalar();
            cmd2.Parameters.AddWithValue("@p1", result1);
            cmd2.Parameters.AddWithValue("@p2", int.Parse(cmbMusteriTuru.SelectedValue.ToString()));
            cmd2.ExecuteNonQuery();
            

            //BİLET EKLEME
            
            
            NpgsqlCommand cmd3 = new NpgsqlCommand("insert into \"Sinema\".\"Bilet\" (\"filmId\",\"filmAdi\",\"seansId\",\"salonId\",\"koltukId\",\"musteriId\") values (@p1,@p2,@p3,@p4,@p5,@p6)", conn);
            cmd3.Parameters.AddWithValue("@p1", int.Parse(cmbFilmAdi.SelectedValue.ToString()));
            cmd3.Parameters.AddWithValue("@p2", cmbFilmAdi.GetItemText(cmbFilmAdi.SelectedItem));
            cmd3.Parameters.AddWithValue("@p3", int.Parse(cmbSeans.SelectedValue.ToString()));
            cmd3.Parameters.AddWithValue("@p4", int.Parse(cmbSalon.SelectedValue.ToString()));
            cmd3.Parameters.AddWithValue("@p5", int.Parse(cmbKoltuk.SelectedValue.ToString()));
            cmd3.Parameters.AddWithValue("@p6", result1);
            cmd3.ExecuteNonQuery();

            string sqlSorgu  = @"select max(""id"") from ""Sinema"".""Bilet"";";
            NpgsqlCommand cmd = new NpgsqlCommand(sqlSorgu, conn);
            //cmd.Parameters.AddWithValue("username", username);
            int result = (int)cmd.ExecuteScalar();

            NpgsqlCommand cmdBilet = new NpgsqlCommand("UPDATE \"Sinema\".\"Bilet\" set \"biletAdi\"='--' where \"id\"=\'"+result+"\'",conn);
            cmdBilet.ExecuteNonQuery();


            NpgsqlCommand cmd4 = new NpgsqlCommand("insert into \"Sinema\".\"Fatura\" (\"odemeYontemiId\",\"yiyecekId\",\"biletId\") values (@p1,@p2,@p3)", conn);
            cmd4.Parameters.AddWithValue("@p1", int.Parse(cmbOdeme.SelectedValue.ToString()));//odeme yontemi
            cmd4.Parameters.AddWithValue("@p2", int.Parse(cmbYiyecek.SelectedValue.ToString()));//yiyecekId

            string sqlBilet = @"select max(""id"") from ""Sinema"".""Bilet"";";
            NpgsqlCommand cmdBiletId = new NpgsqlCommand(sqlBilet, conn);
            //cmdBiletId.Parameters.AddWithValue("username", username);
            int resultBilet = (int)cmd.ExecuteScalar();

            cmd4.Parameters.AddWithValue("@p3", resultBilet);
            
            cmd4.ExecuteNonQuery();

            string sqlFatura = @"select max(""id"") from ""Sinema"".""Fatura"";";
            NpgsqlCommand cmdFatura = new NpgsqlCommand(sqlFatura, conn);
            //cmdBiletId.Parameters.AddWithValue("username", username);
            int resultFatura = (int)cmdFatura.ExecuteScalar();


            this.Hide();
            new FormBiletFatura(resultBilet, username).Show();

        }

        private void cmbMusteriTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void cmbYiyecek_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbFilmAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(cmbFilmAdi.GetItemText(cmbFilmAdi.SelectedItem));


        }
    }
}

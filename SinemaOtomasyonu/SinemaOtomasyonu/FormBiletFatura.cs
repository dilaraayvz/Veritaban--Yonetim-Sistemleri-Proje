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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SinemaOtomasyonu
{
    public partial class FormBiletFatura : Form
    {
        private int idBilet;
        private string username;
        public FormBiletFatura()
        {
            InitializeComponent();
        }
        public FormBiletFatura(int idBilet, string username)
        {
            this.username = username;
            this.idBilet = idBilet;
            InitializeComponent();
        }
        NpgsqlConnection conn = new NpgsqlConnection("server=localHost; port=5432; Database=SinemaOtomasyonu; user ID=postgres; password=12345");

        private void FormBiletFatura_Load(object sender, EventArgs e)
        {
            lblUser.Text = lblUser.Text + username;

            string queryBilet = "select bilet.\"id\" as \"Bilet ID\", bilet.\"biletAdi\" as \"Bilet Adı\", bilet.\"filmAdi\" as \"Film Adı\" , salon.\"adi\" as \"Salon Adı\" ,seans.\"saat\" as \"Seans Saati\" , koltuk.\"adi\" as \"Koltuk\" , odemeyontemi.\"adi\" as \"Ödeme Yöntemi\", fatura.\"tarih\" as \"Satış Tarihi\" ,yiyecek.\"adi\" as \"Yiyecek\" from \"Sinema\".\"Bilet\" as bilet join \"Sinema\".\"Fatura\" as fatura on bilet.\"id\" = fatura.\"biletId\"join \"Sinema\".\"Salon\" as salon on bilet.\"salonId\" = salon.\"id\" join \"Sinema\".\"Seans\" as seans on bilet.\"seansId\" = seans.\"id\" join \"Sinema\".\"Koltuk\" as koltuk on bilet.\"koltukId\" = koltuk.\"id\" join \"Sinema\".\"Yiyecek\" as yiyecek on fatura.\"yiyecekId\" = yiyecek.\"id\" join \"Sinema\".\"OdemeYontemi\" as odemeyontemi on odemeyontemi.\"id\" = fatura.\"odemeYontemiId\" where bilet.\"id\" = \' "+idBilet+"\'";
            //string queryBilet = "SELECT * FROM \"Sinema\".\"biletBilgileriGetir\"("+idBilet+")";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(queryBilet, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewBilet.DataSource = ds.Tables[0];
        }

        private void btnExitt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormAdmin(username).Show();
        }
    }
}

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
    public partial class FormAdmin : Form
    {
        public FormAdmin(string username)
        {
            this.username = username;
            InitializeComponent();

        }
        public FormAdmin()
        {
            InitializeComponent();
        }
        private string username;
       

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = lblUser.Text + username;
        }

        private void btnExitt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void btnFilm_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormFilm(username).Show();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormPersonel(username).Show();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormSatis(username).Show();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connString = String.Format("Server={0}; Port={1};" +
            "User Id={2}; Password={3};Database={4};",
            "localhost", "5432", "postgres", "12345", "SinemaOtomasyonu"
            );
        private NpgsqlCommand cmd;
        private string sqlLogin = null;
        private string sqlCheckPersonel = null;
        
        private void btnExitt_Click(object sender, EventArgs e)
        {
            Application.Exit();
            conn.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //If login successfully, hide this form and show the main form.
            //passing username from the login form into main form.
            try
            {
                conn.Open();
                sqlLogin = @"select * from ""Kisi"".""userLogin""(:username,:password)";
                cmd = new NpgsqlCommand(sqlLogin, conn);
                cmd.Parameters.AddWithValue("username", txtUsername.Text);
                cmd.Parameters.AddWithValue("password", txtPassword.Text);
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)//login succesfully
                {
                    sqlLogin = @"select * from ""Sinema"".""yoneticiMi""(:username)";
                    cmd = new NpgsqlCommand(sqlLogin, conn);
                    cmd.Parameters.AddWithValue("username", txtUsername.Text);
                    result = (int)cmd.ExecuteScalar();
                    if(result == 1)
                    {
                        this.Hide();
                        new FormAdmin(txtUsername.Text).Show();
                    }
                    else
                    {
                        this.Hide();
                        new FormSatis(txtUsername.Text).Show();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please check your username or password!","Login fail.",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    conn.Close();
                    return;
                }
                     
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }
    }
}

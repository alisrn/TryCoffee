using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace serin
{
    public partial class form_UserEntry : Form
    {
       

        public form_UserEntry()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_UserEnter_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = serin; Integrated Security = True");
            conn.Open();

            string query = "SELECT UserPassword FROM UserList WHERE UserName = @UserNames";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@UserNames", txt_UserName.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            if (dt.Rows[0][0].ToString() != txt_UserPassword.Text)
            {
                MessageBox.Show("Parola yanlış.");
            }
            else
            {
                MainPage mp = new MainPage();
                mp.Show();

                
            }
        }

        private void btn_NewUser_Click(object sender, EventArgs e)
        {
            NewUser Nu = new NewUser();
            Nu.Show();
        }
    }
}

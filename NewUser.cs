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
using System.Configuration;

namespace serin
{
    public partial class NewUser : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = serin; Integrated Security = True");

        public NewUser()
        {
            InitializeComponent();
        }

        private void btn_Record_Click(object sender, EventArgs e)
        {
            if(txt_Password.Text == txt_PasswordAgain.Text) { 
                conn.Open();

                string query = "INSERT INTO dbo.UserList (UserName, UserPassword, EmailAddress, SystemDate) " +
                    "VALUES (@UserNames, @Password, @Email, GETDATE()) ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserNames", txt_UserName.Text);
                cmd.Parameters.AddWithValue("@Password", txt_Password.Text);
                cmd.Parameters.AddWithValue("@Email", txt_EmailAddress.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Kayıt işlemi başarılı.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmamaktadır.");
            }
        }
    }
}

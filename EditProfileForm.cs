using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Pendaftaran_anggota
{
    public partial class EditProfileForm : Form
    {
        public EditProfileForm()
        {
            InitializeComponent();
        }

        private void EditProfileForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Username=postgres;Password=270203;Database=Db_pendaftarananggota";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE anggota SET nama = @nama, email = @email WHERE username = @username";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nama", txtnama.Text);
                    command.Parameters.AddWithValue("@email", txtemail.Text);
                    command.Parameters.AddWithValue("@username", txtusername.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Edit profil berhasil
                        MessageBox.Show("Profil berhasil diperbarui!");
                    }
                    else
                    {
                        // Edit profil gagal
                        MessageBox.Show("Gagal memperbarui profil. Coba lagi.");
                    }
                }
            }
        }
    }
}

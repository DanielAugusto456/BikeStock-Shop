using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UserRepository
    {
        class Usuario
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public int Rol { get; set; }
        }

        public void IngresarUsuario(string username, string password, int rol)
        {
            string query = "exec sp_InsertarUsuario @Username = @A1, @Password = @A2, @Rol = @A3";

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", username);
                    cmd.Parameters.AddWithValue("@A2", password);
                    cmd.Parameters.AddWithValue("@A3", rol);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ValidarUsuario(string username, string password)
        {
            string query = "exec sp_ValidarUsuario @Username = @A1, @Password = @A2";
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", username);
                    cmd.Parameters.AddWithValue("@A2", password);

                    int result = (int)cmd.ExecuteScalar();

                    return result == 1;
                }
            }
        }

        public void ActualizarUsuario(int id, string username, string password, int rol)
        {
            string query = "exec sp_ActualizarUsuario @Id = @A1, @UserName = @A2, @Password = @A3, @Rol = @A4";
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", id);
                    cmd.Parameters.AddWithValue("@A2", username);
                    cmd.Parameters.AddWithValue("@A3", password);
                    cmd.Parameters.AddWithValue("@A4", rol);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarUsuario(int id)
        {
            string query = "exec sp_EliminarUsuario @Id = @A1";
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

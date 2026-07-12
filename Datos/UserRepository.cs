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
        public class Usuario
        {
            public int Id { get; set; }
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

        public Usuario ValidarUsuario(string username, string password)
        {
            string query = "exec sp_ValidarUsuario @Username = @A1, @Password = @A2";
            Usuario usuario = null;
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", username);
                    cmd.Parameters.AddWithValue("@A2", password);

                    using (SqlDataReader rd = cmd.ExecuteReader()) { 
                        if (rd.Read())
                        {
                            usuario = new Usuario
                            {
                                Username = rd["Username"].ToString(),
                                Password = rd["Password"].ToString(),
                                Rol = Convert.ToInt32(rd["Rol"])
                            };
                            return usuario;
                        }
                        else
                        {
                            return null;
                        }
                    }
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

        public List<Usuario> BuscarUsuarios(string nombre) 
        {
            string query = "exec sp_BuscarUsuario @Username = @A1";
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection cxn = new SqlConnection(cnn.db)) 
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn)) 
                {
                    cmd.Parameters.AddWithValue("@A1", nombre);
                    using (SqlDataReader rd = cmd.ExecuteReader()) 
                    {
                        while (rd.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                Username = rd["Username"].ToString(),
                                Password = rd["Password"].ToString(),
                                Rol = Convert.ToInt32(rd["Rol"])
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }
    }
}

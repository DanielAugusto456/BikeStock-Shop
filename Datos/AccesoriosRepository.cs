using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class AccesoriosRepository : IAccesoriosRepository
    {
        public class Accesorio
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string tipo { get; set; }
            public string Marca { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }
        }

        public void InsertarAccesorio(string nombre, string tipo, string marca, decimal precio, int stock)
        {
            string query = "exec sp_InsertarAccesorio @Nombre = @A1, @Tipo = @A2, @Marca = @A3, @Precio = @A4, @Stock = @A5";
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", nombre);
                    cmd.Parameters.AddWithValue("@A2", tipo);
                    cmd.Parameters.AddWithValue("@A3", marca);
                    cmd.Parameters.AddWithValue("@A4", precio);
                    cmd.Parameters.AddWithValue("@A5", stock);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarAccesorio(int id, string nombre, string tipo, string marca, decimal precio, int stock)
        {
            string query = "exec sp_ActualizarAccesorio @Id = @A1, @Nombre = @A2, @Tipo = @A3, @Marca = @A4, @Precio = @A5, @Stock = @A6";
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", id);
                    cmd.Parameters.AddWithValue("@A2", nombre);
                    cmd.Parameters.AddWithValue("@A3", tipo);
                    cmd.Parameters.AddWithValue("@A4", marca);
                    cmd.Parameters.AddWithValue("@A5", precio);
                    cmd.Parameters.AddWithValue("@A6", stock);
                    cmd.ExecuteNonQuery();
                }
            }
        }

         public List<Accesorio> BuscarAccesorios(string nombre, string tipo, string marca) { 
            string query = "exec sp_BuscarAccesorios @Nombre = @A1, @Tipo = @A2, @Marca = @A3";
            List<Accesorio> accesorios = new List<Accesorio>();
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", nombre);
                    cmd.Parameters.AddWithValue("@A2", tipo);
                    cmd.Parameters.AddWithValue("@A3", marca);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Accesorio accesorio = new Accesorio
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                tipo = reader.GetString(2),
                                Marca = reader.GetString(3),
                                Precio = reader.GetDecimal(4),
                                Stock = reader.GetInt32(5)
                            };
                            accesorios.Add(accesorio);
                        }
                    }
                }
            }
            return accesorios;
        }

        public void EliminarAccesorio(int id) 
        {
            string query = "exec sp_EliminarAccesorio @Id = @A1";
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

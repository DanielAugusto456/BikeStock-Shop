using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class BicecletasRepository
    {
        public class Bicicleta
        {
            public int Id { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public string Color { get; set; }
            public decimal Precio { get; set; }
            public int Disponible { get; set; }
            public int Reparacion { get; set; }
        }

        public void IngresarBicicleta(string marca, string modelo, string color, decimal precio, int disponible, int reparacion)
        {
            string query = "exec sp_InsertarBicicleta @Marca = @A1, @Modelo = @A2, @Color = @A3, @Precio = @A4, @Disponible = @A5, @Reparacion = @A6";
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", marca);
                    cmd.Parameters.AddWithValue("@A2", modelo);
                    cmd.Parameters.AddWithValue("@A3", color);
                    cmd.Parameters.AddWithValue("@A4", precio);
                    cmd.Parameters.AddWithValue("@A5", disponible);
                    cmd.Parameters.AddWithValue("@A6", reparacion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Bicicleta> ObtenerBicicletas(string marca = null, string modelo = null, string color = null)
        {
            List<Bicicleta> bicicletas = new List<Bicicleta>();
            string query = "exec sp_BuscarBicicletas @Marca = @A1, @Modelo = @A2, @Color = @A3";
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmd.Parameters.AddWithValue("@A1", marca ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@A2", modelo ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@A3", color ?? (object)DBNull.Value);

                        while (reader.Read())
                        {
                            bicicletas.Add(new Bicicleta
                            {
                                Id = reader.GetInt32(0),
                                Marca = reader.GetString(1),
                                Modelo = reader.GetString(2),
                                Color = reader.GetString(3),
                                Precio = reader.GetDecimal(4),
                                Disponible = reader.GetInt32(5),
                                Reparacion = reader.GetInt32(6)
                            });
                        }
                    }
                }
            }
            return bicicletas;
        }

        public void ActualizarStock(int disponible, int reparacion)
        {
            string query = "exec sp_ActualiarStockBicicleta @Disponible = @A1, @Reparacion = @A2";
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", disponible);
                    cmd.Parameters.AddWithValue("@A2", reparacion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarBicicleta(int id, string marca, string modelo, string color, decimal precio, int disponible, int reparacion)
        {
            string query = "exec sp_ActualizarBicicleta @Id = @A1, @Marca = @A2, @Modelo = @A3, @Color = @A4, @Precio = @A5, @Disponible = @A6, @Reparacion = @A7";
            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                cxn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cxn))
                {
                    cmd.Parameters.AddWithValue("@A1", id);
                    cmd.Parameters.AddWithValue("@A2", marca);
                    cmd.Parameters.AddWithValue("@A3", modelo);
                    cmd.Parameters.AddWithValue("@A4", color);
                    cmd.Parameters.AddWithValue("@A5", precio);
                    cmd.Parameters.AddWithValue("@A6", disponible);
                    cmd.Parameters.AddWithValue("@A7", reparacion);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void EliminarBicicleta(int id)
        {
            string query = "exec sp_EliminarBicicleta @Id = @A1";
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

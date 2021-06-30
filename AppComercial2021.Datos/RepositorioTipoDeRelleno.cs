using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Datos
{
    public class RepositorioTipoDeRelleno
    {
        public static RepositorioTipoDeRelleno instancia;

        public static RepositorioTipoDeRelleno GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioTipoDeRelleno();
            }

            return instancia;
        }

        private RepositorioTipoDeRelleno()
        {

        }

        public List<TipoRelleno> GetLista()
        {
            List<TipoRelleno> lista = new List<TipoRelleno>();
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "SELECT TipoRellenoId, Descripcion FROM TipoDeRellenos";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tipo = ConstruirTipo(reader);
                                lista.Add(tipo);
                            }
                        }
                    }

                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar leer los datos de la tabla de Rellenos o al establecer la conexión");
            }

            
        }


        private TipoRelleno ConstruirTipo(SqlDataReader reader)
        {
            return new TipoRelleno()
            {
                TipoRellenoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public int Agregar(TipoRelleno tipoRelleno)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "INSERT INTO TipoDeRellenos VALUES (@desc)";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);

                        registrosAfectados = comando.ExecuteNonQuery();
                        cadenaComando = "SELECT @@IDENTITY";
                        using (var comandoOutput=new SqlCommand(cadenaComando, cn))
                        {
                            tipoRelleno.TipoRellenoId = (int)(decimal)comando.ExecuteScalar();
                            
                        }
                    }
                }
                return registrosAfectados;

            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Registro repetido");
                }
                throw new Exception(e.Message);
            }
        }

        public int Borrar(int tipoRellenoId)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "DELETE FROM TipoDeRellenos WHERE TipoRellenoId=@id";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@id", tipoRellenoId);
                        registrosAfectados = comando.ExecuteNonQuery();
                    }
                }
                return registrosAfectados;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public int Editar(TipoRelleno tipoRelleno)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "UPDATE TipoDeRellenos SET Descripcion=@desc WHERE TipoRellenoId=@id";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);
                        comando.Parameters.AddWithValue("@id", tipoRelleno.TipoRellenoId);

                        registrosAfectados = comando.ExecuteNonQuery();

                    }

                }
                return registrosAfectados;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("IX_"))
                {
                    throw new Exception("Registro repetido");
                }
                throw new Exception(e.Message);

            }
        }
    }
}

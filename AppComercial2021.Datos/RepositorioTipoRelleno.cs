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
    public class RepositorioTipoRelleno
    {
        public static RepositorioTipoRelleno instancia;

        public static RepositorioTipoRelleno GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioTipoRelleno();
            }

            return instancia;
        }

        private RepositorioTipoRelleno()
        {

        }

        public bool EstaRelacionado(TipoRelleno tipoRelleno)
        {
            int registrosEncontrados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {

                    string cadenaComando = "SELECT COUNT(*) FROM Bombones WHERE TipoRellenoId=@id";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@id", tipoRelleno.TipoRellenoId);
                        registrosEncontrados = (int)comando.ExecuteScalar();
                    }

                }

                return registrosEncontrados > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public bool Existe(TipoRelleno tipoRelleno)
        {
            int registrosEncontrados = 0;
            try
            {
                using (var cn=ConexionBd.GetInstancia().GetConexion())
                {

                    if (tipoRelleno.TipoRellenoId==0)
                    {
                        string cadenaComando = "SELECT COUNT(*) FROM TipoRellenos WHERE Descripcion=@desc";
                        using (var comando = new SqlCommand(cadenaComando, cn))
                        {
                            comando.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);
                            registrosEncontrados = (int)comando.ExecuteScalar();
                        }

                    }
                    else
                    {
                        string cadenaComando = "SELECT COUNT(*) FROM TipoRellenos WHERE Descripcion=@desc AND TipoRellenoId<>@id";
                        using (var comando = new SqlCommand(cadenaComando, cn))
                        {
                            comando.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);
                            comando.Parameters.AddWithValue("@id", tipoRelleno.TipoRellenoId);

                            registrosEncontrados = (int)comando.ExecuteScalar();
                        }
                        
                    }
                }

                return registrosEncontrados > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public List<TipoRelleno> GetLista()
        {
            List<TipoRelleno> lista = new List<TipoRelleno>();
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "SELECT TipoRellenoId, Descripcion, RowVersion FROM TipoRellenos";
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
                Descripcion = reader.GetString(1),
                RowVersion =(byte[]) reader[2]
            };
        }

        public int Agregar(TipoRelleno tipoRelleno)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "INSERT INTO TipoRellenos (Descripcion) VALUES (@desc)";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);

                        registrosAfectados = comando.ExecuteNonQuery();
                        if (registrosAfectados>0)
                        {
                            cadenaComando = "SELECT @@IDENTITY";
                            using (var comandoOutput = new SqlCommand(cadenaComando, cn))
                            {
                                tipoRelleno.TipoRellenoId = (int)(decimal)comandoOutput.ExecuteScalar();

                            }
                            cadenaComando = "SELECT RowVersion FROM TipoRellenos WHERE TipoRellenoId=@id";
                            using (var comandoRow = new SqlCommand(cadenaComando, cn))
                            {
                                comandoRow.Parameters.AddWithValue("@id", tipoRelleno.TipoRellenoId);
                                tipoRelleno.RowVersion = (byte[])comandoRow.ExecuteScalar();
                            }
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

        public int Borrar(TipoRelleno tipoRelleno)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "DELETE FROM TipoRellenos WHERE TipoRellenoId=@id AND RowVersion=@ver";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@id",tipoRelleno.TipoRellenoId);
                        comando.Parameters.AddWithValue("@ver", tipoRelleno.RowVersion);
                        registrosAfectados = comando.ExecuteNonQuery();
                    }
                }
                return registrosAfectados;

            }
            catch (Exception e)
            {
                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro Relacionado... Baja denegada");
                }
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
                    string cadenaComando = "UPDATE TipoRellenos SET Descripcion=@desc WHERE TipoRellenoId=@id AND RowVersion=@ver";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);
                        comando.Parameters.AddWithValue("@id", tipoRelleno.TipoRellenoId);
                        comando.Parameters.AddWithValue("@ver", tipoRelleno.RowVersion);

                        registrosAfectados = comando.ExecuteNonQuery();
                        
                    }

                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM TipoRellenos WHERE TipoRellenoId=@id";
                        using (var comandoRow = new SqlCommand(cadenaComando, cn))
                        {
                            comandoRow.Parameters.AddWithValue("@id", tipoRelleno.TipoRellenoId);
                            tipoRelleno.RowVersion = (byte[])comandoRow.ExecuteScalar();
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
    }
}

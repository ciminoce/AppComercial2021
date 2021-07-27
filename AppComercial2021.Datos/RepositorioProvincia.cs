using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Datos
{
    public class RepositorioProvincia
    {
        public static RepositorioProvincia instancia;

        public static RepositorioProvincia GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new RepositorioProvincia();
            }

            return instancia;
        }

        private RepositorioProvincia()
        {

        }

        public bool EstaRelacionado(Provincia provincia)
        {
            int registrosEncontrados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {

                    string cadenaComando = "SELECT COUNT(*) FROM Localidades WHERE ProvinciaId=@id";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
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
        public bool Existe(Provincia provincia)
        {
            int registrosEncontrados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {

                    if (provincia.ProvinciaId == 0)
                    {
                        string cadenaComando = "SELECT COUNT(*) FROM Provincias WHERE NombreProvincia=@nom";
                        using (var comando = new SqlCommand(cadenaComando, cn))
                        {
                            comando.Parameters.AddWithValue("@nom", provincia.NombreProvincia);
                            registrosEncontrados = (int)comando.ExecuteScalar();
                        }

                    }
                    else
                    {
                        string cadenaComando = "SELECT COUNT(*) FROM Provincias WHERE NombreProvincia=@desc AND ProvinciaId<>@id";
                        using (var comando = new SqlCommand(cadenaComando, cn))
                        {
                            comando.Parameters.AddWithValue("@desc", provincia.NombreProvincia);
                            comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);

                            registrosEncontrados = (int)comando.ExecuteScalar();
                        }

                    }
                }

                return registrosEncontrados > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Provincia> GetLista()
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "SELECT ProvinciaId, NombreProvincia, RowVersion FROM Provincias ORDER BY NombreProvincia";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tipo = ConstruirProvincia(reader);
                                lista.Add(tipo);
                            }
                        }
                    }

                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar leer los datos de la tabla o al establecer la conexión");
            }


        }


        private Provincia ConstruirProvincia(SqlDataReader reader)
        {
            return new Provincia()
            {
                ProvinciaId = reader.GetInt32(0),
                NombreProvincia = reader.GetString(1),
                RowVersion = (byte[])reader[2]
            };
        }

        public int Agregar(Provincia provincia)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "INSERT INTO Provincias (NombreProvincia) VALUES (@nom)";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@nom", provincia.NombreProvincia);

                        registrosAfectados = comando.ExecuteNonQuery();
                        if (registrosAfectados > 0)
                        {
                            cadenaComando = "SELECT @@IDENTITY";
                            using (var comandoOutput = new SqlCommand(cadenaComando, cn))
                            {
                                provincia.ProvinciaId = (int)(decimal)comandoOutput.ExecuteScalar();

                            }
                            cadenaComando = "SELECT RowVersion FROM Provincias WHERE ProvinciaId=@id";
                            using (var comandoRow = new SqlCommand(cadenaComando, cn))
                            {
                                comandoRow.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                                provincia.RowVersion = (byte[])comandoRow.ExecuteScalar();
                            }
                        }

                    }
                }
                return registrosAfectados;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Borrar(Provincia provincia)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "DELETE FROM Provincias WHERE ProvinciaId=@id AND RowVersion=@ver";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                        comando.Parameters.AddWithValue("@ver", provincia.RowVersion);
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

        public int Editar(Provincia provincia)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "UPDATE Provincias SET NombreProvincia=@nom WHERE ProvinciaId=@id AND RowVersion=@ver";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@nom", provincia.NombreProvincia);
                        comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                        comando.Parameters.AddWithValue("@ver", provincia.RowVersion);

                        registrosAfectados = comando.ExecuteNonQuery();

                    }

                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM Provincias WHERE ProvinciaId=@id";
                        using (var comandoRow = new SqlCommand(cadenaComando, cn))
                        {
                            comandoRow.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                            provincia.RowVersion = (byte[])comandoRow.ExecuteScalar();
                        }

                    }
                }
                return registrosAfectados;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public Provincia GetProvinciaPorId(int id)
        {
            Provincia provincia = null;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "SELECT ProvinciaId, NombreProvincia, RowVersion FROM Provincias WHERE ProvinciaId=@id";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@id", id);

                        using (var reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                provincia = ConstruirProvincia(reader);
                            }
                        }
                    }

                }

                return provincia;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}

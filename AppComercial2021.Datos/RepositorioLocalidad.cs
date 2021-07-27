using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Entidades.DTOs;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Datos
{
    public class RepositorioLocalidad
    {
        public static RepositorioLocalidad instancia;

        public static RepositorioLocalidad GetInstancia()
        {
            if (instancia==null)
            {
                instancia = new RepositorioLocalidad();
            }

            return instancia;
        }
        private RepositorioLocalidad()
        {
            
        }

        public bool Existe(Localidad localidad)
        {
            int registrosEncontrados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {

                    if (localidad.LocalidadId == 0)
                    {
                        string cadenaComando = "SELECT COUNT(*) FROM Localidades WHERE NombreLocalidad=@nom AND ProvinciaId=@provId";
                        using (var comando = new SqlCommand(cadenaComando, cn))
                        {
                            comando.Parameters.AddWithValue("@nom", localidad.NombreLocalidad);
                            comando.Parameters.AddWithValue("@provId", localidad.Provincia.ProvinciaId);

                            registrosEncontrados = (int)comando.ExecuteScalar();
                        }

                    }
                    else
                    {
                        string cadenaComando = "SELECT COUNT(*) FROM Localidades WHERE NombreLocalidad=@nom AND ProvinciaId=@provId AND LocalidadId<>@locId";
                        using (var comando = new SqlCommand(cadenaComando, cn))
                        {
                            comando.Parameters.AddWithValue("@nom", localidad.NombreLocalidad);
                            comando.Parameters.AddWithValue("@provId", localidad.Provincia.ProvinciaId);
                            comando.Parameters.AddWithValue("@locId", localidad.LocalidadId);


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
        public List<LocalidadDto> GetLista()
        {
            try
            {
                List<LocalidadDto> lista = new List<LocalidadDto>();
                using (var cn=ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando =
                        "SELECT LocalidadId, NombreLocalidad, NombreProvincia FROM Localidades "+
                    "INNER JOIN Provincias ON Localidades.ProvinciaId=Provincias.ProvinciaId "+
                        " ORDER BY NombreLocalidad";
                    using (var comando=new SqlCommand(cadenaComando, cn))
                    {
                        using (var reader=comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LocalidadDto loc = ConstruirLocalidadDto(reader);
                                lista.Add(loc);
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private LocalidadDto ConstruirLocalidadDto(SqlDataReader reader)
        {
            return new LocalidadDto()
            {
                LocalidadId = reader.GetInt32(0),
                NombreLocalidad = reader.GetString(1),
                NombreProvincia = reader.GetString(2)
            };
        }

        public int Agregar(Localidad localidad)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "INSERT INTO Localidades (NombreLocalidad, ProvinciaId) VALUES (@nom, @provId)";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@nom", localidad.NombreLocalidad);
                        comando.Parameters.AddWithValue("@provId", localidad.Provincia.ProvinciaId);

                        registrosAfectados = comando.ExecuteNonQuery();
                        if (registrosAfectados > 0)
                        {
                            cadenaComando = "SELECT @@IDENTITY";
                            using (var comandoOutput = new SqlCommand(cadenaComando, cn))
                            {
                                localidad.LocalidadId = (int)(decimal)comandoOutput.ExecuteScalar();

                            }
                            cadenaComando = "SELECT RowVersion FROM Localidades WHERE LocalidadId=@id";
                            using (var comandoRow = new SqlCommand(cadenaComando, cn))
                            {
                                comandoRow.Parameters.AddWithValue("@id", localidad.LocalidadId);
                                localidad.RowVersion = (byte[])comandoRow.ExecuteScalar();
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

        public int Borrar(Localidad localidad)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "DELETE FROM Localidades WHERE LocalidadId=@id AND RowVersion=@ver";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                        comando.Parameters.AddWithValue("@ver", localidad.RowVersion);
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

        public int Editar(Localidad localidad)
        {
            int registrosAfectados = 0;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "UPDATE Localidades SET NombreLocalidad=@nom, ProvinciaId=@provId WHERE LocalidadId=@id AND RowVersion=@ver";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@nom", localidad.NombreLocalidad);
                        comando.Parameters.AddWithValue("@provId", localidad.Provincia.ProvinciaId);

                        comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                        comando.Parameters.AddWithValue("@ver", localidad.RowVersion);

                        registrosAfectados = comando.ExecuteNonQuery();

                    }

                    if (registrosAfectados > 0)
                    {
                        cadenaComando = "SELECT RowVersion FROM Localidades WHERE LocalidadId=@id";
                        using (var comandoRow = new SqlCommand(cadenaComando, cn))
                        {
                            comandoRow.Parameters.AddWithValue("@id", localidad.LocalidadId);
                            localidad.RowVersion = (byte[])comandoRow.ExecuteScalar();
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
        //TODO:Codificar el método para ver si está relacionado con otra tabla
        public bool EstaRelacionado(Localidad localidad)
        {
            return false;
        }

        public Localidad GetLocalidadPorId(int id)
        {
            Localidad localidad = null;
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {

                   
                    string cadenaComando = "SELECT LocalidadId, NombreLocalidad, ProvinciaId, RowVersion FROM Localidades WHERE LocalidadId=@id";
                    using (var comando = new SqlCommand(cadenaComando, cn))
                    {
                        comando.Parameters.AddWithValue("@id", id);

                        using (var reader=comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                localidad = ConstruirLocalidad(reader);
                            }
                        }
                    }

                }

                return localidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Localidad ConstruirLocalidad(SqlDataReader reader)
        {
            return new Localidad()
            {
                LocalidadId = reader.GetInt32(0),
                NombreLocalidad = reader.GetString(1),
                Provincia = RepositorioProvincia.GetInstancia().GetProvinciaPorId(reader.GetInt32(2)),
                RowVersion =(byte[]) reader[3]
            };
        }
    }
}

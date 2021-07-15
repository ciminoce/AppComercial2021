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

        //public bool Existe(Localidad localidad)
        //{

        //}
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

        //public int Agregar(Localidad localidad)
        //{

        //}

        //public int Borrar(Localidad localidad)
        //{

        //}

        //public int Editar(Localidad localidad)
        //{

        //}

    }
}

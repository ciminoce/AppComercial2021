using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Datos
{
    public class RepositorioTipoDeChocolate
    {
        private ConexionBd conexionBd;

        public RepositorioTipoDeChocolate()
        {

        }

        public List<TipoChocolate> GetLista()
        {
            List<TipoChocolate> lista = new List<TipoChocolate>();
           
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "SELECT TipoChocolateId, Descripcion FROM TipoDeChocolates";
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
                throw new Exception(ex.Message);
            }

            
        }


        private TipoChocolate ConstruirTipo(SqlDataReader reader)
        {
            return new TipoChocolate()
            {
                TipoChocolateId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

    }
}

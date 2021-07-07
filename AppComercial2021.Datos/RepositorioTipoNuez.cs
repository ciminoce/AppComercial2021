using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Datos
{
    public class RepositorioTipoNuez
    {
        public static RepositorioTipoNuez instancia;

        public static RepositorioTipoNuez GetInstancia()
        {
            if (instancia==null)
            {
                instancia = new RepositorioTipoNuez();
            }

            return instancia;
        }

        private RepositorioTipoNuez()
        {

        }

        public List<TipoNuez> GetLista()
        {
            List<TipoNuez> lista = new List<TipoNuez>();
            
            try
            {
                using (var cn = ConexionBd.GetInstancia().GetConexion())
                {
                    string cadenaComando = "SELECT TipoNuezId, Descripcion FROM TipoNueces";
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }


        private TipoNuez ConstruirTipo(SqlDataReader reader)
        {
            return new TipoNuez()
            {
                TipoNuezId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

    }
}

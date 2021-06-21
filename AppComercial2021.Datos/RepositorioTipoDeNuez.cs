using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Datos
{
    public class RepositorioTipoDeNuez
    {
        private ConexionBd conexionBd;

        public RepositorioTipoDeNuez()
        {

        }

        public List<TipoNuez> GetLista()
        {
            List<TipoNuez> lista = new List<TipoNuez>();
            SqlCommand comando = null;
            try
            {
                conexionBd = new ConexionBd();
                var cn = conexionBd.GetConexion();
                cn.Open();
                string cadenaComando = "SELECT TipoNuezId, Descripcion FROM TipoDeNueces";
                comando = new SqlCommand(cadenaComando, cn);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var tipo = ConstruirTipo(reader);
                    lista.Add(tipo);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                comando.Connection.Close();
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

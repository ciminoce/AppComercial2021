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
            SqlCommand comando = null;
            try
            {
                conexionBd = new ConexionBd();
                var cn = conexionBd.GetConexion();
                cn.Open();
                string cadenaComando = "SELECT TipoChocolateId, Descripcion FROM TipoDeChocolates";
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

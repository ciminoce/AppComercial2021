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
        private ConexionBd conexionBd;

        public RepositorioTipoDeRelleno()
        {
            
        }

        public List<TipoRelleno> GetLista()
        {
            List<TipoRelleno> lista = new List<TipoRelleno>();
            SqlCommand comando = null;
            try
            {
                conexionBd = new ConexionBd();
                var cn = conexionBd.GetConexion();
                cn.Open();
                string cadenaComando = "SELECT TipoRellenoId, Descripcion FROM TipoDeRellenos";
                comando = new SqlCommand(cadenaComando, cn);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var tipo = ConstruirTipo(reader);
                    lista.Add(tipo);
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al crear o abrir la conexión");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar leer los datos de la tabla de Rellenos");
            }
            finally
            {
                if (comando!=null)
                {
                    if (comando.Connection.State == ConnectionState.Open)
                    {
                        comando.Connection.Close();

                    }

                }            }

            return lista;
        }


        private TipoRelleno ConstruirTipo(SqlDataReader reader)
        {
            return new TipoRelleno()
            {
                TipoRellenoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }
    }
}

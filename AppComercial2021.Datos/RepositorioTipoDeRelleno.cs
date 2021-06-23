﻿using System;
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
            catch (Exception ex)
            {
                throw new Exception("Error al intentar leer los datos de la tabla de Rellenos o al establecer la conexión");
            }
            finally
            {
                if (comando != null)
                {
                    if (comando.Connection.State == ConnectionState.Open)
                    {
                        comando.Connection.Close();
                        comando.Connection.Dispose();
                    }

                }
            }

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

        public int Agregar(TipoRelleno tipoRelleno)
        {
            int registrosAfectados = 0;
            try
            {
                conexionBd = new ConexionBd();
                var cn = conexionBd.GetConexion();
                string cadenaComando = "INSERT INTO TipoDeRellenos VALUES (@desc)";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@desc", tipoRelleno.Descripcion);
                cn.Open();
                registrosAfectados = comando.ExecuteNonQuery();
                cadenaComando = "SELECT @@IDENTITY";
                comando = new SqlCommand(cadenaComando, cn);
                tipoRelleno.TipoRellenoId=(int)(decimal)comando.ExecuteScalar();
                cn.Close();
                cn.Dispose();
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
                conexionBd = new ConexionBd();
                var cn = conexionBd.GetConexion();
                string cadenaComando = "DELETE FROM TipoDeRellenos WHERE TipoRellenoId=@id";
                var comando = new SqlCommand(cadenaComando, cn);
                comando.Parameters.AddWithValue("@id", tipoRellenoId);
                cn.Open();
                registrosAfectados = comando.ExecuteNonQuery();
                cn.Close();
                cn.Dispose();
                return registrosAfectados;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}

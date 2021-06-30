using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace AppComercial2021.Datos
{
    public class ConexionBd
    {
         private string cadenaDeConexion;
         private SqlConnection cn;

         public static ConexionBd instancia;
         //Patrón Singleton
         public static ConexionBd GetInstancia()
         {
             if (instancia==null)
             {
                 instancia = new ConexionBd();
             }

             return instancia;
         }
         private ConexionBd()
         {
             this.cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
         }

         public SqlConnection GetConexion()
         {
             try
             {
                 cn = new SqlConnection(cadenaDeConexion);
                 cn.Open();
                 return cn;
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }
    }
    
}

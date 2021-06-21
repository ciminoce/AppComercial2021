using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppComercial2021.Datos
{
    public class ConexionBd
    {
         private string cadenaDeConexion;
         private SqlConnection cn;

         public ConexionBd()
         {
             this.cadenaDeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
         }

         public SqlConnection GetConexion()
         {
             try
             {
                 cn = new SqlConnection(cadenaDeConexion);
                 return cn;
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }
    }
    
}

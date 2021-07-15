using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Datos;
using AppComercial2021.Entidades.DTOs;

namespace AppComercial2021.Servicios
{
    public class ServicioLocalidad
    {
        public static ServicioLocalidad instancia;

        public static ServicioLocalidad GetInstancia()
        {
            if (instancia==null)
            {
                instancia = new ServicioLocalidad();
            }

            return instancia;
        }

        private ServicioLocalidad()
        {
            
        }

        public List<LocalidadDto> GetLista()
        {
            try
            {
                return RepositorioLocalidad.GetInstancia().GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

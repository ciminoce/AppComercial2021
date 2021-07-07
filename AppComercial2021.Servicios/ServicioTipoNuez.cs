using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Datos;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Servicios
{
    public class ServicioTipoNuez
    {
        private RepositorioTipoNuez repositorio;
        public ServicioTipoNuez()
        {

        }

        public List<TipoNuez> GetLista()
        {
            try
            {
                repositorio = RepositorioTipoNuez.GetInstancia();
                var lista = repositorio.GetLista();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Datos;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Servicios
{
    public class ServicioTipoDeNuez
    {
        private RepositorioTipoDeNuez repositorio;
        public ServicioTipoDeNuez()
        {

        }

        public List<TipoNuez> GetLista()
        {
            try
            {
                repositorio = RepositorioTipoDeNuez.GetInstancia();
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

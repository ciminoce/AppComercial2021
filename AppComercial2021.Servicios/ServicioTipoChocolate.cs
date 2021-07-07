using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Datos;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Servicios
{
    public class ServicioTipoChocolate
    {
        private RepositorioTipoChocolate repositorio;
        public ServicioTipoChocolate()
        {

        }

        public List<TipoChocolate> GetLista()
        {
            try
            {
                repositorio = new RepositorioTipoChocolate();
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

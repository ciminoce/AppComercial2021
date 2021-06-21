using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Datos;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Servicios
{
    public class ServicioTipoDeChocolate
    {
        private RepositorioTipoDeChocolate repositorio;
        public ServicioTipoDeChocolate()
        {

        }

        public List<TipoChocolate> GetLista()
        {
            try
            {
                repositorio = new RepositorioTipoDeChocolate();
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

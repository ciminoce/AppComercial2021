using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Datos;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Servicios
{
    public class ServicioTipoDeRelleno
    {
        private RepositorioTipoDeRelleno repositorio;

        public ServicioTipoDeRelleno()
        {
            
        }

        public List<TipoRelleno> GetLista()
        {
            try
            {
                repositorio = new RepositorioTipoDeRelleno();
                var lista = repositorio.GetLista();
                return lista;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Agregar(TipoRelleno tipoRelleno)
        {
            try
            {
                repositorio = new RepositorioTipoDeRelleno();
                return repositorio.Agregar(tipoRelleno);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int Borrar(int tipoRellenoId)
        {
            try
            {
                repositorio = new RepositorioTipoDeRelleno();
                return repositorio.Borrar(tipoRellenoId);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

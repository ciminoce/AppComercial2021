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
        public static ServicioTipoDeRelleno instancia;

        public static ServicioTipoDeRelleno GetInstancia()
        {
            if (instancia==null)
            {
                instancia = new ServicioTipoDeRelleno();
            }

            return instancia;
        }
        private ServicioTipoDeRelleno()
        {
            
        }

        public List<TipoRelleno> GetLista()
        {
            try
            {
                repositorio = RepositorioTipoDeRelleno.GetInstancia();
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
                repositorio = RepositorioTipoDeRelleno.GetInstancia();
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
                repositorio = RepositorioTipoDeRelleno.GetInstancia();
                return repositorio.Borrar(tipoRellenoId);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int Editar(TipoRelleno tipoRelleno)
        {
            try
            {
                repositorio = RepositorioTipoDeRelleno.GetInstancia();
                return repositorio.Editar(tipoRelleno);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

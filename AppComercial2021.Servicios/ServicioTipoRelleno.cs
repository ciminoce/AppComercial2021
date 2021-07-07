using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Datos;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Servicios
{
    public class ServicioTipoRelleno
    {
        private RepositorioTipoRelleno repositorio;
        public static ServicioTipoRelleno instancia;

        public static ServicioTipoRelleno GetInstancia()
        {
            if (instancia==null)
            {
                instancia = new ServicioTipoRelleno();
            }

            return instancia;
        }
        private ServicioTipoRelleno()
        {
            
        }

        public List<TipoRelleno> GetLista()
        {
            try
            {
                repositorio = RepositorioTipoRelleno.GetInstancia();
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
                repositorio = RepositorioTipoRelleno.GetInstancia();
                return repositorio.Agregar(tipoRelleno);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EstaRelacionado(TipoRelleno tipoRelleno)
        {
            try
            {
                return RepositorioTipoRelleno.GetInstancia().EstaRelacionado(tipoRelleno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public bool Existe(TipoRelleno tipoRelleno)
        {
            try
            {
                return RepositorioTipoRelleno.GetInstancia().Existe(tipoRelleno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Borrar(TipoRelleno tipoRelleno)
        {
            try
            {
                repositorio = RepositorioTipoRelleno.GetInstancia();
                return repositorio.Borrar(tipoRelleno);

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
                repositorio = RepositorioTipoRelleno.GetInstancia();
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

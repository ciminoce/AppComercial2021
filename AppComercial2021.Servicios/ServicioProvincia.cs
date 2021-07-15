using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Datos;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Servicios
{
    public class ServicioProvincia
    {
        private RepositorioProvincia repositorio;
        public static ServicioProvincia instancia;

        public static ServicioProvincia GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new ServicioProvincia();
            }

            return instancia;
        }
        private ServicioProvincia()
        {

        }

        public List<Provincia> GetLista()
        {
            try
            {
                return RepositorioProvincia.GetInstancia().GetLista();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Agregar(Provincia tipoRelleno)
        {
            try
            {
                repositorio = RepositorioProvincia.GetInstancia();
                return repositorio.Agregar(tipoRelleno);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool EstaRelacionado(Provincia tipoRelleno)
        {
            try
            {
                return RepositorioProvincia.GetInstancia().EstaRelacionado(tipoRelleno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public bool Existe(Provincia tipoRelleno)
        {
            try
            {
                return RepositorioProvincia.GetInstancia().Existe(tipoRelleno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int Borrar(Provincia tipoRelleno)
        {
            try
            {
                repositorio = RepositorioProvincia.GetInstancia();
                return repositorio.Borrar(tipoRelleno);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Editar(Provincia tipoRelleno)
        {
            try
            {
                repositorio = RepositorioProvincia.GetInstancia();
                return repositorio.Editar(tipoRelleno);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppComercial2021.Datos;
using AppComercial2021.Entidades.DTOs;
using AppComercial2021.Entidades.Entidades;

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

        public bool Existe(Localidad localidad)
        {
            try
            {
                return RepositorioLocalidad.GetInstancia().Existe(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

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

        public int Agregar(Localidad localidad)
        {
            try
            {
                return RepositorioLocalidad.GetInstancia().Agregar(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public int Editar(Localidad localidad)
        {
            try
            {
                return RepositorioLocalidad.GetInstancia().Editar(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public int Borrar(Localidad localidad)
        {
            try
            {
                return RepositorioLocalidad.GetInstancia().Borrar(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public Localidad GetLocalidadPorId(int id)
        {
            try
            {
                return RepositorioLocalidad.GetInstancia().GetLocalidadPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Localidad localidad)
        {
            try
            {
                return RepositorioLocalidad.GetInstancia().EstaRelacionado(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AppComercial2021.Entidades.Entidades
{
    public class Localidad
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public Provincia Provincia { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppComercial2021.Entidades.Entidades
{
    public class TipoRelleno
    {
        public int TipoRellenoId { get; set; }
        public string Descripcion { get; set; }
        public byte[] RowVersion { get; set; }

        public bool Validar()
        {
            bool esValido = true;
            if (string.IsNullOrEmpty(Descripcion) || string.IsNullOrWhiteSpace(Descripcion))
            {
                esValido = false;
            }

            return esValido;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppComercial2021.Entidades.Entidades
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }
        public string NombreProvincia { get; set; }
        public byte[] RowVersion { get; set; }

        public bool Validar()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(NombreProvincia))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppComercial2021.Entidades.Entidades;
using AppComercial2021.Servicios;

namespace AppComercial2021.Windows.Helpers
{
    public class HelperCombo
    {
        public static void CargarDatosComboProvincias(ref ComboBox combo)
        {
            List<Provincia> lista = ServicioProvincia.GetInstancia().GetLista();
            Provincia defaultProvincia = new Provincia()
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccione Provincia>"
            };
            lista.Insert(0,defaultProvincia);
            combo.DataSource = lista;
            combo.DisplayMember = "NombreProvincia";
            combo.ValueMember = "ProvinciaId";
            combo.SelectedIndex = 0;
        }
    }
}

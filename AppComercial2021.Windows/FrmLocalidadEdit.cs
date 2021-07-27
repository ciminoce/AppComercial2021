using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppComercial2021.Entidades.Entidades;
using AppComercial2021.Windows.Helpers;

namespace AppComercial2021.Windows
{
    public partial class FrmLocalidadEdit : Form
    {
        public FrmLocalidadEdit()
        {
            InitializeComponent();
        }

        private Localidad localidad;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HelperCombo.CargarDatosComboProvincias(ref ProvinciasComboBox);
            if (localidad==null)
            {
                TareaLabel.Text = "Nueva Localidad";
            }
            else
            {
                TareaLabel.Text = "Editar Localidad";
            }

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidad==null)
                {
                    localidad = new Localidad();
                }

                localidad.NombreLocalidad = LocalidadTextBox.Text;
                localidad.Provincia =(Provincia) ProvinciasComboBox.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool esValido = true;
            if (ProvinciasComboBox.SelectedIndex==0)
            {
                esValido = false;
                errorProvider1.SetError(ProvinciasComboBox,"Debe seleccionar una provincia");
            }

            if (string.IsNullOrEmpty(LocalidadTextBox.Text))
            {
                esValido = false;
                errorProvider1.SetError(LocalidadTextBox,"Debe ingresar el nombre de una localidad");
            }

            return esValido;
        }

        public Localidad GetLocalidad()
        {
            return localidad;
        }
    }
}

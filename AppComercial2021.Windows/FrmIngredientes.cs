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
using AppComercial2021.Entidades.Enums;
using AppComercial2021.Servicios;
using AppComercial2021.Windows.Helpers;

namespace AppComercial2021.Windows
{
    public partial class FrmIngredientes : Form
    {
        public FrmIngredientes()
        {
            InitializeComponent();
        }

        private ServicioTipoDeRelleno servicioRellenos;
        private ServicioTipoDeChocolate servicioChocolate;
        private ServicioTipoDeNuez servicioNuez;

        private List<TipoRelleno> listaRellenos;
        private List<TipoChocolate> listaChocolates;
        private List<TipoNuez> listaNueces;

        private OperacionesBd operacion;
        private TipoRelleno tipoRelleno;

        private DataGridViewRow r;
        private void CargarRellenosToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //servicioRellenos = ServicioTipoDeRelleno.GetInstancia()
                listaRellenos = ServicioTipoDeRelleno.GetInstancia().GetLista();
                MostrarDatosRellenosEnGrilla();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MostrarDatosRellenosEnGrilla()
        {
            HelperGrid.LimpiarGrilla(RellenosDataGridView);
            foreach (var relleno in listaRellenos)
            {
                r = HelperGrid.ConstruirFila(RellenosDataGridView);
                HelperGrid.SetearFila(r, relleno);
                HelperGrid.AgregarFila(RellenosDataGridView,r);
            }
        }
        private void ManejarBotonesNueces(bool habilitado)
        {
            CargarNuecesToolStripButton.Enabled = habilitado;
            NuevoNuecesToolStripButton.Enabled = habilitado;
            BorrarNuecesToolStripButton.Enabled = habilitado;
            EditarNuecesToolStripButton.Enabled = habilitado;

            OKNuecesToolStripButton.Enabled = !habilitado;
            CancelarNuecesToolStripButton.Enabled = !habilitado;
            ImprimirNuecesToolStripButton.Enabled = habilitado;
            CerrarNuecesToolStripButton.Enabled = habilitado;
        }

        private void ManejarBotonesRellenos(bool habilitado)
        {
            CargarRellenosToolStripButton.Enabled = habilitado;
            NuevoRellenoToolStripButton.Enabled = habilitado;
            BorrarRellenoToolStripButton.Enabled = habilitado;
            EditarRellenoToolStripButton.Enabled = habilitado;

            OKRellenoToolStripButton.Enabled = !habilitado;
            CancelarRellenoToolStripButton.Enabled = !habilitado;
            ImprimirRellenoToolStripButton.Enabled = habilitado;
            CerrarRellenoToolStripButton.Enabled = habilitado;
        }
        private void ManejarBotonesChocolates(bool habilitado)
        {
            CargarChocolatesToolStripButton.Enabled = habilitado;
            NuevoChocolateToolStripButton.Enabled = habilitado;
            BorrarChocolateToolStripButton.Enabled = habilitado;
            EditarChocolateToolStripButton.Enabled = habilitado;

            OKChocolatesToolStripButton.Enabled = !habilitado;
            CancelarChocolatesToolStripButton.Enabled = !habilitado;
            ImprimirChocolatesToolStripButton.Enabled = habilitado;
            CerrarChocolatesToolStripButton.Enabled = habilitado;
        }

        private void FrmIngredientes_Load(object sender, EventArgs e)
        {
            ManejarBotonesRellenos(true);
            ManejarBotonesChocolates(true);
            ManejarBotonesNueces(true);

            HabilitarTextBoxRellenos(false);

        }

        private void CerrarRellenoToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarChocolatesToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                servicioChocolate = new ServicioTipoDeChocolate();
                listaChocolates = servicioChocolate.GetLista();
                MostrarDatosChocolatesEnGrilla();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosChocolatesEnGrilla()
        {
            HelperGrid.LimpiarGrilla(ChocolatesDataGridView);
            foreach (var chocolate  in listaChocolates)
            {
                r = HelperGrid.ConstruirFila(ChocolatesDataGridView);
                HelperGrid.SetearFila(r, chocolate);
                HelperGrid.AgregarFila(ChocolatesDataGridView,r);
            }
        }

        private void CargarNuecesToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                servicioNuez = new ServicioTipoDeNuez();
                listaNueces = servicioNuez.GetLista();
                MostrarDatosNuecesEnGrilla();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosNuecesEnGrilla()
        {
            HelperGrid.LimpiarGrilla(NuecesDataGridView);
            foreach (var nuez in listaNueces)
            {
                r = HelperGrid.ConstruirFila(NuecesDataGridView);
                HelperGrid.SetearFila(r, nuez);
                HelperGrid.AgregarFila(NuecesDataGridView,r);
            }

        }


        private void CerrarNuecesToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CerrarChocolatesToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HabilitarTextBoxRellenos(bool habilitado)
        {
            RellenoTextBox.Enabled = habilitado;
        }

        private void NuevoRellenoToolStripButton_Click(object sender, EventArgs e)
        {
            operacion = OperacionesBd.Agregar;
            HabilitarTextBoxRellenos(true);
            ManejarBotonesRellenos(false);
            RellenoTextBox.Focus();
        }

        private void CancelarRellenoToolStripButton_Click(object sender, EventArgs e)
        {
            RellenoTextBox.Clear();
            errorProvider1.Clear();
            HabilitarTextBoxRellenos(false);
            ManejarBotonesRellenos(true);
        }

        private void OKRellenoToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                errorProvider1.Clear();
                if (operacion==OperacionesBd.Agregar)
                {
                    tipoRelleno = new TipoRelleno()
                    {
                        Descripcion = RellenoTextBox.Text
                    };

                    if (tipoRelleno.Validar())
                    {
                        //TODO:Verificar antes que no haya duplicados
                        int registrosGuardados = ServicioTipoDeRelleno.GetInstancia().Agregar(tipoRelleno);
                        MessageBox.Show($"Se agregaron {registrosGuardados} registro/s", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        if (registrosGuardados == 0)
                        {
                            return;
                        }

                        r = HelperGrid.ConstruirFila(RellenosDataGridView);
                        HelperGrid.SetearFila(r, tipoRelleno);
                        HelperGrid.AgregarFila(RellenosDataGridView, r);

                    }
                    else
                    {
                        errorProvider1.SetError(RellenoTextBox,"Debe ingresar un relleno");
                        return;
                    }
                }

                if (operacion==OperacionesBd.Editar)
                {
                    tipoRelleno.Descripcion = RellenoTextBox.Text;

                    if (tipoRelleno.Validar())
                    {
                        int registrosGuardados = ServicioTipoDeRelleno.GetInstancia().Editar(tipoRelleno);
                        MessageBox.Show($"Se editaron {registrosGuardados} registro/s", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        if (registrosGuardados == 0)
                        {
                            return;
                        }
                        HelperGrid.SetearFila(r, tipoRelleno);

                    }
                    else
                    {
                        errorProvider1.SetError(RellenoTextBox, "Debe ingresar un relleno");
                        return;

                    }
                }
                RellenoTextBox.Clear();
                ManejarBotonesRellenos(true);
                HabilitarTextBoxRellenos(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarRellenoToolStripButton_Click(object sender, EventArgs e)
        {
            if (RellenosDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            r = RellenosDataGridView.SelectedRows[0];
            tipoRelleno =(TipoRelleno) r.Tag;
            DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr==DialogResult.Yes)
            {
                try
                {
                    int registrosBorrados = ServicioTipoDeRelleno.GetInstancia().Borrar(tipoRelleno.TipoRellenoId);
                    MessageBox.Show($"Se borraron {registrosBorrados} registro/s", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    if (registrosBorrados == 0)
                    {
                        return;
                    }

                    HelperGrid.QuitarFila(RellenosDataGridView, r);
                    ManejarBotonesRellenos(true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void EditarRellenoToolStripButton_Click(object sender, EventArgs e)
        {
            if (RellenosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            operacion = OperacionesBd.Editar;
            r = RellenosDataGridView.SelectedRows[0];
            tipoRelleno = (TipoRelleno) r.Tag;
            HabilitarTextBoxRellenos(true);
            ManejarBotonesRellenos(false);
            MostrarEnControlesTipoRelleno(tipoRelleno);
        }

        private void MostrarEnControlesTipoRelleno(TipoRelleno tipoRelleno)
        {
            RellenoTextBox.Text = tipoRelleno.Descripcion;
            RellenoTextBox.Focus();
        }
    }
}

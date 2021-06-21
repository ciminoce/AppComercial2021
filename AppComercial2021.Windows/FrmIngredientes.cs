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
using AppComercial2021.Servicios;

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

        private void CargarRellenosToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                servicioRellenos = new ServicioTipoDeRelleno();
                listaRellenos = servicioRellenos.GetLista();
                MostrarDatosRellenosEnGrilla();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MostrarDatosRellenosEnGrilla()
        {
            RellenosDataGridView.Rows.Clear();
            foreach (var relleno in listaRellenos)
            {
                DataGridViewRow r = ConstruirFilaRelleno();
                SetearFilaRelleno(r, relleno);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            RellenosDataGridView.Rows.Add(r);
        }

        private void SetearFilaRelleno(DataGridViewRow r, TipoRelleno relleno)
        {
            r.Cells[colRelleno.Index].Value = relleno.Descripcion;

            r.Tag = relleno;
        }

        

        private DataGridViewRow ConstruirFilaRelleno()
        {
            DataGridViewRow r=new DataGridViewRow();
            r.CreateCells(RellenosDataGridView);
            return r;
        }
        private void ManejarBotonesNueces(bool habilitado)
        {
            CargarNuecesToolStripButton.Enabled = habilitado;
            NuevoNuecesToolStripButton.Enabled = habilitado;
            BorrarNuecesToolStripButton.Enabled = habilitado;
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
            ChocolatesDataGridView.Rows.Clear();
            foreach (var chocolate  in listaChocolates)
            {
                DataGridViewRow r = ConstruirFilaChocolate();
                SetearFilaChocolate(r, chocolate);
                AgregarFilaChocolate(r);
            }
        }

        private void AgregarFilaChocolate(DataGridViewRow r)
        {
            ChocolatesDataGridView.Rows.Add(r);
        }

        private void SetearFilaChocolate(DataGridViewRow r, TipoChocolate chocolate)
        {
            r.Cells[colChocolate.Index].Value = chocolate.Descripcion;

            r.Tag = chocolate;

        }

        private DataGridViewRow ConstruirFilaChocolate()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(ChocolatesDataGridView);
            return r;
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
            NuecesDataGridView.Rows.Clear();
            foreach (var nuez in listaNueces)
            {
                DataGridViewRow r = ConstruirFilaNuez();
                SetearFilaNuez(r, nuez);
                AgregarFilaNueces(r);
            }

        }

        private void AgregarFilaNueces(DataGridViewRow r)
        {
            NuecesDataGridView.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFilaNuez()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(NuecesDataGridView);
            return r;
        }

        private void SetearFilaNuez(DataGridViewRow r, TipoNuez nuez)
        {
            r.Cells[colNuez.Index].Value = nuez.Descripcion;

            r.Tag = nuez;
        }

        private void CerrarNuecesToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CerrarChocolatesToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

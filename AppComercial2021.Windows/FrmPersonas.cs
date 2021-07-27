using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppComercial2021.Entidades.DTOs;
using AppComercial2021.Entidades.Entidades;
using AppComercial2021.Entidades.Enums;
using AppComercial2021.Servicios;
using AppComercial2021.Windows.Helpers;

namespace AppComercial2021.Windows
{
    public partial class FrmPersonas : Form
    {
        public FrmPersonas()
        {
            InitializeComponent();
        }

        private List<Provincia> listaProvincia;
        private Provincia provincia;

        private List<LocalidadDto> listaLocalidad;
        private Localidad localidad;

        private DataGridViewRow r;
        private OperacionesBd operacion;
        private void FrmPersonas_Load(object sender, EventArgs e)
        {
            ManejarBotonesProvincias(true);
            HabilitarTextBoxProvincias(false);


        }


        #region Código para el manejo de Provincias



        private void CargarProvinciasToolStripButton_Click(object sender, EventArgs e)
        {
            RellenarGrillaProvincias();
        }

        private void RellenarGrillaProvincias()
        {
            try
            {
                listaProvincia = ServicioProvincia.GetInstancia().GetLista();
                MostrarDatosProvinciasEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosProvinciasEnGrilla()
        {
            HelperGrid.LimpiarGrilla(ProvinciasDataGridView);
            foreach (var provincia in listaProvincia)
            {
                r = HelperGrid.ConstruirFila(ProvinciasDataGridView);
                HelperGrid.SetearFila(r, provincia);
                HelperGrid.AgregarFila(ProvinciasDataGridView, r);
            }
        }

        private void NuevoProvinciaToolStripButton_Click(object sender, EventArgs e)
        {
            operacion = OperacionesBd.Agregar;
            HabilitarTextBoxProvincias(true);
            ManejarBotonesProvincias(false);
            ProvinciaTextBox.Focus();

        }

        private void BorrarProvinciaToolStripButton_Click(object sender, EventArgs e)
        {
            if (ProvinciasDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            r = ProvinciasDataGridView.SelectedRows[0];
            provincia = (Provincia)r.Tag;
            DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                try
                {

                    if (!ServicioProvincia.GetInstancia().EstaRelacionado(provincia))
                    {
                        int registrosBorrados = ServicioProvincia.GetInstancia().Borrar(provincia);
                        if (registrosBorrados == 0)
                        {
                            MessageBox.Show("Registro borrado o modificado por otro usuario", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RellenarGrillaProvincias();
                            return;

                        }
                        MessageBox.Show($"Se borraron {registrosBorrados} registro/s", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        HelperGrid.QuitarFila(ProvinciasDataGridView, r);

                    }
                    else
                    {
                        MessageBox.Show("Registro relacionado... Baja denegada", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    ManejarBotonesProvincias(true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void EditarProvinciaToolStripButton_Click(object sender, EventArgs e)
        {
            if (ProvinciasDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            operacion = OperacionesBd.Editar;
            r = ProvinciasDataGridView.SelectedRows[0];
            provincia = (Provincia)r.Tag;
            HabilitarTextBoxProvincias(true);
            ManejarBotonesProvincias(false);
            MostrarEnControlesProvincias(provincia);

        }

        private void MostrarEnControlesProvincias(Provincia provincia)
        {
            ProvinciaTextBox.Text = provincia.NombreProvincia;
        }

        private void OKProvinciaToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (operacion == OperacionesBd.Agregar)
                {
                    provincia = new Provincia()
                    {
                        NombreProvincia = ProvinciaTextBox.Text
                    };

                    if (provincia.Validar())
                    {
                        if (ServicioProvincia.GetInstancia().Existe(provincia))
                        {
                            MessageBox.Show("Registro existente... Alta denegada", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ProvinciaTextBox.SelectAll();
                            ProvinciaTextBox.Focus();
                            return;
                        }
                        int registrosGuardados = ServicioProvincia.GetInstancia().Agregar(provincia);
                        MessageBox.Show($"Se agregaron {registrosGuardados} registro/s", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        if (registrosGuardados == 0)
                        {
                            return;
                        }

                        r = HelperGrid.ConstruirFila(ProvinciasDataGridView);
                        HelperGrid.SetearFila(r, provincia);
                        HelperGrid.AgregarFila(ProvinciasDataGridView, r);

                    }
                    else
                    {
                        errorProvider1.SetError(ProvinciaTextBox, "Debe ingresar una provincia");
                        return;
                    }
                }

                if (operacion == OperacionesBd.Editar)
                {
                    provincia.NombreProvincia = ProvinciaTextBox.Text;

                    if (provincia.Validar())
                    {
                        if (ServicioProvincia.GetInstancia().Existe(provincia))
                        {
                            MessageBox.Show("Registro existente... Edición denegada", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ProvinciaTextBox.SelectAll();
                            ProvinciaTextBox.Focus();
                            return;
                        }

                        int registrosGuardados = ServicioProvincia.GetInstancia().Editar(provincia);
                        if (registrosGuardados == 0)
                        {
                            MessageBox.Show("Registro inexistente o modificado por otro usuario", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            RellenarGrillaProvincias();

                            return;
                        }
                        MessageBox.Show($"Se editaron {registrosGuardados} registro/s", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        HelperGrid.SetearFila(r, provincia);

                    }
                    else
                    {
                        errorProvider1.SetError(ProvinciaTextBox, "Debe ingresar un relleno");
                        return;

                    }
                }
                ProvinciaTextBox.Clear();
                ManejarBotonesProvincias(true);
                HabilitarTextBoxProvincias(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CancelarProvinciaToolStripButton_Click(object sender, EventArgs e)
        {
            ProvinciaTextBox.Clear();
            errorProvider1.Clear();
            HabilitarTextBoxProvincias(false);
            ManejarBotonesProvincias(true);

        }

        private void HabilitarTextBoxProvincias(bool habilitado)
        {
            ProvinciaTextBox.Enabled = habilitado;
        }

        private void ManejarBotonesProvincias(bool habilitado)
        {
            CargarProvinciasToolStripButton.Enabled = habilitado;
            NuevoProvinciaToolStripButton.Enabled = habilitado;
            BorrarProvinciaToolStripButton.Enabled = habilitado;
            EditarProvinciaToolStripButton.Enabled = habilitado;

            OKProvinciaToolStripButton.Enabled = !habilitado;
            CancelarProvinciaToolStripButton.Enabled = !habilitado;
            ImprimirProvinciaToolStripButton.Enabled = habilitado;
            CerrarProvinciaToolStripButton.Enabled = habilitado;
        }
        private void CerrarProvinciaToolStripButton_Click(object sender, EventArgs e)
        {
            Close();

        }
        #endregion

        #region Código para el manejo de Localidades


        private void CargarLocalidadToolStripButton_Click(object sender, EventArgs e)
        {
            RellenarGrillaLocalidades();
        }

        private void RellenarGrillaLocalidades()
        {
            try
            {
                listaLocalidad = ServicioLocalidad.GetInstancia().GetLista();
                MostrarDatosLocalidadesEnGrilla();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosLocalidadesEnGrilla()
        {
            HelperGrid.LimpiarGrilla(LocalidadesDataGridView);
            foreach (var localidadDto in listaLocalidad)
            {
                r = HelperGrid.ConstruirFila(LocalidadesDataGridView);
                HelperGrid.SetearFila(r, localidadDto);
                HelperGrid.AgregarFila(LocalidadesDataGridView, r);
            }
        }

        private void CerrarLocalidadToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void NuevoLocalidadToolStripButton_Click(object sender, EventArgs e)
        {
            FrmLocalidadEdit frm = new FrmLocalidadEdit();
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Localidad localidad = frm.GetLocalidad();
                if (ServicioLocalidad.GetInstancia().Existe(localidad))
                {
                    MessageBox.Show("Registro existente... Alta denegada", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return;

                }
                int registrosGuardados = ServicioLocalidad.GetInstancia().Agregar(localidad);
                MessageBox.Show($"Se agregaron {registrosGuardados} registro/s", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                if (registrosGuardados == 0)
                {
                    return;
                }

                LocalidadDto localidadDto = new LocalidadDto()
                {
                    LocalidadId = localidad.LocalidadId,
                    NombreLocalidad = localidad.NombreLocalidad,
                    NombreProvincia = localidad.Provincia.NombreProvincia
                };

                r = HelperGrid.ConstruirFila(LocalidadesDataGridView);
                HelperGrid.SetearFila(r, localidadDto);
                HelperGrid.AgregarFila(LocalidadesDataGridView, r);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void BorrarLocalidadToolStripButton_Click(object sender, EventArgs e)
        {
            if (LocalidadesDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            DataGridViewRow r = LocalidadesDataGridView.SelectedRows[0];
            LocalidadDto localidadDto =(LocalidadDto) r.Tag;
            try
            {
                Localidad localidad = ServicioLocalidad.GetInstancia()
                    .GetLocalidadPorId(localidadDto.LocalidadId);
                if (localidad == null)
                {
                    MessageBox.Show("Registro Inexistente o borrado por otro usuario...",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    if (!ServicioLocalidad.GetInstancia().EstaRelacionado(localidad))
                    {
                        int registrosBorrados = ServicioLocalidad.GetInstancia().Borrar(localidad);
                        if (registrosBorrados == 0)
                        {
                            MessageBox.Show("Registro borrado o modificado por otro usuario", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            RellenarGrillaLocalidades();
                            return;

                        }

                        MessageBox.Show($"Se borraron {registrosBorrados} registro/s", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        HelperGrid.QuitarFila(LocalidadesDataGridView, r);

                    }
                    else
                    {
                        MessageBox.Show("Registro relacionado... Baja denegada", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

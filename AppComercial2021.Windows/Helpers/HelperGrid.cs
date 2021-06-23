using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppComercial2021.Entidades.Entidades;

namespace AppComercial2021.Windows.Helpers
{
    public class HelperGrid
    {
        public static void AgregarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Add(r);
        }
        public static void SetearFila(DataGridViewRow r, Object obj)
        {
            if (obj is TipoRelleno)
            {
                r.Cells[0].Value = ((TipoRelleno) obj).Descripcion;
            }else if (obj is TipoChocolate)
            {
                r.Cells[0].Value = ((TipoChocolate) obj).Descripcion;
            }else if (obj is TipoNuez)
            {
                r.Cells[0].Value = ((TipoNuez) obj).Descripcion;
            }

            r.Tag = obj;
        }
        public static DataGridViewRow ConstruirFila(DataGridView dataGridView)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridView);
            return r;
        }
        public static void LimpiarGrilla(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
        }

        public static void QuitarFila(DataGridView dataGridView, DataGridViewRow r)
        {
            dataGridView.Rows.Remove(r);
        }
    }
}

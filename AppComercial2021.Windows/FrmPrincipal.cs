using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppComercial2021.Windows
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngredientes frm = new FrmIngredientes();
            frm.Show();

        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Desea salir de la aplicación?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

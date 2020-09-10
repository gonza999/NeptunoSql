using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeptunoSql.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarcas frm=new FrmMarcas();
            frm.ShowDialog(this);

        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias frm = new FrmCategorias();
            frm.ShowDialog(this);
        }
    }
}

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
    public partial class FrmCategoriasAE : Form
    {
        private FrmCategorias frmCategorias;

        public FrmCategoriasAE(FrmCategorias frmCategorias)
        {
            InitializeComponent();
            this.frmCategorias = frmCategorias;
        }
    }
}

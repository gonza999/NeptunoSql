using System.Windows.Forms;
using NeptunoSql.Windows.Helpers.Enum;

namespace NeptunoSql.Windows.Helpers
{
    public class Helper
    {
        public static void MensajeBox(string mensaje, Tipo tipo)
        {
            switch (tipo)
            {
                case Tipo.Success:
                    MessageBox.Show(mensaje, "Operación Exitosa", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;
                case Tipo.Error:
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    break;
                //case Tipo.Warning:
                //    break;
                //case Tipo.Question:
                //    break;
                //default:
                //    break;
            }
        }
        public static DialogResult MensajeBox(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmar operación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

    }
}

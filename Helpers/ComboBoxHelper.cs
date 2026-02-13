using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscritorioUPT.Helpers
{
    public static class ComboBoxHelper
    {
        /// <summary>
        /// Carga un ComboBox con una lista y agrega la opción
        /// "Selecciona una opción" como primer elemento.
        /// </summary>
        public static void CargarConSeleccionDefault<T>(
            ComboBox combo,
            IEnumerable<T> lista,
            string displayMember,
            string valueMember,
            T itemDefault)
        {
            var data = lista.ToList();
            data.Insert(0, itemDefault);

            combo.DataSource = null;
            combo.DataSource = data;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.SelectedIndex = 0;
        }
    }
}

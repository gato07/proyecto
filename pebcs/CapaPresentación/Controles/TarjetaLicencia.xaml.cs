using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CapaPresentación.Controles
{
    /// <summary>
    /// Lógica de interacción para TarjetaLicencia.xaml
    /// </summary>
    public partial class TarjetaLicencia : UserControl
    {
        String[] datos = new string[7];
        public TarjetaLicencia()
        {
            InitializeComponent();
        }
        public void CargaDatosLicencia(int ID,string etiqueta,string NoLicencia,string folio,string tipoobra,string uso ,string presupuesto)
        {
            datos[0] = ID.ToString();
            datos[1] = etiqueta;
            datos[2] = folio;
            datos[3] = NoLicencia;
            datos[4] = tipoobra;
            datos[5] = uso;
            datos[6] = presupuesto;
            titulo.Content =etiqueta;
            TXT_Folio.Text = folio;
            TXT_NoLicencia.Text = NoLicencia;
            TXT_TipoObra.Text = tipoobra;
            TXT_Uso.Text = uso;
            TXT_presupuesto.Text = presupuesto;
        }
    }
}

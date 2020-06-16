using CapaLogica;
using CapaPresentación.Controles;
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
using System.IO;
using System.Data;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaLicencias.xaml
    /// </summary>
    public partial class PantallaLicencias : UserControl
    {
        Menu_Principal2 Mn;
        public PantallaLicencias(object A) 
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
            GenerarLicencias();
        }
        private void GenerarLicencias()
        {
            Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
            DataTable Licenciasactivas = proyecto_.SelPRES1XCampoEliminado();
            Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
            TarjetaLicencia[] tarjetaLicencias = new TarjetaLicencia[Licenciasactivas.Rows.Count];
            for(int x=0;x<tarjetaLicencias.Length;x++)
            {
                Documentacion_Licencia docLi = new Documentacion_Licencia();
                tarjetaLicencias[x] = new TarjetaLicencia(Mn);
                tarjetaLicencias[x].CargaDatosLicencia(Convert.ToInt32(Licenciasactivas.Rows[x]["Numero"]), Licenciasactivas.Rows[x]["Etiqueta"].ToString(), Licenciasactivas.Rows[x]["Numero_Licencia"].ToString(), Licenciasactivas.Rows[x]["Folio"].ToString(), Licenciasactivas.Rows[x]["Tipo_Obra"].ToString(), Licenciasactivas.Rows[x]["Uso"].ToString(), Licenciasactivas.Rows[x]["Total"].ToString(), Licenciasactivas.Rows[x]["Estado"].ToString(), Convert.ToDateTime(Licenciasactivas.Rows[x]["Fecha"]));
                n.Items.Add(tarjetaLicencias[x]);
            }
        }
    }
}

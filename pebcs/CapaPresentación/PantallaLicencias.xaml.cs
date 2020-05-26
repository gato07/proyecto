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
        }

        private void Btn_ElaborarPresupuesto_Click(object sender, RoutedEventArgs e)
        {
            Mn.AbrirFormHijo(new Pantalla_InfoLicencia());
        }
    }
}

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
    /// Lógica de interacción para Pantalla_Presupustos.xaml
    /// </summary>
    /// 
    public partial class Pantalla_Presupustos : UserControl
    {
        Menu_Principal2 Mn;
        public Pantalla_Presupustos(object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
        }
        private void Btn_ElaborarPresupuesto_Click(object sender, RoutedEventArgs e)
        {
            Mn.AbrirFormHijo(new PantallaPresupuestos());
        }
    }
}

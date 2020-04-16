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
using System.Windows.Shapes;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Menu_Principal2.xaml
    /// </summary>
    public partial class Menu_Principal2 : Window
    {
        public Menu_Principal2()
        {
            InitializeComponent();
        }
        public void AbrirFormHijo(object formhijo)
        {
            if (this.PanelContenedor.Children.Count > 0)
                this.PanelContenedor.Children.RemoveAt(0);
            UserControl userControl = formhijo as UserControl;
            PanelContenedor.Children.Add(userControl);
        }
        private void BtnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            AbrirFormHijo(new PantallaUsuario());
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            AbrirFormHijo(new PantallaClientes());
        }

        private void BtnConceptos_Click(object sender, RoutedEventArgs e)
        {
            AbrirFormHijo(new PantallaConceptos());
        }

        private void BtnInmuebles_Click(object sender, RoutedEventArgs e)
        {
            AbrirFormHijo(new PantallaInmuebles());
        }
        private void BtnLicencias_MouseMove(object sender, MouseEventArgs e)
        {
            BtnLicencias.Margin = new Thickness(0, 80, 0, 0);
        }

        private void BtnLicencias_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnLicencias.Margin = new Thickness(0, 80, 146, 0);
        }

        private void BtnDictamenes_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnDictamenes.Margin = new Thickness(0, 20, 146, 0);
        }

        private void BtnDictamenes_MouseMove(object sender, MouseEventArgs e)
        {
            BtnDictamenes.Margin = new Thickness(0, 20, 0, 0);
        }

        private void BtnEstimaciones_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnEstimaciones.Margin = new Thickness(0,20, 146, 0);
        }

        private void BtnEstimaciones_MouseMove(object sender, MouseEventArgs e)
        {
            BtnEstimaciones.Margin = new Thickness(0,20, 0, 0);
        }

        private void BtnCargaDeTrabajo_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnCargaDeTrabajo.Margin = new Thickness(0,20, 146, 0);
        }

        private void BtnCargaDeTrabajo_MouseMove(object sender, MouseEventArgs e)
        {
            BtnCargaDeTrabajo.Margin = new Thickness(0,20, 0, 0);
        }

        private void BtnEmpleados_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnEmpleados.Margin = new Thickness(0, 20, 146, 0);
        }

        private void BtnEmpleados_MouseMove(object sender, MouseEventArgs e)
        {
            BtnEmpleados.Margin = new Thickness(0, 20, 0, 0);
        }

        private void BtnClientes_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnClientes.Margin = new Thickness(0, 20, 146, 0);
        }

        private void BtnClientes_MouseMove(object sender, MouseEventArgs e)
        {
            BtnClientes.Margin = new Thickness(0, 20, 0, 0);
        }

        private void BtnConceptos_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnConceptos.Margin = new Thickness(0, 20, 146, 0);
        }

        private void BtnConceptos_MouseMove(object sender, MouseEventArgs e)
        {
            BtnConceptos.Margin = new Thickness(0, 20, 0, 0);
        }

        private void BtnInmuebles_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnInmuebles.Margin = new Thickness(0, 20, 146, 0);
        }

        private void BtnInmuebles_MouseMove(object sender, MouseEventArgs e)
        {
            BtnInmuebles.Margin = new Thickness(0, 20, 0, 0);
        }
    }
}

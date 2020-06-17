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
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {

            }
        }
        public void AbrirFormHijo(object formhijo)
        {
            try
            {
                if (this.PanelContenedor.Children.Count > 0)
                    this.PanelContenedor.Children.RemoveAt(0);
                UserControl userControl = formhijo as UserControl;
                PanelContenedor.Children.Add(userControl);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AbrirFormHijo(new PantallaUsuario(this));
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AbrirFormHijo(new PantallaClientes());
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnConceptos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AbrirFormHijo(new PantallaConceptos());
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnInmuebles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AbrirFormHijo(new PantallaInmuebles());
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnLicencias_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnLicencias.Margin = new Thickness(0, 10, 0, 0);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnLicencias_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnLicencias.Margin = new Thickness(0, 10, 120, 0);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnDictamenes_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnDictamenes.Margin = new Thickness(0, 10, 120, 0);
            }
            catch (Exception ex)
            {
                
            }
        }
        private void BtnDictamenes_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnDictamenes.Margin = new Thickness(0, 10, 0, 0);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnEstimaciones_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnEstimaciones.Margin = new Thickness(0, 10, 120, 0);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnEstimaciones_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnEstimaciones.Margin = new Thickness(0, 10, 0, 0);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnCargaDeTrabajo_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnCargaDeTrabajo.Margin = new Thickness(0, 10, 120, 0);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnCargaDeTrabajo_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnCargaDeTrabajo.Margin = new Thickness(0,10, 0, 0);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnEmpleados_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnEmpleados.Margin = new Thickness(0, 10, 120, 0);
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnEmpleados_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnEmpleados.Margin = new Thickness(0, 10, 0, 0);
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnClientes_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnClientes.Margin = new Thickness(0, 10, 120, 0);
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnClientes_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnClientes.Margin = new Thickness(0, 10, 0, 0);
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnConceptos_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnConceptos.Margin = new Thickness(0, 10, 120, 0);
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnConceptos_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnConceptos.Margin = new Thickness(0, 10, 0, 0);
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnInmuebles_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnInmuebles.Margin = new Thickness(0, 10, 120, 0);
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnInmuebles_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnInmuebles.Margin = new Thickness(0, 10, 0, 0);
            }
            catch(Exception ex)
            {

            }
        }

        private void BtnLicencias_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AbrirFormHijo(new PantallaLicencias(this));
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnPresupuesto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AbrirFormHijo(new Pantalla_Presupustos(this));
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnPresupuesto_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnPresupuesto.Margin = new Thickness(0, 80, 120, 0);
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnPresupuesto_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnPresupuesto.Margin = new Thickness(0, 80, 0, 0);
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnCargaDeTrabajo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AbrirFormHijo(new Pantalla_CargaDeTrabajo(this));
            }catch(Exception ex)
            {

            }
        }

        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
            }catch(Exception ex)
            {

            }
        }
    }
}

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

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_Presupustos.xaml
    /// </summary>
    /// 
    public partial class Pantalla_Presupustos : UserControl
    {
        Menu_Principal2 Mn;
        CapaLogica.Presupuesto presupuesto = new CapaLogica.Presupuesto();
        public Pantalla_Presupustos(object A)
        {
            try
            {
                InitializeComponent();
                Mn = A as Menu_Principal2;
                CargarPresupuestos(1);
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarPresupuestos(int N)
        {
            try
            {
                CapaLogica.Presupuesto[] presupuestos = presupuesto.TableToArray(presupuesto.SelXAprobado(N));
                Controles.Presupuesto[] PresCard = new Controles.Presupuesto[presupuestos.Length];
                for (int x = 0; x < PresCard.Length; x++)
                {
                    PresCard[x] = new Controles.Presupuesto(Mn);
                    PresCard[x].CargarDatos(presupuestos[x].Etiqueta, presupuestos[x].Numero, presupuestos[x].Nombre_Solicitante, presupuestos[x].Clave_Empleado.ToString(), presupuestos[x].Fecha, presupuestos[x].Aprobado.ToString(), presupuestos[x].Total.ToString());
                    n.Items.Add(PresCard[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarPresupuestosLikeClaveCatastral(TextBox box,int aprobado)
        {
            try
            {
                CapaLogica.Presupuesto[] presupuestos = presupuesto.TableToArray(presupuesto.SelLikeCatastral(box.Text, aprobado));
                Controles.Presupuesto[] PresCard = new Controles.Presupuesto[presupuestos.Length];
                for (int x = 0; x < PresCard.Length; x++)
                {
                    PresCard[x] = new Controles.Presupuesto(Mn);
                    PresCard[x].CargarDatos(presupuestos[x].Etiqueta, presupuestos[x].Numero, presupuestos[x].Nombre_Solicitante, presupuestos[x].Clave_Empleado.ToString(), presupuestos[x].Fecha, presupuestos[x].Aprobado.ToString(), presupuestos[x].Total.ToString());
                    n.Items.Add(PresCard[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarPresupuestosLikePropietario(TextBox box, int aprobado)
        {
            try
            {
                CapaLogica.Presupuesto[] presupuestos = presupuesto.TableToArray(presupuesto.SelLikePropietario(box.Text, aprobado));
                Controles.Presupuesto[] PresCard = new Controles.Presupuesto[presupuestos.Length];
                for (int x = 0; x < PresCard.Length; x++)
                {
                    PresCard[x] = new Controles.Presupuesto(Mn);
                    PresCard[x].CargarDatos(presupuestos[x].Etiqueta, presupuestos[x].Numero, presupuestos[x].Nombre_Solicitante, presupuestos[x].Clave_Empleado.ToString(), presupuestos[x].Fecha, presupuestos[x].Aprobado.ToString(), presupuestos[x].Total.ToString());
                    n.Items.Add(PresCard[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarPresupuestosLikeEtiqueta(TextBox box, int aprobado)
        {
            try
            {
                CapaLogica.Presupuesto[] presupuestos = presupuesto.TableToArray(presupuesto.SelLikeEtiqueta(box.Text, aprobado));
                Controles.Presupuesto[] PresCard = new Controles.Presupuesto[presupuestos.Length];
                for (int x = 0; x < PresCard.Length; x++)
                {
                    PresCard[x] = new Controles.Presupuesto(Mn);
                    PresCard[x].CargarDatos(presupuestos[x].Etiqueta, presupuestos[x].Numero, presupuestos[x].Nombre_Solicitante, presupuestos[x].Clave_Empleado.ToString(), presupuestos[x].Fecha, presupuestos[x].Aprobado.ToString(), presupuestos[x].Total.ToString());
                    n.Items.Add(PresCard[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_Cerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 47;
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 107;
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_AgregarPantalla_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new PantallaPresupuestos(0,Mn)) ;
            }catch(Exception ex)
            {

            }
        }

        private void Activador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Activador.IsChecked == true)
                {
                    Opciones.IsEnabled = true;
                    OpcionesAprobado.IsEnabled = true;
                    TxtBusqueda.IsEnabled = true;
                    Opciones.SelectedIndex = -1;
                    OpcionesAprobado.SelectedIndex = -1;
                    TxtBusqueda.Clear();
                }
                else
                {
                    Opciones.IsEnabled = false;
                    TxtBusqueda.IsEnabled = false;
                    OpcionesAprobado.IsEnabled = false;
                    Opciones.SelectedIndex = -1;
                    OpcionesAprobado.SelectedIndex = -1;
                    TxtBusqueda.Clear();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void TxtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (OpcionesAprobado.SelectedIndex == 0 || OpcionesAprobado.SelectedIndex == -1)
                {
                    if (Opciones.SelectedIndex == -1)
                    {
                        n.Items.Clear();
                        CargarPresupuestos(0);
                    }
                    else if (Opciones.SelectedIndex == 0)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 60;
                        CargarPresupuestosLikeClaveCatastral(TxtBusqueda,0);
                    }
                    else if (Opciones.SelectedIndex == 1)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 255;
                        CargarPresupuestosLikeEtiqueta(TxtBusqueda,0);
                    }
                    else if (Opciones.SelectedIndex == 2)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 15;
                        CargarPresupuestosLikePropietario(TxtBusqueda,0);
                    }
                }
                else if (OpcionesAprobado.SelectedIndex == 1)
                {
                    if (Opciones.SelectedIndex == -1)
                    {
                        n.Items.Clear();
                        CargarPresupuestos(1);
                    }
                    else if (Opciones.SelectedIndex == 0)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 60;
                        CargarPresupuestosLikeClaveCatastral(TxtBusqueda, 1);
                    }
                    else if (Opciones.SelectedIndex == 1)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 255;
                        CargarPresupuestosLikeEtiqueta(TxtBusqueda, 1);
                    }
                    else if (Opciones.SelectedIndex == 2)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 15;
                        CargarPresupuestosLikePropietario(TxtBusqueda, 1);

                    }
                }
                else if (OpcionesAprobado.SelectedIndex == 2)
                {
                    if (Opciones.SelectedIndex == -1)
                    {
                        n.Items.Clear();
                        CargarPresupuestos(2);
                    }
                    else if (Opciones.SelectedIndex == 0)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 60;
                        CargarPresupuestosLikeClaveCatastral(TxtBusqueda, 2);
                    }
                    else if (Opciones.SelectedIndex == 1)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 255;
                        CargarPresupuestosLikeEtiqueta(TxtBusqueda, 2);
                    }
                    else if (Opciones.SelectedIndex == 2)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 15;
                        CargarPresupuestosLikePropietario(TxtBusqueda, 2);

                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void OpcionesAprobado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (OpcionesAprobado.SelectedIndex == 0 || OpcionesAprobado.SelectedIndex == -1)
                {
                    if (Opciones.SelectedIndex == -1)
                    {
                        n.Items.Clear();
                        CargarPresupuestos(0);
                    }
                    else if (Opciones.SelectedIndex == 0)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 60;
                        CargarPresupuestosLikeClaveCatastral(TxtBusqueda, 0);
                    }
                    else if (Opciones.SelectedIndex == 1)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 255;
                        CargarPresupuestosLikeEtiqueta(TxtBusqueda, 0);
                    }
                    else if (Opciones.SelectedIndex == 2)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 15;
                        CargarPresupuestosLikePropietario(TxtBusqueda, 0);
                    }
                }
                else if (OpcionesAprobado.SelectedIndex == 1)
                {
                    if (Opciones.SelectedIndex == -1)
                    {
                        n.Items.Clear();
                        CargarPresupuestos(1);
                    }
                    else if (Opciones.SelectedIndex == 0)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 60;
                        CargarPresupuestosLikeClaveCatastral(TxtBusqueda, 1);
                    }
                    else if (Opciones.SelectedIndex == 1)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 255;
                        CargarPresupuestosLikeEtiqueta(TxtBusqueda, 1);
                    }
                    else if (Opciones.SelectedIndex == 2)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 15;
                        CargarPresupuestosLikePropietario(TxtBusqueda, 1);

                    }
                }
                else if (OpcionesAprobado.SelectedIndex == 2)
                {
                    if (Opciones.SelectedIndex == -1)
                    {
                        n.Items.Clear();
                        CargarPresupuestos(2);
                    }
                    else if (Opciones.SelectedIndex == 0)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 60;
                        CargarPresupuestosLikeClaveCatastral(TxtBusqueda, 2);
                    }
                    else if (Opciones.SelectedIndex == 1)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 255;
                        CargarPresupuestosLikeEtiqueta(TxtBusqueda, 2);
                    }
                    else if (Opciones.SelectedIndex == 2)
                    {
                        n.Items.Clear();
                        TxtBusqueda.MaxLength = 15;
                        CargarPresupuestosLikePropietario(TxtBusqueda, 2);

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

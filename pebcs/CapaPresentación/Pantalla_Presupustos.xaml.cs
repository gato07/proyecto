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
using System.Security.Principal;
using System.Security.Permissions;
using System.Threading;
using System.Security;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_Presupustos.xaml
    /// </summary>
    /// 
    public partial class Pantalla_Presupustos : UserControl
    {
        string NombreUsuario;
        Menu_Principal2 Mn;
        CapaLogica.Presupuesto presupuesto = new CapaLogica.Presupuesto();
        int IdUSUATIO;
        public Pantalla_Presupustos(object A,int iDe)
        {
            try
            {
                InitializeComponent();
                CargarRolesUsuarios(iDe);
                Mn = A as Menu_Principal2;
                CargarPresupuestos(2);
                IdUSUATIO = iDe;
            }
            catch (Exception ex)
            {

            }
        }
        private void CargarRolesUsuarios(int ID)
        {
            try
            {
                Empleado empleado = new Empleado(ID);
                Permiso permiso = new Permiso();
                NombreUsuario = empleado.Nombre;
                GenericIdentity identidad = new GenericIdentity(NombreUsuario);
                String[] roles = permiso.SelXPerfil(empleado.Perfil);
                GenericPrincipal MyPrincipal =
                new GenericPrincipal(identidad, roles);
                Thread.CurrentPrincipal = MyPrincipal;
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarPresupuestos(int N)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "P4");
                MyPermission.Demand();
                CapaLogica.Presupuesto[] presupuestos = presupuesto.TableToArray(presupuesto.SelXAprobado(N));
                Controles.Presupuesto[] PresCard = new Controles.Presupuesto[presupuestos.Length];
                for (int x = 0; x < PresCard.Length; x++)
                {
                    PresCard[x] = new Controles.Presupuesto(Mn, IdUSUATIO);
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "P4");
                MyPermission.Demand();
                CapaLogica.Presupuesto[] presupuestos = presupuesto.TableToArray(presupuesto.SelLikeCatastral(box.Text, aprobado));
                Controles.Presupuesto[] PresCard = new Controles.Presupuesto[presupuestos.Length];
                for (int x = 0; x < PresCard.Length; x++)
                {
                    PresCard[x] = new Controles.Presupuesto(Mn, IdUSUATIO);
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "P4");
                MyPermission.Demand();
                CapaLogica.Presupuesto[] presupuestos = presupuesto.TableToArray(presupuesto.SelLikePropietario(box.Text, aprobado));
                Controles.Presupuesto[] PresCard = new Controles.Presupuesto[presupuestos.Length];
                for (int x = 0; x < PresCard.Length; x++)
                {
                    PresCard[x] = new Controles.Presupuesto(Mn, IdUSUATIO);
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "P4");
                MyPermission.Demand();
                CapaLogica.Presupuesto[] presupuestos = presupuesto.TableToArray(presupuesto.SelLikeEtiqueta(box.Text, aprobado));
                Controles.Presupuesto[] PresCard = new Controles.Presupuesto[presupuestos.Length];
                for (int x = 0; x < PresCard.Length; x++)
                {
                    PresCard[x] = new Controles.Presupuesto(Mn, IdUSUATIO);
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "P1");
                MyPermission.Demand();
                Mn.AbrirFormHijo(new PantallaPresupuestos(0,Mn, IdUSUATIO)) ;
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
                    CargarPresupuestos(2);
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "P4");
                MyPermission.Demand();
                int E = 0;
                if (OpcionesAprobado.SelectedIndex == 0)
                {
                    E = 0;
                }
                else if (OpcionesAprobado.SelectedIndex == 1)
                {
                    E = 1;
                }
                else if (OpcionesAprobado.SelectedIndex == 2)
                {
                    E = 2;
                }
                if (Opciones.SelectedIndex == 0)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 60;
                    CargarPresupuestosLikeClaveCatastral(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 1)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 255;
                    CargarPresupuestosLikeEtiqueta(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 2)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 15;
                    CargarPresupuestosLikePropietario(TxtBusqueda, E);
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "P4");
                MyPermission.Demand();
                int E = 0;
                if (OpcionesAprobado.SelectedIndex == 0)
                {
                    E = 0;
                }
                else if (OpcionesAprobado.SelectedIndex == 1)
                {
                    E = 1;
                }
                else if (OpcionesAprobado.SelectedIndex == 2)
                {
                    E = 2;
                }
                if (Opciones.SelectedIndex == 0)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 60;
                    CargarPresupuestosLikeClaveCatastral(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 1)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 255;
                    CargarPresupuestosLikeEtiqueta(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 2)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 15;
                    CargarPresupuestosLikePropietario(TxtBusqueda, E);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

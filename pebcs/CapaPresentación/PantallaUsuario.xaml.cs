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
using CapaLogica;
using CapaPresentación.Controles;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaUsuario.xaml
    /// </summary>
    public partial class PantallaUsuario : UserControl
    {
        Flipper[] flippers;
        FlipperUsuarioInactivo[] flipperInactivos;
        //RowDefinition rowDefinition;
        //ColumnDefinition columnDefinition;
        Menu_Principal2 Mn;
        //Empleado emp;
        public PantallaUsuario(object A)
        {
            try
            {
                InitializeComponent();
                Mn = A as Menu_Principal2;
                generartarjetas();
            }
            catch (Exception ex)
            {

            }
        }
        public void generartarjetas()
        {
            try
            {
                Empleado empleado = new Empleado();
                Empleado[] empleadosActivos = empleado.TableToArray(empleado.SelActivos());
                Empleado[] empleadosInactivos = empleado.TableToArray(empleado.SelEliminados());
                ActualizarContadores(empleadosActivos, empleadosInactivos);
                flippers = new Flipper[empleadosActivos.Length];
                flipperInactivos = new FlipperUsuarioInactivo[empleadosInactivos.Length];
                //int fila = 1;
                //int columna = 1;
                //agregarcolumnas();
                //agregarfila(flippers.Length + flipperInactivos.Length);
                for (int x = 0; x < flippers.Length; x++)
                {
                    flippers[x] = new Flipper(this, Mn);
                    flippers[x].CargarDatosTarjeta(empleadosActivos[x].Clave, empleadosActivos[x].Nombre, empleadosActivos[x].Domicilio, empleadosActivos[x].Telefono, empleadosActivos[x].Email, empleadosActivos[x].Foto, empleadosActivos[x].Perfil, empleadosActivos[x].Usuario);
                    //Grid.SetColumn(flippers[x], columna - 1);
                    //Grid.SetRow(flippers[x], fila - 1);
                    //GridContenedor.Children.Add(flippers[x]);
                    n.Items.Add(flippers[x]);
                    //if (columna > 3)
                    //{
                    //    columna = 1;
                    //    fila++;
                    //}
                    //else
                    //{
                    //    columna++;
                    //}
                }
                for (int x = 0; x < flipperInactivos.Length; x++)
                {
                    flipperInactivos[x] = new FlipperUsuarioInactivo(this, Mn);
                    flipperInactivos[x].CargarDatosTarjeta(empleadosInactivos[x].Clave, empleadosInactivos[x].Nombre, empleadosInactivos[x].Domicilio, empleadosInactivos[x].Telefono, empleadosInactivos[x].Email, empleadosInactivos[x].Foto, empleadosInactivos[x].Perfil, empleadosInactivos[x].Usuario);
                    //Grid.SetColumn(flipperInactivos[x], columna - 1);
                    //Grid.SetRow(flipperInactivos[x], fila - 1);
                    //GridContenedor.Children.Add(flipperInactivos[x]);
                    n.Items.Add(flipperInactivos[x]);
                    //if (columna > 3)
                    //{
                    //    columna = 1;
                    //    fila++;
                    //}
                    //else
                    //{
                    //    columna++;
                    //}
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void ActualizarContadores(Empleado[] A,Empleado[] B)
        {
            try
            {
                ACTIVOS.Text = "ACTIVOS: " + A.Length.ToString();
                INACTIVOS.Text = "INACTIVOS: " + B.Length.ToString();
            }
            catch(Exception ex)
            {

            }
        }
        public void generartarjetasLikeNombre(TextBox Busqueda)
        {
            try
            {
                Empleado empleado = new Empleado();
                Empleado[] empleadosActivos = empleado.TableToArray(empleado.SelLikeNombre(Busqueda.Text, false));
                Empleado[] empleadosInactivos = empleado.TableToArray(empleado.SelLikeNombre(Busqueda.Text, true));
                flippers = new Flipper[empleadosActivos.Length];
                flipperInactivos = new FlipperUsuarioInactivo[empleadosInactivos.Length];
                //int fila = 1;
                //int columna = 1;
                //agregarcolumnas();
                //agregarfila(flippers.Length + flipperInactivos.Length);
                for (int x = 0; x < flippers.Length; x++)
                {
                    flippers[x] = new Flipper(this, Mn);
                    flippers[x].CargarDatosTarjeta(empleadosActivos[x].Clave, empleadosActivos[x].Nombre, empleadosActivos[x].Domicilio, empleadosActivos[x].Telefono, empleadosActivos[x].Email, empleadosActivos[x].Foto, empleadosActivos[x].Perfil, empleadosActivos[x].Usuario);
                    //Grid.SetColumn(flippers[x], columna - 1);
                    //Grid.SetRow(flippers[x], fila - 1);
                    //GridContenedor.Children.Add(flippers[x]);
                    n.Items.Add(flippers[x]);
                    //if (columna > 3)
                    //{
                    //    columna = 1;
                    //    fila++;
                    //}
                    //else
                    //{
                    //    columna++;
                    //}
                }
                if (flipperInactivos.Length != 0)
                {
                    for (int x = 0; x < flipperInactivos.Length; x++)
                    {
                        flipperInactivos[x] = new FlipperUsuarioInactivo(this, Mn);
                        flipperInactivos[x].CargarDatosTarjeta(empleadosInactivos[x].Clave, empleadosInactivos[x].Nombre, empleadosInactivos[x].Domicilio, empleadosInactivos[x].Telefono, empleadosInactivos[x].Email, empleadosInactivos[x].Foto, empleadosInactivos[x].Perfil, empleadosInactivos[x].Usuario);
                        //Grid.SetColumn(flipperInactivos[x], columna - 1);
                        //Grid.SetRow(flipperInactivos[x], fila - 1);
                        //GridContenedor.Children.Add(flipperInactivos[x]);
                        n.Items.Add(flipperInactivos[x]);
                        //if (columna > 3)
                        //{
                        //    columna = 1;
                        //    fila++;
                        //}
                        //else
                        //{
                        //    columna++;
                        //}
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void generartarjetasLikeUsuario(TextBox Busqueda)
        {
            try
            {
                Empleado empleado = new Empleado();
                Empleado[] empleadosActivos = empleado.TableToArray(empleado.SelLikeUsuario(Busqueda.Text, false));
                Empleado[] empleadosInactivos = empleado.TableToArray(empleado.SelLikeUsuario(Busqueda.Text, true));
                flippers = new Flipper[empleadosActivos.Length];
                flipperInactivos = new FlipperUsuarioInactivo[empleadosInactivos.Length];
                //int fila = 1;
                //int columna = 1;
                //agregarcolumnas();
                //agregarfila(flippers.Length + flipperInactivos.Length);
                for (int x = 0; x < flippers.Length; x++)
                {
                    flippers[x] = new Flipper(this, Mn);
                    flippers[x].CargarDatosTarjeta(empleadosActivos[x].Clave, empleadosActivos[x].Nombre, empleadosActivos[x].Domicilio, empleadosActivos[x].Telefono, empleadosActivos[x].Email, empleadosActivos[x].Foto, empleadosActivos[x].Perfil, empleadosActivos[x].Usuario);
                    //Grid.SetColumn(flippers[x], columna - 1);
                    //Grid.SetRow(flippers[x], fila - 1);
                    //GridContenedor.Children.Add(flippers[x]);
                    n.Items.Add(flippers[x]);
                    //if (columna > 3)
                    //{
                    //    columna = 1;
                    //    fila++;
                    //}
                    //else
                    //{
                    //    columna++;
                    //}
                }
                if (flipperInactivos.Length != 0)
                {
                    for (int x = 0; x < flipperInactivos.Length; x++)
                    {
                        flipperInactivos[x] = new FlipperUsuarioInactivo(this, Mn);
                        flipperInactivos[x].CargarDatosTarjeta(empleadosInactivos[x].Clave, empleadosInactivos[x].Nombre, empleadosInactivos[x].Domicilio, empleadosInactivos[x].Telefono, empleadosInactivos[x].Email, empleadosInactivos[x].Foto, empleadosInactivos[x].Perfil, empleadosInactivos[x].Usuario);
                        //Grid.SetColumn(flipperInactivos[x], columna - 1);
                        //Grid.SetRow(flipperInactivos[x], fila - 1);
                        //GridContenedor.Children.Add(flipperInactivos[x]);
                        n.Items.Add(flipperInactivos[x]);
                        //if (columna > 3)
                        //{
                        //    columna = 1;
                        //    fila++;
                        //}
                        //else
                        //{
                        //    columna++;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void generartarjetasLikeCorreo(TextBox Busqueda)
        {
            try
            { 
                Empleado empleado = new Empleado();
                Empleado[] empleadosActivos = empleado.TableToArray(empleado.SelLikeEmail(Busqueda.Text, false));
                Empleado[] empleadosInactivos = empleado.TableToArray(empleado.SelLikeEmail(Busqueda.Text, true));
                flippers = new Flipper[empleadosActivos.Length];
                flipperInactivos = new FlipperUsuarioInactivo[empleadosInactivos.Length];
                //int fila = 1;
                //int columna = 1;
                //agregarcolumnas();
                //agregarfila(flippers.Length + flipperInactivos.Length);
                for (int x = 0; x < flippers.Length; x++)
                {
                    flippers[x] = new Flipper(this, Mn);
                    flippers[x].CargarDatosTarjeta(empleadosActivos[x].Clave, empleadosActivos[x].Nombre, empleadosActivos[x].Domicilio, empleadosActivos[x].Telefono, empleadosActivos[x].Email, empleadosActivos[x].Foto, empleadosActivos[x].Perfil, empleadosActivos[x].Usuario);
                    //Grid.SetColumn(flippers[x], columna - 1);
                    //Grid.SetRow(flippers[x], fila - 1);
                    //GridContenedor.Children.Add(flippers[x]);
                    n.Items.Add(flippers[x]);
                    //if (columna > 3)
                    //{
                    //    columna = 1;
                    //    fila++;
                    //}
                    //else
                    //{
                    //    columna++;
                    //}
                }
                if (flipperInactivos.Length != 0)
                {
                    for (int x = 0; x < flipperInactivos.Length; x++)
                    {
                        flipperInactivos[x] = new FlipperUsuarioInactivo(this,Mn);
                        flipperInactivos[x].CargarDatosTarjeta(empleadosInactivos[x].Clave, empleadosInactivos[x].Nombre, empleadosInactivos[x].Domicilio, empleadosInactivos[x].Telefono, empleadosInactivos[x].Email, empleadosInactivos[x].Foto, empleadosInactivos[x].Perfil, empleadosInactivos[x].Usuario);
                        //Grid.SetColumn(flipperInactivos[x], columna - 1);
                        //Grid.SetRow(flipperInactivos[x], fila - 1);
                        //GridContenedor.Children.Add(flipperInactivos[x]);
                        n.Items.Add(flipperInactivos[x]);
                        //if (columna > 3)
                        //{
                        //    columna = 1;
                        //    fila++;
                        //}
                        //else
                        //{
                        //    columna++;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
       
        //public void agregarcolumnas()
        //{
        //    try
        //    {
        //        for (int x = 0; x < 4; x++)
        //        {
        //            columnDefinition = new ColumnDefinition();
        //            //GridContenedor.ColumnDefinitions.Add(columnDefinition);
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}
        //public void agregarfila(int c)
        //{
        //    try
        //    {
        //        int res;
        //        if ((c % 4) == 0)
        //        {
        //            res = c / 4;
        //        }
        //        else
        //        {
        //            res = (c / 4) + 1;
        //        }
        //        for (int x = 0; x < res; x++)
        //        {
        //            rowDefinition = new RowDefinition();
        //            //GridContenedor.RowDefinitions.Add(rowDefinition);
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}
        private void Btn_Limpiar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Limpiar.Width = 47;
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_Limpiar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Limpiar.Width = 107;
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_AgregarEmpleado_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_AgregarEmpleado.Width = 107;
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_AgregarEmpleado_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_AgregarEmpleado.Width = 47;
            }
            catch(Exception ex)
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
                    Btn_Limpiar.IsEnabled = true;
                    TxtBusqueda.IsEnabled = true;
                    Opciones.SelectedIndex = -1;
                    TxtBusqueda.Clear();
                }
                else
                {
                    Opciones.IsEnabled = false;
                    Btn_Limpiar.IsEnabled = false;
                    TxtBusqueda.IsEnabled = false;
                    Opciones.SelectedIndex = -1;
                    TxtBusqueda.Clear();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Opciones.SelectedIndex = -1;
                TxtBusqueda.Clear();
                impiar();
                generartarjetas();
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_AgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new Pantalla_PerfilUsuario(null, Mn));
            }
            catch(Exception ex)
            {

            }
        }
        public void impiar()
        {
            try
            {
                //GridContenedor.Children.Clear();
                //GridContenedor.ColumnDefinitions.Clear();
                //GridContenedor.RowDefinitions.Clear();
                n.Items.Clear();
            }
            catch(Exception ex)
            {

            }
        }
        private void TxtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Opciones.SelectedIndex == -1)
                {
                    impiar();
                    generartarjetas();
                }
                else if (Opciones.SelectedIndex == 0)
                {
                    impiar();
                    TxtBusqueda.MaxLength = 60;
                    generartarjetasLikeNombre(TxtBusqueda);
                }
                else if (Opciones.SelectedIndex == 1)
                {
                    impiar();
                    TxtBusqueda.MaxLength = 255;
                    generartarjetasLikeCorreo(TxtBusqueda);
                }
                else if (Opciones.SelectedIndex == 2)
                {
                    impiar();
                    TxtBusqueda.MaxLength = 15;
                    generartarjetasLikeUsuario(TxtBusqueda);
                }

            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_Cerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 47;
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 107;
            }
            catch(Exception ex)
            {

            }
        }
    }
}
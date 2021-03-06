﻿using CapaLogica;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Security.Principal;
using System.Security.Permissions;
using System.Threading;
using System.Security;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaClientes.xaml
    /// </summary>
    public partial class PantallaClientes : UserControl
    {
        string NombreUsuario;
        Cliente cliente = new Cliente();
        int IdUSUATIO ;
        public PantallaClientes(int iDe)
        {
            try
            {
                InitializeComponent();
                IdUSUATIO = iDe;
                CargarRolesUsuarios(iDe);
                LlenarData();
            }
            catch(Exception ex)
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
        private DataTable PresentacionTable(DataTable Dt)
        {
            try
            {
                Dt.Columns["Rfc"].ColumnName = "RFC";
                Dt.Columns["Telefono"].ColumnName = "Teléfono";
                return Dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void LimpiarCampos()
        {
            TXTRfc.Clear();
            TXTNombre.Clear();
            TXTApellido.Clear();
            TXTTelefono.Clear();
            TXTEmail.Clear();
            TXTRfcModificar.Clear();
            TXTNombreModificar.Clear();
            TXTApellidoModificar.Clear();
            TXTTelefonoModificar.Clear();
            TXTEmailModificar.Clear();
        }
        public void LlenarData()
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C4");
                MyPermission.Demand();
                DataTable table = new DataTable();
                table = PresentacionTable(cliente.SelActivos());
                GridClientesActivos.ItemsSource = table.AsDataView();
                ACTIVOS.Text = "ACTIVOS: " + table.Rows.Count.ToString();
                DataTable table2 = new DataTable();
                table2 = PresentacionTable(cliente.SelEliminados());
                GridClientesInactivos.ItemsSource = table2.AsDataView();
                INACTIVOS.Text = "INACTIVOS: " + table2.Rows.Count.ToString();
            }
            catch(Exception ex)
            {

            }
        }
        public void llenarDataLikeRFC(string txt, bool Actividad)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C4");
                MyPermission.Demand();
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(cliente.SelLikeRfc(txt, Actividad));
                    GridClientesInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(cliente.SelLikeRfc(txt, Actividad));
                    GridClientesActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void llenarDataLikeNombre(string txt, bool Actividad)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C4");
                MyPermission.Demand();
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(cliente.SelLikeNombre(txt, Actividad));
                    GridClientesInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(cliente.SelLikeNombre(txt, Actividad));
                    GridClientesActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void llenarDataLikeTelefono(string txt, bool Actividad)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C4");
                MyPermission.Demand();
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(cliente.SelLikeTelefono(txt, Actividad));
                    GridClientesInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(cliente.SelLikeTelefono(txt, Actividad));
                    GridClientesActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void llenarDataLikeCorreo(string txt, bool Actividad)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C4");
                MyPermission.Demand();
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(cliente.SelLikeEmail(txt, Actividad));
                    GridClientesInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(cliente.SelLikeEmail(txt, Actividad));
                    GridClientesActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C1");
                MyPermission.Demand();
                bool res = false;
                res = cliente.Insertar(TXTRfc.Text, TXTNombre.Text, TXTApellido.Text, TXTTelefono.Text, TXTEmail.Text);
                if (res)
                {
                    PantallaCheck check = new PantallaCheck();
                    LlenarData();
                    check.ShowDialog();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show(cliente.Mensaje);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C3");
                MyPermission.Demand();
                DataRowView data = (GridClientesActivos as DataGrid).SelectedItem as DataRowView;
                cliente.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
                LlenarData();
                PantallaCheck check = new PantallaCheck();
                check.ShowDialog();
            }
            catch(Exception ex)
            {

            }
        }
        private void GridClientesActivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
                //TXTNombreModificar.Text = data.Row.ItemArray[1].ToString();
                //TXTApellidoModificar.Text = data.Row.ItemArray[2].ToString();
                //TXTTelefonoModificar.Text = data.Row.ItemArray[3].ToString();
                //TXTEmailModificar.Text = data.Row.ItemArray[4].ToString();
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C2");
                MyPermission.Demand();
                DataRowView data = (GridClientesActivos as DataGrid).SelectedItem as DataRowView;
                TXTRfcModificar.Text = data.Row.ItemArray[1].ToString();
                TXTNombreModificar.Text = data.Row.ItemArray[2].ToString();
                TXTApellidoModificar.Text = data.Row.ItemArray[3].ToString();
                TXTTelefonoModificar.Text = data.Row.ItemArray[4].ToString();
                TXTEmailModificar.Text = data.Row.ItemArray[5].ToString();
                FormularioClientesModificar.IsOpen = true;
            }
            catch(Exception ex)
            {

            }
        }
        private void btnClienteModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C2");
                MyPermission.Demand();
                bool res = false;
                DataRowView data = (GridClientesActivos as DataGrid).SelectedItem as DataRowView;
                res = cliente.Actualizar(Convert.ToInt16(data.Row.ItemArray[0].ToString()), TXTRfcModificar.Text, TXTNombreModificar.Text, TXTApellidoModificar.Text, TXTTelefonoModificar.Text, TXTEmailModificar.Text);
                if (res)
                {
                    LlenarData();
                    PantallaCheck check = new PantallaCheck();
                    check.ShowDialog();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show(cliente.Mensaje);
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnRestaurar_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                BtnRestaurar.Width = 39;
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnRestaurar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                BtnRestaurar.Width = 119;
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnRestaurar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C2");
                MyPermission.Demand();
                DataRowView data = (GridClientesInactivos as DataGrid).SelectedItem as DataRowView;
                cliente.Activar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
                LlenarData();
                PantallaCheck check = new PantallaCheck();
                check.ShowDialog();
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_Cerrar_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 47;
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_Cerrar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 107;
            }
            catch(Exception ex)
            {

            }
        }
        private void ActivadorActivos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ActivadorActivos.IsChecked == true)
                {
                    OpcionesActivos.IsEnabled = true;
                    TxtBusquedaActivos.IsEnabled = true;
                    OpcionesActivos.SelectedIndex = -1;
                    TxtBusquedaActivos.Clear();
                }
                else
                {
                    OpcionesActivos.IsEnabled = false;
                    TxtBusquedaActivos.IsEnabled = false;
                    OpcionesActivos.SelectedIndex = -1;
                    TxtBusquedaActivos.Clear();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
        }
        private void GridClientesInactivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        private void ActivadorInactivos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ActivadorInactivos.IsChecked == true)
                {
                    OpcionesInactivos.IsEnabled = true;
                    TxtBusquedaInactivos.IsEnabled = true;
                    OpcionesInactivos.SelectedIndex = -1;
                    TxtBusquedaInactivos.Clear();
                }
                else
                {
                    OpcionesInactivos.IsEnabled = false;
                    TxtBusquedaInactivos.IsEnabled = false;
                    OpcionesInactivos.SelectedIndex = -1;
                    TxtBusquedaInactivos.Clear();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void TxtBusquedaActivos_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C4");
                MyPermission.Demand();
                //Activos
                if (OpcionesActivos.SelectedIndex == -1)
                {
                    LlenarData();
                }
                else if (OpcionesActivos.SelectedIndex == 0)
                {
                    TxtBusquedaActivos.MaxLength = 13;
                    llenarDataLikeRFC(TxtBusquedaActivos.Text, false);
                }
                else if (OpcionesActivos.SelectedIndex == 1)
                {
                    TxtBusquedaActivos.MaxLength = 30;
                    llenarDataLikeNombre(TxtBusquedaActivos.Text, false);
                }
                else if (OpcionesActivos.SelectedIndex == 2)
                {
                    TxtBusquedaActivos.MaxLength = 10;
                    llenarDataLikeTelefono(TxtBusquedaActivos.Text, false);
                }
                else if (OpcionesActivos.SelectedIndex == 3)
                {
                    TxtBusquedaActivos.MaxLength = 255;
                    llenarDataLikeCorreo(TxtBusquedaActivos.Text, false);
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void TxtBusquedaInactivos_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "C4");
                MyPermission.Demand();
                //Inactivos
                if (OpcionesInactivos.SelectedIndex == -1)
                {
                    LlenarData();
                }
                else if (OpcionesInactivos.SelectedIndex == 0)
                {
                    TxtBusquedaInactivos.MaxLength = 13;
                    llenarDataLikeRFC(TxtBusquedaInactivos.Text, true);
                }
                else if (OpcionesInactivos.SelectedIndex == 1)
                {
                    TxtBusquedaInactivos.MaxLength = 30;
                    llenarDataLikeNombre(TxtBusquedaInactivos.Text, true);
                }
                else if (OpcionesInactivos.SelectedIndex == 2)
                {
                    TxtBusquedaInactivos.MaxLength = 10;
                    llenarDataLikeTelefono(TxtBusquedaInactivos.Text, true);
                }
                else if (OpcionesInactivos.SelectedIndex == 3)
                {
                    TxtBusquedaInactivos.MaxLength = 255;
                    llenarDataLikeCorreo(TxtBusquedaInactivos.Text, true);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}

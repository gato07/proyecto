﻿using System;
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
using System.Data;
using System.Globalization;
using System.Security.Principal;
using System.Security.Permissions;
using System.Threading;
using System.Security;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaConceptos.xaml
    /// </summary>
    public partial class PantallaConceptos : UserControl
    {
        string NombreUsuario;
        Concepto concepto = new Concepto();
        string tipo;
        int IdUSUATIO;
        public PantallaConceptos(int iDe)
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
                DataTable copia = Dt.Clone();
                copia.Columns["Descripcion"].ColumnName = "Descripción";
                copia.Columns["Costo"].DataType = typeof(string);
                int i = 0;
                foreach (DataRow row in Dt.Rows)
                {
                    copia.ImportRow(row);
                    copia.Rows[i]["Costo"] = Convert.ToDecimal(copia.Rows[i]["Costo"]).ToString("C");
                    i++;
                }
                return copia;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void LlenarData()
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U4");
                MyPermission.Demand();
                DataTable table = new DataTable();
                table = PresentacionTable(concepto.SelActivos());
                GridConceptosActivos.ItemsSource = table.AsDataView();
                ACTIVOS.Text = "Activos: " + table.Rows.Count.ToString();
                DataTable table2 = new DataTable();
                table2 = PresentacionTable(concepto.SelEliminados());
                GridConceptosInactivos.ItemsSource = table2.AsDataView();
                INACTIVOS.Text = "Inactivos: " + table2.Rows.Count.ToString();
            }
            catch(Exception ex)
            {

            }
        }
        
        public void llenarDataLikeTipo(string txt, bool Actividad)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U4");
                MyPermission.Demand();
                if (Actividad)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(concepto.SelLikeTipo(txt, Actividad));
                    GridConceptosInactivos.ItemsSource = table.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(concepto.SelLikeTipo(txt, Actividad));
                    GridConceptosActivos.ItemsSource = table2.AsDataView();
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U4");
                MyPermission.Demand();
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(concepto.SelLikeNombre(txt, Actividad));
                    GridConceptosInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(concepto.SelLikeNombre(txt, Actividad));
                    GridConceptosActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void llenarDataLikeDescripcion(string txt, bool Actividad)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U4");
                MyPermission.Demand();
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(concepto.SelLikeDescripcion(txt, Actividad));
                    GridConceptosInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(concepto.SelLikeDescripcion(txt, Actividad));
                    GridConceptosActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void btnAgregarConcepto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U1");
                MyPermission.Demand();
                bool res = false;
                if (Decimal.TryParse(TXTCosto.Text.Trim(), NumberStyles.Currency,
                    CultureInfo.CurrentCulture.NumberFormat, out decimal costo))
                {
                    if (OpcionesTipo.SelectedIndex == 0)
                    {
                        tipo = "Pago De Honorarios";
                    }
                    else if (OpcionesTipo.SelectedIndex == 1)
                    {
                        tipo = "Pago Ante Ayuntamiento";
                    }
                    res = concepto.Insertar(tipo, TXTNombre.Text, TXTDescripcion.Text, costo);
                    if (res)
                    {
                        PantallaCheck check = new PantallaCheck();
                        LlenarData();
                        check.ShowDialog();
                    }
                    else
                        MessageBox.Show(concepto.Mensaje);
                }
                else
                    MessageBox.Show("El campo de Costo debe ser numerico con decimales");
            }
            catch(Exception ex)
            {

            }
        }
        private void btnConceptoModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U2");
                MyPermission.Demand();
                bool res = false;
                DataRowView data = (GridConceptosActivos as DataGrid).SelectedItem as DataRowView;
                if (Decimal.TryParse(TXTCostoModificar.Text.Trim(), NumberStyles.Currency, 
                    CultureInfo.CurrentCulture.NumberFormat, out decimal costo))
                {
                    if (OpcionesTipoModificar.SelectedIndex == 0)
                    {
                        tipo = "Pago de honorarios";
                    }
                    else if (OpcionesTipoModificar.SelectedIndex == 1)
                    {
                        tipo = "Pagos ante ayuntamiento";
                    }
                    res = concepto.Actualizar(Convert.ToInt16(data.Row.ItemArray[0].ToString()), tipo, TXTNombreModificar.Text, TXTDescripcionModificar.Text, costo);
                    if (res)
                    {
                        LlenarData();
                        PantallaCheck check = new PantallaCheck();
                        check.ShowDialog();
                    }
                    else
                        MessageBox.Show(concepto.Mensaje);
                }
                else
                    MessageBox.Show("El campo de Costo debe ser numerico con decimales");
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnRestaurar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnRestaurar.Width = 39;
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnRestaurar_MouseMove(object sender, MouseEventArgs e)
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U2");
                MyPermission.Demand();
                DataRowView data = (GridConceptosInactivos as DataGrid).SelectedItem as DataRowView;
                concepto.Activar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
                LlenarData();
                PantallaCheck check = new PantallaCheck();
                check.ShowDialog();
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U3");
                MyPermission.Demand();
                DataRowView data = (GridConceptosActivos as DataGrid).SelectedItem as DataRowView;
                concepto.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
                LlenarData();
                PantallaCheck check = new PantallaCheck();
                check.ShowDialog();
            }
            catch(Exception ex)
            {

            }
        }
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U2");
                MyPermission.Demand();
                DataRowView data = (GridConceptosActivos as DataGrid).SelectedItem as DataRowView;
                if(data.Row.ItemArray[1].ToString().Length==18)
                {
                    OpcionesTipoModificar.SelectedIndex = 0;
                    tipo = "Pago de honorarios";
                }
                else if (data.Row.ItemArray[1].ToString().Length == 22)
                {
                    OpcionesTipoModificar.SelectedIndex = 1;
                    tipo = "Pagos ante ayuntamiento";

                }
                //TXTTipoModificar.Text = data.Row.ItemArray[1].ToString();
                TXTNombreModificar.Text = data.Row.ItemArray[2].ToString();
                TXTDescripcionModificar.Text = data.Row.ItemArray[3].ToString();
                TXTCostoModificar.Text = data.Row.ItemArray[4].ToString();
                FormularioConceptosModificar.IsOpen = true;
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
        private void TxtBusquedaActivos_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U4");
                MyPermission.Demand();
                //ACTIVOS
                if (OpcionesActivos.SelectedIndex == -1)
                {
                    LlenarData();
                }
                else if (OpcionesActivos.SelectedIndex == 0)
                {
                    TxtBusquedaActivos.MaxLength = 25;
                    llenarDataLikeTipo(TxtBusquedaActivos.Text, false);
                }
                else if (OpcionesActivos.SelectedIndex == 1)
                {
                    TxtBusquedaActivos.MaxLength = 75;
                    llenarDataLikeNombre(TxtBusquedaActivos.Text, false);
                }
                else if (OpcionesActivos.SelectedIndex == 2)
                {
                    TxtBusquedaActivos.MaxLength = 255;
                    llenarDataLikeDescripcion(TxtBusquedaActivos.Text, false);
                }
            }
            catch(Exception ex)
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
        private void TxtBusquedaInactivos_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "U4");
                MyPermission.Demand();
                //INACTIVOS
                if (OpcionesInactivos.SelectedIndex == -1)
                {
                    LlenarData();
                }
                else if (OpcionesInactivos.SelectedIndex == 0)
                {
                    TxtBusquedaInactivos.MaxLength = 25;
                    llenarDataLikeTipo(TxtBusquedaInactivos.Text, true);
                }
                else if (OpcionesInactivos.SelectedIndex == 1)
                {
                    TxtBusquedaInactivos.MaxLength = 75;
                    llenarDataLikeNombre(TxtBusquedaInactivos.Text, true);
                }
                else if (OpcionesInactivos.SelectedIndex == 2)
                {
                    TxtBusquedaInactivos.MaxLength = 255;
                    llenarDataLikeDescripcion(TxtBusquedaInactivos.Text, true);
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
    }
}

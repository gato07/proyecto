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
using System.Data;
using CapaLogica;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaInmuebles.xaml
    /// </summary>
    public partial class PantallaInmuebles : UserControl
    {
        Inmueble inmueble = new Inmueble();
        public PantallaInmuebles()
        {
            try
            {
                InitializeComponent();
                LlenarData();
            }
            catch(Exception ex)
            {

            }
        }

        private DataTable PresentacionTable(DataTable Dt)
        {
            try
            {
                Dt.Columns["Clave_Catastral"].ColumnName = "Clave catastral";
                Dt.Columns["Nombre_Propietario"].ColumnName = "Nombre propietario";
                Dt.Columns["Telefono_Propietario"].ColumnName = "Teléfono propietario";
                Dt.Columns["Entre_Calles"].ColumnName = "Entre calles";
                Dt.Columns["Numero_Interior"].ColumnName = "Número interior";
                Dt.Columns["Numero_Exterior"].ColumnName = "Número exterior";
                return Dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        private void LimpiarCampos()
        {
            try
            {
                TXTClaveCatastral.Clear();
                TXTNombrePropietario.Clear();
                TXTTelefonoPropietario.Clear();
                TXTColonia.Clear();
                TXTCalle.Clear();
                TXTEntreCalles.Clear();
                TXTNumeroExterior.Clear();
                TXTNumeroInterior.Clear();
                TXTClaveCatastralModificar.Clear();
                TXTNombrePropietarioModificar.Clear();
                TXTTelefonoPropietarioModificar.Clear();
                TXTColoniaModificar.Clear();
                TXTCalleModificar.Clear();
                TXTEntreCallesModificar.Clear();
                TXTNumeroExteriorModificar.Clear();
                TXTNumeroInteriorModificar.Clear();
            }
            catch(Exception ex)
            {

            }
        }
        public void LlenarData()
        {
            try
            {
                DataTable table = new DataTable();
                table = PresentacionTable(inmueble.SelActivos());
                GridInmueblesActivos.ItemsSource = table.AsDataView();
                ACTIVOS.Text = "ACTIVOS: " + table.Rows.Count.ToString();
                DataTable table2 = new DataTable();
                table2 = PresentacionTable(inmueble.SelEliminados());
                GridInmueblesInactivos.ItemsSource = table2.AsDataView();
                INACTIVOS.Text = "INACTIVOS: " + table2.Rows.Count.ToString();
            }
            catch(Exception ex)
            {

            }
        }
        public void llenarDataLikeClaveCatastral(string txt,bool Actividad)
        {
            try
            {
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(inmueble.SelLikeClaveCatastral(txt, Actividad));
                    GridInmueblesInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(inmueble.SelLikeClaveCatastral(txt, Actividad));
                    GridInmueblesActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void llenarDataLikeNombrePropietario(string txt, bool Actividad)
        {
            try
            {
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(inmueble.SelLikeNombrePropietario(txt, Actividad));
                    GridInmueblesInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(inmueble.SelLikeNombrePropietario(txt, Actividad));
                    GridInmueblesActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void llenarDataLikeTelefonoPropietario(string txt, bool Actividad)
        {
            try
            {
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(inmueble.SelLikeTelefonoPropietario(txt, Actividad));
                    GridInmueblesInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(inmueble.SelLikeTelefonoPropietario(txt, Actividad));
                    GridInmueblesActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void llenarDataLikeColonia(string txt, bool Actividad)
        {
            try
            {
                if (Actividad)
                {
                    DataTable table2 = new DataTable();
                    table2 = PresentacionTable(inmueble.SelLikeColonia(txt, Actividad));
                    GridInmueblesInactivos.ItemsSource = table2.AsDataView();
                }
                else if (Actividad == false)
                {
                    DataTable table = new DataTable();
                    table = PresentacionTable(inmueble.SelLikeColonia(txt, Actividad));
                    GridInmueblesActivos.ItemsSource = table.AsDataView();
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void btnModificarInmuebles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool res = false;
                DataRowView data = (GridInmueblesActivos as DataGrid).SelectedItem as DataRowView;
                res = inmueble.Actualizar(Convert.ToInt16(data.Row.ItemArray[0].ToString()), TXTClaveCatastralModificar.Text, TXTNombrePropietarioModificar.Text, TXTTelefonoPropietarioModificar.Text, TXTColoniaModificar.Text, TXTCalleModificar.Text, TXTEntreCallesModificar.Text, TXTNumeroInteriorModificar.Text, TXTNumeroExteriorModificar.Text);
                if (res)
                {
                    LlenarData();
                    PantallaCheck check = new PantallaCheck();
                    check.ShowDialog();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show(inmueble.Mensaje);
            }
            catch(Exception ex)
            {

            }
        }
        private void btnAgregarInmueble_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool re = false;
                re = inmueble.Insertar(TXTClaveCatastral.Text, TXTNombrePropietario.Text, TXTTelefonoPropietario.Text, TXTColonia.Text, TXTCalle.Text, TXTEntreCalles.Text, TXTNumeroInterior.Text, TXTNumeroExterior.Text);
                if (re)
                {
                    PantallaCheck check = new PantallaCheck();
                    LlenarData();
                    check.ShowDialog();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show(inmueble.Mensaje);
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
                DataRowView data = (GridInmueblesInactivos as DataGrid).SelectedItem as DataRowView;
                inmueble.Activar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
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
                DataRowView data = (GridInmueblesActivos as DataGrid).SelectedItem as DataRowView;
                inmueble.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
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
                DataRowView data = (GridInmueblesActivos as DataGrid).SelectedItem as DataRowView;
                TXTClaveCatastralModificar.Text = data.Row.ItemArray[1].ToString();
                TXTNombrePropietarioModificar.Text = data.Row.ItemArray[2].ToString();
                TXTTelefonoPropietarioModificar.Text = data.Row.ItemArray[3].ToString();
                //CMBColoniaModificar.ItemsSource = new string[]{data.Row.ItemArray[4].ToString()};
                //CMBColoniaModificar.SelectedIndex = 0;
                TXTColoniaModificar.Text= data.Row.ItemArray[4].ToString();
                TXTCalleModificar.Text = data.Row.ItemArray[5].ToString();
                TXTEntreCallesModificar.Text = data.Row.ItemArray[6].ToString();
                TXTNumeroInteriorModificar.Text = data.Row.ItemArray[7].ToString();
                TXTNumeroExteriorModificar.Text = data.Row.ItemArray[8].ToString();
                FormularioInmueblesModificar.IsOpen = true;
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
                //ACTIVOS
                if (OpcionesActivos.SelectedIndex == -1)
                {
                    LlenarData();
                }
                else if (OpcionesActivos.SelectedIndex == 0)
                {
                    TxtBusquedaActivos.MaxLength = 15;
                    llenarDataLikeClaveCatastral(TxtBusquedaActivos.Text, false);
                }
                else if (OpcionesActivos.SelectedIndex == 1)
                {
                    TxtBusquedaActivos.MaxLength = 60;
                    llenarDataLikeNombrePropietario(TxtBusquedaActivos.Text, false);
                }
                else if (OpcionesActivos.SelectedIndex == 2)
                {
                    TxtBusquedaActivos.MaxLength = 10;
                    llenarDataLikeTelefonoPropietario(TxtBusquedaActivos.Text, false);
                }
                else if (OpcionesActivos.SelectedIndex == 3)
                {
                    TxtBusquedaActivos.MaxLength = 50;
                    llenarDataLikeColonia(TxtBusquedaActivos.Text, false);
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
                //INACTIVOS
                if (OpcionesInactivos.SelectedIndex == -1)
                {
                    LlenarData();
                }
                else if (OpcionesInactivos.SelectedIndex == 0)
                {
                    TxtBusquedaInactivos.MaxLength = 15;
                    llenarDataLikeClaveCatastral(TxtBusquedaInactivos.Text, true);
                }
                else if (OpcionesInactivos.SelectedIndex == 1)
                {
                    TxtBusquedaInactivos.MaxLength = 60;
                    llenarDataLikeNombrePropietario(TxtBusquedaInactivos.Text, true);
                }
                else if (OpcionesInactivos.SelectedIndex == 2)
                {
                    TxtBusquedaInactivos.MaxLength = 10;
                    llenarDataLikeTelefonoPropietario(TxtBusquedaInactivos.Text, true);
                }
                else if (OpcionesInactivos.SelectedIndex == 3)
                {
                    TxtBusquedaInactivos.MaxLength = 50;
                    llenarDataLikeColonia(TxtBusquedaInactivos.Text, true);
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

        //private void TXTCodigoPostal_KeyUp(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        string codpos = TXTCodigoPostal.Text.Trim();
        //        if (codpos.Length == 5)
        //        {
        //            Sepomex sepomex = new Sepomex();
        //            CMBColonia.ItemsSource = sepomex.BuscarColoniaXCodigoPostal(codpos);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private void TXTCodigoPostalModificar_KeyUp(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        string codpos = TXTCodigoPostalModificar.Text.Trim();
        //        if (codpos.Length == 5)
        //        {
        //            Sepomex sepomex = new Sepomex();
        //            CMBColoniaModificar.ItemsSource = sepomex.BuscarColoniaXCodigoPostal(codpos);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}

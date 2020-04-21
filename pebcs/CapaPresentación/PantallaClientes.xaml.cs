using CapaLogica;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaClientes.xaml
    /// </summary>
    public partial class PantallaClientes : UserControl
    {
        Cliente cliente = new Cliente();
        Menu_Principal2 Mn;
        public PantallaClientes(Object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
            LlenarData();
        }
        public void LlenarData()
        {
            DataTable table = new DataTable();
            table = cliente.SelActivos();
            GridClientesActivos.ItemsSource = table.AsDataView();
            ACTIVOS.Text = "ACTIVOS: " + table.Rows.Count.ToString();
            DataTable table2 = new DataTable();
            table2 = cliente.SelEliminados();
            GridClientesInactivos.ItemsSource = table2.AsDataView();
            INACTIVOS.Text = "INACTIVOS: " + table2.Rows.Count.ToString();
        }
        public void llenarDataLikeRFC(string txt, bool Actividad)
        {
            if (Actividad)
            {
                DataTable table2 = new DataTable();
                table2 = cliente.SelLikeRfc(txt, Actividad);
                GridClientesInactivos.ItemsSource = table2.AsDataView();
            }
            else if (Actividad == false)
            {
                DataTable table = new DataTable();
                table = cliente.SelLikeRfc(txt, Actividad);
                GridClientesActivos.ItemsSource = table.AsDataView();
            }
        }
        public void llenarDataLikeNombre(string txt, bool Actividad)
        {
            if (Actividad)
            {
                DataTable table2 = new DataTable();
                table2 = cliente.SelLikeNombre(txt, Actividad);
                GridClientesInactivos.ItemsSource = table2.AsDataView();
            }
            else if (Actividad == false)
            {
                DataTable table = new DataTable();
                table = cliente.SelLikeNombre(txt, Actividad);
                GridClientesActivos.ItemsSource = table.AsDataView();
            }
        }
        public void llenarDataLikeTelefono(string txt, bool Actividad)
        {
            if (Actividad)
            {
                DataTable table2 = new DataTable();
                table2 = cliente.SelLikeTelefono(txt, Actividad);
                GridClientesInactivos.ItemsSource = table2.AsDataView();
            }
            else if (Actividad == false)
            {
                DataTable table = new DataTable();
                table = cliente.SelLikeTelefono(txt, Actividad);
                GridClientesActivos.ItemsSource = table.AsDataView();
            }
        }
        public void llenarDataLikeCorreo(string txt, bool Actividad)
        {
            if (Actividad)
            {
                DataTable table2 = new DataTable();
                table2 = cliente.SelLikeEmail(txt, Actividad);
                GridClientesInactivos.ItemsSource = table2.AsDataView();
            }
            else if (Actividad == false)
            {
                DataTable table = new DataTable();
                table = cliente.SelLikeEmail(txt, Actividad);
                GridClientesActivos.ItemsSource = table.AsDataView();
            }
        }
        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            cliente.Insertar(TXTRfc.Text,TXTNombre.Text, TXTApellido.Text, TXTTelefono.Text, TXTEmail.Text);
            PantallaCheck check = new PantallaCheck();
            LlenarData();
            check.ShowDialog();
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridClientesActivos as DataGrid).SelectedItem as DataRowView;
            cliente.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }
        private void GridClientesActivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            //TXTNombreModificar.Text = data.Row.ItemArray[1].ToString();
            //TXTApellidoModificar.Text = data.Row.ItemArray[2].ToString();
            //TXTTelefonoModificar.Text = data.Row.ItemArray[3].ToString();
            //TXTEmailModificar.Text = data.Row.ItemArray[4].ToString();
        }
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridClientesActivos as DataGrid).SelectedItem as DataRowView;
            TXTRfcModificar.Text = data.Row.ItemArray[1].ToString();
            TXTNombreModificar.Text = data.Row.ItemArray[2].ToString();
            TXTApellidoModificar.Text = data.Row.ItemArray[3].ToString();
            TXTTelefonoModificar.Text = data.Row.ItemArray[4].ToString();
            TXTEmailModificar.Text = data.Row.ItemArray[5].ToString();
            FormularioClientesModificar.IsOpen = true;
        }
        private void btnClienteModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridClientesActivos as DataGrid).SelectedItem as DataRowView;
            cliente.Actualizar(Convert.ToInt16(data.Row.ItemArray[0].ToString()),TXTRfcModificar.Text, TXTNombreModificar.Text, TXTApellidoModificar.Text, TXTTelefonoModificar.Text, TXTEmailModificar.Text);
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();

        }
        private void BtnRestaurar_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BtnRestaurar.Margin = new Thickness(81, 4, 0, 4);
        }
        private void BtnRestaurar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BtnRestaurar.Margin = new Thickness(0, 4, 0, 4);
        }
        private void BtnRestaurar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridClientesInactivos as DataGrid).SelectedItem as DataRowView;
            cliente.Activar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }
        private void Btn_Cerrar_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Btn_Cerrar.Margin = new Thickness(119, 4, 0, 4);
        }
        private void Btn_Cerrar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Btn_Cerrar.Margin = new Thickness(69, 4, 0, 4);
        }
        private void ActivadorActivos_Click(object sender, RoutedEventArgs e)
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
        private void Btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GridClientesInactivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ActivadorInactivos_Click(object sender, RoutedEventArgs e)
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
        private void TxtBusquedaActivos_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //Activos
            if (OpcionesActivos.SelectedIndex == -1)
            {
                LlenarData();
            }
            else if (OpcionesActivos.SelectedIndex == 0)
            {
                TxtBusquedaActivos.MaxLength = 13;
                llenarDataLikeRFC(TxtBusquedaActivos.Text,false);
            }
            else if (OpcionesActivos.SelectedIndex == 1)
            {
                TxtBusquedaActivos.MaxLength = 30;
                llenarDataLikeNombre(TxtBusquedaActivos.Text,false);
            }
            else if (OpcionesActivos.SelectedIndex == 2)
            {
                TxtBusquedaActivos.MaxLength = 10;
                llenarDataLikeTelefono(TxtBusquedaActivos.Text,false);
            }
            else if (OpcionesActivos.SelectedIndex == 3)
            {
                TxtBusquedaActivos.MaxLength = 255;
                llenarDataLikeCorreo(TxtBusquedaActivos.Text,false);
            }
        }
        private void TxtBusquedaInactivos_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
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
    }
}

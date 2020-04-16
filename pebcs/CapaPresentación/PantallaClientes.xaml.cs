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
        public PantallaClientes()
        {
            InitializeComponent();
            LlenarData();
        }
        public void LlenarData()
        {
            DataTable table = new DataTable();
            table = cliente.SelActivos();
            GridConceptos.ItemsSource = table.AsDataView();
            DataTable table2 = new DataTable();
            table2 = cliente.SelEliminados();
            GridConceptosEliminados.ItemsSource = table2.AsDataView();
        }
        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            bool re;
            re = cliente.dtsInsertar(TXTNombre.Text, TXTApellido.Text, TXTTelefono.Text, TXTEmail.Text);
            if (re)
            {
                PantallaCheck check = new PantallaCheck();
                LlenarData();
                check.ShowDialog();
            }
            else
            {
                MessageBox.Show("no se pudo");
                
            }
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            cliente.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }

        private void GridConceptos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            //TXTNombreModificar.Text = data.Row.ItemArray[1].ToString();
            //TXTApellidoModificar.Text = data.Row.ItemArray[2].ToString();
            //TXTTelefonoModificar.Text = data.Row.ItemArray[3].ToString();
            //TXTEmailModificar.Text = data.Row.ItemArray[4].ToString();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            TXTNombreModificar.Text = data.Row.ItemArray[1].ToString();
            TXTApellidoModificar.Text = data.Row.ItemArray[2].ToString();
            TXTTelefonoModificar.Text = data.Row.ItemArray[3].ToString();
            TXTEmailModificar.Text = data.Row.ItemArray[4].ToString();
            FormularioClientesModificar.IsOpen = true;
        }

        private void btnClienteModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            cliente.Actualizar(Convert.ToInt16(data.Row.ItemArray[0].ToString()), TXTNombreModificar.Text, TXTApellidoModificar.Text, TXTTelefonoModificar.Text, TXTEmailModificar.Text);
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();

        }

        private void BtnRestaurar_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BtnRestaurar.Margin = new Thickness(837, 15, 0, 353);
        }

        private void BtnRestaurar_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            BtnRestaurar.Margin = new Thickness(752, 15, 0, 353);
        }

        private void BtnRestaurar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptosEliminados as DataGrid).SelectedItem as DataRowView;
        }
    }
}

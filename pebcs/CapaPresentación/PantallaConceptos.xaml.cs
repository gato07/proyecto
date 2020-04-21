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
using System.Data;


namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaConceptos.xaml
    /// </summary>
    public partial class PantallaConceptos : UserControl
    {
        Concepto concepto = new Concepto();
        public PantallaConceptos()
        {
            InitializeComponent();
            LlenarData();
        }
        public void LlenarData()
        {
            DataTable table = new DataTable();
            table = concepto.SelActivos();
            GridConceptosActivos.ItemsSource = table.AsDataView();
            ACTIVOS.Text = "Activos: " + table.Rows.Count.ToString();
            DataTable table2 = new DataTable();
            table2 = concepto.SelEliminados();
            GridConceptosInactivos.ItemsSource = table2.AsDataView();
            INACTIVOS.Text = "Inactivos: " + table2.Rows.Count.ToString();
        }
        private void btnAgregarConcepto_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;
            if (Decimal.TryParse(TXTCosto.Text, out decimal costo))
            {
                res = concepto.Insertar(TXTTipo.Text, TXTNombre.Text, TXTDescripcion.Text, costo);
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
        private void btnConceptoModificar_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;
            DataRowView data = (GridConceptosActivos as DataGrid).SelectedItem as DataRowView;
            if (Decimal.TryParse(TXTCostoModificar.Text, out decimal costo))
            {
                res = concepto.Actualizar(Convert.ToInt16(data.Row.ItemArray[0].ToString()), TXTTipoModificar.Text, TXTNombreModificar.Text, TXTDescripcionModificar.Text, costo);
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
        private void BtnRestaurar_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnRestaurar.Margin = new Thickness(81, 4, 0, 4);
        }
        private void BtnRestaurar_MouseMove(object sender, MouseEventArgs e)
        {
            BtnRestaurar.Margin = new Thickness(0, 4, 0, 4);
        }
        private void BtnRestaurar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptosInactivos as DataGrid).SelectedItem as DataRowView;
            concepto.Activar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptosActivos as DataGrid).SelectedItem as DataRowView;
            concepto.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptosActivos as DataGrid).SelectedItem as DataRowView;
            TXTTipoModificar.Text = data.Row.ItemArray[1].ToString();
            TXTNombreModificar.Text = data.Row.ItemArray[2].ToString();
            TXTDescripcionModificar.Text = data.Row.ItemArray[3].ToString();
            TXTCostoModificar.Text = data.Row.ItemArray[4].ToString();
            FormularioConceptosModificar.IsOpen = true;
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
        private void TxtBusquedaActivos_KeyUp(object sender, KeyEventArgs e)
        {
            //ACTIVOS
            if (OpcionesActivos.SelectedIndex == -1)
            {
                LlenarData();
            }
            else if (OpcionesActivos.SelectedIndex == 0)
            {
                TxtBusquedaActivos.MaxLength = 25;
                //Busqueda Tipo
            }
            else if (OpcionesActivos.SelectedIndex == 1)
            {
                TxtBusquedaActivos.MaxLength = 75;
                //Busqueda Nombre
            }
            else if (OpcionesActivos.SelectedIndex == 2)
            {
                TxtBusquedaActivos.MaxLength = 255;
                //Busqueda Descripcion
            }
            else if (OpcionesActivos.SelectedIndex == 3)
            {
                TxtBusquedaActivos.MaxLength = 10;
                //Buesqueda Costo
            }
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
        private void TxtBusquedaInactivos_KeyUp(object sender, KeyEventArgs e)
        {
            //INACTIVOS
            if (OpcionesInactivos.SelectedIndex == -1)
            {
                LlenarData();
            }
            else if (OpcionesInactivos.SelectedIndex == 0)
            {
                TxtBusquedaInactivos.MaxLength = 25;
                //Busqueda Tipo 
            }
            else if (OpcionesInactivos.SelectedIndex == 1)
            {
                TxtBusquedaInactivos.MaxLength = 75;
                //Busqueda Nombre
            }
            else if (OpcionesInactivos.SelectedIndex == 2)
            {
                TxtBusquedaInactivos.MaxLength = 255;
                //Busqueda Descripcion
            }
            else if (OpcionesInactivos.SelectedIndex == 3)
            {
                TxtBusquedaInactivos.MaxLength = 10;
                //Buesqueda Costo
            }
        }
        private void Btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Cerrar.Margin = new Thickness(69, 4, 0, 4);
        }
        private void Btn_Cerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_Cerrar.Margin = new Thickness(119, 4, 0, 4);
        }
    }
}

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
            GridConceptos.ItemsSource = table.AsDataView();
            DataTable table2 = new DataTable();
            table2 = concepto.SelEliminados();
            GridConceptosEliminados.ItemsSource = table2.AsDataView();
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
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
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
            BtnRestaurar.Margin = new Thickness(837, 15, 0, 353);
        }

        private void BtnRestaurar_MouseMove(object sender, MouseEventArgs e)
        {
            BtnRestaurar.Margin = new Thickness(752, 15, 0, 353);
        }

        private void BtnRestaurar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptosEliminados as DataGrid).SelectedItem as DataRowView;
            concepto.Activar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            concepto.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            TXTTipoModificar.Text = data.Row.ItemArray[1].ToString();
            TXTNombreModificar.Text = data.Row.ItemArray[2].ToString();
            TXTDescripcionModificar.Text = data.Row.ItemArray[3].ToString();
            TXTCostoModificar.Text = data.Row.ItemArray[4].ToString();
            FormularioConceptosModificar.IsOpen = true;
        }
    }
}

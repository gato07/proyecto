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
            table = concepto.SelTodos();
            GridConceptos.ItemsSource = table.AsDataView();
        }

        private void btnAgregarConcepto_Click(object sender, RoutedEventArgs e)
        {
            bool re;
            re = concepto.dtsInsertar(TXTTipo.Text, TXTNombre.Text, TXTDescripcion.Text, Convert.ToDecimal(TXTCosto.Text));
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

        private void btnConceptoModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            concepto.Actualizar(Convert.ToInt16(data.Row.ItemArray[0].ToString()), TXTTipoModificar.Text, TXTNombreModificar.Text, TXTDescripcionModificar.Text, Convert.ToDecimal(TXTCostoModificar.Text));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }

        private void BtnEliminarConcepto_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            concepto.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }

        private void BtnModificarConcepto_Click(object sender, RoutedEventArgs e)
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

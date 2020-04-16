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
            InitializeComponent();
            LlenarData();
        }
        public void LlenarData()
        {
            DataTable table = new DataTable();
            table = inmueble.SelActivos();
            GridConceptos.ItemsSource = table.AsDataView();
        }

        private void btnModificarInmuebles_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            inmueble.Actualizar(Convert.ToInt16(data.Row.ItemArray[0].ToString()), TXTClaveCatastralModificar.Text, TXTNombrePropietarioModificar.Text, TXTTelefonoPropietarioModificar.Text, TXTColoniaModificar.Text, TXTCalleModificar.Text, TXTEntreCallesModificar.Text, TXTNumeroInteriorModificar.Text, TXTNumeroExteriorModificar.Text);
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }

        private void BtnEliminarInmueble_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            inmueble.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }

        private void BtnModificarInmueble_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            TXTClaveCatastralModificar.Text = data.Row.ItemArray[1].ToString();
            TXTNombrePropietarioModificar.Text = data.Row.ItemArray[2].ToString();
            TXTTelefonoPropietarioModificar.Text = data.Row.ItemArray[3].ToString();
            TXTColoniaModificar.Text = data.Row.ItemArray[4].ToString();
            TXTCalleModificar.Text = data.Row.ItemArray[4].ToString();
            TXTEntreCallesModificar.Text = data.Row.ItemArray[4].ToString();
            TXTNumeroInteriorModificar.Text = data.Row.ItemArray[4].ToString();
            TXTNumeroExteriorModificar.Text = data.Row.ItemArray[4].ToString();
            FormularioInmueblesModificar.IsOpen = true;
        }

        private void btnAgregarInmueble_Click(object sender, RoutedEventArgs e)
        {
            bool re;
            re = inmueble.dtsInsertar(TXTClaveCatastral.Text,TXTNombrePropietario.Text,TXTTelefonoPropietario.Text,TXTColonia.Text,TXTCalle.Text,TXTEntreCalles.Text,TXTNumeroInterior.Text,TXTNumeroExterior.Text);
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
    }
}

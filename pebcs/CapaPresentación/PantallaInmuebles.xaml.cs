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
            DataTable table2 = new DataTable();
            table2 = inmueble.SelEliminados();
            GridConceptosEliminados.ItemsSource = table2.AsDataView();
        }

        private void btnModificarInmuebles_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            res = inmueble.Actualizar(Convert.ToInt16(data.Row.ItemArray[0].ToString()), TXTClaveCatastralModificar.Text, TXTNombrePropietarioModificar.Text, TXTTelefonoPropietarioModificar.Text, TXTColoniaModificar.Text, TXTCalleModificar.Text, TXTEntreCallesModificar.Text, TXTNumeroInteriorModificar.Text, TXTNumeroExteriorModificar.Text);
            if (res)
            {
                LlenarData();
                PantallaCheck check = new PantallaCheck();
                check.ShowDialog();
            }
            else
                MessageBox.Show(inmueble.Mensaje);
        }
        private void btnAgregarInmueble_Click(object sender, RoutedEventArgs e)
        {
            bool re = false;
            re = inmueble.Insertar(TXTClaveCatastral.Text,TXTNombrePropietario.Text,TXTTelefonoPropietario.Text,TXTColonia.Text,TXTCalle.Text,TXTEntreCalles.Text,TXTNumeroInterior.Text,TXTNumeroExterior.Text);
            if (re)
            {
                PantallaCheck check = new PantallaCheck();
                LlenarData();
                check.ShowDialog();
            }
            else
                MessageBox.Show(inmueble.Mensaje);
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
            inmueble.Activar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            inmueble.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridConceptos as DataGrid).SelectedItem as DataRowView;
            TXTClaveCatastralModificar.Text = data.Row.ItemArray[1].ToString();
            TXTNombrePropietarioModificar.Text = data.Row.ItemArray[2].ToString();
            TXTTelefonoPropietarioModificar.Text = data.Row.ItemArray[3].ToString();
            TXTColoniaModificar.Text = data.Row.ItemArray[4].ToString();
            TXTCalleModificar.Text = data.Row.ItemArray[5].ToString();
            TXTEntreCallesModificar.Text = data.Row.ItemArray[6].ToString();
            TXTNumeroInteriorModificar.Text = data.Row.ItemArray[7].ToString();
            TXTNumeroExteriorModificar.Text = data.Row.ItemArray[8].ToString();
            FormularioInmueblesModificar.IsOpen = true;
        }
    }
}

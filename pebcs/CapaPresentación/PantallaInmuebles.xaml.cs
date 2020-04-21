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
            GridInmueblesActivos.ItemsSource = table.AsDataView();
            ACTIVOS.Text = "ACTIVOS: " + table.Rows.Count.ToString();
            DataTable table2 = new DataTable();
            table2 = inmueble.SelEliminados();
            GridInmueblesInactivos.ItemsSource = table2.AsDataView();
            INACTIVOS.Text = "INACTIVOS: " + table2.Rows.Count.ToString();
        }
        public void llenarDataLikeClaveCatastral(string txt,bool Actividad)
        {
            if (Actividad)
            {
                DataTable table2 = new DataTable();
                table2 = inmueble.SelLikeClaveCatastral(txt, Actividad);
                GridInmueblesInactivos.ItemsSource = table2.AsDataView();
            }
            else if(Actividad==false)
            {
                DataTable table = new DataTable();
                table = inmueble.SelLikeClaveCatastral(txt, Actividad);
                GridInmueblesActivos.ItemsSource = table.AsDataView();
            }
        }
        public void llenarDataLikeNombrePropietario(string txt, bool Actividad)
        {
            if (Actividad)
            {
                DataTable table2 = new DataTable();
                table2 = inmueble.SelLikeNombrePropietario(txt, Actividad);
                GridInmueblesInactivos.ItemsSource = table2.AsDataView();
            }
            else if (Actividad == false)
            {
                DataTable table = new DataTable();
                table = inmueble.SelLikeNombrePropietario(txt, Actividad);
                GridInmueblesActivos.ItemsSource = table.AsDataView();
            }
        }
        public void llenarDataLikeTelefonoPropietario(string txt, bool Actividad)
        {
            if (Actividad)
            {
                DataTable table2 = new DataTable();
                table2 = inmueble.SelLikeTelefonoPropietario(txt, Actividad);
                GridInmueblesInactivos.ItemsSource = table2.AsDataView();
            }
            else if (Actividad == false)
            {
                DataTable table = new DataTable();
                table = inmueble.SelLikeTelefonoPropietario(txt, Actividad);
                GridInmueblesActivos.ItemsSource = table.AsDataView();
            }
        }
        public void llenarDataLikeColonia(string txt, bool Actividad)
        {
            if (Actividad)
            {
                DataTable table2 = new DataTable();
                table2 = inmueble.SelLikeColonia(txt, Actividad);
                GridInmueblesInactivos.ItemsSource = table2.AsDataView();
            }
            else if (Actividad == false)
            {
                DataTable table = new DataTable();
                table = inmueble.SelLikeColonia(txt, Actividad);
                GridInmueblesActivos.ItemsSource = table.AsDataView();
            }
        }
        private void btnModificarInmuebles_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;
            DataRowView data = (GridInmueblesActivos as DataGrid).SelectedItem as DataRowView;
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
            BtnRestaurar.Margin = new Thickness(81, 4, 0, 4);
        }
        private void BtnRestaurar_MouseMove(object sender, MouseEventArgs e)
        {
            BtnRestaurar.Margin = new Thickness(0, 4, 0, 4);
        }
        private void BtnRestaurar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridInmueblesInactivos as DataGrid).SelectedItem as DataRowView;
            inmueble.Activar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridInmueblesActivos as DataGrid).SelectedItem as DataRowView;
            inmueble.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            LlenarData();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
        }
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = (GridInmueblesActivos as DataGrid).SelectedItem as DataRowView;
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
        private void Btn_Cerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_Cerrar.Margin = new Thickness(119, 4, 0, 4);
        }
        private void Btn_Cerrar_MouseMove(object sender, MouseEventArgs e)
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
        private void TxtBusquedaActivos_KeyUp(object sender, KeyEventArgs e)
        {
            //ACTIVOS
            if (OpcionesActivos.SelectedIndex == -1)
            {
                LlenarData();
            }
            else if (OpcionesActivos.SelectedIndex == 0)
            {
                TxtBusquedaActivos.MaxLength = 15;
                llenarDataLikeClaveCatastral(TxtBusquedaActivos.Text,false);
            }
            else if (OpcionesActivos.SelectedIndex == 1)
            {
                TxtBusquedaActivos.MaxLength = 60;
                llenarDataLikeNombrePropietario(TxtBusquedaActivos.Text,false);
            }
            else if (OpcionesActivos.SelectedIndex == 2)
            {
                TxtBusquedaActivos.MaxLength = 10;
                llenarDataLikeTelefonoPropietario(TxtBusquedaActivos.Text,false);
            }
            else if (OpcionesActivos.SelectedIndex == 3)
            {
                TxtBusquedaActivos.MaxLength = 50;
                llenarDataLikeColonia(TxtBusquedaActivos.Text,false);
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
        private void Btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

﻿using CapaLogica;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Menu_Principal.xaml
    /// </summary>
    public partial class Menu_Principal : Window
    {
        public Menu_Principal()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonOpenMenu.Visibility = Visibility.Collapsed;
                ButtonCloseMenu.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

            }
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonOpenMenu.Visibility = Visibility.Visible;
                ButtonCloseMenu.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AbrirFormHijo(new PantallaUsuario(this));
                titulo.Text = "USUARIOS";
                btnCerrarModulo.Visibility = Visibility.Visible;
                btnAgregarAModulo.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

            }
        }
        public void AbrirFormHijo(object formhijo)
        {
            try
            {
                if (this.PanelPrincipal.Children.Count > 0)
                    this.PanelPrincipal.Children.RemoveAt(0);
                UserControl userControl = formhijo as UserControl;
                PanelPrincipal.Children.Add(userControl);
            }
            catch (Exception ex)
            {

            }
        }
        private void btnCerrarModulo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.PanelPrincipal.Children.RemoveAt(0);
                titulo.Text = "BIENVENIDO";
                btnCerrarModulo.Visibility = Visibility.Hidden;
                btnAgregarAModulo.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonimg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                BitmapImage b = new BitmapImage();
                openFile.Title = "Seleccione la Imagen a Mostrar";
                openFile.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp";
                if (openFile.ShowDialog() == true)
                {
                    if (new FileInfo(openFile.FileName).Length > 131072)
                    {
                        MessageBox.Show(
                    "El tamaño máximo permitido de la imagen es de 128 KB",
                    "Mensaje de Sistema",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning,
                        MessageBoxResult.OK);
                        return;
                    }
                    b.BeginInit();
                    b.UriSource = new Uri(openFile.FileName);
                    b.EndInit();
                    imgb.ImageSource = new BitmapImage(new Uri(openFile.FileName));
                    imgb.Stretch = Stretch.UniformToFill;
                    buttonimg.Background = imgb;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Empleado emp = new Empleado();
                if (emp.Insertar(TXTNombreCompleto.Text, TXTDomicilio.Text, TXTTelefono.Text, TXTEmail.Text, imgb.ImageSource.ToString(), Convert.ToInt16(listPerfil.SelectedIndex.ToString()), TXTUsuario.Text, TXTConstraseña.Text) == true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.ShowDialog();
                }
                else
                {
                    MessageBox.Show(emp.Mensaje);
                }
                AbrirFormHijo(new PantallaUsuario(this));
            }
            catch (Exception ex)
            {

            }
        }

        private void listViewItem4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AbrirFormHijo(new PantallaConceptos());
                titulo.Text = "CONCEPTOS";
                btnCerrarModulo.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

            }
        }

        private void listViewItem5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AbrirFormHijo(new PantallaClientes());
                titulo.Text = "CLIENTES";
                btnCerrarModulo.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

            }
        }

        private void listViewItem6_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AbrirFormHijo(new PantallaInmuebles());
                titulo.Text = "INMUEBLES";
                btnCerrarModulo.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

            }
        }
    }
}

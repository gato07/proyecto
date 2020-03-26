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
using System.Windows.Shapes;
using TestStack.White.ScreenObjects;
using Microsoft.Win32;
using System.IO;
using CapaLogica;
using CapaPresentación.Controles;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Menu_Principal.xaml
    /// </summary>
    public partial class Menu_Principal : Window
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private  void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AbrirFormHijo(new PantallaUsuario());
            titulo.Text = "USUARIOS";
            btnCerrarModulo.Visibility = Visibility.Visible;
            btnAgregarAModulo.Visibility = Visibility.Visible;
        }
        public void AbrirFormHijo(object formhijo)
        {
            if (this.PanelPrincipal.Children.Count > 0)
                this.PanelPrincipal.Children.RemoveAt(0);
            UserControl userControl = formhijo as UserControl;
            PanelPrincipal.Children.Add(userControl);
        }
        private void btnCerrarModulo_Click(object sender, RoutedEventArgs e)
        {
            this.PanelPrincipal.Children.RemoveAt(0);
            titulo.Text = "BIENVENIDO";
            btnCerrarModulo.Visibility = Visibility.Hidden;
            btnAgregarAModulo.Visibility = Visibility.Hidden;
        }

        private void buttonimg_Click(object sender, RoutedEventArgs e)
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

        private void btnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = new Empleado();
            if (emp.Insertar(TXTNombreCompleto.Text, TXTDomicilio.Text, TXTTelefono.Text, TXTEmail.Text, TXTPuesto.Text, imgb.ImageSource.ToString(), Convert.ToInt16(listPerfil.SelectedIndex.ToString()), TXTUsuario.Text, TXTConstraseña.Text)==true)
            {
                PantallaCheck check = new PantallaCheck();
                check.ShowDialog();
            }
            else
            {
                MessageBox.Show(emp.Mensaje);
            }
            AbrirFormHijo(new PantallaUsuario());
        }
    }
}

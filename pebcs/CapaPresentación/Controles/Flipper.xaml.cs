using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace CapaPresentación.Controles
{
    /// <summary>
    /// Lógica de interacción para Flipper.xaml
    /// </summary>
    public partial class Flipper : UserControl
    {
        int ID;
        PantallaUsuario Win;
        public Flipper(Object A)
        {
            InitializeComponent();
            Win = A as PantallaUsuario;
        }

        private void BTN_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = new Empleado();
            emp.Actualizar(ID,TXTNombreCompleto.Text,TXTDomicilio.Text,TXTTelefono.Text,TXTEmail.Text,TXTPuesto.Text, imgb.ImageSource.ToString(), TXTPerfil.Text,TXTUsuario.Text,TXTConstraseña.Text);
            Win.panelprincipal.Children.Clear();
            Win.generartarjetas();
        }
        public void CargarDatosTarjeta(int CALVE,string NombreCompleto,string Domicilio, string Telefono,string Email,string Puesto,string Foto,string Perfil,string Usuario,string Contraseña)
        {
            ID = CALVE;
            imgb.ImageSource = new BitmapImage(new Uri(Foto));
            imgb.Stretch = Stretch.UniformToFill;
            Etiqueta.Text = Usuario;
            TXTNombreCompleto.Text = NombreCompleto;
            TXTDomicilio.Text = Domicilio;
            TXTTelefono.Text = Telefono;
            TXTEmail.Text = Email;
            TXTPuesto.Text = Puesto;
            buttonimg.Background = imgb;
            TXTPerfil.Text = Perfil;
            TXTUsuario.Text = Usuario;
            TXTConstraseña.Text = Contraseña;
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

        private void BTN_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado em = new Empleado();
            em.Eliminar(ID);
            Win.panelprincipal.Children.Clear();
            Win.generartarjetas();
        }
    }
}

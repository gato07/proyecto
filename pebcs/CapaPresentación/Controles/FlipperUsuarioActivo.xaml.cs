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
        Menu_Principal2 MN;
        PantallaCheck check = new PantallaCheck();
        string[] Datos = new string[10];
        int IdUSUATIO;
        public Flipper(Object A,Object B,int iDe)
        {
            try
            {
                InitializeComponent();
                Win = A as PantallaUsuario;
                MN = B as Menu_Principal2;
                IdUSUATIO = iDe;
            }
            catch (Exception ex)
            {

            }
        }

        //private void BTN_Guardar_Click(object sender, RoutedEventArgs e)
        //{
        //    Empleado emp = new Empleado();
        //    emp.Actualizar(ID,TXTNombreCompleto.Text,TXTDomicilio.Text,TXTTelefono.Text,TXTEmail.Text,TXTPuesto.Text, imgb.ImageSource.ToString(), Convert.ToInt16(listPerfil.SelectedIndex.ToString()),TXTUsuario.Text,TXTConstraseña.Text);
        //    Win.panelprincipal.Children.Clear();
        //    Win.generartarjetas();
        //    check.ShowDialog();
        //}
        public void CargarDatosTarjeta(int CALVE, string NombreCompleto, string Domicilio, string Telefono, string Email, string Foto, int Perfil, string Usuario)
        {
            try
            {
                Datos[0] = CALVE.ToString();
                Datos[1] = NombreCompleto;
                Datos[2] = Domicilio;
                Datos[3] = Telefono.ToString();
                Datos[4] = Email;
                Datos[5] = Foto;
                Datos[6] = Perfil.ToString();
                Datos[7] = Usuario;
                ID = CALVE;
                imgb.ImageSource = new BitmapImage(new Uri(Foto));
                imgb.Stretch = Stretch.UniformToFill;
                Etiqueta.Text = Usuario;
                buttonimg.Background = imgb;
            }
            catch(Exception ex)
            {

            }
        }

        private void buttonimg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //OpenFileDialog openFile = new OpenFileDialog();
                //BitmapImage b = new BitmapImage();
                //openFile.Title = "Seleccione la Imagen a Mostrar";
                //openFile.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp";
                //if (openFile.ShowDialog() == true)
                //{
                //    if (new FileInfo(openFile.FileName).Length > 131072)
                //    {
                //        MessageBox.Show(
                //    "El tamaño máximo permitido de la imagen es de 128 KB",
                //    "Mensaje de Sistema",
                //        MessageBoxButton.OK,
                //        MessageBoxImage.Warning,
                //        MessageBoxResult.OK);
                //        return;
                //    }
                //    b.BeginInit();
                //    b.UriSource = new Uri(openFile.FileName);
                //    b.EndInit();
                //    imgb.ImageSource = new BitmapImage(new Uri(openFile.FileName));
                //    imgb.Stretch = Stretch.UniformToFill;
                //    buttonimg.Background = imgb;
                //}
            }
            catch(Exception ex)
            {

            }
        }

        private void BTN_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Empleado em = new Empleado();
                em.Eliminar(ID);
                //Win.GridContenedor.Children.Clear();
                Win.n.Items.Clear();
                Win.generartarjetas();
                check.ShowDialog();
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //this.Cursor = Cursors.Wait;
                //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
                MN.AbrirFormHijo(new Pantalla_PerfilUsuario(Datos, MN, IdUSUATIO));
            }
            catch (Exception ex)
            {

            }
        }

        private void Card_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Card.Margin = new Thickness(0, 0, 0, 0);
            }
            catch (Exception ex)
            {

            }
        }

        private void Card_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Card.Margin = new Thickness(10, 10, 10, 10);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

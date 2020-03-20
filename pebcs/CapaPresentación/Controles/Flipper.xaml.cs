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

namespace CapaPresentación.Controles
{
    /// <summary>
    /// Lógica de interacción para Flipper.xaml
    /// </summary>
    public partial class Flipper : UserControl
    {
        int ID;
        public Flipper()
        {
            InitializeComponent();
        }

        private void BTN_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = new Empleado();
            emp.Actualizar(ID,TXTNombreCompleto.Text,TXTDomicilio.Text,TXTTelefono.Text,TXTEmail.Text,TXTPuesto.Text, "C:/Users/Alejandro/Pictures/pexels-photo-247885.jpeg", TXTPerfil.Text,TXTUsuario.Text,TXTConstraseña.Text);
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

        }
    }
}

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

namespace CapaPresentación.Controles
{
    /// <summary>
    /// Lógica de interacción para Flipper.xaml
    /// </summary>
    public partial class Flipper : UserControl
    {
        public Flipper()
        {
            InitializeComponent();
        }

        private void BTN_Guardar_Click(object sender, RoutedEventArgs e)
        {

        }
        public void CargarDatosTarjeta(string NombreCompleto,string Domicilio, string Telefono,string Email,string Puesto,string Foto,string Perfil,string Usuario,string Contraseña)
        {
            imgb.ImageSource = new BitmapImage(new Uri(Foto));
            imgb.Stretch = Stretch.UniformToFill;
            Etiqueta.Text = Usuario;
            TXTNombreCompleto.Text = NombreCompleto;
            TXTDomicilio.Text = Domicilio;
            TXTTelefono.Text = Telefono;
            TXTEmail.Text = Email;
            TXTPuesto.Text = Puesto;
            button.Background = imgb;
            TXTPerfil.Text = Perfil;
            TXTUsuario.Text = Usuario;
            TXTConstraseña.Text = Contraseña;
        }
    }
}

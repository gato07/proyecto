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
    /// Lógica de interacción para FlipperUsuarioInactivo.xaml
    /// </summary>
    public partial class FlipperUsuarioInactivo : UserControl
    {
        int ID;
        PantallaUsuario Win;
        Menu_Principal2 MN;
        string[] Datos = new string[10];
        public FlipperUsuarioInactivo(object A, Object B)
        {
            InitializeComponent();
            Win = A as PantallaUsuario;
            MN = B as Menu_Principal2;
        }

        private void Flip_MouseLeave(object sender, MouseEventArgs e)
        {
            Flip.Margin = new Thickness(10, 10, 10, 10);
        }

        private void Flip_MouseMove(object sender, MouseEventArgs e)
        {
            Flip.Margin = new Thickness(0, 0, 0, 0);
        }
        public void CargarDatosTarjeta(int CALVE, string NombreCompleto, string Domicilio, string Telefono, string Email, string Puesto, string Foto, int Perfil, string Usuario, string Contraseña)
        {
            Datos[0] = CALVE.ToString();
            Datos[1] = NombreCompleto;
            Datos[2] = Domicilio;
            Datos[3] = Telefono.ToString();
            Datos[4] = Email;
            Datos[5] = Puesto;
            Datos[6] = Foto;
            Datos[7] = Perfil.ToString();
            Datos[8] = Usuario;
            Datos[9] = Contraseña;
            ID = CALVE;
            imgb.ImageSource = new BitmapImage(new Uri(Foto));
            imgb.Stretch = Stretch.UniformToFill;
            Etiqueta.Text = Usuario;
            buttonimg.Background = imgb;
        }
        private void Btn_Restaurar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = new Empleado();
            PantallaCheck check = new PantallaCheck();
            check.ShowDialog();
            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
            emp.Activar(ID);
            MN.AbrirFormHijo(new PantallaUsuario(MN));
        }
    }
}

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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
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
        int IdUSUATIO;
        public FlipperUsuarioInactivo(object A, Object B ,int iDe)
        {
            try
            {
                InitializeComponent();
                Win = A as PantallaUsuario;
                MN = B as Menu_Principal2;
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += Timer_Tick;
                timer.Start();
                IdUSUATIO = iDe;
            }
            catch(Exception ex)
            {

            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                var fadeAnimation = new DoubleAnimation();
                fadeAnimation.From = 1;
                fadeAnimation.To = 0.5;
                fadeAnimation.AutoReverse = true;
                Card.BeginAnimation(Label.OpacityProperty, fadeAnimation);
            }
            catch(Exception ex)
            {

            }
        }
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
        private void Btn_Restaurar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Empleado emp = new Empleado();
                PantallaCheck check = new PantallaCheck();
                check.ShowDialog();
                //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));
                emp.Activar(ID);
                MN.AbrirFormHijo(new PantallaUsuario(MN, IdUSUATIO));
            }
            catch(Exception ex)
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

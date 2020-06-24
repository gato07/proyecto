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

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {

            }
        }

        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {

            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Empleado empleado = new Empleado();
                empleado.dtsSelXUsuario(txt_Usuario.Text.Trim());
                if (empleado.Existe)
                {
                    string contrasena = txt_Password.Password.Trim();
                    if (Seguridad.Desencriptar(empleado.Contrasena) == contrasena)
                    {
                        Menu_Principal2 Ventana = new Menu_Principal2();
                        Ventana.ShowDialog();
                    }
                    else
                        MessageBox.Show("Nombre de usuario y/o contraseña incorrecto(s), intente de nuevo");
                }
                else
                    MessageBox.Show("Nombre de usuario y/o contraseña incorrecto(s), intente de nuevo");
            }
            catch(Exception ex)
            {

            }
        }
    }
}

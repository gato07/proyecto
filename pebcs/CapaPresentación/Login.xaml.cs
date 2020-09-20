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
                int ID = empleado.Validar_Usuario(txt_Usuario.Text, txt_Password.Password);
                if (ID>0)
                {
                    Menu_Principal2 Ventana = new Menu_Principal2(ID);
                    Ventana.ShowDialog();
       
                }
                else
                    MessageBox.Show(empleado.Mensaje);
            }
            catch(Exception ex)
            {

            }
        }
    }
}

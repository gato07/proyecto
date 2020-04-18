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

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_PerfilUsuario.xaml
    /// </summary>
    public partial class Pantalla_PerfilUsuario : UserControl
    {
        public Pantalla_PerfilUsuario(string []A)
        {
            InitializeComponent();
            LlenarDatos(A);
        }
        public void LlenarDatos(string[] vs)
        {
            TXTNombreCompleto.Text = vs[1];
            TXTDomicilio.Text = vs[2];
            TXTTelefono.Text = vs[3];
            TXTEmail.Text = vs[4];
            TXTPuesto.Text = vs[5];
            img.ImageSource = new BitmapImage(new Uri(vs[6].ToString()));
            listPerfil.SelectedIndex = Convert.ToInt16(vs[7]);
            TXTUsuario.Text = vs[8];
            TXTConstraseña.Text = vs[9];
        }

        private void Btn_Guardar_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_Guardar.Margin = new Thickness(820, 36, 0, 285);
        }

        private void Btn_Guardar_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Guardar.Margin = new Thickness(765, 36, 0, 285);
        }

        private void Btn_Limpiar_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_Limpiar.Margin = new Thickness(820, 81, 0, 240);
        }

        private void Btn_Limpiar_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Limpiar.Margin = new Thickness(765, 81, 0, 240);
        }

        private void Btn_Cancelar_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_Cancelar.Margin = new Thickness(820, 126, 0, 195);
        }

        private void Btn_Cancelar_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Cancelar.Margin = new Thickness(765, 126, 0, 195);
        }
    }
}

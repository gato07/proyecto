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
    /// Lógica de interacción para TarjetaLicencia.xaml
    /// </summary>
    public partial class TarjetaLicencia : UserControl
    {
        int ID;
        Menu_Principal2 Mn;
        public TarjetaLicencia(Object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
        }
        public void CargaDatosLicencia(int ID2,string etiqueta,string NoLicencia,string folio,string tipoobra,string uso ,string presupuesto,string Estado, DateTime date)
        {
            ID = ID2;
            titulo.Content =etiqueta;
            TXT_Folio.Text = folio;
            TXT_NoLicencia.Text = NoLicencia;
            TXT_TipoObra.Text = tipoobra;
            TXT_Uso.Text = uso;
            TXT_presupuesto.Text = presupuesto;
            Status.Content = Estado;
            Fecha.Content = date;
        }

        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Mn.AbrirFormHijo(new Pantalla_InfoLicencia(0,ID)) ;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                CardLicencia.Margin = new Thickness(0, 0, 0, 0);
            }
            catch (Exception ex)
            {

            }
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                CardLicencia.Margin = new Thickness(10, 10, 10, 10);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

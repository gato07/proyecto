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
using System.IO;

namespace CapaPresentación.Controles
{
    /// <summary>
    /// Lógica de interacción para Presupuesto.xaml
    /// </summary>
    public partial class Presupuesto : UserControl
    {
        int IDPRES;
        Menu_Principal2 Mn;
        int IdUSUATIO;
        public Presupuesto(object A,int iDe)
        {
            try
            {
                InitializeComponent();
                Mn = A as Menu_Principal2;
                IdUSUATIO = iDe;
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarDatos(string titulo,int ID, string NombreCliente,string Empleado ,DateTime Fecha,string Aprobado ,string Total)
        {
            try
            {
                IDPRES = ID;
                lbtitulo.Content = titulo;
                TXT_NombreCliente.Text = NombreCliente;
                TXT_Empleado.Text = Empleado;
                TXT_FechaElaboración.Text = Fecha.ToString();
                TXT_Aprobado.Text = Aprobado;
                TXT_Total.Text = Total;
            }
            catch (Exception ex)
            {

            }
        }

        private void pres_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                pres.Margin = new Thickness(0, 0, 0, 0);
            }
            catch (Exception ex)
            {

            }
        }

        private void pres_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                pres.Margin = new Thickness(10, 10, 10, 10);
            }
            catch (Exception ex)
            {

            }
        }

        private void pres_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new PantallaPresupuestos(IDPRES,Mn, IdUSUATIO));
            }
            catch (Exception ex)
            {

            }
        }
    }
}

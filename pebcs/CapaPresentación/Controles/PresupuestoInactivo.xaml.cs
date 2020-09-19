using CapaLogica;
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
    /// Lógica de interacción para PresupuestoInactivo.xaml
    /// </summary>
    public partial class PresupuestoInactivo : UserControl
    {
        int IDPRES;
        Menu_Principal2 Mn;
        int IdUSUATIO;
        public PresupuestoInactivo(object A, int iDe)
        {
            InitializeComponent();
            IdUSUATIO = iDe;
            Mn = A as Menu_Principal2;

        }
        public void CargarDatos(string titulo, int ID, string NombreCliente, string Empleado, DateTime Fecha, string Aprobado, string Total)
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

        private void Btn_Restaurar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CapaLogica.Presupuesto presupuesto = new CapaLogica.Presupuesto();
                presupuesto.Activar(IDPRES);
                Mn.AbrirFormHijo(new Pantalla_Presupustos(Mn,IdUSUATIO));
            }catch(Exception ex)
            { 
            }
        }
    }
}

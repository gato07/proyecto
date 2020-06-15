using CapaLogica;
using CapaPresentación.Controles;
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
    /// Lógica de interacción para Pantalla_Presupustos.xaml
    /// </summary>
    /// 
    public partial class Pantalla_Presupustos : UserControl
    {
        Menu_Principal2 Mn;
        CapaLogica.Presupuesto presupuesto = new CapaLogica.Presupuesto();
        public Pantalla_Presupustos(object A)
        {
            try
            {
                InitializeComponent();
                Mn = A as Menu_Principal2;
                CargarPresupuestos();
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarPresupuestos()
        {
            try
            {
                CapaLogica.Presupuesto[] presupuestos = presupuesto.TableToArray(presupuesto.SelActivos());
                Controles.Presupuesto[] PresCard = new Controles.Presupuesto[presupuestos.Length];
                for (int x = 0; x < PresCard.Length; x++)
                {
                    Preproyecto preproyecto = new Preproyecto(presupuestos[x].Id_Preproyecto);
                    PresCard[x] = new Controles.Presupuesto(Mn);
                    PresCard[x].CargarDatos(preproyecto.Etiqueta, presupuestos[x].Numero, presupuestos[x].Dirigido, presupuestos[x].Clave_Empleado.ToString(), presupuestos[x].Fecha, presupuestos[x].Aprobado.ToString(), presupuestos[x].Total.ToString());
                    n.Items.Add(PresCard[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void Btn_Cerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 47;
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 107;
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_Limpiar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Limpiar.Width = 47;
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_Limpiar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Limpiar.Width = 107;
            }
            catch (Exception ex)
            {

            }
        }
    }
}

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
    /// Lógica de interacción para PantallaPresupuestos.xaml
    /// </summary>
    public partial class PantallaPresupuestos : UserControl
    {
        public PantallaPresupuestos()
        {
            InitializeComponent();
            //llenar();
        }

        //public void llenar()
        //{
        //    List<Presupues> presupues = new List<Presupues>();
        //    presupues.Add(new Presupues() { Concepto = "Planos Arquitectonicos", Importe = 250 });
        //    presupues.Add(new Presupues() { Concepto = "Planos hidraulicos", Importe = 250 });
        //    presupues.Add(new Presupues() { Concepto = "Planos Estructurales", Importe = 250 });
        //    ListConceptos.ItemsSource = presupues;
        //}
        //public class Presupues
        //{
        //    public string Concepto { get; set; }
        //    public int Importe { get; set; }
        //}
    }
}

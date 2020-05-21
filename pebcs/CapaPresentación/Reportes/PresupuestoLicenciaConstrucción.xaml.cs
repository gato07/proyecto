
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
using System.Windows.Shapes;

namespace CapaPresentación.Reportes
{
    /// <summary>
    /// Lógica de interacción para PresupuestoLicenciaConstrucción.xaml
    /// </summary>
    public partial class PresupuestoLicenciaConstrucción : Window
    {
        float TotalA, TotalB = 0;
        public PresupuestoLicenciaConstrucción(string [,] A)
        {
            InitializeComponent();
            llenarReporte(A);
        }

        private void BtnImprimir_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnImprimir.Margin = new Thickness(565, 47, 0, 62);
        }

        private void BtnImprimir_MouseMove(object sender, MouseEventArgs e)
        {
            BtnImprimir.Margin = new Thickness(500, 47, 0, 62);
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog()==true)
            {
                BtnImprimir.Visibility = Visibility.Hidden;
                BtnImprimir.Visibility = Visibility.Hidden;
                printDialog.PrintVisual(pintar,"reporte");
            }
        }
        public class PresupuestoAgregado
        {
            public int ID { get; set; }
            public string ConceptoA { get; set; }
            public float ImporteA { get; set; }
            public int CantidadA { get; set; }
            public float TotalA { get; set; }
            public string Tipo { get; set; }
        }
        public void llenarReporte(string [,] A)
        {
            for (int x=0;x<(A.Length/3);x++)
            {
                PresupuestoAgregado presupuesto = new PresupuestoAgregado() { Tipo = A[x, 1].ToString(), ConceptoA = A[x, 0].ToString(), ImporteA = Convert.ToSingle(A[x, 2]) };
                if (A[x,1]== "Pago De Honorarios")
                {
                    pagosdehonorarios.Items.Add(presupuesto);
                    TotalA += presupuesto.ImporteA;
                }
                else if(A[x, 1] == "Pago Ante Ayuntamiento")
                {
                    pagosanteayuntamiento.Items.Add(presupuesto);
                    TotalB += presupuesto.ImporteA;
                }
            }
            tolA.Text = "$"+TotalA.ToString();
            TolB.Text = "$"+TotalB.ToString();
            s.Text = "Total: $" + (TotalA + TotalB).ToString();
        }

        private void BtnImprimir_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

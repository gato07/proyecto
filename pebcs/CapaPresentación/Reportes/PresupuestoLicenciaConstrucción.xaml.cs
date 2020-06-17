
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
using System.Windows.Shapes;

namespace CapaPresentación.Reportes
{
    /// <summary>
    /// Lógica de interacción para PresupuestoLicenciaConstrucción.xaml
    /// </summary>
    public partial class PresupuestoLicenciaConstrucción : Window
    {
        decimal TotalA, TotalB = 0;
        string[,] listado;
        string[] Info;
        int IDPresupuesto;
        public PresupuestoLicenciaConstrucción(int NumeroPresupuesto,string [,] A,string[] B)
        {
            try
            {
                InitializeComponent();
                llenarReporte(A);
                listado = A;
                IDPresupuesto = NumeroPresupuesto;
                Info = B;
                LLenar(B);
            }
            catch (Exception ex)
            {

            }
        }
        public void LLenar(string[] vs)
        {
            try
            {
                LB_Propietario.Text = "";
                LB_Solicitante.Text = "";
                Texto.Text = "";
                LB_Propietario.Text = vs[0];
                LB_Solicitante.Text = vs[1];
                Texto.Text = "Por medio de la presente y no sin antes saludarle se atiende su solicitud de presupuesto de firma y " +
                    "gestoría para licencia de construcción para " + vs[2] + " sobre " + vs[3] + " m2 en base a los siguientes conceptos.";
            }
            catch (Exception ex)
            {

            }
        }
        private void BtnImprimir_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                BtnImprimir.Margin = new Thickness(565, 47, 0, 62);
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnImprimir_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                BtnImprimir.Margin = new Thickness(500, 47, 0, 62);
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    BtnImprimir_Copy.Visibility = Visibility.Hidden;
                    BtnImprimir.Visibility = Visibility.Hidden;
                    printDialog.PrintVisual(pintar, "reporte");
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public class PresupuestoAgregado
        {
            public int ID { get; set; }
            public string ConceptoA { get; set; }
            public decimal ImporteA { get; set; }
            public int CantidadA { get; set; }
            public decimal TotalA { get; set; }
            public string Tipo { get; set; }
        }
        public void llenarReporte(string [,] A)
        {
            try
            {
                for (int x = 0; x < (A.Length / 7); x++)
                {
                    PresupuestoAgregado presupuesto = new PresupuestoAgregado() { ID = Convert.ToInt32(A[x, 0]), Tipo = A[x, 1], ConceptoA = A[x, 2], ImporteA = Convert.ToDecimal(A[x, 3]), CantidadA = Convert.ToInt32(A[x, 4]), TotalA = Convert.ToDecimal(A[x, 5]) };
                    if (A[x, 1] == "Pago de honorarios")
                    {
                        pagosdehonorarios.Items.Add(presupuesto);
                        TotalA += presupuesto.TotalA;
                    }
                    else if (A[x, 1] == "Pagos ante ayuntamiento")
                    {
                        pagosanteayuntamiento.Items.Add(presupuesto);
                        TotalB += presupuesto.TotalA;
                    }
                }
                tolA.Text = "$" + TotalA.ToString();
                TolB.Text = "$" + TotalB.ToString();
                s.Text = "Total: $" + (TotalA + TotalB).ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnImprimir_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}

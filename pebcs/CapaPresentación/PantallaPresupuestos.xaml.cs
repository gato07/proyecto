using System;
using System.Collections.Generic;
using System.Data;
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
using CapaPresentación.Reportes;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaPresupuestos.xaml
    /// </summary>
    public partial class PantallaPresupuestos : UserControl
    {
        Concepto ListaConcepto;
        Cliente TiCliente;
        Concepto[] ListConceptos;
        Cliente[] TodCliente;
        public PantallaPresupuestos()
        {
            InitializeComponent();
            LlenarCombo();
        }

        private void Btn_Cerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_Cerrar.Margin = new Thickness(53, 0, 0, 160);
        }

        private void Btn_Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Cerrar.Margin = new Thickness(0, 0, 0, 160);
        }

        private void Btn_Limpiar_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_Limpiar.Margin = new Thickness(53, 60, 0, 100);
        }

        private void Btn_Limpiar_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Limpiar.Margin = new Thickness(0, 60, 0, 100);
        }

        private void Btn_GenerarPresupuesto_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_GenerarPresupuesto.Margin = new Thickness(53, 120, 0, 40);
        }

        private void Btn_GenerarPresupuesto_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_GenerarPresupuesto.Margin = new Thickness(0, 120, 0, 40);
        }

        public void llenar(int x)
        {
            string tipos = null;
            ListaConceptos.Items.Clear();
            ListaConcepto = new Concepto();
            if (x == 0)
            {
                ListConceptos = ListaConcepto.TableToArray(ListaConcepto.dtsSelNumeroNombreCostoXTipEli("Pago De Honorarios", false));
                tipos = "Pago De Honorarios";
            }
            else if (x == 1)
            {
                ListConceptos = ListaConcepto.TableToArray(ListaConcepto.dtsSelNumeroNombreCostoXTipEli("Pago Ante Ayuntamiento", false));
                tipos = "Pago Ante Ayuntamiento";
            }
            for (int p = 0; p < ListConceptos.Length; p++)
            {
                PresupuestoAgregado presupuesto = (new PresupuestoAgregado() { ID = ListConceptos[p].Numero, Tipo = tipos,ConceptoA = ListConceptos[p].Nombre.ToString(), ImporteA = Convert.ToSingle(ListConceptos[p].Costo), CantidadA = 1, TotalA = Convert.ToSingle(ListConceptos[p].Costo) });
                bool esta = false;
                for (int c=0;c<ListaConceptosAgregados.Items.Count;c++)
                {
                    PresupuestoAgregado agregado = (PresupuestoAgregado)ListaConceptosAgregados.Items[c];
                    if (agregado.ID==presupuesto.ID)
                    {
                        esta = true;
                        break;
                    }
                }
                if (esta==false)
                {
                   ListaConceptos.Items.Add(presupuesto);
                }
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
        public class ClientesInfo
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string RFC { get; set; }
        }
        public void LlenarCombo()
        {
            TiCliente = new Cliente();
            TodCliente=TiCliente.TableToArray(TiCliente.SelActivos());
            for(int x=0;x<TodCliente.Length;x++)
            {
                ClientesInfo clientesInfo = (new ClientesInfo() { ID =  TodCliente[x].Id,Nombre=TodCliente[x].Nombre,RFC=TodCliente[x].Rfc});
                Clientes.Items.Add(clientesInfo);
            }
        }

        private void OpcionesTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenar(OpcionesTipo.SelectedIndex);
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Grid grid = (Grid)button.Parent;
            PresupuestoAgregado P = (PresupuestoAgregado)grid.DataContext;
            if(P!=null)
            {
                ListaConceptosAgregados.Items.Add(P);
                ListaConceptos.Items.Remove(P);
                Total.Text = ((P.CantidadA * P.ImporteA)+Convert.ToInt32(Total.Text)).ToString();
            }
        }
        private void Activador_Click(object sender, RoutedEventArgs e)
        {
            if (Activador.IsChecked==true)
            {
                TxtBusquedaCliente.IsEnabled = true;
                Clientes.IsEnabled = false;
            }
            else
            {
                TxtBusquedaCliente.IsEnabled = false;
                Clientes.IsEnabled = true;
            }
        }

        private void BtnQuitar_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Grid grid = (Grid)button.Parent;
            PresupuestoAgregado P = (PresupuestoAgregado)grid.DataContext;
            if (P != null)
            {
                ListaConceptosAgregados.Items.Remove(P);
                if (P.Tipo==OpcionesTipo.Text)
                {
                    ListaConceptos.Items.Add(P);
                }

            }
        }

        private void TxtPrecioAgregado_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            Grid grid = (Grid)box.Parent;
            PresupuestoAgregado P = (PresupuestoAgregado)grid.DataContext;
            if(P!=null)
            {
                Total.Text = ((P.CantidadA * P.ImporteA) + Convert.ToInt32(Total.Text)).ToString();
            }
        }

        private void TxtCantidadAgregado_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            Grid grid = (Grid)box.Parent;
            PresupuestoAgregado P = (PresupuestoAgregado)grid.DataContext;
            if (P != null)
            {
                Total.Text =((P.CantidadA * P.ImporteA)+Convert.ToInt16(Total.Text)).ToString();
            }
        }

        private void Btn_GenerarPresupuesto_Click(object sender, RoutedEventArgs e)
        {
            string[,] vs = new string[ListaConceptosAgregados.Items.Count,3];
            for(int x=0; x<ListaConceptosAgregados.Items.Count;x++)
            {
                PresupuestoAgregado presupuestoAgregado = (PresupuestoAgregado)ListaConceptosAgregados.Items[x];
                vs[x, 0] = presupuestoAgregado.ConceptoA;
                vs[x, 1] = presupuestoAgregado.Tipo;
                vs[x, 2] = presupuestoAgregado.ImporteA.ToString();
            }
            PresupuestoLicenciaConstrucción construcción = new PresupuestoLicenciaConstrucción(vs);
            construcción.ShowDialog();
        }
    }
}

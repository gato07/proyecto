using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        Concepto[] ListConceptos;
        Presupuesto presupuesto = new Presupuesto();
        Proyecto_Licencia licencia = new Proyecto_Licencia();
        Tipo_Proyecto tipProyecto = new Tipo_Proyecto();
        string[] datosPresupuesto = new string[4];
        int idpreproyecto, idpresupuesto;
        bool Aprobado = false;
        int aproaux, IdTipodeproyecto;
        Menu_Principal2 Mn;
        public PantallaPresupuestos(int IDPresupuesto,Object A)
        {
            try
            {
                InitializeComponent();
                idpresupuesto = IDPresupuesto;
                Mn = A as Menu_Principal2;
                CargarInfo(idpresupuesto);
                CargarTipoProyectos();
            }
            catch(Exception ex)
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

        private void Btn_GenerarPresupuesto_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_GenerarPresupuesto.Width = 47;
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_GenerarPresupuesto_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_GenerarPresupuesto.Width = 107;
            }
            catch (Exception ex)
            {

            }
        }

        public void llenarConceptos(int x)
        {
            try
            {
                string tipos = null;
                ListaConceptos.Items.Clear();
                ListaConcepto = new Concepto();
                if (x == 0)
                {
                    ListConceptos = ListaConcepto.TableToArray(ListaConcepto.dtsSelNumeroNombreCostoXTipEli("Pago De Honorarios", false));
                    tipos = "Pago de honorarios";
                }
                else if (x == 1)
                {
                    ListConceptos = ListaConcepto.TableToArray(ListaConcepto.dtsSelNumeroNombreCostoXTipEli("Pagos Ante Ayuntamiento", false));
                    tipos = "Pagos ante ayuntamiento";
                }
                for (int p = 0; p < ListConceptos.Length; p++)
                {
                    PresupuestoAgregado presupuesto = (new PresupuestoAgregado() { ID = ListConceptos[p].Numero, Tipo = tipos, ConceptoA = ListConceptos[p].Nombre.ToString(), ImporteA = Convert.ToDecimal(ListConceptos[p].Costo), CantidadA = 1, TotalA = Convert.ToDecimal(ListConceptos[p].Costo), eliminado = ListConceptos[p].Eliminado });
                    bool esta = false;
                    for (int c = 0; c < ListaConceptosAgregados.Items.Count; c++)
                    {
                        PresupuestoAgregado agregado = (PresupuestoAgregado)ListaConceptosAgregados.Items[c];
                        if (agregado.ID == presupuesto.ID)
                        {
                            esta = true;
                            break;
                        }
                    }
                    if (esta == false)
                    {
                        ListaConceptos.Items.Add(presupuesto);
                    }
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
            public bool eliminado { get; set; }
        }
        public class TipoProyec
        {
            public int ID { get; set; }
            public string TipoDeObra { get; set; }
            public string Uso { get; set; }
            public string Cabeza { get; set; }
        }
        private void CargarTipoProyectos()
        {
            try
            {
                Tipo_Proyecto[] _Proyectos = tipProyecto.TableToArray(tipProyecto.SelTodos());
                string n = null;
                for (int x = 0; x < _Proyectos.Length; x++)
                {
                    if (x + 1 == 1)
                    {
                        n = "A";
                    }
                    if (x + 1 == 5)
                    {
                        n = "R";
                    }
                    if (x + 1 == 9)
                    {
                        n = "O";
                    }
                    if (x + 1 == 13)
                    {
                        n = "R";
                    }
                    if (x + 1 == 17)
                    {
                        n = "P";
                    }
                    TipoProyec ProInfo = (new TipoProyec() { ID = _Proyectos[x].Id, TipoDeObra = _Proyectos[x].Tipo_Obra, Uso = _Proyectos[x].Uso, Cabeza = n });
                    tipoProyecto.Items.Add(ProInfo);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarInfo(int idp)
        {
            try
            {
                if(idp!=0)
                {
                    Presupuesto sd = new Presupuesto(idpresupuesto);
                    TXT_Etiqueta.Text = sd.Etiqueta;
                    TXT_Propietario.Text = sd.Nombre_Propietario;
                    TXT_Solicitante.Text = sd.Nombre_Solicitante;
                    TXT_Metros.Text = sd.Mts.ToString();
                    TXT_Genero.Text = sd.Genero;
                    EstadoPresupuesto.SelectedIndex = sd.Aprobado;
                    tipoProyecto.SelectedIndex = sd.Id_Tipo_Proyecto-1;
                    IdTipodeproyecto = sd.Id_Tipo_Proyecto;
                    CargarConceptos(idp);
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void CargarConceptos(int id)
        {
            try
            {
                Presupuesto_Contenido presupuesto = new Presupuesto_Contenido();
                Presupuesto_Contenido[] contenido = presupuesto.TableToArray(presupuesto.SelXNumPresupuesto(id));
                for (int x = 0; x < contenido.Length; x++)
                {
                    if (contenido[x].Eliminado == false)
                    {
                        Concepto n = new Concepto(contenido[x].Numero_Concepto);
                        PresupuestoAgregado pres = (new PresupuestoAgregado() { ID = contenido[x].Numero_Concepto, Tipo = n.Tipo, ConceptoA = n.Nombre, ImporteA = Convert.ToDecimal(n.Costo), CantidadA = 1, TotalA = Convert.ToDecimal(n.Costo) });
                        ListaConceptosAgregados.Items.Add(pres);
                    }
                }
                Totalpres();
            }
            catch (Exception ex)
            {

            }
        }
        public void IngresarDatos(string[,] m)
        {
            try
            {
                if(m!=null)
                {
                    Presupuesto_Contenido sa = new Presupuesto_Contenido();
                    Presupuesto_Contenido[] l = sa.TableToArray(sa.SelXNumPresupuesto(idpresupuesto));
                    bool esta = false;
                    for (int x = 0; x < l.Length; x++)
                    {
                        for (int y = 0; y < m.Length / 7; y++)
                        {
                            if (Convert.ToInt32(m[y, 0]) == l[x].Numero_Concepto && l[x].Eliminado == false)
                            {
                                esta = true;
                            }
                        }
                        if (esta == false)
                        {
                            sa.Eliminar(idpresupuesto, l[x].Numero_Concepto);
                            esta = false;
                        }
                        esta = false;
                    }
                    for (int x = 0; x < m.Length / 7; x++)
                    {
                        Presupuesto_Contenido agregar = new Presupuesto_Contenido(idpresupuesto, Convert.ToInt32(m[x, 0]));
                        if (agregar.Numero_Concepto != 0)
                        {

                            if (agregar.Eliminado == false)
                            {
                                agregar.Actualizar(idpresupuesto, Convert.ToInt32(m[x, 0]), Convert.ToInt32(m[x, 4]), Convert.ToDecimal(m[x, 5]));
                            }
                            else
                            {
                                agregar.Activar(idpresupuesto, agregar.Numero_Concepto);
                                agregar.Actualizar(idpresupuesto, Convert.ToInt32(m[x, 0]), Convert.ToInt32(m[x, 4]), Convert.ToDecimal(m[x, 5]));
                            }
                        }
                        else if (agregar.Numero_Concepto == 0)
                        {
                            agregar.Insertar(idpresupuesto, Convert.ToInt32(m[x, 0]), Convert.ToInt32(m[x, 4]), Convert.ToDecimal(m[x, 5]));
                        }
                    }
                    Presupuesto presupuesto = new Presupuesto(idpresupuesto);
                    if (presupuesto.Existe)
                        presupuesto.Actualizar(idpresupuesto, presupuesto.Etiqueta, presupuesto.Nombre_Solicitante, presupuesto.Nombre_Propietario,TXT_Genero.Text, presupuesto.Mts, Convert.ToDecimal(Total.Text.Trim()), EstadoPresupuesto.SelectedIndex, IdTipodeproyecto);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void OpcionesTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                llenarConceptos(OpcionesTipo.SelectedIndex);
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                Grid grid = (Grid)button.Parent;
                PresupuestoAgregado P = (PresupuestoAgregado)grid.DataContext;
                if (P != null)
                {
                    ListaConceptosAgregados.Items.Add(P);
                    ListaConceptos.Items.Remove(P);
                    Totalpres();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void BtnQuitar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                Grid grid = (Grid)button.Parent;
                PresupuestoAgregado P = (PresupuestoAgregado)grid.DataContext;
                if (P != null)
                {
                    ListaConceptosAgregados.Items.Remove(P);
                    Totalpres();
                    if (P.Tipo == OpcionesTipo.Text)
                    {
                        ListaConceptos.Items.Add(P);

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Totalpres()
        {
            try
            {
                decimal subtotal = 0.00m, tol = 0.00m;
                Total.Text = "0.00";
                SubTotal.Text = "0.00";
                for (int x = 0; x < ListaConceptosAgregados.Items.Count; x++)
                {
                    PresupuestoAgregado p = (PresupuestoAgregado)ListaConceptosAgregados.Items[x];
                    subtotal += Convert.ToDecimal(p.TotalA);
                }
                SubTotal.Text = subtotal.ToString();
                tol = Decimal.Round(subtotal + (subtotal * 0.16m), 2);
                Total.Text = tol.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void TxtTotalAgregado_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox ttotal = (TextBox)sender;
                if (decimal.TryParse(ttotal.Text.Trim(), out decimal total))
                {
                    Grid grid = (Grid)ttotal.Parent;
                    PresupuestoAgregado p = (PresupuestoAgregado)grid.DataContext;
                    if (p != null)
                    {
                        p.TotalA = total;
                        Totalpres();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void TxtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox tcantidad = (TextBox)sender;
                if (int.TryParse(tcantidad.Text.Trim(), out int cantidad))
                {
                    Grid grid = (Grid)tcantidad.Parent;
                    PresupuestoAgregado p = (PresupuestoAgregado)grid.DataContext;
                    if (p != null)
                    {
                        TextBox total = (TextBox)grid.Children[3];
                        p.CantidadA = cantidad;
                        p.TotalA = p.CantidadA * p.ImporteA;
                        total.Text = p.TotalA.ToString();
                        Totalpres();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void TxtPrecioAgregado_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox tprecio = (TextBox)sender;
                if (decimal.TryParse(tprecio.Text.Trim(), out decimal precio))
                {
                    Grid grid = (Grid)tprecio.Parent;
                    PresupuestoAgregado p = (PresupuestoAgregado)grid.DataContext;
                    if (p != null)
                    {
                        TextBox total = (TextBox)grid.Children[3];
                        p.ImporteA = precio;
                        p.TotalA = p.CantidadA * p.ImporteA;
                        total.Text = p.TotalA.ToString();
                        Totalpres();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_GenerarLicencia_Click(object sender, RoutedEventArgs e)
        {
            if(idpresupuesto!=0 && EstadoPresupuesto.SelectedIndex==1)
            {
                Mn.AbrirFormHijo(new Pantalla_InfoLicencia(0,Mn, idpresupuesto));
            }
        }

        private void tip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToggleButton toggle = (ToggleButton)sender;
                //Button button = (Button)sender;
                Grid grid = (Grid)toggle.Parent;
                TipoProyec P = (TipoProyec)grid.DataContext;
                if (P != null)
                {
                    IdTipodeproyecto = P.ID;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_GenerarPresupuesto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[,] vs = new string[ListaConceptosAgregados.Items.Count, 7];
                datosPresupuesto[1] = TXT_Solicitante.Text;
                for (int x = 0; x < ListaConceptosAgregados.Items.Count; x++)
                {
                    PresupuestoAgregado presupuestoAgregado = (PresupuestoAgregado)ListaConceptosAgregados.Items[x];
                    vs[x, 0] = presupuestoAgregado.ID.ToString();
                    vs[x, 1] = presupuestoAgregado.Tipo;
                    vs[x, 2] = presupuestoAgregado.ConceptoA.ToString();
                    vs[x, 3] = presupuestoAgregado.ImporteA.ToString();
                    vs[x, 4] = presupuestoAgregado.CantidadA.ToString();
                    vs[x, 5] = presupuestoAgregado.TotalA.ToString();
                    vs[x, 6] = presupuestoAgregado.eliminado.ToString();
                }
                if(idpresupuesto==0)
                {
                    idpresupuesto = presupuesto.Insertar(TXT_Etiqueta.Text, TXT_Solicitante.Text, TXT_Propietario.Text,TXT_Genero.Text, Convert.ToDecimal(TXT_Metros.Text), Convert.ToDecimal(Total.Text), EstadoPresupuesto.SelectedIndex, IdTipodeproyecto, 1);
                }
                if (idpresupuesto!=0)
                {
                    IngresarDatos(vs);
                    PresupuestoLicenciaConstrucción construcción = new PresupuestoLicenciaConstrucción(idpresupuesto, vs, datosPresupuesto);
                    construcción.ShowDialog();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
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
using static CapaPresentación.Pantalla_CargaDeTrabajo;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_InfoLicencia.xaml
    /// </summary>
    public partial class Pantalla_InfoLicencia : UserControl
    {
        Tipo_Proyecto tipProyecto = new Tipo_Proyecto();
        Proyecto_Licencia ProyectoLicencia = new Proyecto_Licencia();
        Presupuesto presupuesto = new Presupuesto();
        Cliente cliente = new Cliente();
        Inmueble inmueble = new Inmueble();
        bool F = false;
        int IDinmueble, IDcliente, IDpresupuesto, IDlicen, IdTipodeproyecto;
        string[] Documentacion = new string[] {"Escrituras Del Terreno","Constacia De Alineamiento y No Oficial","Cosntacia De Pago Del Impuesto Predial",
                                               "Contrato o Recibo De Agua Potable","Planos Arquitectonicos De La Obra","Planos Estructurales De La Obra","Planos De Instalación De La Obra","Memoria De Calculo" };
        bool[] dockcheck = new bool[8];
        Menu_Principal2 Mn;
        public Pantalla_InfoLicencia( int IDLicencia,Object A,int IDpresu)
        {
            try
            {
                InitializeComponent();
                Mn = A as Menu_Principal2;
                CargarClientes();
                CargarInmuebles();
                CargarTipoProyectos();
                CargarDatos(IDLicencia, IDpresu);
                IDlicen = IDLicencia;
                IDpresupuesto = IDpresu;
            }
            catch (Exception ex)
            {

            }
        }

        public void CargarDatos( int IDLicencia ,int iDpRESU)
        {
            try
            {
                if(iDpRESU!=0)
                {
                    Presupuesto prec = new Presupuesto(iDpRESU);
                    Etiqueta.Text = TXT_Etiqueta.Text = prec.Etiqueta;
                    TXT_Metros.Text = prec.Mts.ToString();
                    TXT_Genero.Text = prec.Genero;
                    tipoProyecto.SelectedIndex = prec.Id_Tipo_Proyecto - 1;
                    cargarDocumentacion(null);
                    F = true;
                }
                else if(IDLicencia==0)
                {
                    cargarDocumentacion(null);
                    ActivarCampos();
                    F = true;
                }
                else if (IDLicencia != 0)
                {
                    ProyectoLicencia = new Proyecto_Licencia(IDLicencia);
                    IDlicen = IDLicencia;
                    presupuesto = new Presupuesto(ProyectoLicencia.Numero_Presupuesto);
                    TXT_Genero.Text = presupuesto.Genero;
                    TXT_Etiqueta.Text = presupuesto.Etiqueta;
                    TXT_Metros.Text = presupuesto.Mts.ToString();
                    Clientes.SelectedIndex = ProyectoLicencia.Id_Cliente - 1;
                    Inmuebles.SelectedIndex = ProyectoLicencia.Clave_Inmueble - 1;
                    tipoProyecto.SelectedIndex = presupuesto.Id_Tipo_Proyecto - 1;
                    dockcheck[0] = ProyectoLicencia.Escrituras;
                    dockcheck[1] = ProyectoLicencia.Constancia_Alineamiento;
                    dockcheck[2] = ProyectoLicencia.Pago_Predial;
                    dockcheck[3] = ProyectoLicencia.Recibo_Agua;
                    dockcheck[4] = ProyectoLicencia.Planos_Arquitectonicos;
                    dockcheck[5] = ProyectoLicencia.Planos_Estructurales;
                    dockcheck[6] = ProyectoLicencia.Planos_Instalaciones;
                    dockcheck[7] = ProyectoLicencia.Memoria_Calculo;
                    cargarDocumentacion(dockcheck);
                    F = false;
                    DesactivarCampos();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void cargarDocumentacion(bool[] n)
        {
            try
            {
                if (n != null)
                {
                    for (int x = 0; x < Documentacion.Length; x++)
                    {
                        Document document = (new Document { ID = x + 1, NombreDocumento = Documentacion[x], ISCHECK = n[x] });
                        ArmadoPaquete.Items.Add(document);
                    }
                }
                else if (n == null)
                {
                    for (int x = 0; x < Documentacion.Length; x++)
                    {
                        dockcheck[x] = false;
                        Document document = (new Document { ID = x + 1, NombreDocumento = Documentacion[x], ISCHECK = false });
                        ArmadoPaquete.Items.Add(document);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CargarClientes()
        {
            try
            {
                Cliente[] c = cliente.TableToArray(cliente.SelActivos());
                for (int x = 0; x < c.Length; x++)
                {
                    Clientea clientea = (new Clientea() { ID = c[x].Id, Nombre = c[x].Nombre, Apellido = c[x].Apellido, Telefono = c[x].Telefono });
                    Clientes.Items.Add(clientea);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CargarInmuebles()
        {
            try
            {
                Inmueble[] c = inmueble.TableToArray(inmueble.SelActivos());
                for (int x = 0; x < c.Length; x++)
                {
                    Inmueblea inmueblea = (new Inmueblea() { ID = c[x].Clave, ClaveCatastral = c[x].Clave_Catastral, Propietario = c[x].Nombre_Propietario, Colonia = c[x].Colonia, Calle = c[x].Calle, EntreCalles = c[x].Entre_Calles, NumeroExterior = c[x].Numero_Exterior, NumeroInterior = c[x].Numero_Interior });
                    Inmuebles.Items.Add(inmueblea);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ActivarCampos()
        {
            try
            {
                Clientes.IsEnabled = true;
                Inmuebles.IsEnabled = true;
                tipoProyecto.IsEnabled = true;
                TXT_Etiqueta.IsReadOnly = false;
                TXT_Metros.IsReadOnly = false;
                TXT_Genero.IsReadOnly = false;
            }
            catch (Exception ex)
            {

            }
        }
        private void DesactivarCampos()
        {
            try
            {
                Clientes.IsEnabled = false;
                Inmuebles.IsEnabled = false;
                tipoProyecto.IsEnabled = false;
                TXT_Etiqueta.IsReadOnly = true;
                TXT_Metros.IsReadOnly = true;
                TXT_Genero.IsReadOnly = true;
            }
            catch(Exception ex)
            {

            }
        }
        public class Document
        {
            public int ID { get; set; }
            public string NombreDocumento { get; set; }
            public bool ISCHECK { get; set; }
        }
        public class Clientea
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
        }
        public class Inmueblea
        {
            public int ID { get; set; }
            public string ClaveCatastral { get; set; }
            public string Propietario { get; set; }
            public string Colonia { get; set; }
            public string Calle { get; set; }
            public string EntreCalles { get; set; }
            public string NumeroInterior { get; set; }
            public string NumeroExterior { get; set; }
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
                for (int x = 0; x < _Proyectos.Length-5; x++)
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

        private void Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Clientea p = (Clientea)Clientes.SelectedItem;
                if (p != null)
                {
                    TXT_NombreCliente.Text = p.Nombre;
                    TXT_TelefonoCliente.Text = p.Telefono;
                    IDcliente = p.ID;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DocActivar_Click(object sender, RoutedEventArgs e)
        {
            if(DocActivar.IsChecked==true)
            {
                ArmadoPaquete.IsEnabled = true;
            }
            else
            {
                ArmadoPaquete.IsEnabled = false;
            }
        }

        private void Btn_Cambio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(IDlicen!=0)
                {
                    Mn.AbrirFormHijo(new Pantalla_SeguimientoLicencia(IDlicen, Mn));
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void Btn_CambioPresupuesto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProyectoLicencia = new Proyecto_Licencia(IDlicen);
                if(ProyectoLicencia.Existe)
                    Mn.AbrirFormHijo(new PantallaPresupuestos(ProyectoLicencia.Numero_Presupuesto, Mn));
            }
            catch(Exception ex)
            {

            }
        }

        private void Inmuebles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Inmueblea p = (Inmueblea)Inmuebles.SelectedItem;
                if (p != null)
                {
                    TXT_ClaveCatastral.Text = p.ClaveCatastral;
                    TXT_Propietario.Text = p.Propietario;
                    TXT_Colonia.Text = p.Colonia;
                    TXT_Calle.Text = p.Calle;
                    TXT_EntreCalles.Text = p.EntreCalles;
                    TXT_NumeroInterior.Text = p.NumeroInterior;
                    TXT_NumeroExterior.Text = p.NumeroExterior;
                    IDinmueble = p.ID;
                }
            }
            catch (Exception ex)
            {

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

        private void Btn_GuardarLicencia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (F == false)
                {
                    bool n = false;
                    n=ProyectoLicencia.Actualizar(IDlicen,dockcheck[0], dockcheck[1], dockcheck[2], dockcheck[3], dockcheck[4], dockcheck[5], dockcheck[6], dockcheck[7]);
                    if(n==true)
                    {
                        PantallaCheck check = new PantallaCheck();
                        check.Show();
                    }
                }
                else if (F == true)
                {
                    if(IDpresupuesto==0)
                    {
                        IDpresupuesto = presupuesto.Insertar(TXT_Etiqueta.Text, TXT_NombreCliente.Text, TXT_Propietario.Text,TXT_Genero.Text, Convert.ToDecimal(TXT_Metros.Text), 0, 0, IdTipodeproyecto, 1);
                        if (IDpresupuesto != 0)
                        {
                            IDlicen = ProyectoLicencia.Insertar( dockcheck[0], dockcheck[1], dockcheck[2], dockcheck[3], dockcheck[4], dockcheck[5], dockcheck[6], dockcheck[7], 1, IDpresupuesto, IDcliente, IDinmueble, 1);
                            if (IDlicen != 0)
                            {
                                PantallaCheck check = new PantallaCheck();
                                check.Show();
                                F = false;
                                DesactivarCampos();
                            }
                            else if (IDlicen == 0)
                            {//elimina el prosupuesto si la licencia no se registro corretamente
                                presupuesto.Depurar(IDpresupuesto);
                            }
                        }
                    }
                    else if (IDpresupuesto!=0)
                    {
                            IDlicen = ProyectoLicencia.Insertar( dockcheck[0], dockcheck[1], dockcheck[2], dockcheck[3], dockcheck[4], dockcheck[5], dockcheck[6], dockcheck[7], 1, IDpresupuesto, IDcliente, IDinmueble, 1);
                            if (IDlicen != 0)
                            {
                                PantallaCheck check = new PantallaCheck();
                                check.Show();
                                F = false;
                                DesactivarCampos();
                            }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToggleButton toggle = (ToggleButton)sender;
                Grid grid = (Grid)toggle.Parent;
                Document p = (Document)grid.DataContext;
                if (p != null)
                {
                    switch (p.ID)
                    {
                        case 1:
                            if (dockcheck[0] == false)
                            {
                                dockcheck[0] = true;
                            }
                            else if (dockcheck[0] == true)
                            {
                                dockcheck[0] = false;
                            }
                            break;
                        case 2:
                            if (dockcheck[1] == false)
                            {
                                dockcheck[1] = true;
                            }
                            else if (dockcheck[1] == true)
                            {
                                dockcheck[1] = false;
                            }
                            break;
                        case 3:
                            if (dockcheck[2] == false)
                            {
                                dockcheck[2] = true;
                            }
                            else if (dockcheck[2] == true)
                            {
                                dockcheck[2] = false;
                            }
                            break;
                        case 4:
                            if (dockcheck[3] == false)
                            {
                                dockcheck[3] = true;
                            }
                            else if (dockcheck[3] == true)
                            {
                                dockcheck[3] = false;
                            }
                            break;
                        case 5:
                            if (dockcheck[4] == false)
                            {
                                dockcheck[4] = true;
                            }
                            else if (dockcheck[4] == true)
                            {
                                dockcheck[4] = false;
                            }
                            break;
                        case 6:
                            if (dockcheck[5] == false)
                            {
                                dockcheck[5] = true;
                            }
                            else if (dockcheck[5] == true)
                            {
                                dockcheck[5] = false;
                            }
                            break;
                        case 7:
                            if (dockcheck[6] == false)
                            {
                                dockcheck[6] = true;
                            }
                            else if (dockcheck[6] == true)
                            {
                                dockcheck[6] = false;
                            }
                            break;
                        case 8:
                            if (dockcheck[7] == false)
                            {
                                dockcheck[7] = true;
                            }
                            else if (dockcheck[7] == true)
                            {
                                dockcheck[7] = false;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

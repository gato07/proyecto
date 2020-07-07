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

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_InfoAvaluo.xaml
    /// </summary>
    public partial class Pantalla_InfoAvaluo : UserControl
    {
        Cliente cliente = new Cliente();
        Inmueble inmueble = new Inmueble();
        Avaluo_Pericial Avaluo = new Avaluo_Pericial();
        string[] Documentacion = new string[] {"Escrituras Del Terreno","Manifestación","Oficion De Subdivición",
                                               "Oficio De Fusión" };
        int IDAvaluo;
        bool[] dockcheck = new bool[4];
        int Estado;
        int IDcliente;
        int IDinmueble;
        public Pantalla_InfoAvaluo(int ID)
        {
            try
            {
                InitializeComponent();
                CargarClientes();
                CargarInmuebles();
                IDAvaluo = ID;
                CargarInfo(IDAvaluo);
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
        private void CargarInfo(int id)
        {
            try
            {
                if (id!=0)
                {
                    Avaluo = new Avaluo_Pericial(id);
                    TXT_NoFolio.Text = Avaluo.Folio;
                    DTP_FechaDeElaboracion.SelectedDate = Avaluo.Fecha;
                    TXT_MetrosDeConstruccion.Text = Avaluo.Mts_Construccion.ToString();
                    TXT_MetrosDeTerreno.Text = Avaluo.Mts_Terreno.ToString();
                    TXT_UsoInmueble.Text = Avaluo.Uso;
                    TXT_CostoNeto.Text = Avaluo.Costo_Neto.ToString();
                    TXT_PagoDeDerechos.Text = Avaluo.Pago_Derechos.ToString();
                    Clientes.SelectedIndex = Avaluo.Id_Cliente-1;
                    Inmuebles.SelectedIndex = Avaluo.Clave_Inmueble;
                    dockcheck[0] = Avaluo.Escrituras;
                    dockcheck[1] = Avaluo.Manifestacion;
                    dockcheck[2] = Avaluo.Oficio_Subdivision;
                    dockcheck[3] = Avaluo.Oficio_Fusion;
                    cargarDocumentacion(dockcheck);
                }
                else
                {
                    cargarDocumentacion(null);
                }
            }catch(Exception ex)
            {

            }
        }
        private void Btn_GuardarAvaluo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(IDAvaluo==0)
                {
                    IDAvaluo= Avaluo.Insertar(TXT_NoFolio.Text, Convert.ToDateTime(DTP_FechaDeElaboracion.SelectedDate), TXT_UsoInmueble.Text, Convert.ToDecimal(TXT_MetrosDeTerreno.Text), Convert.ToDecimal(TXT_MetrosDeConstruccion.Text),Convert.ToDecimal(TXT_CostoNeto.Text),Convert.ToDecimal(TXT_PagoDeDerechos.Text),dockcheck[0],dockcheck[1],dockcheck[2],dockcheck[3],Estado, IDcliente, IDinmueble, 1);
                    if(IDAvaluo==0)
                    {
                        MessageBox.Show(Avaluo.Mensaje);
                    }
                    else
                    {
                        PantallaCheck check = new PantallaCheck();
                        check.Show();
                    }
                }
                else if(IDAvaluo!=0)
                {
                    bool n = Avaluo.Actualizar(IDAvaluo, TXT_NoFolio.Text, Convert.ToDateTime(DTP_FechaDeElaboracion.SelectedDate), TXT_UsoInmueble.Text, Convert.ToDecimal(TXT_MetrosDeTerreno.Text), Convert.ToDecimal(TXT_MetrosDeConstruccion.Text), Convert.ToDecimal(TXT_CostoNeto.Text), Convert.ToDecimal(TXT_PagoDeDerechos.Text), dockcheck[0], dockcheck[1], dockcheck[2], dockcheck[3], Estado, IDcliente, IDinmueble);
                    if(n)
                    {
                        PantallaCheck check = new PantallaCheck();
                        check.Show();
                    }
                    else
                    {
                        MessageBox.Show(Avaluo.Mensaje);
                    }
                }
            }catch(Exception ex)
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
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DocActivar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DocActivar.IsChecked == true)
                {
                    ArmadoPaquete.IsEnabled = true;
                }
                else
                {
                    ArmadoPaquete.IsEnabled = false;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btn_Entregado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Estado = 1;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Autorizado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Estado = 1;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Observacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Estado = 1;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Revision_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Estado = 1;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_EnCaptura_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Estado = 1;
            }
            catch (Exception ex)
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
    }
}

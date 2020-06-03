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
        Cliente cliente = new Cliente();
        Inmueble inmueble = new Inmueble();
        string[] Documentacion = new string[] {"Escrituras Del Terreno","Constacia De Alineamiento y No Oficial","Cosntacia De Pago Del Impuesto Predial",
                                               "Contrato o Recibo De Agua Potable","Planos Arquitectonicos De La Obra","Planos Estructurales De La Obra","Planos De Instalación De La Obra","Memoria De Calculo" };
        public Pantalla_InfoLicencia(string[] vs)
        {
            InitializeComponent();
            CargarTipoProyectos();
            cargarDocumentacion();
            CargarClientes();
            CargarInmuebles();
            CargarDatos(vs);
        }
        public void CargarDatos( string[] datos)
        {
            if(datos!=null)
            {
                if(Convert.ToInt32(datos[7])==1|| Convert.ToInt32(datos[7]) == 2 || Convert.ToInt32(datos[7]) == 4 || Convert.ToInt32(datos[7]) == 9 || Convert.ToInt32(datos[7]) == 10 || Convert.ToInt32(datos[7]) == 7)
                {
                    if(Convert.ToDecimal(datos[5])>400)
                    {
                        USODESUELOTAB.Visibility = Visibility.Hidden;
                        USODESUELOTAB.IsEnabled = false;
                    }
                    else
                    {
                        USODESUELOTAB.Visibility = Visibility.Hidden;
                        USODESUELOTAB.IsEnabled = false;
                        SUPERVICIONTECNICATAB.Visibility = Visibility.Hidden;
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                    }
                }
                else if(Convert.ToInt32(datos[7]) == 3 || Convert.ToInt32(datos[7]) == 5 || Convert.ToInt32(datos[7]) == 6 || Convert.ToInt32(datos[7]) == 8 || Convert.ToInt32(datos[7]) == 11 || Convert.ToInt32(datos[7]) == 12|| Convert.ToInt32(datos[7]) == 13 || Convert.ToInt32(datos[7]) == 14 || Convert.ToInt32(datos[7]) == 15)
                {
                    USODESUELOTAB.Visibility = Visibility.Visible;
                    USODESUELOTAB.IsEnabled = true;
                    SUPERVICIONTECNICATAB.Visibility = Visibility.Visible;
                    SUPERVICIONTECNICATAB.IsEnabled = true;
                }
                else if(Convert.ToInt32(datos[7]) == 31 || Convert.ToInt32(datos[7]) == 32 || Convert.ToInt32(datos[7]) == 34 || Convert.ToInt32(datos[7]) == 39 || Convert.ToInt32(datos[7]) == 40 || Convert.ToInt32(datos[7]) == 37)
                {
                    if (Convert.ToDecimal(datos[5]) > 400)
                    {
                        USODESUELOTAB.Visibility = Visibility.Hidden;
                        USODESUELOTAB.IsEnabled = false;
                        SUPERVICIONTECNICATAB.Visibility = Visibility.Visible;
                        SUPERVICIONTECNICATAB.IsEnabled = true;
                    }
                    else
                    {
                        USODESUELOTAB.Visibility = Visibility.Hidden;
                        USODESUELOTAB.IsEnabled = false;
                        SUPERVICIONTECNICATAB.Visibility = Visibility.Hidden;
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                    }
                }
                else if (Convert.ToInt32(datos[7]) == 33 || Convert.ToInt32(datos[7]) == 35 || Convert.ToInt32(datos[7]) == 36 || Convert.ToInt32(datos[7]) == 38 || Convert.ToInt32(datos[7]) == 41 || Convert.ToInt32(datos[7]) == 42 || Convert.ToInt32(datos[7]) == 43 || Convert.ToInt32(datos[7]) == 44 || Convert.ToInt32(datos[7]) == 45)
                {
                    USODESUELOTAB.Visibility = Visibility.Visible;
                    USODESUELOTAB.IsEnabled = true;
                    SUPERVICIONTECNICATAB.Visibility = Visibility.Visible;
                    SUPERVICIONTECNICATAB.IsEnabled = true;
                }
                else if (Convert.ToInt32(datos[7]) == 61 || Convert.ToInt32(datos[7]) == 62 || Convert.ToInt32(datos[7]) == 64 || Convert.ToInt32(datos[7]) == 69 || Convert.ToInt32(datos[7]) == 70 || Convert.ToInt32(datos[7]) == 77)
                {
                    USODESUELOTAB.Visibility = Visibility.Hidden;
                    USODESUELOTAB.IsEnabled = false;
                    SUPERVICIONTECNICATAB.Visibility = Visibility.Hidden;
                    SUPERVICIONTECNICATAB.IsEnabled = false;
                }
                else if (Convert.ToInt32(datos[7]) == 63 || Convert.ToInt32(datos[7]) == 65 || Convert.ToInt32(datos[7]) == 66 || Convert.ToInt32(datos[7]) == 68 || Convert.ToInt32(datos[7]) == 71 || Convert.ToInt32(datos[7]) == 72 || Convert.ToInt32(datos[7]) == 73 || Convert.ToInt32(datos[7]) == 74 || Convert.ToInt32(datos[7]) == 75)
                {
                    SUPERVICIONTECNICATAB.Visibility = Visibility.Hidden;
                    SUPERVICIONTECNICATAB.IsEnabled = false;
                }
                TXT_Etiqueta.Text = datos[1];
                TXT_Metros.Text = datos[5];
                tipoProyecto.SelectedIndex = (Convert.ToInt32(datos[7]) - 1);
            }
        }
        private void CargarTipoProyectos()
        {
            Tipo_Proyecto[] _Proyectos = tipProyecto.TableToArray(tipProyecto.SelTodos());
            string n = null;
            for (int x = 0; x < _Proyectos.Length; x++)
            {
                if (x + 1 == 1)
                {
                    n = "A";
                }
                if (x + 1 == 16)
                {
                    n = "D";
                }
                if (x + 1 == 31)
                {
                    n = "O";
                }
                if (x + 1 == 46)
                {
                    n = "P";
                }
                if (x + 1 == 61)
                {
                    n = "R";
                }
                TipoProyec ProInfo = (new TipoProyec() { ID = _Proyectos[x].Id, TipoDeObra = _Proyectos[x].Tipo_Obra, Uso = _Proyectos[x].Uso, Cabeza = n });
                tipoProyecto.Items.Add(ProInfo);
            }

        }
        private void cargarDocumentacion()
        {
            for(int x=0;x<Documentacion.Length;x++)
            {
                Document document = (new Document { NombreDocumento = Documentacion[x], ISCHECK = false });
                ArmadoPaquete.Items.Add(document);
            }
        }
        private void CargarClientes()
        {
            Cliente[] c = cliente.TableToArray(cliente.SelActivos());
            for(int x=0;x<c.Length;x++)
            {
                Clientea clientea = (new Clientea() {ID=c[x].Id,Nombre=c[x].Nombre,Apellido=c[x].Apellido,Telefono=c[x].Telefono });
                Clientes.Items.Add(clientea);
            }
        }
        private void CargarInmuebles()
        {
            Inmueble[] c = inmueble.TableToArray(inmueble.SelActivos());
            for(int x=0;x<c.Length;x++)
            {
                Inmueblea inmueblea = (new Inmueblea() {ID=c[x].Clave,ClaveCatastral=c[x].Clave_Catastral,Propietario=c[x].Nombre_Propietario,Colonia=c[x].Colonia,Calle=c[x].Calle,EntreCalles=c[x].Entre_Calles,NumeroExterior=c[x].Numero_Exterior,NumeroInterior=c[x].Numero_Interior });
                Inmuebles.Items.Add(inmueblea);
            }
        }
        public class Document
        {
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

        private void Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clientea p=(Clientea)Clientes.SelectedItem;
            if(p!=null)
            {
                TXT_NombreCliente.Text = p.Nombre;
                TXT_TelefonoCliente.Text = p.Telefono;
            }
        }

        private void Inmuebles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Inmueblea p = (Inmueblea)Inmuebles.SelectedItem;
            if(p!=null)
            {
                TXT_ClaveCatastral.Text = p.ClaveCatastral;
                TXT_Propietario.Text = p.Propietario;
                TXT_Colonia.Text = p.Colonia;
                TXT_Calle.Text = p.Calle;
                TXT_EntreCalles.Text = p.EntreCalles;
                TXT_NumeroInterior.Text = p.NumeroInterior;
                TXT_NumeroExterior.Text = p.NumeroExterior;
            }
        }
    }
}

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
        Preproyecto preproyecto = new Preproyecto();
        Proyecto_Licencia ProyectoLicencia = new Proyecto_Licencia();
        Presupuesto presupuesto = new Presupuesto();
        Cliente cliente = new Cliente();
        Inmueble inmueble = new Inmueble();
        bool F = false;
        int IDinmueble, IDcliente,IDprep,IDlicen;
        string[] Documentacion = new string[] {"Escrituras Del Terreno","Constacia De Alineamiento y No Oficial","Cosntacia De Pago Del Impuesto Predial",
                                               "Contrato o Recibo De Agua Potable","Planos Arquitectonicos De La Obra","Planos Estructurales De La Obra","Planos De Instalación De La Obra","Memoria De Calculo" };
        bool[] dockcheck = new bool[8];
        public Pantalla_InfoLicencia( int IDPreproyecto, int IDLicencia)
        {
            InitializeComponent();
            CargarTipoProyectos();
            CargarClientes();
            CargarInmuebles();
            CargarDatos(IDLicencia, IDPreproyecto);
        }
        public void CargarDatos( int IDLicencia, int IDPreproyecto)
        {
            if(IDPreproyecto != 0)
            {
                preproyecto = new Preproyecto(IDPreproyecto);
                IDprep = IDPreproyecto;
                TXT_Etiqueta.Text = preproyecto.Etiqueta;
                TXT_Metros.Text = preproyecto.Mts.ToString();
                tipoProyecto.SelectedIndex = preproyecto.Id_Tipo_Proyecto-1;
                cargarDocumentacion(null);
                F = true;
            }
            else if (IDLicencia != 0)
            {
                ProyectoLicencia = new Proyecto_Licencia(IDLicencia);
                IDlicen = IDLicencia;
                Clientes.SelectedIndex = ProyectoLicencia.Id_Cliente-1;
                Inmuebles.SelectedIndex = ProyectoLicencia.Clave_Inmueble-1;
                preproyecto = new Preproyecto(ProyectoLicencia.Id_Preproyecto);
                TXT_Etiqueta.Text = preproyecto.Etiqueta;
                TXT_Metros.Text = preproyecto.Mts.ToString();
                tipoProyecto.SelectedIndex =preproyecto.Id_Tipo_Proyecto;
                TXT_NoFolio.Text = ProyectoLicencia.Folio;
                TXT_NoLicencia.Text = ProyectoLicencia.Numero_Licencia;
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
        private void cargarDocumentacion(bool[] n)
        {
            if(n!=null)
            {
                for (int x = 0; x < Documentacion.Length; x++)
                {
                    Document document = (new Document {ID=x+1, NombreDocumento = Documentacion[x], ISCHECK = n[x]});
                    ArmadoPaquete.Items.Add(document);
                }
            }
            else if(n==null)
            {
                for (int x = 0; x < Documentacion.Length; x++)
                {
                    dockcheck[x] = false;
                    Document document = (new Document { ID=x+1,NombreDocumento = Documentacion[x], ISCHECK = false });
                    ArmadoPaquete.Items.Add(document);
                }
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

        private void Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clientea p=(Clientea)Clientes.SelectedItem;
            if(p!=null)
            {
                TXT_NombreCliente.Text = p.Nombre;
                TXT_TelefonoCliente.Text = p.Telefono;
                IDcliente = p.ID;
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
                IDinmueble = p.ID;
            }
        }

        private void Btn_GuardarLicencia_Click(object sender, RoutedEventArgs e)
        {
            if (F == false)
            {
                ProyectoLicencia.Actualizar(ProyectoLicencia.Numero, TXT_NoFolio.Text, TXT_NoLicencia.Text, dockcheck[0], dockcheck[1], dockcheck[2], dockcheck[3], dockcheck[4], dockcheck[5], dockcheck[6], dockcheck[7], ProyectoLicencia.Id_Estado_Licencia, ProyectoLicencia.Id_Preproyecto, ProyectoLicencia.Id_Cliente, ProyectoLicencia.Clave_Inmueble, ProyectoLicencia.Clave_Empleado);
            }
            else if (F == true)
            {
                ProyectoLicencia.Insertar(TXT_NoFolio.Text, TXT_NoLicencia.Text, dockcheck[0], dockcheck[1], dockcheck[2], dockcheck[3], dockcheck[4], dockcheck[5], dockcheck[6], dockcheck[7], 1, IDprep, IDcliente, IDinmueble, 1);
                presupuesto.Insertar(TXT_NombreCliente.Text,0,0,1,IDprep);
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggle =(ToggleButton)sender;
            Grid grid = (Grid)toggle.Parent;
            Document p = (Document)grid.DataContext;
            if(p!=null)
            {
                switch (p.ID)
                {
                    case 1:
                        if(dockcheck[0]==false)
                        {
                            dockcheck[0] = true;
                        }
                        else if(dockcheck[0]==true)
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
                            dockcheck[5] = false;
                        }
                        else if (dockcheck[5] == true)
                        {
                            dockcheck[5] = true;
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
    }
}

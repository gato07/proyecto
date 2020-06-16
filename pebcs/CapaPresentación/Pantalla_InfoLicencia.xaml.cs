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
            try
            {
                InitializeComponent();
                CargarTipoProyectos();
                CargarClientes();
                CargarInmuebles();
                CargarDatos(IDLicencia, IDPreproyecto);
                IDlicen = IDLicencia;
                CargarIfoProcesos(IDLicencia);
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarDatos( int IDLicencia, int IDPreproyecto)
        {
            try
            {
                if (IDPreproyecto != 0)
                {
                    preproyecto = new Preproyecto(IDPreproyecto);
                    IDprep = IDPreproyecto;
                    TXT_Etiqueta.Text = preproyecto.Etiqueta;
                    TXT_Metros.Text = preproyecto.Mts.ToString();
                    tipoProyecto.SelectedIndex = preproyecto.Id_Tipo_Proyecto - 1;
                    cargarDocumentacion(null);
                    F = true;
                    CargarProcesos(preproyecto.Id_Tipo_Proyecto, preproyecto.Mts);
                }
                else if (IDLicencia != 0)
                {
                    ProyectoLicencia = new Proyecto_Licencia(IDLicencia);
                    IDlicen = IDLicencia;
                    Clientes.SelectedIndex = ProyectoLicencia.Id_Cliente - 1;
                    Inmuebles.SelectedIndex = ProyectoLicencia.Clave_Inmueble - 1;
                    preproyecto = new Preproyecto(ProyectoLicencia.Id_Preproyecto);
                    TXT_Etiqueta.Text = preproyecto.Etiqueta;
                    TXT_Metros.Text = preproyecto.Mts.ToString();
                    tipoProyecto.SelectedIndex = preproyecto.Id_Tipo_Proyecto;
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
                    CargarProcesos(preproyecto.Id_Tipo_Proyecto, preproyecto.Mts);
                    ActivarCampos();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CargarProcesos(int tipobra, Decimal metros)
        {
            try
            {
                if (tipobra > 0 && tipobra < 16)//ampliacion
                {
                    if (tipobra == 3 || tipobra == 5 || tipobra == 6 || tipobra == 8 || tipobra == 11 || tipobra == 12 || tipobra == 14 || tipobra == 15)//comercial
                    {

                    }
                    else if (tipobra == 1 || tipobra == 2 || tipobra == 4 || tipobra == 7 || tipobra == 9 || tipobra == 10 || tipobra == 13)//casa habitacion
                    {
                        USODESUELOTAB.Visibility = Visibility.Hidden;
                        USODESUELOTAB.IsEnabled = false;
                    }
                }
                else if (tipobra > 31 && tipobra < 46)//obra nueva
                {
                    if (tipobra == 33 || tipobra == 35 || tipobra == 36 || tipobra == 38 || tipobra == 41 || tipobra == 42 || tipobra == 44 || tipobra == 45)//comercial
                    {

                    }
                    else if (tipobra == 31 || tipobra == 32 || tipobra == 34 || tipobra == 37 || tipobra == 39 || tipobra == 40 || tipobra == 43)//casa habitacion
                    {
                        if (metros >= 400)
                        {
                            USODESUELOTAB.Visibility = Visibility.Hidden;
                            USODESUELOTAB.IsEnabled = false;
                        }
                        else if (metros < 400)
                        {
                            USODESUELOTAB.Visibility = Visibility.Hidden;
                            USODESUELOTAB.IsEnabled = false;
                            SUPERVICIONTECNICATAB.Visibility = Visibility.Hidden;
                            SUPERVICIONTECNICATAB.IsEnabled = false;
                        }
                    }
                }
                else if (tipobra > 61 && tipobra < 76)//regularizacion
                {
                    if (tipobra == 63 || tipobra == 65 || tipobra == 66 || tipobra == 68 || tipobra == 71 || tipobra == 72 || tipobra == 74 || tipobra == 75)//comercial
                    {
                        SUPERVICIONTECNICATAB.Visibility = Visibility.Hidden;
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                    }
                    else if (tipobra == 61 || tipobra == 62 || tipobra == 64 || tipobra == 67 || tipobra == 69 || tipobra == 70 || tipobra == 73)//casa habitacion
                    {
                        SUPERVICIONTECNICATAB.Visibility = Visibility.Hidden;
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CargarIfoProcesos(int IDeLicencia)
        {
            try
            {
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                Documentacion_Licencia[] info = documentacion_Licencia.TableToArray(documentacion_Licencia.SelXNumeroProLic(IDeLicencia));
                for (int x = 0; x < info.Length; x++)
                {
                    Estado_Licencia estado = new Estado_Licencia(info[x].Id_Estado_Licencia);
                    if (estado.Proceso == 1)//ALINEAMIENTO
                    {
                        if (estado.Subproceso == 1)
                        {
                            DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            DTP_FechaDePagoDerechosAlineamiento.SelectedDate = info[x].Fecha;
                            TXT_ObservacinesPagoDerechosAlineamiento.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesRecogerDocumentacionAlineamiento.Text = info[x].Nota;
                        }
                    }
                    else if (estado.Proceso == 2)//USODESUELO
                    {
                        if (estado.Subproceso == 1)
                        {
                            DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate = info[x].Fecha;
                            TXT_ObservacinesPagoDerechosUsoDeSuelo.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text = info[x].Nota;
                        }
                    }
                    else if (estado.Proceso == 3)//SUPERVISIONTECNICA
                    {
                        if (estado.Subproceso == 1)
                        {
                            DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate = info[x].Fecha;
                            TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text = info[x].Nota;
                        }
                    }
                    else if (estado.Proceso == 4)//LICENCIA
                    {
                        if (estado.Subproceso == 1)
                        {
                            DTP_FechaDeArmadoPaqueteLicencia.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesDeArmadoPaqueteLicencia.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            DTP_FechaDePagoDerechosLicencia.SelectedDate = info[x].Fecha;
                            TXT_ObservacinesPagoDerechosLicencia.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            DTP_FechaDeRecogerDocumentacionLicencia.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesRecogerDocumentacionLicencia.Text = info[x].Nota;
                        }
                    }
                    else if (estado.Proceso == 5)//TERMINACIÓNDEOBRA
                    {
                        if (estado.Subproceso == 1)
                        {
                            DTP_FechaDeArmadoPaqueteTO.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesDeArmadoPaqueteTO.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            DTP_FechaDePagoDerechosTO.SelectedDate = info[x].Fecha;
                            TXT_ObservacinesPagoDerechosTO.Text = info[x].Nota;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            DTP_FechaDeRecogerDocumentacionTO.SelectedDate = info[x].Fecha;
                            TXT_ObservacionesRecogerDocumentacionTO.Text = info[x].Nota;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
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
                Clientes.IsEnabled = false;
                Inmuebles.IsEnabled = false;
                tipoProyecto.IsEnabled = false;
            }
            catch (Exception ex)
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

        private void btn_GuardarProcesosAlineamiento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool cambio = false;
                Proyecto_Licencia proyecto_Licencia = new Proyecto_Licencia(IDlicen);
                Documentacion_Licencia _Licencia = new Documentacion_Licencia(IDlicen, 2);
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text.ToString() != "")
                {
                    _Licencia.Actualizar(IDlicen, 2, "Alineamiento", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate), TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 2);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 2, "Alineamiento", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate), TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 2);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 3);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosAlineamiento.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 3, "Alineamiento", Convert.ToDateTime(DTP_FechaDePagoDerechosAlineamiento.SelectedDate), TXT_ObservacinesPagoDerechosAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 3);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosAlineamiento.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 3, "Alineamiento", Convert.ToDateTime(DTP_FechaDePagoDerechosAlineamiento.SelectedDate), TXT_ObservacinesPagoDerechosAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 3);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 4);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionAlineamiento.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 4, "Alineamiento", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate), TXT_ObservacionesRecogerDocumentacionAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 4);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionAlineamiento.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 4, "Alineamiento", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate), TXT_ObservacionesRecogerDocumentacionAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 4);
                    cambio = true;
                }
                if (cambio == true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.Show();
                    cambio = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_GuardarProcesosUsoDeSuelo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool cambio = false;
                Proyecto_Licencia proyecto_Licencia = new Proyecto_Licencia(IDlicen);
                Documentacion_Licencia _Licencia = new Documentacion_Licencia(IDlicen, 5);
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text.ToString() != "")
                {
                    _Licencia.Actualizar(IDlicen, 5, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate), TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 5);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 5, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate), TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 5);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 6);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosUsoDeSuelo.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 6, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate), TXT_ObservacinesPagoDerechosUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 6);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosUsoDeSuelo.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 6, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate), TXT_ObservacinesPagoDerechosUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 6);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 7);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 7, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate), TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 7);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 7, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate), TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 7);
                    cambio = true;
                }
                if (cambio == true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.Show();
                    cambio = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_GuardarProcesosSupervicionTecnica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool cambio = false;
                Proyecto_Licencia proyecto_Licencia = new Proyecto_Licencia(IDlicen);
                Documentacion_Licencia _Licencia = new Documentacion_Licencia(IDlicen, 8);
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text.ToString() != "")
                {
                    _Licencia.Actualizar(IDlicen, 8, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate), TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 8);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 8, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate), TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 8);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 9);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 9, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate), TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 9);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 9, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate), TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 9);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 10);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 10, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate), TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 10);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 10, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate), TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 10);
                    cambio = true;
                }
                if (cambio == true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.Show();
                    cambio = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_GuardarProcesosLicencia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool cambio = false;
                Proyecto_Licencia proyecto_Licencia = new Proyecto_Licencia(IDlicen);
                Documentacion_Licencia _Licencia = new Documentacion_Licencia(IDlicen, 11);
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaqueteLicencia.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteLicencia.Text.ToString() != "")
                {
                    _Licencia.Actualizar(IDlicen, 11, "Licencia", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteLicencia.SelectedDate), TXT_ObservacionesDeArmadoPaqueteLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 11);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteLicencia.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteLicencia.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 11, "Licencia", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteLicencia.SelectedDate), TXT_ObservacionesDeArmadoPaqueteLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 11);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 12);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosLicencia.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosLicencia.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 12, "Licencia", Convert.ToDateTime(DTP_FechaDePagoDerechosLicencia.SelectedDate), TXT_ObservacinesPagoDerechosLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 12);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosLicencia.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosLicencia.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 12, "Licencia", Convert.ToDateTime(DTP_FechaDePagoDerechosLicencia.SelectedDate), TXT_ObservacinesPagoDerechosLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 12);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 13);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionLicencia.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionLicencia.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 13, "Licencia", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionLicencia.SelectedDate), TXT_ObservacionesRecogerDocumentacionLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 13);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionLicencia.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionLicencia.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 13, "Licencia", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionLicencia.SelectedDate), TXT_ObservacionesRecogerDocumentacionLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 13);
                    cambio = true;
                }
                if (cambio == true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.Show();
                    cambio = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_GuardarProcesosTerminacionDeObra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool cambio = false;
                Proyecto_Licencia proyecto_Licencia = new Proyecto_Licencia(IDlicen);
                Documentacion_Licencia _Licencia = new Documentacion_Licencia(IDlicen, 14);
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaqueteTO.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteTO.Text.ToString() != "")
                {
                    _Licencia.Actualizar(IDlicen, 14, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteTO.SelectedDate), TXT_ObservacionesDeArmadoPaqueteTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 14);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteTO.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteTO.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 14, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteTO.SelectedDate), TXT_ObservacionesDeArmadoPaqueteTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 14);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 15);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosTO.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosTO.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 15, "Terminación de obra", Convert.ToDateTime(DTP_FechaDePagoDerechosTO.SelectedDate), TXT_ObservacinesPagoDerechosTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 15);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosTO.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosTO.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 15, "Terminación de obra", Convert.ToDateTime(DTP_FechaDePagoDerechosTO.SelectedDate), TXT_ObservacinesPagoDerechosTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 15);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 16);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionTO.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionTO.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 16, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionTO.SelectedDate), TXT_ObservacionesRecogerDocumentacionTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 16);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionTO.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionTO.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 16, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionTO.SelectedDate), TXT_ObservacionesRecogerDocumentacionTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, 16);
                    cambio = true;
                }
                if (cambio == true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.Show();
                    cambio = false;
                }
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

        private void Btn_GuardarLicencia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (F == false)
                {
                    ProyectoLicencia.Actualizar(ProyectoLicencia.Numero, TXT_NoFolio.Text.ToString(), TXT_NoLicencia.Text.ToString(), dockcheck[0], dockcheck[1], dockcheck[2], dockcheck[3], dockcheck[4], dockcheck[5], dockcheck[6], dockcheck[7]);
                    PantallaCheck check = new PantallaCheck();
                    check.Show();
                }
                else if (F == true)
                {
                    ProyectoLicencia.Insertar(TXT_NoFolio.Text, TXT_NoLicencia.Text, dockcheck[0], dockcheck[1], dockcheck[2], dockcheck[3], dockcheck[4], dockcheck[5], dockcheck[6], dockcheck[7], 1, IDprep, IDcliente, IDinmueble, 1);
                    presupuesto.Insertar(TXT_NombreCliente.Text, 0, 0, 1, IDprep);
                    PantallaCheck check = new PantallaCheck();
                    check.Show();
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

using CapaLogica;
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
using System.Security.Principal;
using System.Security.Permissions;
using System.Threading;
using System.Security;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para EstimacionDeValor.xaml
    /// </summary>
    public partial class EstimacionDeValor : UserControl
    {
        Dictamen_Estimacion dictamen;
        string NombreUsuario;
        Cliente cliente = new Cliente();
        Inmueble inmueble = new Inmueble();
        int numcliente, numinmueble, numeroestimacion;
        bool ela = false, entre = false, manis = false, oficio = false, escrituras = false, licencia = false, otra = false;
        List<DictamenEstructural> lit = new List<DictamenEstructural>();
        List<DictamenEstructural> lit2 = new List<DictamenEstructural>();
        int IdUSUATIO;
        public EstimacionDeValor( int iDe)
        {
            InitializeComponent();
            IdUSUATIO = iDe;
            CargarRolesUsuarios(iDe);
            CargarDatosactivos();
            CargarDatosinactivos();
            CargarClientes();
            CargarInmuebles();
            
        }
        private void CargarRolesUsuarios(int ID)
        {
            try
            {
                Empleado empleado = new Empleado(ID);
                Permiso permiso = new Permiso();
                NombreUsuario = empleado.Nombre;
                GenericIdentity identidad = new GenericIdentity(NombreUsuario);
                String[] roles = permiso.SelXPerfil(empleado.Perfil);
                GenericPrincipal MyPrincipal =
                new GenericPrincipal(identidad, roles);
                Thread.CurrentPrincipal = MyPrincipal;
            }
            catch(Exception ex)
            {

            }
        }
        private void btnConceptoModificar_Click(object sender, RoutedEventArgs e)
        {
        }
        public class DictamenEstructural
        {
            public int ID { get; set; }
            public string Etiqueta { get; set; }
            public bool Tipo { get; set; }
            public DateTime FechaRegistro { get; set; }
            public DateTime FechaVisita { get; set; }
            public bool Elaboracion { get; set; }
            public string Observacion { get; set; }
            public bool Entregado { get; set; }
            public bool Manifestacion { get; set; }
            public bool Oficiosub { get; set; }
            public bool Escrituras { get; set; }
            public bool Licencia { get; set; }
            public bool Otra { get; set; }
            public string OtraNombre { get; set; }
            public int cliente { get; set; }
            public int inmueble { get; set; }

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
        private void llenardatalikeClavecatastral(string texto)
        {
            lit.Clear();
            DataTable table = new DataTable();
            dictamen = new Dictamen_Estimacion();
            Dictamen_Estimacion[] datos = dictamen.TableToArray(table = dictamen.SelXTipoLikeCatastral(true, texto));
            for (int x = 0; x < datos.Length; x++)
            {
                lit.Add(new DictamenEstructural() { ID = datos[x].Numero, Etiqueta = datos[x].Etiqueta, Tipo = datos[x].Tipo, FechaRegistro = datos[x].Fecha_Registro, FechaVisita = datos[x].Visita_Programada, Elaboracion = datos[x].Elaboracion, Observacion = datos[x].Observacion_Elaboracion, Entregado = datos[x].Entregado, Manifestacion = datos[x].Manifestacion, Oficiosub = datos[x].Oficio_Subdivision, Escrituras = datos[x].Escrituras, Licencia = datos[x].Licencia_Construccion, Otra = datos[x].Otra, OtraNombre = datos[x].Otra_Nombre, cliente = datos[x].Id_Cliente, inmueble = datos[x].Clave_Inmueble });
            }
            GridConceptosActivos.ItemsSource = lit;
        }
        private void llenardatalikeetiqueta(string texto)
        {
            lit.Clear();
            DataTable table = new DataTable();
            dictamen = new Dictamen_Estimacion();
            Dictamen_Estimacion[] datos = dictamen.TableToArray(table = dictamen.SelXTipoLikeEtiqueta(true, texto));
            for (int x = 0; x < datos.Length; x++)
            {
                lit.Add(new DictamenEstructural() { ID = datos[x].Numero, Etiqueta = datos[x].Etiqueta, Tipo = datos[x].Tipo, FechaRegistro = datos[x].Fecha_Registro, FechaVisita = datos[x].Visita_Programada, Elaboracion = datos[x].Elaboracion, Observacion = datos[x].Observacion_Elaboracion, Entregado = datos[x].Entregado, Manifestacion = datos[x].Manifestacion, Oficiosub = datos[x].Oficio_Subdivision, Escrituras = datos[x].Escrituras, Licencia = datos[x].Licencia_Construccion, Otra = datos[x].Otra, OtraNombre = datos[x].Otra_Nombre, cliente = datos[x].Id_Cliente, inmueble = datos[x].Clave_Inmueble });
            }
            GridConceptosActivos.ItemsSource = lit;
        }
        private void llenardatalikepropietario(string texto)
        {
            lit.Clear();
            DataTable table = new DataTable();
            dictamen = new Dictamen_Estimacion();
            Dictamen_Estimacion[] datos = dictamen.TableToArray(table = dictamen.SelXTipoLikePropietario(true, texto));
            for (int x = 0; x < datos.Length; x++)
            {
                lit.Add(new DictamenEstructural() { ID = datos[x].Numero, Etiqueta = datos[x].Etiqueta, Tipo = datos[x].Tipo, FechaRegistro = datos[x].Fecha_Registro, FechaVisita = datos[x].Visita_Programada, Elaboracion = datos[x].Elaboracion, Observacion = datos[x].Observacion_Elaboracion, Entregado = datos[x].Entregado, Manifestacion = datos[x].Manifestacion, Oficiosub = datos[x].Oficio_Subdivision, Escrituras = datos[x].Escrituras, Licencia = datos[x].Licencia_Construccion, Otra = datos[x].Otra, OtraNombre = datos[x].Otra_Nombre, cliente = datos[x].Id_Cliente, inmueble = datos[x].Clave_Inmueble });
            }
            GridConceptosActivos.ItemsSource = lit;
        }
        private void llenardatalikeClavecatastraleliminado(string texto)
        {
            lit2.Clear();
            DataTable table = new DataTable();
            dictamen = new Dictamen_Estimacion();
            Dictamen_Estimacion[] datos = dictamen.TableToArray(table = dictamen.SelXTipoLikeCatastral(true, texto, true));
            for (int x = 0; x < datos.Length; x++)
            {
                lit2.Add(new DictamenEstructural() { ID = datos[x].Numero, Etiqueta = datos[x].Etiqueta, Tipo = datos[x].Tipo, FechaRegistro = datos[x].Fecha_Registro, FechaVisita = datos[x].Visita_Programada, Elaboracion = datos[x].Elaboracion, Observacion = datos[x].Observacion_Elaboracion, Entregado = datos[x].Entregado, Manifestacion = datos[x].Manifestacion, Oficiosub = datos[x].Oficio_Subdivision, Escrituras = datos[x].Escrituras, Licencia = datos[x].Licencia_Construccion, Otra = datos[x].Otra, OtraNombre = datos[x].Otra_Nombre, cliente = datos[x].Id_Cliente, inmueble = datos[x].Clave_Inmueble });
            }
            GridConceptosActivos.ItemsSource = lit2;
        }
        private void llenardatalikeetiquetaeliminado(string texto)
        {
            lit2.Clear();
            DataTable table = new DataTable();
            dictamen = new Dictamen_Estimacion();
            Dictamen_Estimacion[] datos = dictamen.TableToArray(table = dictamen.SelXTipoLikeEtiqueta(true, texto, true));
            for (int x = 0; x < datos.Length; x++)
            {
                lit2.Add(new DictamenEstructural() { ID = datos[x].Numero, Etiqueta = datos[x].Etiqueta, Tipo = datos[x].Tipo, FechaRegistro = datos[x].Fecha_Registro, FechaVisita = datos[x].Visita_Programada, Elaboracion = datos[x].Elaboracion, Observacion = datos[x].Observacion_Elaboracion, Entregado = datos[x].Entregado, Manifestacion = datos[x].Manifestacion, Oficiosub = datos[x].Oficio_Subdivision, Escrituras = datos[x].Escrituras, Licencia = datos[x].Licencia_Construccion, Otra = datos[x].Otra, OtraNombre = datos[x].Otra_Nombre, cliente = datos[x].Id_Cliente, inmueble = datos[x].Clave_Inmueble });
            }
            GridConceptosActivos.ItemsSource = lit2;
        }
        private void llenardatalikepropietarioeliminado(string texto)
        {
            lit2.Clear();
            DataTable table = new DataTable();
            dictamen = new Dictamen_Estimacion();
            Dictamen_Estimacion[] datos = dictamen.TableToArray(table = dictamen.SelXTipoLikePropietario(true, texto, true));
            for (int x = 0; x < datos.Length; x++)
            {
                lit2.Add(new DictamenEstructural() { ID = datos[x].Numero, Etiqueta = datos[x].Etiqueta, Tipo = datos[x].Tipo, FechaRegistro = datos[x].Fecha_Registro, FechaVisita = datos[x].Visita_Programada, Elaboracion = datos[x].Elaboracion, Observacion = datos[x].Observacion_Elaboracion, Entregado = datos[x].Entregado, Manifestacion = datos[x].Manifestacion, Oficiosub = datos[x].Oficio_Subdivision, Escrituras = datos[x].Escrituras, Licencia = datos[x].Licencia_Construccion, Otra = datos[x].Otra, OtraNombre = datos[x].Otra_Nombre, cliente = datos[x].Id_Cliente, inmueble = datos[x].Clave_Inmueble });
            }
            GridConceptosActivos.ItemsSource = lit2;
        }
        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Clientea p = (Clientea)Clientes.SelectedItem;
                if (p != null)
                {
                    numcliente = p.ID;
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
                    numinmueble = p.ID;

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V3");
                MyPermission.Demand();
                DictamenEstructural dictamen2 = (DictamenEstructural)GridConceptosActivos.SelectedItem;
                if (dictamen2 != null)
                {
                    dictamen.Eliminar(dictamen2.ID);
                    CargarDatosactivos();
                    CargarDatosinactivos();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void TxtBusquedaActivos_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V4");
                MyPermission.Demand();
                if (OpcionesActivos.SelectedIndex == -1)
                {
                    CargarDatosactivos();
                }
                else if (OpcionesActivos.SelectedIndex == 0)
                {
                    llenardatalikeClavecatastral(TxtBusquedaActivos.Text);
                }
                else if (OpcionesActivos.SelectedIndex == 1)
                {
                    llenardatalikeetiqueta(TxtBusquedaActivos.Text);
                }
                else if (OpcionesActivos.SelectedIndex == 2)
                {
                    llenardatalikepropietario(TxtBusquedaActivos.Text);
                }
            }
            catch(Exception EX)
            {

            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V1");
                MyPermission.Demand();
                numeroestimacion = 0;
            }catch(Exception ex)
            {

            }
        }

        private void BtnRestaurar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V2");
                MyPermission.Demand();
                DictamenEstructural dictamen2 = (DictamenEstructural)GridConceptosInactivos.SelectedItem;
                if (dictamen2 != null)
                {
                    dictamen.Activar(dictamen2.ID);
                    CargarDatosactivos();
                    CargarDatosinactivos();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ActivadorInactivos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ActivadorInactivos.IsChecked == true)
                {
                    OpcionesInactivos.IsEnabled = true;
                    TxtBusquedaInactivos.IsEnabled = true;
                    OpcionesInactivos.SelectedIndex = -1;
                    TxtBusquedaInactivos.Clear();
                }
                else
                {
                    OpcionesInactivos.IsEnabled = false;
                    TxtBusquedaInactivos.IsEnabled = false;
                    OpcionesInactivos.SelectedIndex = -1;
                    TxtBusquedaInactivos.Clear();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void TxtBusquedaInactivos_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (OpcionesInactivos.SelectedIndex == -1)
                {
                    CargarDatosinactivos();
                }
                else if (OpcionesInactivos.SelectedIndex == 0)
                {
                    llenardatalikeClavecatastraleliminado(TxtBusquedaInactivos.Text);
                }
                else if (OpcionesInactivos.SelectedIndex == 1)
                {
                    llenardatalikeetiquetaeliminado(TxtBusquedaInactivos.Text);
                }
                else if (OpcionesInactivos.SelectedIndex == 2)
                {
                    llenardatalikeetiquetaeliminado(TxtBusquedaInactivos.Text);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void GridConceptosActivos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DictamenEstructural dictamen = (DictamenEstructural)GridConceptosActivos.SelectedItem;
                if (dictamen != null)
                {
                    tit.Text = "Editar Estimación de Valor";
                    numeroestimacion = dictamen.ID;
                    TXTetiqueta.Text = dictamen.Etiqueta;
                    Clientes.SelectedIndex = dictamen.cliente - 1;
                    Inmuebles.SelectedIndex = dictamen.inmueble - 1;
                    DTP_FechaRegistro.SelectedDate = dictamen.FechaRegistro;
                    DTP_FechaVisita.SelectedDate = dictamen.FechaVisita;
                    if(dictamen.Elaboracion)
                        elaboracion.SelectedIndex = 1;
                    else
                        elaboracion.SelectedIndex = 0;
                    TXTObservaciionElaboracion.Text = dictamen.Observacion;
                    if (dictamen.Entregado)
                        Entregado.SelectedIndex = 1;
                    else
                        Entregado.SelectedIndex = 0;
                    if (dictamen.Manifestacion)
                        Manifestacion.SelectedIndex = 1;
                    else
                        Manifestacion.SelectedIndex = 0;
                    if (dictamen.Oficiosub)
                        OficioSub.SelectedIndex = 1;
                    else
                        OficioSub.SelectedIndex = 0;
                    if (dictamen.Escrituras)
                        Escrituras.SelectedIndex = 1;
                    else
                        Escrituras.SelectedIndex = 0;
                    if (dictamen.Licencia)
                        Licencia.SelectedIndex = 1;
                    else
                        Licencia.SelectedIndex = 0;
                    if (dictamen.Otra)
                        Otra.SelectedIndex = 1;
                    else
                        Otra.SelectedIndex = 0;
                    TXTOtra.Text = dictamen.OtraNombre;
                    Formulario.IsOpen = true;
                }
            }catch(Exception ex)
            {

            }
        }

        private void ActivadorActivos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ActivadorActivos.IsChecked == true)
                {
                    OpcionesActivos.IsEnabled = true;
                    TxtBusquedaActivos.IsEnabled = true;
                    OpcionesActivos.SelectedIndex = -1;
                    TxtBusquedaActivos.Clear();
                }
                else
                {
                    OpcionesActivos.IsEnabled = false;
                    TxtBusquedaActivos.IsEnabled = false;
                    OpcionesActivos.SelectedIndex = -1;
                    TxtBusquedaActivos.Clear();
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V4");
                MyPermission.Demand();
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V4");
                MyPermission.Demand();
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
        public void CargarDatosactivos()
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V4");
                MyPermission.Demand();
                GridConceptosActivos.ItemsSource = null;
                lit.Clear();
                DataTable table = new DataTable();
                dictamen = new Dictamen_Estimacion();
                Dictamen_Estimacion[] datos = dictamen.TableToArray(table = dictamen.SelXTipoLikeCatastral(true, ""));
                for (int x = 0; x < datos.Length; x++)
                {
                    lit.Add(new DictamenEstructural() { ID = datos[x].Numero, Etiqueta = datos[x].Etiqueta, Tipo = datos[x].Tipo, FechaRegistro = datos[x].Fecha_Registro, FechaVisita = datos[x].Visita_Programada, Elaboracion = datos[x].Elaboracion, Observacion = datos[x].Observacion_Elaboracion, Entregado = datos[x].Entregado, Manifestacion = datos[x].Manifestacion, Oficiosub = datos[x].Oficio_Subdivision, Escrituras = datos[x].Escrituras, Licencia = datos[x].Licencia_Construccion, Otra = datos[x].Otra, OtraNombre = datos[x].Otra_Nombre, cliente = datos[x].Id_Cliente, inmueble = datos[x].Clave_Inmueble });
                }
                GridConceptosActivos.ItemsSource = lit;
            }
            catch(Exception ex)
            {

            }
        }
        public void CargarDatosinactivos()
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V4");
                MyPermission.Demand();
                GridConceptosInactivos.ItemsSource = null;
                lit2.Clear();
                dictamen = new Dictamen_Estimacion();
                DataTable table2 = new DataTable();
                Dictamen_Estimacion[] datos2 = dictamen.TableToArray(table2 = dictamen.SelXTipoLikeCatastral(true, "", true));
                for (int x = 0; x < datos2.Length; x++)
                {
                    lit2.Add(new DictamenEstructural() { ID = datos2[x].Numero, Etiqueta = datos2[x].Etiqueta, Tipo = datos2[x].Tipo, FechaRegistro = datos2[x].Fecha_Registro, FechaVisita = datos2[x].Visita_Programada, Elaboracion = datos2[x].Elaboracion, Observacion = datos2[x].Observacion_Elaboracion, Entregado = datos2[x].Entregado, Manifestacion = datos2[x].Manifestacion, Oficiosub = datos2[x].Oficio_Subdivision, Escrituras = datos2[x].Escrituras, Licencia = datos2[x].Licencia_Construccion, Otra = datos2[x].Otra, OtraNombre = datos2[x].Otra_Nombre, cliente = datos2[x].Id_Cliente, inmueble = datos2[x].Clave_Inmueble });
                }
                GridConceptosInactivos.ItemsSource = lit2;
            }
            catch(Exception ex)
            {

            }
        }
        public void limpiar()
        {
            tit.Text= "Agregar Estimación de Valor";
            TXTetiqueta.Clear();
            DTP_FechaRegistro.SelectedDate = null;
            DTP_FechaVisita.SelectedDate = null;
            ela = false;
            elaboracion.SelectedIndex = -1;
            TXTObservaciionElaboracion.Clear();
            entre = false;
            Entregado.SelectedIndex = -1;
            manis = false;
            Manifestacion.SelectedIndex = -1;
            oficio = false;
            OficioSub.SelectedIndex = -1;
            escrituras = false;
            Escrituras.SelectedIndex = -1;
            licencia = false;
            Licencia.SelectedIndex = -1;
            otra = false;
            Otra.SelectedIndex = -1;
            TXTOtra.Clear();
        }
        public void sacarbool()
        {
            if (elaboracion.SelectedIndex == 0)
            {
                ela = true;
            }
            else if (elaboracion.SelectedIndex == 1)
            {
                ela = false;
            }
            if (Entregado.SelectedIndex == 0)
            {
                entre = false;
            }
            else if (Entregado.SelectedIndex == 1)
            {
                entre = true;
            }
            if (Manifestacion.SelectedIndex == 0)
            {
                manis = false;
            }
            else if (Manifestacion.SelectedIndex == 1)
            {
                manis = true;
            }
            if (OficioSub.SelectedIndex == 0)
            {
                oficio = false;
            }
            else if (OficioSub.SelectedIndex == 1)
            {
                oficio = true;
            }
            if (Escrituras.SelectedIndex == 0)
            {
                escrituras = false;
            }
            else if (Escrituras.SelectedIndex == 1)
            {
                escrituras = true;
            }
            if (Licencia.SelectedIndex == 0)
            {
                licencia = false;
            }
            else if (Licencia.SelectedIndex == 1)
            {
                licencia = true;
            }
            if (Otra.SelectedIndex == 0)
            {
                otra = false;
            }
            else if (Otra.SelectedIndex == 1)
            {
                otra = true;
            }
        }

        private void btnAgregarConcepto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V1");
                MyPermission.Demand();
                if (numeroestimacion == 0)
                {
                    sacarbool();
                    dictamen.Insertar(TXTetiqueta.Text, true, Convert.ToDateTime(DTP_FechaRegistro.SelectedDate), Convert.ToDateTime(DTP_FechaVisita.SelectedDate), ela, TXTObservaciionElaboracion.Text, entre, manis, oficio, escrituras, licencia, otra, TXTOtra.Text, numcliente, numinmueble, 1);
                    CargarDatosactivos();
                    CargarDatosinactivos();
                    limpiar();
                }
            }
            catch(Exception ex)
            {

            }
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "V2");
                MyPermission.Demand();
                if (numeroestimacion != 0)
                {
                    sacarbool();
                    dictamen.Actualizar(numeroestimacion, TXTetiqueta.Text, true, Convert.ToDateTime(DTP_FechaRegistro.SelectedDate), Convert.ToDateTime(DTP_FechaVisita.SelectedDate), ela, TXTObservaciionElaboracion.Text, entre, manis, oficio, escrituras, licencia, otra, TXTOtra.Text, numcliente, numinmueble, 1);
                    CargarDatosactivos();
                    CargarDatosinactivos();
                    limpiar();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}

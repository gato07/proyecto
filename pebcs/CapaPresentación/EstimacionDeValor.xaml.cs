﻿using CapaLogica;
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

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para EstimacionDeValor.xaml
    /// </summary>
    public partial class EstimacionDeValor : UserControl
    {
        Dictamen_Estimacion dictamen;
        Cliente cliente = new Cliente();
        Inmueble inmueble = new Inmueble();
        int numcliente, numinmueble, numeroestimacion;
        bool ela = false, entre = false, manis = false, oficio = false, escrituras = false, licencia = false, otra = false;
        List<DictamenEstructural> lit = new List<DictamenEstructural>();
        public EstimacionDeValor()
        {
            InitializeComponent();
            CargarDatos();
            CargarClientes();
            CargarInmuebles();
            
        }
        private void btnConceptoModificar_Click(object sender, RoutedEventArgs e)
        {
            CargarDatos();
            limpiar();
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
            DataTable table = new DataTable();
            dictamen = new Dictamen_Estimacion();
            Dictamen_Estimacion[] datos = dictamen.TableToArray(table = dictamen.SelXTipoLikePropietario(true, texto));
            for (int x = 0; x < datos.Length; x++)
            {
                lit.Add(new DictamenEstructural() { ID = datos[x].Numero, Etiqueta = datos[x].Etiqueta, Tipo = datos[x].Tipo, FechaRegistro = datos[x].Fecha_Registro, FechaVisita = datos[x].Visita_Programada, Elaboracion = datos[x].Elaboracion, Observacion = datos[x].Observacion_Elaboracion, Entregado = datos[x].Entregado, Manifestacion = datos[x].Manifestacion, Oficiosub = datos[x].Oficio_Subdivision, Escrituras = datos[x].Escrituras, Licencia = datos[x].Licencia_Construccion, Otra = datos[x].Otra, OtraNombre = datos[x].Otra_Nombre, cliente = datos[x].Id_Cliente, inmueble = datos[x].Clave_Inmueble });
            }
            GridConceptosActivos.ItemsSource = lit;
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
            DataRowView data = (GridConceptosActivos as DataGrid).SelectedItem as DataRowView;
            dictamen.Eliminar(Convert.ToInt16(data.Row.ItemArray[0].ToString()));
            CargarDatos();
        }

        private void TxtBusquedaActivos_KeyUp(object sender, KeyEventArgs e)
        {
            if (OpcionesActivos.SelectedIndex == -1)
            {
                CargarDatos();
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

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                numeroestimacion = 0;
            }catch(Exception ex)
            {

            }
        }

        private void BtnRestaurar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Inmueblea p = (Inmueblea)Inmuebles.SelectedItem;
                if (p != null)
                {
                    dictamen.Activar(p.ID);
                    CargarDatos();
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
        public void CargarDatos()
        {
            DataTable table = new DataTable();
            dictamen = new Dictamen_Estimacion();
            Dictamen_Estimacion[] datos = dictamen.TableToArray(table = dictamen.SelXTipoLikeCatastral(false, ""));
            for (int x = 0; x < datos.Length; x++)
            {
                lit.Add(new DictamenEstructural() { ID = datos[x].Numero, Etiqueta = datos[x].Etiqueta, Tipo = datos[x].Tipo, FechaRegistro = datos[x].Fecha_Registro, FechaVisita = datos[x].Visita_Programada, Elaboracion = datos[x].Elaboracion, Observacion = datos[x].Observacion_Elaboracion, Entregado = datos[x].Entregado, Manifestacion = datos[x].Manifestacion, Oficiosub = datos[x].Oficio_Subdivision, Escrituras = datos[x].Escrituras, Licencia = datos[x].Licencia_Construccion, Otra = datos[x].Otra, OtraNombre = datos[x].Otra_Nombre, cliente = datos[x].Id_Cliente, inmueble = datos[x].Clave_Inmueble });
            }
            GridConceptosActivos.ItemsSource = lit;
        }
        public void limpiar()
        {
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
            if(numeroestimacion==0)
            {
                sacarbool();
                dictamen.Insertar(TXTetiqueta.Text, true, Convert.ToDateTime(DTP_FechaRegistro.SelectedDate), Convert.ToDateTime(DTP_FechaVisita.SelectedDate), ela, TXTObservaciionElaboracion.Text, entre, manis, oficio, escrituras, licencia, otra, TXTOtra.Text, numcliente, numinmueble, 1);
                CargarDatos();
                limpiar();
            }
            else if (numeroestimacion!=0)
            {
                sacarbool();
                dictamen.Actualizar(numeroestimacion, TXTetiqueta.Text, true, Convert.ToDateTime(DTP_FechaRegistro.SelectedDate), Convert.ToDateTime(DTP_FechaVisita.SelectedDate), ela, TXTObservaciionElaboracion.Text, entre, manis, oficio, escrituras, licencia, otra, TXTOtra.Text, numcliente, numinmueble, 1);
                CargarDatos();
                limpiar();
            }
        }
    }
}

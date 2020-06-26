using CapaLogica;
using CapaPresentación.Controles;
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

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_SeguimientoLicencia.xaml
    /// </summary>
    public partial class Pantalla_SeguimientoLicencia : UserControl
    {
        int IDlicen;
        Proyecto_Licencia ProyectoLicencia = new Proyecto_Licencia();
        Proyecto_Licencia ProyectoLicenciaProrroga = new Proyecto_Licencia();
        CapaLogica.Presupuesto pre = new CapaLogica.Presupuesto();
        Menu_Principal2 Mn;
        public Pantalla_SeguimientoLicencia(int IDlicencia, Object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
            IDlicen = IDlicencia;
            ProyectoLicencia = new Proyecto_Licencia(IDlicencia);
            pre = new  CapaLogica.Presupuesto(ProyectoLicencia.Numero_Presupuesto);
            CargarProcesos(pre.Id_Tipo_Proyecto, pre.Mts);
            CargarIfoProcesos(IDlicen);
            CargarDatos(IDlicen);
        }
        public void CargarDatos(int IDeLicencia)
        {
            ProyectoLicencia = new Proyecto_Licencia(IDeLicencia);
            pre = new CapaLogica.Presupuesto(ProyectoLicencia.Numero_Presupuesto);
            TXT_NoFolio.Text = ProyectoLicencia.Folio;
            TXT_NoLicencia.Text = ProyectoLicencia.Numero_Licencia;
            DTP_Vigencia.SelectedDate = ProyectoLicencia.Vigencia;
            ProyectoLicenciaProrroga = new Proyecto_Licencia(ProyectoLicencia.Numero_Proyecto_Original);
            if(ProyectoLicenciaProrroga.Existe)
            {
                TXT_NoFolioProrroga.Text = ProyectoLicenciaProrroga.Folio;
                TXT_NoLicenciaProrroga.Text = ProyectoLicenciaProrroga.Numero_Licencia;
                DTP_VigenciaProrroga.SelectedDate = ProyectoLicenciaProrroga.Vigencia;
                LICENCIAPRORROGATAB.IsEnabled = true;
            }
        }
        private void CargarIfoProcesos(int IDeLicencia)
        {
            try
            {
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                ProyectoLicencia = new Proyecto_Licencia(IDeLicencia);
                Documentacion_Licencia[] infoProrroga = documentacion_Licencia.TableToArray(documentacion_Licencia.SelXNumeroProLic(ProyectoLicencia.Numero_Proyecto_Original));
                Documentacion_Licencia[] info = documentacion_Licencia.TableToArray(documentacion_Licencia.SelXNumeroProLic(IDeLicencia));
                for(int x=0;x<infoProrroga.Length;x++)
                {
                    Estado_Licencia estado = new Estado_Licencia(infoProrroga[x].Id_Estado_Licencia);
                    if (estado.Proceso == 5)//Licencia Prorroga
                    {
                        if (estado.Subproceso == 1)
                        {
                            DTP_FechaDeArmadoPaqueteLicenciaProrroga.SelectedDate = infoProrroga[x].Fecha;
                            TXT_ObservacionesDeArmadoPaqueteLicenciaProrroga.Text = infoProrroga[x].Nota;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            DTP_FechaDePagoDerechosLicenciaProrroga.SelectedDate = infoProrroga[x].Fecha;
                            TXT_ObservacinesPagoDerechosLicenciaProrroga.Text = infoProrroga[x].Nota;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            DTP_FechaDeRecogerDocumentacionLicenciaProrroga.SelectedDate = infoProrroga[x].Fecha;
                            TXT_ObservacionesRecogerDocumentacionLicenciaProrroga.Text = infoProrroga[x].Nota;
                        }
                    }
                }
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
                    else if (estado.Proceso == 6)//TERMINACIÓNDEOBRA
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
        private void CargarProcesos(int tipobra, Decimal metros)
        {
            try
            {
                switch (tipobra)
                {
                    case 1://Ampliacion Habitacional
                        if(metros>300)
                        {
                            SUPERVICIONTECNICATAB.IsEnabled = false;
                            LICENCIAPRORROGATAB.IsEnabled = false;
                        }
                        else
                        {
                            SUPERVICIONTECNICATAB.IsEnabled = false;
                            LICENCIAPRORROGATAB.IsEnabled = false;
                            USODESUELOTAB.IsEnabled = false;
                        }
                        break;
                    case 2://Ampliacion Comercial
                        //todo
                        break;
                    case 3://Ampliacion Industrial
                        //todo
                        break;
                    case 4://Hampliacion Obra Complementaria
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        USODESUELOTAB.IsEnabled = false;
                        break;
                    case 5://Ampliacion Otros
                        //todo
                        break;
                    case 6://Regularizacion Habitacional
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        USODESUELOTAB.IsEnabled = false;
                        break;
                    case 7://Regularizacion Comercial
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        break;
                    case 8://Regularizacion Industrial
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        break;
                    case 9://Regularizacion Obra Complementaria
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        USODESUELOTAB.IsEnabled = false;
                        break;
                    case 10://Regularizacion Otros
                        //todo
                        break;
                    case 11://Obra Nueva Habitacional
                        if (metros > 300)
                        {
                            SUPERVICIONTECNICATAB.IsEnabled = false;
                            LICENCIAPRORROGATAB.IsEnabled = false;
                        }
                        else
                        {
                            SUPERVICIONTECNICATAB.IsEnabled = false;
                            LICENCIAPRORROGATAB.IsEnabled = false;
                            USODESUELOTAB.IsEnabled = false;
                        }
                        break;
                    case 12://Obra Nueva Comercial
                        //todo
                        break;
                    case 13://Obra Nueva Industrial
                        //todo
                        break;
                    case 14://Obra Nueva Complementaria
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        USODESUELOTAB.IsEnabled = false;
                        break;
                    case 15://Obra Nueva Otros
                        //todo
                        break;
                    case 16://Remodelacion Habitacional
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        USODESUELOTAB.IsEnabled = false;
                        break;
                    case 17://Remodelacion Comercial
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        break;
                    case 18://Remodelacion Industrial
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        break;
                    case 19://Remodelacion Obra Complementaria
                        SUPERVICIONTECNICATAB.IsEnabled = false;
                        LICENCIAPRORROGATAB.IsEnabled = false;
                        USODESUELOTAB.IsEnabled = false;
                        break;
                    case 20://Remodelacion Otros
                        //todo
                        break;
                    case 21://Demolicion Habitacional

                        break;
                    case 22://Demolicion Comercial

                        break;
                    case 23://Demolicion Industrial

                        break;
                    case 24://Demolicion Obra Complementaria

                        break;
                    case 25://Demolicion Otros

                        break;
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
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text.ToString()!="" )
                {
                    _Licencia.Actualizar(IDlicen, 2, "Alineamiento", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate), TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen,TXT_NoFolio.Text,TXT_NoLicencia.Text,Convert.ToDateTime(DTP_Vigencia.SelectedDate), 2);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text != "" )
                {
                    _Licencia.Insertar(IDlicen, 2, "Alineamiento", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate), TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 2);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 3);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosAlineamiento.Text != "" )
                {
                    _Licencia.Actualizar(IDlicen, 3, "Alineamiento", Convert.ToDateTime(DTP_FechaDePagoDerechosAlineamiento.SelectedDate), TXT_ObservacinesPagoDerechosAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 3);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosAlineamiento.Text != "" )
                {
                    _Licencia.Insertar(IDlicen, 3, "Alineamiento", Convert.ToDateTime(DTP_FechaDePagoDerechosAlineamiento.SelectedDate), TXT_ObservacinesPagoDerechosAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 3);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 4);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionAlineamiento.Text != "" )
                {
                    _Licencia.Actualizar(IDlicen, 4, "Alineamiento", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate), TXT_ObservacionesRecogerDocumentacionAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 4);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionAlineamiento.Text != "" )
                {
                    _Licencia.Insertar(IDlicen, 4, "Alineamiento", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate), TXT_ObservacionesRecogerDocumentacionAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 4);
                    cambio = true;
                }
                if(TXT_NoFolio.Text!="")
                {
                    ProyectoLicencia = new Proyecto_Licencia(IDlicen);
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), ProyectoLicencia.Id_Estado_Licencia);
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
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text.ToString() != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 5, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate), TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 5);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 5, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate), TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 5);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 6);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosUsoDeSuelo.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 6, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate), TXT_ObservacinesPagoDerechosUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 6);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosUsoDeSuelo.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 6, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate), TXT_ObservacinesPagoDerechosUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 6);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 7);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 7, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate), TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 7);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 7, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate), TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 7);
                    cambio = true;
                }
                if (TXT_NoFolio.Text != "")
                {
                    ProyectoLicencia = new Proyecto_Licencia(IDlicen);
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), ProyectoLicencia.Id_Estado_Licencia);
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
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text.ToString() != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 8, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate), TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 8);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 8, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate), TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 8);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 9);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 9, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate), TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 9);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 9, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate), TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 9);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 10);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 10, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate), TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 10);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 10, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate), TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 10);
                    cambio = true;
                }
                if (TXT_NoFolio.Text != "")
                {
                    ProyectoLicencia = new Proyecto_Licencia(IDlicen);
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), ProyectoLicencia.Id_Estado_Licencia);
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
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 11);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteLicencia.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteLicencia.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 11, "Licencia", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteLicencia.SelectedDate), TXT_ObservacionesDeArmadoPaqueteLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 11);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 12);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosLicencia.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosLicencia.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 12, "Licencia", Convert.ToDateTime(DTP_FechaDePagoDerechosLicencia.SelectedDate), TXT_ObservacinesPagoDerechosLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 12);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosLicencia.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosLicencia.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 12, "Licencia", Convert.ToDateTime(DTP_FechaDePagoDerechosLicencia.SelectedDate), TXT_ObservacinesPagoDerechosLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 12);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 13);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionLicencia.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionLicencia.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 13, "Licencia", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionLicencia.SelectedDate), TXT_ObservacionesRecogerDocumentacionLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 13);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionLicencia.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionLicencia.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 13, "Licencia", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionLicencia.SelectedDate), TXT_ObservacionesRecogerDocumentacionLicencia.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 13);
                    cambio = true;
                }
                if (cambio == true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.Show();
                    cambio = false;
                }
                if (TXT_NoFolio.Text != ""||TXT_NoLicencia.Text!=""||DTP_Vigencia.SelectedDate.ToString()!="")
                {
                    ProyectoLicencia = new Proyecto_Licencia(IDlicen);
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), ProyectoLicencia.Id_Estado_Licencia);
                    cambio = true;
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
                Documentacion_Licencia _Licencia = new Documentacion_Licencia(IDlicen, 17);
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaqueteTO.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteTO.Text.ToString() != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 17, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteTO.SelectedDate), TXT_ObservacionesDeArmadoPaqueteTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 14);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteTO.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteTO.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 17, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteTO.SelectedDate), TXT_ObservacionesDeArmadoPaqueteTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 14);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 18);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosTO.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosTO.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 18, "Terminación de obra", Convert.ToDateTime(DTP_FechaDePagoDerechosTO.SelectedDate), TXT_ObservacinesPagoDerechosTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 15);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosTO.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosTO.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 18, "Terminación de obra", Convert.ToDateTime(DTP_FechaDePagoDerechosTO.SelectedDate), TXT_ObservacinesPagoDerechosTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 15);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 19);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionTO.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionTO.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 19, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionTO.SelectedDate), TXT_ObservacionesRecogerDocumentacionTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 16);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionTO.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionTO.Text != "" && TXT_NoFolio.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 19, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionTO.SelectedDate), TXT_ObservacionesRecogerDocumentacionTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 16);
                    cambio = true;
                }
                if (TXT_NoFolio.Text != "")
                {
                    ProyectoLicencia = new Proyecto_Licencia(IDlicen);
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), ProyectoLicencia.Id_Estado_Licencia);
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

        private void Btn_Cambio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(IDlicen!=0)
                {
                    Mn.AbrirFormHijo(new Pantalla_InfoLicencia(IDlicen, Mn,0));
                }
            }catch(Exception ex)
            {

            }
        }

        private void btn_GuardarProcesosLicenciaPrprroga_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool cambio = false;
                Proyecto_Licencia proyecto_Licencia = new Proyecto_Licencia(IDlicen);
                Proyecto_Licencia prorroga = new Proyecto_Licencia(proyecto_Licencia.Numero_Proyecto_Original);
                Documentacion_Licencia _Licencia = new Documentacion_Licencia(prorroga.Numero, 14);
                if (_Licencia.Existe == true && DTP_FechaDeArmadoPaqueteLicenciaProrroga.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteLicenciaProrroga.Text.ToString() != "" )
                {
                    _Licencia.Actualizar(prorroga.Numero, 14, "Licencia prórroga", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteLicenciaProrroga.SelectedDate), TXT_ObservacionesDeArmadoPaqueteLicenciaProrroga.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(prorroga.Numero, TXT_NoFolioProrroga.Text, TXT_NoLicenciaProrroga.Text, Convert.ToDateTime(DTP_VigenciaProrroga.SelectedDate), 14);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteLicenciaProrroga.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteLicenciaProrroga.Text != "" )
                {
                    _Licencia.Insertar(prorroga.Numero, 14, "Licencia prórroga", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteLicenciaProrroga.SelectedDate), TXT_ObservacionesDeArmadoPaqueteLicenciaProrroga.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(prorroga.Numero, TXT_NoFolioProrroga.Text, TXT_NoLicenciaProrroga.Text, Convert.ToDateTime(DTP_VigenciaProrroga.SelectedDate), 14);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(prorroga.Numero, 15);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosLicenciaProrroga.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosLicenciaProrroga.Text != "" )
                {
                    _Licencia.Actualizar(prorroga.Numero, 15, "Licencia prórroga", Convert.ToDateTime(DTP_FechaDePagoDerechosLicenciaProrroga.SelectedDate), TXT_ObservacinesPagoDerechosLicenciaProrroga.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(prorroga.Numero, TXT_NoFolioProrroga.Text, TXT_NoLicenciaProrroga.Text, Convert.ToDateTime(DTP_VigenciaProrroga.SelectedDate), 15);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosLicenciaProrroga.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosLicenciaProrroga.Text != "" )
                {
                    _Licencia.Insertar(prorroga.Numero, 15, "Licencia prórroga", Convert.ToDateTime(DTP_FechaDePagoDerechosLicenciaProrroga.SelectedDate), TXT_ObservacinesPagoDerechosLicenciaProrroga.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(prorroga.Numero, TXT_NoFolioProrroga.Text, TXT_NoLicenciaProrroga.Text, Convert.ToDateTime(DTP_VigenciaProrroga.SelectedDate), 15);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(prorroga.Numero, 16);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionLicenciaProrroga.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionLicenciaProrroga.Text != "" )
                {
                    _Licencia.Actualizar(prorroga.Numero, 16, "Licencia prórroga", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionLicenciaProrroga.SelectedDate), TXT_ObservacionesRecogerDocumentacionLicenciaProrroga.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(prorroga.Numero, TXT_NoFolioProrroga.Text, TXT_NoLicenciaProrroga.Text, Convert.ToDateTime(DTP_VigenciaProrroga.SelectedDate), 16);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionLicenciaProrroga.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionLicenciaProrroga.Text != "" )
                {
                    _Licencia.Insertar(prorroga.Numero, 16, "Licencia prórroga", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionLicenciaProrroga.SelectedDate), TXT_ObservacionesRecogerDocumentacionLicenciaProrroga.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(prorroga.Numero, TXT_NoFolioProrroga.Text, TXT_NoLicenciaProrroga.Text, Convert.ToDateTime(DTP_VigenciaProrroga.SelectedDate), 16);
                    cambio = true;
                }
                if (TXT_NoFolioProrroga.Text != ""||TXT_NoLicenciaProrroga.Text!=""||DTP_VigenciaProrroga.SelectedDate.ToString()!="")
                {
                    ProyectoLicencia = new Proyecto_Licencia(prorroga.Numero);
                    ProyectoLicencia.ActualizarIdEstadoLic(prorroga.Numero, TXT_NoFolioProrroga.Text, TXT_NoLicenciaProrroga.Text, Convert.ToDateTime(DTP_VigenciaProrroga.SelectedDate), ProyectoLicencia.Id_Estado_Licencia);
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

        private void Btn_AgregarProrroga_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idtipopro =0;
                ProyectoLicencia = new Proyecto_Licencia (IDlicen);
                CapaLogica.Presupuesto pres = new CapaLogica.Presupuesto(ProyectoLicencia.Numero_Presupuesto);
                if(pres.Id_Tipo_Proyecto==1|| pres.Id_Tipo_Proyecto == 6|| pres.Id_Tipo_Proyecto == 11|| pres.Id_Tipo_Proyecto == 16 || pres.Id_Tipo_Proyecto == 21)
                {
                    idtipopro = 26;
                }
                else if (pres.Id_Tipo_Proyecto == 2 || pres.Id_Tipo_Proyecto == 7 | pres.Id_Tipo_Proyecto == 12 || pres.Id_Tipo_Proyecto == 17 || pres.Id_Tipo_Proyecto == 22)
                {
                    idtipopro = 27;
                }
                else if (pres.Id_Tipo_Proyecto == 3 || pres.Id_Tipo_Proyecto == 8 || pres.Id_Tipo_Proyecto == 13 || pres.Id_Tipo_Proyecto == 18 || pres.Id_Tipo_Proyecto == 23)
                {
                    idtipopro = 28;
                }
                else if (pres.Id_Tipo_Proyecto == 4 || pres.Id_Tipo_Proyecto == 9 || pres.Id_Tipo_Proyecto == 14 || pres.Id_Tipo_Proyecto == 19 || pres.Id_Tipo_Proyecto == 24)
                {
                    idtipopro = 29;
                }
                else if (pres.Id_Tipo_Proyecto == 5 || pres.Id_Tipo_Proyecto == 10 || pres.Id_Tipo_Proyecto == 15 || pres.Id_Tipo_Proyecto == 20 | pres.Id_Tipo_Proyecto == 25)
                {
                    idtipopro = 30;
                }
                int m= pre.Insertar(pres.Etiqueta,pres.Nombre_Solicitante,pres.Nombre_Propietario,pres.Genero,pres.Mts,pres.Total,pres.Aprobado, idtipopro, pres.Clave_Empleado);
                int n= ProyectoLicenciaProrroga.Insertar(ProyectoLicencia.Escrituras, ProyectoLicencia.Constancia_Alineamiento, ProyectoLicencia.Pago_Predial, ProyectoLicencia.Recibo_Agua, ProyectoLicencia.Planos_Arquitectonicos, ProyectoLicencia.Planos_Estructurales, ProyectoLicencia.Planos_Instalaciones, ProyectoLicencia.Memoria_Calculo,1,m, ProyectoLicencia.Id_Cliente, ProyectoLicencia.Clave_Inmueble, ProyectoLicencia.Clave_Empleado);
                    if(n!=0)
                {
                    if(ProyectoLicencia.ActualizarNumProOriginal(IDlicen, n)&& ProyectoLicenciaProrroga.ActualizarNumProOriginal(n, IDlicen))
                    {
                        LICENCIAPRORROGATAB.IsEnabled = true;
                        PantallaCheck check = new PantallaCheck();
                        check.Show();
                    }
                }
                    else if (n==0)
                {
                    pre.Depurar(m);
                }
            }
            catch(Exception)
            {

            }
        }
    }
}

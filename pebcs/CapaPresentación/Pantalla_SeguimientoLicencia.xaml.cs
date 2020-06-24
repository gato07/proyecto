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

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_SeguimientoLicencia.xaml
    /// </summary>
    public partial class Pantalla_SeguimientoLicencia : UserControl
    {
        int IDlicen;
        Proyecto_Licencia ProyectoLicencia = new Proyecto_Licencia();
        Menu_Principal2 Mn;
        public Pantalla_SeguimientoLicencia(int IDlicencia,Object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
            IDlicen = IDlicencia;
            CargarIfoProcesos(IDlicen);
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
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen,TXT_NoFolio.Text,TXT_NoLicencia.Text,Convert.ToDateTime(DTP_Vigencia.SelectedDate), 2);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 2, "Alineamiento", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteAlineamiento.SelectedDate), TXT_ObservacionesDeArmadoPaqueteAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 2);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 3);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosAlineamiento.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 3, "Alineamiento", Convert.ToDateTime(DTP_FechaDePagoDerechosAlineamiento.SelectedDate), TXT_ObservacinesPagoDerechosAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 3);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosAlineamiento.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 3, "Alineamiento", Convert.ToDateTime(DTP_FechaDePagoDerechosAlineamiento.SelectedDate), TXT_ObservacinesPagoDerechosAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 3);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 4);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionAlineamiento.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 4, "Alineamiento", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate), TXT_ObservacionesRecogerDocumentacionAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 4);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionAlineamiento.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 4, "Alineamiento", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionAlineamiento.SelectedDate), TXT_ObservacionesRecogerDocumentacionAlineamiento.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 4);
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
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 5);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 5, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeArmadoPaquetUsoDeSuelo.SelectedDate), TXT_ObservacionesDeArmadoPaquetUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 5);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 6);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosUsoDeSuelo.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 6, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate), TXT_ObservacinesPagoDerechosUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 6);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosUsoDeSuelo.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 6, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDePagoDerechosUsoDeSuelo.SelectedDate), TXT_ObservacinesPagoDerechosUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 6);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 7);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 7, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate), TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 7);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 7, "Uso De Suelo", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionUsoDeSuelo.SelectedDate), TXT_ObservacionesRecogerDocumentacionUsoDeSuelo.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 7);
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
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 8);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 8, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteSupervisiónTecnica.SelectedDate), TXT_ObservacionesDeArmadoPaqueteSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 8);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 9);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 9, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate), TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 9);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 9, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDePagoDerechosSupervisiónTecnica.SelectedDate), TXT_ObservacinesPagoDerechosSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 9);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 10);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 10, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate), TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 10);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 10, "Supervisión técnica", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionSupervisiónTecnica.SelectedDate), TXT_ObservacionesRecogerDocumentacionSupervisiónTecnica.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 10);
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
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 14);
                    cambio = true;
                }
                else if (DTP_FechaDeArmadoPaqueteTO.SelectedDate.ToString() != "" && TXT_ObservacionesDeArmadoPaqueteTO.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 14, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeArmadoPaqueteTO.SelectedDate), TXT_ObservacionesDeArmadoPaqueteTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 14);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 15);
                if (_Licencia.Existe == true && DTP_FechaDePagoDerechosTO.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosTO.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 15, "Terminación de obra", Convert.ToDateTime(DTP_FechaDePagoDerechosTO.SelectedDate), TXT_ObservacinesPagoDerechosTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 15);
                    cambio = true;
                }
                else if (DTP_FechaDePagoDerechosTO.SelectedDate.ToString() != "" && TXT_ObservacinesPagoDerechosTO.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 15, "Terminación de obra", Convert.ToDateTime(DTP_FechaDePagoDerechosTO.SelectedDate), TXT_ObservacinesPagoDerechosTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 15);
                    cambio = true;
                }
                _Licencia = new Documentacion_Licencia(IDlicen, 16);
                if (_Licencia.Existe == true && DTP_FechaDeRecogerDocumentacionTO.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionTO.Text != "")
                {
                    _Licencia.Actualizar(IDlicen, 16, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionTO.SelectedDate), TXT_ObservacionesRecogerDocumentacionTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 16);
                    cambio = true;
                }
                else if (DTP_FechaDeRecogerDocumentacionTO.SelectedDate.ToString() != "" && TXT_ObservacionesRecogerDocumentacionTO.Text != "")
                {
                    _Licencia.Insertar(IDlicen, 16, "Terminación de obra", Convert.ToDateTime(DTP_FechaDeRecogerDocumentacionTO.SelectedDate), TXT_ObservacionesRecogerDocumentacionTO.Text.ToString());
                    ProyectoLicencia.ActualizarIdEstadoLic(IDlicen, TXT_NoFolio.Text, TXT_NoLicencia.Text, Convert.ToDateTime(DTP_Vigencia.SelectedDate), 16);
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

            }catch(Exception ex)
            {

            }
        }
    }
}

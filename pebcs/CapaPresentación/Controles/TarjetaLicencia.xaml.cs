using CapaLogica;
using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CapaPresentación.Controles
{
    /// <summary>
    /// Lógica de interacción para TarjetaLicencia.xaml
    /// </summary>
    public partial class TarjetaLicencia : UserControl
    {
        int ID;
        Menu_Principal2 Mn;
        int n, n2, n3, n4, n5,n6 = 0;
        int IdUSUATIO;
        public TarjetaLicencia(Object A,int iDe)
        {
            try
            {
                InitializeComponent();
                IdUSUATIO = iDe;
                Mn = A as Menu_Principal2;

            }
            catch (Exception ex)
            {

            }
        }

        private void CardFront_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new Pantalla_InfoLicencia(ID,Mn,0, IdUSUATIO));
            }catch(Exception ex)
            {

            }
        }
        private void CardBack_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new Pantalla_SeguimientoLicencia(ID,Mn, IdUSUATIO));
            }
            catch(Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CargarIfoProcesos(ID);
            }
            catch (Exception ex)
            {

            }
        }

        public void CargaDatosLicencia(int ID2,string etiqueta,string NoLicencia,string folio,string tipoobra,string uso ,string presupuesto)
        {
            try
            {
                ID = ID2;
                Proyecto_Licencia proyecto = new Proyecto_Licencia(ID);
                Cliente cliente = new Cliente(proyecto.Id_Cliente);
                Inmueble inmueble = new Inmueble(proyecto.Clave_Inmueble);
                TXT_Cliente.Text = cliente.Nombre;
                TXT_ClaveCatastral.Text = inmueble.Clave_Catastral;
                TXT_Colonia.Text = inmueble.Colonia;
                tituloBack.Content= titulo.Content = etiqueta;
                TXT_Folio.Text = folio;
                TXT_NoLicencia.Text = NoLicencia;
                TXT_TipoObra.Text = tipoobra;
                TXT_Uso.Text = uso;
                TXT_presupuesto.Text = presupuesto;
                IndicadorProceso();
            }
            catch (Exception ex)
            {

            }
        }
        public void IndicadorProceso()
        {
            try
            {
                Documentacion_Licencia todaDocumentacion = new Documentacion_Licencia();
                Documentacion_Licencia[] Doc = todaDocumentacion.TableToArray(todaDocumentacion.SelXNumeroProLic(ID));
                if(Doc.Length!=0)
                {
                    for (int X = 0; X < Doc.Length; X++)
                    {
                        switch (Doc[X].Id_Estado_Licencia)
                        {
                            case 2:
                            case 3:
                            case 4:
                                n += 1;
                                break;
                            case 5:
                            case 6:
                            case 7:
                                n2 += 1;
                                break;
                            case 8:
                            case 9:
                            case 10:
                                n3 += 1;
                                break;
                            case 11:
                            case 12:
                            case 13:
                                n4 += 1;
                                break;
                            case 14:
                            case 15:
                            case 16:
                                n5 += 1;
                                break;
                            case 17:
                            case 18:
                            case 19:
                                n6 += 1;
                                break;
                        }
                    }
                }
                //Documentacion_Licencia documentacion11 = new Documentacion_Licencia(ID, 2);
                //if (documentacion11.Existe == true)
                //{
                //    n += 1;
                //}
                //Documentacion_Licencia documentacion12 = new Documentacion_Licencia(ID, 3);
                //if (documentacion12.Existe == true)
                //{
                //    n += 1;
                //}
                //Documentacion_Licencia documentacion13 = new Documentacion_Licencia(ID, 4);
                //if (documentacion13.Existe == true)
                //{
                //    n += 1;
                //}
                IndicadorAlineamiento.Height = 10 * n;
                IndicadorAlineamientoBack.Height = 10 * n;
                //Documentacion_Licencia documentacion21 = new Documentacion_Licencia(ID, 5);
                //if (documentacion21.Existe == true)
                //{
                //    n2 += 1;
                //}
                //Documentacion_Licencia documentacion22 = new Documentacion_Licencia(ID, 6);
                //if (documentacion22.Existe == true)
                //{
                //    n2 += 1;
                //}
                //Documentacion_Licencia documentacion23 = new Documentacion_Licencia(ID, 7);
                //if (documentacion23.Existe == true)
                //{
                //    n2 += 1;
                //}
                IndicadorUsoDeSuelo.Height = n2 * 10;
                IndicadorUsoDeSueloBack.Height = n2 * 10;
                //Documentacion_Licencia documentacion31 = new Documentacion_Licencia(ID, 8);
                //if (documentacion31.Existe == true)
                //{
                //    n3 += 1;
                //}
                //Documentacion_Licencia documentacion32 = new Documentacion_Licencia(ID, 9);
                //if (documentacion32.Existe == true)
                //{
                //    n3 += 1;
                //}
                //Documentacion_Licencia documentacion33 = new Documentacion_Licencia(ID, 10);
                //if (documentacion33.Existe == true)
                //{
                //    n3 += 1;
                //}
                IndicadorSupervisionTecnica.Height = n3 * 10;
                IndicadorSupervisionTecnicaBack.Height = n3 * 10;
                //Documentacion_Licencia documentacion41 = new Documentacion_Licencia(ID, 11);
                //if (documentacion41.Existe == true)
                //{
                //    n4 += 1;
                //}
                //Documentacion_Licencia documentacion42 = new Documentacion_Licencia(ID, 12);
                //if (documentacion42.Existe == true)
                //{
                //    n4 += 1;
                //}
                //Documentacion_Licencia documentacion43 = new Documentacion_Licencia(ID, 13);
                //if (documentacion43.Existe == true)
                //{
                //    n4 += 1;
                //}
                IndicadorLicencia.Height = n4 * 10;
                IndicadorLicenciaBack.Height = n4 * 10;
                //Proyecto_Licencia licencia = new Proyecto_Licencia(ID);
                //Documentacion_Licencia documentacion51 = new Documentacion_Licencia((int)(licencia.Numero_Proyecto_Original ?? 0), 14);
                //if (documentacion51.Existe == true)
                //{
                //    n5 += 1;
                //}
                //Documentacion_Licencia documentacion52 = new Documentacion_Licencia((int)(licencia.Numero_Proyecto_Original ?? 0), 15);
                //if (documentacion52.Existe == true)
                //{
                //    n5 += 1;
                //}
                //Documentacion_Licencia documentacion53 = new Documentacion_Licencia((int)(licencia.Numero_Proyecto_Original ?? 0), 16);
                //if (documentacion53.Existe == true)
                //{
                //    n5 += 1;
                //}
                IndicadorLicenciaProrroga.Height = n5 * 10;
                IndicadorLicenciaProrrogaBack.Height = n5 * 10;
                //Documentacion_Licencia documentacion61 = new Documentacion_Licencia(ID, 17);
                //if (documentacion61.Existe == true)
                //{
                //    n6 += 1;
                //}
                //Documentacion_Licencia documentacion62 = new Documentacion_Licencia(ID, 18);
                //if (documentacion62.Existe == true)
                //{
                //    n6 += 1;
                //}
                //Documentacion_Licencia documentacion63 = new Documentacion_Licencia(ID, 19);
                //if (documentacion63.Existe == true)
                //{
                //    n6 += 1;
                //}
                IndicadorTerminacionObra.Height = n6 * 10;
                IndicadorTerminacionObraBack.Height = n6 * 10;
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
                Proyecto_Licencia ProyectoLicencia = new Proyecto_Licencia(IDeLicencia);
                Documentacion_Licencia[] infoProrroga = documentacion_Licencia.TableToArray(documentacion_Licencia.SelXNumeroProLic((int)(ProyectoLicencia.Numero_Proyecto_Original ?? 0)));
                Documentacion_Licencia[] info = documentacion_Licencia.TableToArray(documentacion_Licencia.SelXNumeroProLic(IDeLicencia));
                for (int x = 0; x < infoProrroga.Length; x++)
                {
                    Estado_Licencia estado = new Estado_Licencia(infoProrroga[x].Id_Estado_Licencia);
                    if (estado.Proceso == 5)//Licencia Prorroga
                    {
                        if (estado.Subproceso == 1)
                        {
                            ArmadoPaquete5.Content = infoProrroga[x].Fecha;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            PagoDeDerechos5.Content = infoProrroga[x].Fecha;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            RecogerDocumentacion5.Content = infoProrroga[x].Fecha;
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
                            ArmadoPaquete1.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            PagoDeDerechos1.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            RecogerDocumentacion1.Content = info[x].Fecha;
                        }
                    }
                    else if (estado.Proceso == 2)//USODESUELO
                    {
                        if (estado.Subproceso == 1)
                        {
                            ArmadoPaquete2.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            PagoDeDerechos2.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            RecogerDocumentacion2.Content = info[x].Fecha;
                        }
                    }
                    else if (estado.Proceso == 3)//SUPERVISIONTECNICA
                    {
                        if (estado.Subproceso == 1)
                        {
                            ArmadoPaquete3.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            PagoDeDerechos3.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            RecogerDocumentacion3.Content = info[x].Fecha;
                        }
                    }
                    else if (estado.Proceso == 4)//LICENCIA
                    {
                        if (estado.Subproceso == 1)
                        {
                            ArmadoPaquete4.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            PagoDeDerechos4.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            RecogerDocumentacion4.Content = info[x].Fecha;
                        }
                    }
                    else if (estado.Proceso == 6)//TERMINACIÓNDEOBRA
                    {
                        if (estado.Subproceso == 1)
                        {
                            ArmadoPaquete6.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 2)
                        {
                            PagoDeDerechos6.Content = info[x].Fecha;
                        }
                        else if (estado.Subproceso == 3)
                        {
                            RecogerDocumentacion6 .Content = info[x].Fecha;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                CardLicencia.Margin = new Thickness(0, 0, 0, 0);
            }
            catch (Exception ex)
            {

            }
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                CardLicencia.Margin = new Thickness(10, 10, 10, 10);
            }
            catch (Exception ex)
            {

            }
        }
    }
}

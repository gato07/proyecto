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
    /// Lógica de interacción para TarjetaLicenciaInactiva.xaml
    /// </summary>
    public partial class TarjetaLicenciaInactiva : UserControl
    {
        int ID;
        Menu_Principal2 Mn;
        int n, n2, n3, n4, n5, n6 = 0;
        int IdUSUATIO;


        public TarjetaLicenciaInactiva(object A,int iDe)
        {
            IdUSUATIO = iDe;
            InitializeComponent();
            Mn = A as Menu_Principal2;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Proyecto_Licencia licencia = new Proyecto_Licencia();
                licencia.Activar(ID);
                Mn.AbrirFormHijo(new PantallaLicencias(Mn,IdUSUATIO)); ;
            }
            catch (Exception ex)
            {

            }
        }
        public void CargaDatosLicencia(int ID2, string etiqueta, string NoLicencia, string folio, string tipoobra, string uso, string presupuesto)
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
                if (Doc.Length != 0)
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
            }
            catch (Exception ex)
            {

            }
        }
    }
}

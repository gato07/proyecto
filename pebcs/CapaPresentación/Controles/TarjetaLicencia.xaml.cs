using CapaLogica;
using ControlzEx.Standard;
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

namespace CapaPresentación.Controles
{
    /// <summary>
    /// Lógica de interacción para TarjetaLicencia.xaml
    /// </summary>
    public partial class TarjetaLicencia : UserControl
    {
        int ID;
        Menu_Principal2 Mn;
        int n, n2, n3, n4, n5 = 0;
        public TarjetaLicencia(Object A)
        {
            try
            {
                InitializeComponent();
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
                Mn.AbrirFormHijo(new Pantalla_InfoLicencia(ID,Mn,0));
            }catch(Exception ex)
            {

            }
        }
        private void CardBack_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new Pantalla_SeguimientoLicencia(ID,Mn));
            }
            catch(Exception ex)
            {

            }
        }
        public void CargaDatosLicencia(int ID2,string etiqueta,string NoLicencia,string folio,string tipoobra,string uso ,string presupuesto,string Estado, DateTime date)
        {
            try
            {
                ID = ID2;
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
                Documentacion_Licencia documentacion11 = new Documentacion_Licencia(ID, 2);
                if (documentacion11.Existe == true)
                {
                    n += 1;
                }
                Documentacion_Licencia documentacion12 = new Documentacion_Licencia(ID, 3);
                if (documentacion12.Existe == true)
                {
                    n += 1;
                }
                Documentacion_Licencia documentacion13 = new Documentacion_Licencia(ID, 4);
                if (documentacion13.Existe == true)
                {
                    n += 1;
                }
                IndicadorAlineamiento.Height = 12 * n;
                IndicadorAlineamientoBack.Height = 12 * n;
                Documentacion_Licencia documentacion21 = new Documentacion_Licencia(ID, 5);
                if (documentacion21.Existe == true)
                {
                    n2 += 1;
                }
                Documentacion_Licencia documentacion22 = new Documentacion_Licencia(ID, 6);
                if (documentacion22.Existe == true)
                {
                    n2 += 1;
                }
                Documentacion_Licencia documentacion23 = new Documentacion_Licencia(ID, 7);
                if (documentacion23.Existe == true)
                {
                    n2 += 1;
                }
                IndicadorUsoDeSuelo.Height = n2 * 12;
                IndicadorUsoDeSueloBack.Height = n2 * 12;
                Documentacion_Licencia documentacion31 = new Documentacion_Licencia(ID, 8);
                if (documentacion31.Existe == true)
                {
                    n3 += 1;
                }
                Documentacion_Licencia documentacion32 = new Documentacion_Licencia(ID, 9);
                if (documentacion32.Existe == true)
                {
                    n3 += 1;
                }
                Documentacion_Licencia documentacion33 = new Documentacion_Licencia(ID, 10);
                if (documentacion33.Existe == true)
                {
                    n3 += 1;
                }
                IndicadorSupervisionTecnica.Height = n3 * 12;
                IndicadorSupervisionTecnicaBack.Height = n3 * 12;
                Documentacion_Licencia documentacion41 = new Documentacion_Licencia(ID, 11);
                if (documentacion41.Existe == true)
                {
                    n4 += 1;
                }
                Documentacion_Licencia documentacion42 = new Documentacion_Licencia(ID, 12);
                if (documentacion42.Existe == true)
                {
                    n4 += 1;
                }
                Documentacion_Licencia documentacion43 = new Documentacion_Licencia(ID, 13);
                if (documentacion43.Existe == true)
                {
                    n4 += 1;
                }
                IndicadorLicencia.Height = n4 * 12;
                IndicadorLicenciaBack.Height = n4 * 12;
                Documentacion_Licencia documentacion51 = new Documentacion_Licencia(ID, 14);
                if (documentacion51.Existe == true)
                {
                    n5 += 1;
                }
                Documentacion_Licencia documentacion52 = new Documentacion_Licencia(ID, 15);
                if (documentacion52.Existe == true)
                {
                    n5 += 1;
                }
                Documentacion_Licencia documentacion53 = new Documentacion_Licencia(ID, 16);
                if (documentacion53.Existe == true)
                {
                    n5 += 1;
                }
                IndicadorTerminacionObra.Height = n5 * 12;
                IndicadorTerminacionObraBack.Height = n5 * 12;
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

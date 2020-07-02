﻿using CapaLogica;
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
using System.IO;
using System.Data;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaLicencias.xaml
    /// </summary>
    public partial class PantallaLicencias : UserControl
    {
        Menu_Principal2 Mn;
        public PantallaLicencias(object A) 
        {
            try
            {
                InitializeComponent();
                Mn = A as Menu_Principal2;
                GenerarLicencias();
            }
            catch (Exception ex)
            {

            }
        }
        private void GenerarLicencias()
        {
            try
            {
                Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
                DataTable Licenciasactivas = proyecto_.SelNoTerminados();
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                TarjetaLicencia[] tarjetaLicencias = new TarjetaLicencia[Licenciasactivas.Rows.Count];
                for (int x = 0; x < tarjetaLicencias.Length; x++)
                {
                    Documentacion_Licencia docLi = new Documentacion_Licencia();
                    tarjetaLicencias[x] = new TarjetaLicencia(Mn);
                    tarjetaLicencias[x].CargaDatosLicencia(Convert.ToInt32(Licenciasactivas.Rows[x]["Numero"]), Licenciasactivas.Rows[x]["Etiqueta"].ToString(), Licenciasactivas.Rows[x]["Numero_Licencia"].ToString(), Licenciasactivas.Rows[x]["Folio"].ToString(), Licenciasactivas.Rows[x]["Tipo_Obra"].ToString(), Licenciasactivas.Rows[x]["Uso"].ToString(), Licenciasactivas.Rows[x]["Total"].ToString(), Licenciasactivas.Rows[x]["Estado"].ToString(), Convert.ToDateTime(Licenciasactivas.Rows[x]["Fecha"]));
                    n.Items.Add(tarjetaLicencias[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GenerarLicenciasLikeEtiqueta(TextBox Busqueda)
        {
            try
            {
                Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
                DataTable Licenciasactivas = proyecto_.SelNoTerLikeEtiqueta(Busqueda.Text);
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                TarjetaLicencia[] tarjetaLicencias = new TarjetaLicencia[Licenciasactivas.Rows.Count];
                for (int x = 0; x < tarjetaLicencias.Length; x++)
                {
                    Documentacion_Licencia docLi = new Documentacion_Licencia();
                    tarjetaLicencias[x] = new TarjetaLicencia(Mn);
                    tarjetaLicencias[x].CargaDatosLicencia(Convert.ToInt32(Licenciasactivas.Rows[x]["Numero"]), Licenciasactivas.Rows[x]["Etiqueta"].ToString(), Licenciasactivas.Rows[x]["Numero_Licencia"].ToString(), Licenciasactivas.Rows[x]["Folio"].ToString(), Licenciasactivas.Rows[x]["Tipo_Obra"].ToString(), Licenciasactivas.Rows[x]["Uso"].ToString(), Licenciasactivas.Rows[x]["Total"].ToString(), Licenciasactivas.Rows[x]["Estado"].ToString(), Convert.ToDateTime(Licenciasactivas.Rows[x]["Fecha"]));
                    n.Items.Add(tarjetaLicencias[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GenerarLicenciasLikeClaveCatastral(TextBox Busqueda)
        {
            try
            {
                Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
                DataTable Licenciasactivas = proyecto_.SelNoTerLikeCatastral(Busqueda.Text);
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                TarjetaLicencia[] tarjetaLicencias = new TarjetaLicencia[Licenciasactivas.Rows.Count];
                for (int x = 0; x < tarjetaLicencias.Length; x++)
                {
                    Documentacion_Licencia docLi = new Documentacion_Licencia();
                    tarjetaLicencias[x] = new TarjetaLicencia(Mn);
                    tarjetaLicencias[x].CargaDatosLicencia(Convert.ToInt32(Licenciasactivas.Rows[x]["Numero"]), Licenciasactivas.Rows[x]["Etiqueta"].ToString(), Licenciasactivas.Rows[x]["Numero_Licencia"].ToString(), Licenciasactivas.Rows[x]["Folio"].ToString(), Licenciasactivas.Rows[x]["Tipo_Obra"].ToString(), Licenciasactivas.Rows[x]["Uso"].ToString(), Licenciasactivas.Rows[x]["Total"].ToString(), Licenciasactivas.Rows[x]["Estado"].ToString(), Convert.ToDateTime(Licenciasactivas.Rows[x]["Fecha"]));
                    n.Items.Add(tarjetaLicencias[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GenerarLicenciasLikePropietario(TextBox Busqueda)
        {
            try
            {
                Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
                DataTable Licenciasactivas = proyecto_.SelNoTerLikePropietario(Busqueda.Text);
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                TarjetaLicencia[] tarjetaLicencias = new TarjetaLicencia[Licenciasactivas.Rows.Count];
                for (int x = 0; x < tarjetaLicencias.Length; x++)
                {
                    Documentacion_Licencia docLi = new Documentacion_Licencia();
                    tarjetaLicencias[x] = new TarjetaLicencia(Mn);
                    tarjetaLicencias[x].CargaDatosLicencia(Convert.ToInt32(Licenciasactivas.Rows[x]["Numero"]), Licenciasactivas.Rows[x]["Etiqueta"].ToString(), Licenciasactivas.Rows[x]["Numero_Licencia"].ToString(), Licenciasactivas.Rows[x]["Folio"].ToString(), Licenciasactivas.Rows[x]["Tipo_Obra"].ToString(), Licenciasactivas.Rows[x]["Uso"].ToString(), Licenciasactivas.Rows[x]["Total"].ToString(), Licenciasactivas.Rows[x]["Estado"].ToString(), Convert.ToDateTime(Licenciasactivas.Rows[x]["Fecha"]));
                    n.Items.Add(tarjetaLicencias[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GenerarcanLicencias()
        {
            try
            {
                Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
                DataTable Licenciasactivas = proyecto_.SelTerminados();
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                TarjetaLicencia[] tarjetaLicencias = new TarjetaLicencia[Licenciasactivas.Rows.Count];
                for (int x = 0; x < tarjetaLicencias.Length; x++)
                {
                    Documentacion_Licencia docLi = new Documentacion_Licencia();
                    tarjetaLicencias[x] = new TarjetaLicencia(Mn);
                    tarjetaLicencias[x].CargaDatosLicencia(Convert.ToInt32(Licenciasactivas.Rows[x]["Numero"]), Licenciasactivas.Rows[x]["Etiqueta"].ToString(), Licenciasactivas.Rows[x]["Numero_Licencia"].ToString(), Licenciasactivas.Rows[x]["Folio"].ToString(), Licenciasactivas.Rows[x]["Tipo_Obra"].ToString(), Licenciasactivas.Rows[x]["Uso"].ToString(), Licenciasactivas.Rows[x]["Total"].ToString(), Licenciasactivas.Rows[x]["Estado"].ToString(), Convert.ToDateTime(Licenciasactivas.Rows[x]["Fecha"]));
                    n.Items.Add(tarjetaLicencias[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GenerarcanLicenciasLikeEtiqueta(TextBox Busqueda)
        {
            try
            {
                Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
                DataTable Licenciasactivas = proyecto_.SelTerLikeEtiqueta(Busqueda.Text);
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                TarjetaLicencia[] tarjetaLicencias = new TarjetaLicencia[Licenciasactivas.Rows.Count];
                for (int x = 0; x < tarjetaLicencias.Length; x++)
                {
                    Documentacion_Licencia docLi = new Documentacion_Licencia();
                    tarjetaLicencias[x] = new TarjetaLicencia(Mn);
                    tarjetaLicencias[x].CargaDatosLicencia(Convert.ToInt32(Licenciasactivas.Rows[x]["Numero"]), Licenciasactivas.Rows[x]["Etiqueta"].ToString(), Licenciasactivas.Rows[x]["Numero_Licencia"].ToString(), Licenciasactivas.Rows[x]["Folio"].ToString(), Licenciasactivas.Rows[x]["Tipo_Obra"].ToString(), Licenciasactivas.Rows[x]["Uso"].ToString(), Licenciasactivas.Rows[x]["Total"].ToString(), Licenciasactivas.Rows[x]["Estado"].ToString(), Convert.ToDateTime(Licenciasactivas.Rows[x]["Fecha"]));
                    n.Items.Add(tarjetaLicencias[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GenerarcanLicenciasLikeClaveCatastral(TextBox Busqueda)
        {
            try
            {
                Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
                DataTable Licenciasactivas = proyecto_.SelTerLikeCatastral(Busqueda.Text);
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                TarjetaLicencia[] tarjetaLicencias = new TarjetaLicencia[Licenciasactivas.Rows.Count];
                for (int x = 0; x < tarjetaLicencias.Length; x++)
                {
                    Documentacion_Licencia docLi = new Documentacion_Licencia();
                    tarjetaLicencias[x] = new TarjetaLicencia(Mn);
                    tarjetaLicencias[x].CargaDatosLicencia(Convert.ToInt32(Licenciasactivas.Rows[x]["Numero"]), Licenciasactivas.Rows[x]["Etiqueta"].ToString(), Licenciasactivas.Rows[x]["Numero_Licencia"].ToString(), Licenciasactivas.Rows[x]["Folio"].ToString(), Licenciasactivas.Rows[x]["Tipo_Obra"].ToString(), Licenciasactivas.Rows[x]["Uso"].ToString(), Licenciasactivas.Rows[x]["Total"].ToString(), Licenciasactivas.Rows[x]["Estado"].ToString(), Convert.ToDateTime(Licenciasactivas.Rows[x]["Fecha"]));
                    n.Items.Add(tarjetaLicencias[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GenerarcanLicenciasLikePropietario(TextBox Busqueda)
        {
            try
            {
                Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
                DataTable Licenciasactivas = proyecto_.SelTerLikePropietario(Busqueda.Text);
                Documentacion_Licencia documentacion_Licencia = new Documentacion_Licencia();
                TarjetaLicencia[] tarjetaLicencias = new TarjetaLicencia[Licenciasactivas.Rows.Count];
                for (int x = 0; x < tarjetaLicencias.Length; x++)
                {
                    Documentacion_Licencia docLi = new Documentacion_Licencia();
                    tarjetaLicencias[x] = new TarjetaLicencia(Mn);
                    tarjetaLicencias[x].CargaDatosLicencia(Convert.ToInt32(Licenciasactivas.Rows[x]["Numero"]), Licenciasactivas.Rows[x]["Etiqueta"].ToString(), Licenciasactivas.Rows[x]["Numero_Licencia"].ToString(), Licenciasactivas.Rows[x]["Folio"].ToString(), Licenciasactivas.Rows[x]["Tipo_Obra"].ToString(), Licenciasactivas.Rows[x]["Uso"].ToString(), Licenciasactivas.Rows[x]["Total"].ToString(), Licenciasactivas.Rows[x]["Estado"].ToString(), Convert.ToDateTime(Licenciasactivas.Rows[x]["Fecha"]));
                    n.Items.Add(tarjetaLicencias[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_AgregarPantalla_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new Pantalla_InfoLicencia(0,Mn,0));
            }catch(Exception ex)
            {

            }
        }

        private void Activador_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Activador.IsChecked == true)
                {
                    Opciones.IsEnabled = true;
                    OpcionesCanceladas.IsEnabled = true;
                    Btn_Limpiar.IsEnabled = true;
                    TxtBusqueda.IsEnabled = true;
                    OpcionesCanceladas.SelectedIndex = -1;
                    Opciones.SelectedIndex = -1;
                    TxtBusqueda.Clear();
                }
                else
                {
                    Opciones.IsEnabled = false;
                    OpcionesCanceladas.IsEnabled = false;
                    Btn_Limpiar.IsEnabled = false;
                    TxtBusqueda.IsEnabled = false;
                    OpcionesCanceladas.SelectedIndex = -1;
                    Opciones.SelectedIndex = -1;
                    TxtBusqueda.Clear();
                    impiar();
                    GenerarLicencias();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void impiar()
        {
            try
            {
                n.Items.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void TxtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if(OpcionesCanceladas.SelectedIndex==0||OpcionesCanceladas.SelectedIndex==-1)
                {
                    if (Opciones.SelectedIndex == -1)
                    {
                        impiar();
                        GenerarLicencias();
                    }
                    else if (Opciones.SelectedIndex == 0)
                    {
                        impiar();
                        TxtBusqueda.MaxLength = 60;
                        GenerarLicenciasLikeEtiqueta(TxtBusqueda);
                    }
                    else if (Opciones.SelectedIndex == 1)
                    {
                        impiar();
                        TxtBusqueda.MaxLength = 255;
                        GenerarLicenciasLikeClaveCatastral(TxtBusqueda);
                    }
                    else if (Opciones.SelectedIndex == 2)
                    {
                        impiar();
                        TxtBusqueda.MaxLength = 15;
                        GenerarLicenciasLikePropietario(TxtBusqueda);
                    }
                }
                else if (OpcionesCanceladas.SelectedIndex == 1)
                {
                    if (Opciones.SelectedIndex == -1)
                    {
                        impiar();
                        GenerarcanLicencias();
                    }
                    else if (Opciones.SelectedIndex == 0)
                    {
                        impiar();
                        TxtBusqueda.MaxLength = 60;
                        GenerarcanLicenciasLikeEtiqueta(TxtBusqueda);
                    }
                    else if (Opciones.SelectedIndex == 1)
                    {
                        impiar();
                        TxtBusqueda.MaxLength = 255;
                        GenerarcanLicenciasLikeClaveCatastral(TxtBusqueda);
                    }
                    else if (Opciones.SelectedIndex == 2)
                    {
                        impiar();
                        TxtBusqueda.MaxLength = 15;
                        GenerarcanLicenciasLikePropietario(TxtBusqueda);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void OpcionesCanceladas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (OpcionesCanceladas.SelectedIndex==0)
                {
                    impiar();
                    GenerarLicencias();
                }
                else if(OpcionesCanceladas.SelectedIndex==1)
                {
                    impiar();
                    GenerarcanLicencias();
                }
            }catch(Exception ex)
            {

            }
        }
    }
}

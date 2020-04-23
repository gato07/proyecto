﻿using System;
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
using CapaLogica;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_PerfilUsuario.xaml
    /// </summary>
    /// 
    public partial class Pantalla_PerfilUsuario : UserControl
    {
        Menu_Principal2 Mn;
        Empleado emp;
        int ID;
        PantallaCheck check = new PantallaCheck();
        bool empleado;
        public Pantalla_PerfilUsuario(string []A,object B)
        {
            try
            {
                InitializeComponent();
                LlenarDatos(A);
                Mn = B as Menu_Principal2;
            }
            catch(Exception ex)
            {

            }
        }
        public void LlenarDatos(string[] vs)
        {
            try
            {
                if (vs != null)
                {
                    ID = Convert.ToInt16(vs[0]);
                    TXTNombreCompleto.Text = vs[1];
                    TXTDomicilio.Text = vs[2];
                    TXTTelefono.Text = vs[3];
                    TXTEmail.Text = vs[4];
                    TXTPuesto.Text = vs[5];
                    img.ImageSource = new BitmapImage(new Uri(vs[6].ToString()));
                    listPerfil.SelectedIndex = Convert.ToInt16(vs[7]);
                    TXTUsuario.Text = vs[8];
                    TXTConstraseña.Text = vs[9];
                    Btn_Eliminar.IsEnabled = true;
                    empleado = true;
                }
                else
                    empleado = false;
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Guardar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Guardar.Margin = new Thickness(820, 51, 0, 270);
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Guardar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Guardar.Margin = new Thickness(765, 51, 0, 270);
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Limpiar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Limpiar.Margin = new Thickness(820, 96, 0, 224);
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Limpiar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Limpiar.Margin = new Thickness(765, 96, 0, 224);
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Cerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Margin = new Thickness(820, 6, 0, 316);
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Margin = new Thickness(765, 6, 0, 316);
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new PantallaUsuario(Mn));
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                emp = new Empleado();
                emp.Eliminar(ID);
                check.ShowDialog();
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (empleado)
                {

                }
                else if (empleado == false)
                {
                    TXTNombreCompleto.Text = null;
                    TXTDomicilio.Text = null;
                    TXTTelefono.Text = null;
                    TXTEmail.Text = null;
                    TXTPuesto.Text = null;
                    string i = "Imagenes/Microsoft_Account.svg.png";
                    img.ImageSource = new BitmapImage(new Uri(i));
                    listPerfil.SelectedIndex = -1;
                    TXTUsuario.Text = null;
                    TXTConstraseña.Text = null;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool res = false;
                if (empleado)
                {
                    emp = new Empleado();
                    res = emp.Actualizar(ID, TXTNombreCompleto.Text, TXTDomicilio.Text, TXTTelefono.Text, TXTEmail.Text, TXTPuesto.Text, img.ImageSource.ToString(), Convert.ToInt16(listPerfil.SelectedIndex.ToString()), TXTUsuario.Text, TXTConstraseña.Text);
                }
                else if (empleado == false)
                {
                    emp = new Empleado();
                    res = emp.Insertar(TXTNombreCompleto.Text, TXTDomicilio.Text, TXTTelefono.Text, TXTEmail.Text, TXTPuesto.Text, img.ImageSource.ToString(), Convert.ToInt16(listPerfil.SelectedIndex.ToString()), TXTUsuario.Text, TXTConstraseña.Text);
                }
                if (res)
                    check.ShowDialog();
                else
                    MessageBox.Show(emp.Mensaje);
            }
            catch(Exception ex)
            {

            }
        }
        private void Btn_Eliminar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Eliminar.Margin = new Thickness(820, 143, 0, 177);
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Eliminar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Eliminar.Margin = new Thickness(765, 143, 0, 177);
            }
            catch(Exception ex)
            {

            }
        }
    }
}

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
using System.Security.Principal;
using System.Security.Permissions;
using System.Threading;
using System.Security;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_PerfilUsuario.xaml
    /// </summary>
    /// 
    public partial class Pantalla_PerfilUsuario : UserControl
    {
        string NombreUsuario;
        Menu_Principal2 Mn;
        Empleado emp;
        int ID;
        bool empleado;
        int IdUSUATIO;
        public Pantalla_PerfilUsuario(string []A,object B,int iDe)
        {
            try
            {
                InitializeComponent();
                IdUSUATIO = iDe;
                CargarRolesUsuarios(iDe);
                LlenarDatos(A);
                Mn = B as Menu_Principal2;
            }
            catch(Exception ex)
            {

            }
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
            catch (Exception ex)
            {

            }
        }
        public void LlenarDatos(string[] vs)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "E4");
                MyPermission.Demand();
                if (vs != null)
                {
                    ID = Convert.ToInt16(vs[0]);
                    TXTNombreCompleto.Text = vs[1];
                    TXTDomicilio.Text = vs[2];
                    TXTTelefono.Text = vs[3];
                    TXTEmail.Text = vs[4];
                    //TXTPuesto.Text = vs[5];
                    img.ImageSource = new BitmapImage(new Uri(vs[5].ToString()));
                    listPerfil.SelectedIndex = Convert.ToInt16(vs[6]);
                    TXTUsuario.Text = vs[7];
                    TXTConstraseña.Password ="******";
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
                Btn_Guardar.Width = 47;
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Guardar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Guardar.Width = 107;
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Limpiar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Limpiar.Width = 47;
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Limpiar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Limpiar.Width = 107;
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Cerrar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 47;
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Cerrar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Cerrar.Width = 107;
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new PantallaUsuario(Mn, IdUSUATIO));
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "E3");
                MyPermission.Demand();
                emp = new Empleado();
                bool n = false;
                n=emp.Eliminar(ID);
                if (n == true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.ShowDialog();
                }
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
                    TXTNombreCompleto.Clear();
                    TXTDomicilio.Clear();
                    TXTTelefono.Clear();
                    TXTEmail.Clear();
                    string i = "Imagenes/Microsoft_Account.svg.png";
                    img.ImageSource = new BitmapImage(new Uri(i));
                    listPerfil.SelectedIndex = -1;
                    TXTUsuario.Text = null;
                    TXTConstraseña.Password = null;
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
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "E2");
                MyPermission.Demand();
                bool res = false;
                if (empleado)
                {
                    emp = new Empleado();
                    res = emp.Actualizar(ID, TXTNombreCompleto.Text, TXTDomicilio.Text, TXTTelefono.Text, TXTEmail.Text, img.ImageSource.ToString(), Convert.ToInt16(listPerfil.SelectedIndex.ToString()), TXTUsuario.Text, TXTConstraseña.Password);
                }
                if (res==true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.ShowDialog();
                }
                else
                    MessageBox.Show(emp.Mensaje);
            }
            catch(Exception ex)
            {

            }
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(NombreUsuario, "E1");
                MyPermission.Demand();
                bool res = false;
                if (empleado == false)
                {
                    emp = new Empleado();
                    res = emp.Insertar(TXTNombreCompleto.Text, TXTDomicilio.Text, TXTTelefono.Text, TXTEmail.Text, img.ImageSource.ToString(), Convert.ToInt16(listPerfil.SelectedIndex.ToString()), TXTUsuario.Text, TXTConstraseña.Password);

                }
                if (res == true)
                {
                    PantallaCheck check = new PantallaCheck();
                    check.ShowDialog();
                }
                else
                    MessageBox.Show(emp.Mensaje);
            }
            catch (Exception EX)
            {

            }
        }
        private void Btn_Eliminar_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Eliminar.Width = 47;
            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_Eliminar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Btn_Eliminar.Width = 107;
            }
            catch(Exception ex)
            {

            }
        }
    }
}

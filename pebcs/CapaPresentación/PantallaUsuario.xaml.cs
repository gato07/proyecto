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
using CapaLogica;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaUsuario.xaml
    /// </summary>
    public partial class PantallaUsuario : UserControl
    {
        public PantallaUsuario()
        {
            InitializeComponent();
            generartarjetas();
        }
        private void generartarjetas()
        {
            Empleado CargaDatos = new Empleado(8);
            flip.CargarDatosTarjeta(CargaDatos.Clave,CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
            //Empleado CargaDatos1 = new Empleado(9);
            //flip_Copy.CargarDatosTarjeta(CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
            //Empleado CargaDatos2 = new Empleado(10);
            //flip_Copy1.CargarDatosTarjeta(CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
            //Empleado CargaDatos3 = new Empleado(11);
            //flip_Copy2.CargarDatosTarjeta(CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
            //Empleado CargaDatos4 = new Empleado(12);
            //flip_Copy3.CargarDatosTarjeta(CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
            //Empleado CargaDatos5 = new Empleado(13);
            //flip_Copy4.CargarDatosTarjeta(CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
            //Empleado CargaDatos6 = new Empleado(14);
            //flip_Copy5.CargarDatosTarjeta(CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
            //Empleado CargaDatos7 = new Empleado(15);
            //flip_Copy6.CargarDatosTarjeta(CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
            //Empleado CargaDatos8 = new Empleado(16);
            //flip_Copy7.CargarDatosTarjeta(CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
            //Empleado CargaDatos9 = new Empleado(17);
            //flip_Copy8.CargarDatosTarjeta(CargaDatos.Nombre, CargaDatos.Domicilio, CargaDatos.Telefono, CargaDatos.Email, CargaDatos.Puesto, CargaDatos.Foto, CargaDatos.Perfil, CargaDatos.Usuario, CargaDatos.Contrasena);
        }
    }
}

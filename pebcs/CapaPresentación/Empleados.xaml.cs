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
using System.Windows.Shapes;
using CapaLogica;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Empleados.xaml
    /// </summary>
    public partial class Empleados : Window
    {
        public Empleados()
        {
            InitializeComponent();
            generartarjetas();
        }
        private void generartarjetas()
        {
            Empleado CargaDatos = new Empleado(1);
            Flip.CargarDatosTarjeta(CargaDatos.Nombre,CargaDatos.Domicilio,CargaDatos.Telefono,CargaDatos.Email,CargaDatos.Puesto,CargaDatos.Foto,CargaDatos.Perfil,CargaDatos.Usuario,CargaDatos.Contrasena);
        }
    }
}

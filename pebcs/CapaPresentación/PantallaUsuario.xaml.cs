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
using CapaPresentación.Controles;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaUsuario.xaml
    /// </summary>
    public partial class PantallaUsuario : UserControl
    {
        Flipper[] flippers;
        public PantallaUsuario()
        {
            InitializeComponent();
            generartarjetas();
        }
        public void generartarjetas()
        {
            Empleado empleado = new Empleado();
            Empleado[] empleados = empleado.Empleados();
            flippers = new Flipper[empleados.Length]; ;
            int top = 0;
            int left = 0;
            for(int x=0;x<flippers.Length;x++)
            {
                flippers[x] = new Flipper(this);
                flippers[x].HorizontalAlignment =HorizontalAlignment.Left;
                Thickness thickness = flippers[x].Margin;
                thickness.Top = top;
                thickness.Left = left;
                flippers[x].Margin = thickness;
                flippers[x].CargarDatosTarjeta(empleados[x].Clave,empleados[x].Nombre,empleados[x].Domicilio,empleados[x].Telefono,empleados[x].Email,empleados[x].Puesto,empleados[x].Foto,empleados[x].Perfil_Texto,empleados[x].Usuario,empleados[x].Contrasena);
                panelprincipal.Children.Add(flippers[x]);
                left += 220;
                if(x==0)
                {
                    top -= (267);
                }
                else
                {
                    top -=0;
                }
            }
        }
    }
}

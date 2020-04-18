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
        RowDefinition rowDefinition;
        ColumnDefinition columnDefinition;
        Menu_Principal2 Mn;
        public PantallaUsuario(object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
            generartarjetas();
        }
        public void generartarjetas()
        {
            Empleado empleado = new Empleado();
            Empleado[] empleados = empleado.Empleados(empleado.SelActivos());
            flippers = new Flipper[empleados.Length]; ;
            int fila = 1;
            int columna = 1;
            agregarcolumnas();
            agregarfila(flippers.Length);
            for (int x=0;x<flippers.Length;x++)
            {
                flippers[x] = new Flipper(this,Mn);
                flippers[x].CargarDatosTarjeta(empleados[x].Clave,empleados[x].Nombre,empleados[x].Domicilio,empleados[x].Telefono,empleados[x].Email,empleados[x].Puesto,empleados[x].Foto,empleados[x].Perfil,empleados[x].Usuario,empleados[x].Contrasena);
                Grid.SetColumn(flippers[x], columna - 1);
                Grid.SetRow(flippers[x],fila-1);
                GridContenedor.Children.Add(flippers[x]);
                if (columna > 3)
                {
                    columna = 1;
                    fila++;
                }
                else
                {
                    columna++;
                }
            }
        }
        public void agregarcolumnas()
        {
            for(int x=0;x<4;x++)
            {
                columnDefinition = new ColumnDefinition();
                GridContenedor.ColumnDefinitions.Add(columnDefinition);
            }
        }
        public void agregarfila(int c)
        {
            int res;
            if((c%4)==0)
            {
                 res = c / 4;
            }
            else
            {
                 res = (c / 4)+1;
            }
            for (int x=0;x<res;x++)
            {
                rowDefinition = new RowDefinition();
                GridContenedor.RowDefinitions.Add(rowDefinition);
            }
        }
        private void Btn_Limpiar_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_Limpiar.Margin = new Thickness(119, 0, 0, 0);
        }

        private void Btn_Limpiar_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Limpiar.Margin = new Thickness(69, 0, 0, 0);
        }

        private void Btn_AgregarEmpleado_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_AgregarEmpleado.Margin = new Thickness(69, 0, 0, 0);
        }

        private void Btn_AgregarEmpleado_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn_AgregarEmpleado.Margin = new Thickness(119, 0, 0, 0);
        }
    }
}
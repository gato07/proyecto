using CapaLogica;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_CargaDeTrabajo.xaml
    /// </summary>
    public partial class Pantalla_CargaDeTrabajo : UserControl
    {
        public Pantalla_CargaDeTrabajo()
        {
            InitializeComponent();
            CargarEmpleados();
        }
        public class ChipEmpleado
        {
            public int ID { get; set; }
            public string Empleado { get; set; }
            public string Ruta { get; set; }
            public string Usuario { get; set; }
            public string Puesto { get; set; }
        }
        public class CargaTrabajoEmpleado
        {
            public string Etiqueta { get; set; }
            public string ClaveCatastral { get; set; }
            public string Cliente { get; set; }
            public string FechaIngreso { get; set; }
            public string Estatus { get; set; }
        }
        public void CargarEmpleados()
        {
            Empleado empleado = new Empleado();
            Empleado[] empleadosActivos = empleado.TableToArray(empleado.SelActivos());
            for (int x = 0; x < empleadosActivos.Length; x++)
            {
                ChipEmpleado chip = (new ChipEmpleado() { ID = empleadosActivos[x].Clave, Empleado = empleadosActivos[x].Nombre, Ruta = empleadosActivos[x].Foto, Puesto = empleadosActivos[x].Perfil_Texto, Usuario = empleadosActivos[x].Usuario });
                n.Items.Add(chip);
            }
        }
        private void tarjeta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Card n = (Card)sender;
                Grid grid = (Grid)n.Parent;
                ChipEmpleado chip = (ChipEmpleado)grid.DataContext;
                if (chip != null)
                {
                    img.ImageSource = new BitmapImage(new Uri(chip.Ruta));
                    TXTNombreCompleto.Text = chip.Empleado;
                    TXTUsuario.Text = chip.Usuario;
                    TXTPuesto.Text = chip.Puesto;
                    cargarPresupuetos(1);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void cargarPresupuetos(int ID)
        {
            CargaTrabajoEmpleado cargaTrabajo = (new CargaTrabajoEmpleado() { Etiqueta = "Prueba", ClaveCatastral = "123-456-789", Cliente = "Maria Mussy Miranda", FechaIngreso = "23/10/2020", Estatus = "En espera" });
            ListPresupuestos.Items.Add(cargaTrabajo);

        }
        private void tarjeta_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
            }
            catch (Exception ex)
            {

            }
        }

        private void tarjeta_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {

            }
        }
    }
}

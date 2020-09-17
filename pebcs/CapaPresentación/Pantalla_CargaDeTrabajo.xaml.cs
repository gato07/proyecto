using CapaLogica;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Security.Principal;
using System.Security.Permissions;
using System.Threading;
using System.Security;

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
            string NombreUsuario = "A";
            GenericIdentity identidad = new GenericIdentity(NombreUsuario);
            String[] roles = { "Ingeniero","ine"};
            GenericPrincipal MyPrincipal =
            new GenericPrincipal(identidad, roles);
            Thread.CurrentPrincipal = MyPrincipal;
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
                PrincipalPermission MyPermission = new PrincipalPermission("A", "ine");
                MyPermission.Demand();
                Card n = (Card)sender;
                Grid grid = (Grid)n.Parent;
                ChipEmpleado chip = (ChipEmpleado)grid.DataContext;
                if (chip != null)
                {
                    img.ImageSource = new BitmapImage(new Uri(chip.Ruta));
                    TXTNombreCompleto.Text = chip.Empleado;
                    TXTUsuario.Text = chip.Usuario;
                    TXTPuesto.Text = chip.Puesto;
                    Listlicencias.Items.Clear();
                    Listestimaciones.Items.Clear();
                    Listdictamen.Items.Clear();
                    Listavaluo.Items.Clear();
                    cargarlicencias(chip.ID);
                    Cargarestimaciones(chip.ID);
                    CargarDictamenes(chip.ID);
                    Cargaravaluos(chip.ID);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void cargarlicencias(int id)
        {
            Proyecto_Licencia proyecto = new Proyecto_Licencia();
            Proyecto_Licencia[] licencias = proyecto.TableToArray(proyecto.SelXEmpleado(id));
            for(int x=0;x<licencias.Length;x++)
            {
                Inmueble inmueble = new Inmueble(licencias[x].Clave_Inmueble);
                Cliente cliente = new Cliente(licencias[x].Id_Cliente);
                Estado_Licencia estado = new Estado_Licencia(licencias[x].Id_Estado_Licencia);
                CargaTrabajoEmpleado carga = (new CargaTrabajoEmpleado {Etiqueta=licencias[x].Numero_Licencia.ToString(),ClaveCatastral=inmueble.Clave_Catastral,Cliente=cliente.Nombre,FechaIngreso=licencias[x].Fecha.ToString(),Estatus=estado.Nombre });
                Listlicencias.Items.Add(carga);
            }
        }
        public void Cargarestimaciones(int id)
        {
            Dictamen_Estimacion estimacion = new Dictamen_Estimacion();
            Dictamen_Estimacion[] estimaciones = estimacion.TableToArray(estimacion.SelXEmpleado(true,id));
            for(int x=0;x<estimaciones.Length;x++)
            {
                Inmueble inmueble = new Inmueble(estimaciones[x].Clave_Inmueble);
                Cliente cliente = new Cliente(estimaciones[x].Id_Cliente);
                string estatus = "";
                if(estimaciones[x].Elaboracion)
                {
                    estatus = "ELABORADO";
                }
                else
                {
                    estatus = "NO ELABORADO";
                }
                CargaTrabajoEmpleado carga = (new CargaTrabajoEmpleado { Etiqueta = estimaciones[x].Etiqueta, ClaveCatastral = inmueble.Clave_Catastral, Cliente = cliente.Nombre, FechaIngreso = estimaciones[x].Fecha_Registro.ToString(), Estatus = estatus});
                Listestimaciones.Items.Add(carga);

            }
        }
        public void CargarDictamenes(int id)
        {
            Dictamen_Estimacion estimacion = new Dictamen_Estimacion();
            Dictamen_Estimacion[] estimaciones = estimacion.TableToArray(estimacion.SelXEmpleado(false, id));
            for (int x = 0; x < estimaciones.Length; x++)
            {
                Inmueble inmueble = new Inmueble(estimaciones[x].Clave_Inmueble);
                Cliente cliente = new Cliente(estimaciones[x].Id_Cliente);
                string estatus = "";
                if (estimaciones[x].Elaboracion)
                {
                    estatus = "ELABORADO";
                }
                else
                {
                    estatus = "NO ELABORADO";
                }
                CargaTrabajoEmpleado carga = (new CargaTrabajoEmpleado { Etiqueta = estimaciones[x].Etiqueta, ClaveCatastral = inmueble.Clave_Catastral, Cliente = cliente.Nombre, FechaIngreso = estimaciones[x].Fecha_Registro.ToString(), Estatus = estatus });
                Listdictamen.Items.Add(carga);
            }
        }
        public void Cargaravaluos(int id)
        {
            Avaluo_Pericial avaluo = new Avaluo_Pericial();
            Avaluo_Pericial[] avaluos = avaluo.TableToArray(avaluo.SelXEmpleado(id));
            for(int x=0;x<avaluos.Length;x++)
            {
                Inmueble inmueble = new Inmueble(avaluos[x].Clave_Inmueble);
                Cliente cliente = new Cliente(avaluos[x].Id_Cliente);
                CargaTrabajoEmpleado carga = (new CargaTrabajoEmpleado { Etiqueta = avaluos[x].Folio, ClaveCatastral = inmueble.Clave_Catastral, Cliente = cliente.Nombre, FechaIngreso = avaluos[x].Fecha.ToString(), Estatus = "-" });
                Listavaluo.Items.Add(carga);
            }
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

using CapaLogica;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_CargaDeTrabajo.xaml
    /// </summary>
    public partial class Pantalla_CargaDeTrabajo : UserControl
    {
        Preproyecto preproyecto = new Preproyecto();
        Tipo_Proyecto tipProyecto = new Tipo_Proyecto();
        int IdPreproyecto,IdTipodeproyecto;
        bool RequierePresupuesto = false;
        Menu_Principal2 Mn;

        public Pantalla_CargaDeTrabajo(object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
            CargarTipoProyectos();
            CargarPrepoyectos();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            bool r = false;
            if(Requiere_Presupuesto.SelectedIndex==0)
            {
                r = false;
            }
            else if(Requiere_Presupuesto.SelectedIndex==1)
            {
                r = true;
            }
            preproyecto.Insertar(TXT_Etiqueta.Text,TXT_Solicitante.Text,TXT_Propietario.Text,Convert.ToDecimal(TXT_Metros.Text),r, IdTipodeproyecto);
            CargarPrepoyectos();
            LimpiarCampos();
        }

        private void CargarTipoProyectos()
        {
            Tipo_Proyecto[] _Proyectos = tipProyecto.TableToArray(tipProyecto.SelTodos());
            string n = null;
            for(int x=0;x<_Proyectos.Length;x++)
            {
                if(x+1==1)
                {
                    n = "A";
                }
                if (x+1 == 16)
                {
                    n = "D";
                }
                if (x+1 == 31)
                {
                    n = "O";
                }
                if (x+1 == 46)
                {
                    n = "P";
                }
                if (x+1 == 61)
                {
                    n = "R";
                }
                TipoProyec ProInfo = (new TipoProyec() { ID = _Proyectos[x].Id,TipoDeObra= _Proyectos[x].Tipo_Obra,Uso= _Proyectos[x].Uso, Cabeza=n});
                tipoProyecto.Items.Add(ProInfo);
            }

        }
        private void CargarPrepoyectos()
        {
            ListaPrePoryectos.Items.Clear();
            Preproyecto[] preproyectos = preproyecto.TableToArray(preproyecto.SelActivos());
            for(int x=0;x<preproyectos.Length;x++)
            {
                preproyect proyectoinfo =(new preproyect() {ID=preproyectos[x].Id,Etiqueta= preproyectos[x].Etiqueta,Solicitante= preproyectos[x].Nombre_Solicitante,Propietario= preproyectos[x].Nombre_Propietario ,
                                                            fecha= preproyectos[x].Fecha,metros= preproyectos[x].Mts,presupuesto= preproyectos[x] .Requiere_Presupuesto,tipoProyecto= preproyectos[x] .Id_Tipo_Proyecto});
                ListaPrePoryectos.Items.Add(proyectoinfo);
            }

        }
        private void LimpiarCampos()
        {
            TXT_Etiqueta.Clear();
            TXT_Metros.Clear();
            TXT_Propietario.Clear();
            TXT_Solicitante.Clear();
            Requiere_Presupuesto.SelectedIndex = -1;
            tipoProyecto.SelectedIndex = -1;
        }

        public class TipoProyec
        {
            public int ID { get; set; }
            public string TipoDeObra { get; set; }
            public string Uso { get; set; }
            public string Cabeza { get; set; }
        }
        public class preproyect
        {
            public int ID { get; set; }
            public string Etiqueta { get; set; }
            public string Solicitante { get; set; }
            public string Propietario { get; set; }
            public DateTime fecha { get; set; }
            public Decimal metros { get; set; }
            public bool presupuesto { get; set; }
            public int tipoProyecto { get; set; }
        }
        public void LimpiarDatos()
        {
            IdPreproyecto =0;
            IdTipodeproyecto = 0;
            RequierePresupuesto = false;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiarDatos();
            ToggleButton toggle=(ToggleButton)sender;
            //Button button = (Button)sender;
            Grid grid = (Grid)toggle.Parent;
            TipoProyec P = (TipoProyec)grid.DataContext;
            if (P != null)
            {
                IdTipodeproyecto = P.ID;
            }
        }

        private void ListaPrePoryectos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LimpiarCampos();
            preproyect p=(preproyect)ListaPrePoryectos.SelectedItem;
            if(p!=null)
            {
                IdPreproyecto = p.ID;
                TXT_Etiqueta.Text = p.Etiqueta;
                TXT_Metros.Text = p.metros.ToString();
                TXT_Propietario.Text = p.Propietario;
                TXT_Solicitante.Text = p.Solicitante;
                RequierePresupuesto = p.presupuesto;
                if(p.presupuesto)
                {
                    Requiere_Presupuesto.SelectedIndex = 1;
                }
                else if (p.presupuesto==false)
                {
                    Requiere_Presupuesto.SelectedIndex = 0;
                }
                tipoProyecto.SelectedIndex = p.tipoProyecto-1;
                IdPreproyecto = p.ID;
            }
        }

        private void BtnLimpiarCampos_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            LimpiarCampos();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            preproyecto.Eliminar(IdPreproyecto);
            CargarPrepoyectos();
            LimpiarCampos();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            bool r = false;
            if (Requiere_Presupuesto.SelectedIndex == 0)
            {
                r = false;
            }
            else if (Requiere_Presupuesto.SelectedIndex == 1)
            {
                r = true;
            }
            IdTipodeproyecto = tipoProyecto.SelectedIndex;
            preproyecto.Actualizar(IdPreproyecto, TXT_Etiqueta.Text, TXT_Solicitante.Text, TXT_Propietario.Text, Convert.ToDecimal(TXT_Metros.Text), r, IdTipodeproyecto + 1);
            CargarPrepoyectos();
            LimpiarCampos();
        }

        private void BtnGenerarPrePlantilla_Click(object sender, RoutedEventArgs e)
        {
            bool ResultadoVerificarPreproyecto = VerificarPreproyecto(IdPreproyecto);
            if(ResultadoVerificarPreproyecto!=true)
            {

                Mn.AbrirFormHijo(new Pantalla_InfoLicencia(IdPreproyecto, 0));

            }
            else
            {
                MessageBox.Show("El preproyecto ya fue asignado");
            }
            LimpiarCampos();
        }
        private bool VerificarPreproyecto(int idpre)
        {
            Proyecto_Licencia proyecto_ = new Proyecto_Licencia();
            Proyecto_Licencia[] p = proyecto_.TableToArray(proyecto_.SelActivos());
            bool resul=false;
            for(int x=0;x<p.Length;x++)
            {
                if(p[x].Id_Preproyecto== idpre)
                {
                    resul= true;
                    break;
                }
            }
            return resul;
        }
    }
}

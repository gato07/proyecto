using CapaLogica;
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

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_AvaluosPericial.xaml
    /// </summary>
    public partial class Pantalla_AvaluosPericial : UserControl
    {
        Menu_Principal2 Mn;
        Avaluo_Pericial avaluo= new Avaluo_Pericial();
        public Pantalla_AvaluosPericial(object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
            CargarAvaluos();
        }
        public void CargarAvaluos()
        {
            try
            {
                Avaluo_Pericial[] avaluos = avaluo.TableToArray(avaluo.SelTodos());
                AvaluoPericial[] CardAvaluos = new AvaluoPericial[avaluos.Length];
                for(int x=0;x<avaluos.Length;x++)
                {
                    CardAvaluos[x] = new AvaluoPericial(avaluos[x].Numero,Mn);
                    n.Items.Add(CardAvaluos[x]);
                }
            }catch(Exception ex)
            {

            }
        }
        public void CargarAvaluosLikeCatastral(TextBox box,int A)
        {
            try
            {
                Avaluo_Pericial[] avaluos = avaluo.TableToArray(avaluo.SelLikeCatastral(box.Text,A));
                AvaluoPericial[] CardAvaluos = new AvaluoPericial[avaluos.Length];
                for (int x = 0; x < avaluos.Length; x++)
                {
                    CardAvaluos[x] = new AvaluoPericial(avaluos[x].Numero, Mn);
                    n.Items.Add(CardAvaluos[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarAvaluosLikeColonia(TextBox box,int A)
        {
            try
            {
                Avaluo_Pericial[] avaluos = avaluo.TableToArray(avaluo.SelLikeColonia(box.Text,A));
                AvaluoPericial[] CardAvaluos = new AvaluoPericial[avaluos.Length];
                for (int x = 0; x < avaluos.Length; x++)
                {
                    CardAvaluos[x] = new AvaluoPericial(avaluos[x].Numero, Mn);
                    n.Items.Add(CardAvaluos[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarAvaluosLikeCliente(TextBox box, int A)
        {
            try
            {
                Avaluo_Pericial[] avaluos = avaluo.TableToArray(avaluo.SelLikeNomCliente(box.Text,A));
                AvaluoPericial[] CardAvaluos = new AvaluoPericial[avaluos.Length];
                for (int x = 0; x < avaluos.Length; x++)
                {
                    CardAvaluos[x] = new AvaluoPericial(avaluos[x].Numero, Mn);
                    n.Items.Add(CardAvaluos[x]);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void CargarAvaluosLikePropietario(TextBox box, int A)
        {
            try
            {
                Avaluo_Pericial[] avaluos = avaluo.TableToArray(avaluo.SelLikeNomPropietario(box.Text,A));
                AvaluoPericial[] CardAvaluos = new AvaluoPericial[avaluos.Length];
                for (int x = 0; x < avaluos.Length; x++)
                {
                    CardAvaluos[x] = new AvaluoPericial(avaluos[x].Numero, Mn);
                    n.Items.Add(CardAvaluos[x]);
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
                Mn.AbrirFormHijo(new Pantalla_InfoAvaluo(0));
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
                    Estados.IsEnabled = true;
                    Btn_Limpiar.IsEnabled = true;
                    TxtBusqueda.IsEnabled = true;
                    Opciones.SelectedIndex = -1;
                    Estados.SelectedIndex = -1;
                    TxtBusqueda.Clear();
                }
                else
                {
                    Opciones.IsEnabled = false;
                    Estados.IsEnabled = false;
                    Btn_Limpiar.IsEnabled = false;
                    TxtBusqueda.IsEnabled = false;
                    Opciones.SelectedIndex = -1;
                    Estados.SelectedIndex = -1;
                    TxtBusqueda.Clear();
                    n.Items.Clear();
                    CargarAvaluos();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void TxtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int E=0;
                if(Estados.SelectedIndex==-1)
                {
                    E = 0;
                }
                else if (Estados.SelectedIndex == 0)
                {
                    E = 24;
                }
                else if (Estados.SelectedIndex == 1)
                {
                    E = 25;
                }
                else if (Estados.SelectedIndex == 2)
                {
                    E = 23;
                }
                if (Opciones.SelectedIndex == 0)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 60;
                    CargarAvaluosLikeCatastral(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 1)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 255;
                    CargarAvaluosLikeColonia(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 2)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 15;
                    CargarAvaluosLikeCliente(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 3)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 15;
                    CargarAvaluosLikePropietario(TxtBusqueda, E);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void Estados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int E = 0;
                if (Estados.SelectedIndex == -1)
                {
                    E = 0;
                }
                else if (Estados.SelectedIndex == 0)
                {
                    E = 24;
                }
                else if (Estados.SelectedIndex == 1)
                {
                    E = 25;
                }
                else if (Estados.SelectedIndex == 2)
                {
                    E = 23;
                }
                if (Opciones.SelectedIndex == -1)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 60;
                    CargarAvaluosLikeCatastral(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 0)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 60;
                    CargarAvaluosLikeCatastral(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 1)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 255;
                    CargarAvaluosLikeColonia(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 2)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 15;
                    CargarAvaluosLikeCliente(TxtBusqueda, E);
                }
                else if (Opciones.SelectedIndex == 3)
                {
                    n.Items.Clear();
                    TxtBusqueda.MaxLength = 15;
                    CargarAvaluosLikePropietario(TxtBusqueda, E);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}

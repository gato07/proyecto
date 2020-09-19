using CapaLogica;
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

namespace CapaPresentación.Controles
{
    /// <summary>
    /// Lógica de interacción para AvaluoPericialInactivo.xaml
    /// </summary>
    public partial class AvaluoPericialInactivo : UserControl
    {
        Avaluo_Pericial Avaluo;
        Cliente cliente;
        Inmueble inmueble;
        Menu_Principal2 Mn;
        int ID;
        int IdUSUATIO;
        public AvaluoPericialInactivo(int Id, object A, int iDe)
        {
            InitializeComponent();
            IdUSUATIO = iDe;
            Mn = A as Menu_Principal2;
            ID = Id;
            CargarInfo(Id);

        }
        public void CargarInfo(int ID)
        {
            Avaluo = new Avaluo_Pericial(ID);
            cliente = new Cliente(Avaluo.Id_Cliente);
            inmueble = new Inmueble(Avaluo.Clave_Inmueble);
            TXT_Cliente.Text = cliente.Nombre;
            TXT_NoFolio.Text = Avaluo.Folio;
            DTP_FechaAvaluo.SelectedDate = Avaluo.Fecha;
            TXT_Colonia.Text = inmueble.Colonia;
            TXT_UsoInmueble.Text = Avaluo.Uso;
            TXT_Propietario.Text = inmueble.Nombre_Propietario;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Avaluo_Pericial pericial = new Avaluo_Pericial();
                pericial.Activar(ID);
            }
            catch(Exception ex)
            {

            }
        }
    }
}

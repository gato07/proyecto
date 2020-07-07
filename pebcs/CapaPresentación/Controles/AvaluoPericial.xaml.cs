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

namespace CapaPresentación.Controles
{
    /// <summary>
    /// Lógica de interacción para AvaluoPericial.xaml
    /// </summary>
    public partial class AvaluoPericial : UserControl
    {
        Avaluo_Pericial Avaluo;
        Cliente cliente;
        Inmueble inmueble;
        Menu_Principal2 Mn;
        int ID;
        public AvaluoPericial(int Id,object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
            ID = Id;
            CargarInfo(Id);
        }
        public void CargarInfo(int ID)
        {
            Avaluo = new Avaluo_Pericial(ID);
            cliente = new Cliente(Avaluo.Id_Cliente);
            inmueble = new Inmueble(Avaluo.Clave_Inmueble);
            ClaveCatastral.Text = inmueble.Clave_Catastral;
            TXT_NoFolio.Text = Avaluo.Folio;
            DTP_FechaAvaluo.SelectedDate = Avaluo.Fecha;
            TXT_Colonia.Text = inmueble.Colonia;
            TXT_UsoInmueble.Text = Avaluo.Uso;
            TXT_Propietario.Text = inmueble.Nombre_Propietario;
            TXT_Utilidad.Text = (Convert.ToDecimal(TXT_CostoNeto.Text = Avaluo.Costo_Neto.ToString()) + Convert.ToDecimal(TXT_PagoDeDerechos.Text = Avaluo.Pago_Derechos.ToString())).ToString();
        }

        private void Card_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new Pantalla_InfoAvaluo(ID)); ;
            }catch(Exception ex)
            {

            }
        }
    }
}

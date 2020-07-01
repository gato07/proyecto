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
        public Pantalla_AvaluosPericial(object A)
        {
            InitializeComponent();
            Mn = A as Menu_Principal2;
            DatosPrueba();
        }
        public void DatosPrueba()
        {
            for(int x=0;x<17;x++)
            {
                AvaluoPericial avaluo = new AvaluoPericial();
                n.Items.Add(avaluo);
            }
        }

        private void Btn_AgregarPantalla_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mn.AbrirFormHijo(new Pantalla_InfoAvaluo());
            }catch(Exception ex)
            {

            }
        }
    }
}

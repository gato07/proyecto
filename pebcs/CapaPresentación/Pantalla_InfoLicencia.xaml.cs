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
    /// Lógica de interacción para Pantalla_InfoLicencia.xaml
    /// </summary>
    public partial class Pantalla_InfoLicencia : UserControl
    {
        public Pantalla_InfoLicencia()
        {
            InitializeComponent();
            llenarArmadoPaquete();
        }
        public class Document
        {
            public string NombreDocumento { get; set; }
            public bool ISCHECK { get; set; }
        }
        public void llenarArmadoPaquete()
        {
            bool F = false;
            for (int x = 0; x < 12; x++)
            {
                if (x%2!=0)
                {
                    F = true;
                }
                else
                {
                    F = false;
                }
                Document documento = (new Document() { NombreDocumento = "Documeto "+x.ToString() ,ISCHECK=F});
                ArmadoPaquete.Items.Add(documento);
            }

        }
    }
}

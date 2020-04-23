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
using System.Windows.Shapes;

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para PantallaCheck.xaml
    /// </summary>
    public partial class PantallaCheck : Window
    {
        public PantallaCheck()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {

            }
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                this.Cursor = null;
                this.Close();
            }
            catch(Exception ex)
            {

            }
        }
    }
}

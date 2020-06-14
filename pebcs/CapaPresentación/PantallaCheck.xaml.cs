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
using System.Windows.Threading;

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
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 3);
                timer.Tick += (a, b) =>
                  {
                      timer.Stop();
                      this.Close();
                  };
                timer.Start();
            }
            catch(Exception ex)
            {

            }
        }
    }
}

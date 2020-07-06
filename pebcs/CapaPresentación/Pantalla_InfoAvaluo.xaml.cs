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

namespace CapaPresentación
{
    /// <summary>
    /// Lógica de interacción para Pantalla_InfoAvaluo.xaml
    /// </summary>
    public partial class Pantalla_InfoAvaluo : UserControl
    {
        Cliente cliente = new Cliente();
        Inmueble inmueble = new Inmueble();
        string[] Documentacion = new string[] {"Escrituras Del Terreno","Manifestación","Oficion De Subdivición",
                                               "Oficio De Fusión" };
        bool[] dockcheck = new bool[4];
        public Pantalla_InfoAvaluo()
        {
            try
            {
                InitializeComponent();
                cargarDocumentacion(null);
                CargarClientes();
                CargarInmuebles();
            }
            catch(Exception ex)
            {

            }
        }
        public class Document
        {
            public int ID { get; set; }
            public string NombreDocumento { get; set; }
            public bool ISCHECK { get; set; }
        }
        public class Clientea
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
        }
        public class Inmueblea
        {
            public int ID { get; set; }
            public string ClaveCatastral { get; set; }
            public string Propietario { get; set; }
            public string Colonia { get; set; }
            public string Calle { get; set; }
            public string EntreCalles { get; set; }
            public string NumeroInterior { get; set; }
            public string NumeroExterior { get; set; }
        }
        private void cargarDocumentacion(bool[] n)
        {
            try
            {
                if (n != null)
                {
                    for (int x = 0; x < Documentacion.Length; x++)
                    {
                        Document document = (new Document { ID = x + 1, NombreDocumento = Documentacion[x], ISCHECK = n[x] });
                        ArmadoPaquete.Items.Add(document);
                    }
                }
                else if (n == null)
                {
                    for (int x = 0; x < Documentacion.Length; x++)
                    {
                        dockcheck[x] = false;
                        Document document = (new Document { ID = x + 1, NombreDocumento = Documentacion[x], ISCHECK = false });
                        ArmadoPaquete.Items.Add(document);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CargarClientes()
        {
            try
            {
                Cliente[] c = cliente.TableToArray(cliente.SelActivos());
                for (int x = 0; x < c.Length; x++)
                {
                    Clientea clientea = (new Clientea() { ID = c[x].Id, Nombre = c[x].Nombre, Apellido = c[x].Apellido, Telefono = c[x].Telefono });
                    Clientes.Items.Add(clientea);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CargarInmuebles()
        {
            try
            {
                Inmueble[] c = inmueble.TableToArray(inmueble.SelActivos());
                for (int x = 0; x < c.Length; x++)
                {
                    Inmueblea inmueblea = (new Inmueblea() { ID = c[x].Clave, ClaveCatastral = c[x].Clave_Catastral, Propietario = c[x].Nombre_Propietario, Colonia = c[x].Colonia, Calle = c[x].Calle, EntreCalles = c[x].Entre_Calles, NumeroExterior = c[x].Numero_Exterior, NumeroInterior = c[x].Numero_Interior });
                    Inmuebles.Items.Add(inmueblea);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}

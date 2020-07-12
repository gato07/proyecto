using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Avaluo_Pericial : dtsAvaluo_Pericial
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Avaluo_Pericial() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Avaluo_Pericial";
            }
        }

        public Avaluo_Pericial(int Numero) : base(Numero)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Avaluo_Pericial";
            }
        }

        public Avaluo_Pericial(int Numero, string Folio, DateTime Fecha, string Uso, decimal Mts_Terreno,
            decimal Mts_Construccion, decimal Costo_Neto, decimal Pago_Derechos, DateTime Fecha_Recepcion,
            string Observacion_Recepcion, DateTime Fecha_Entrega, string Observacion_Entrega, bool Escrituras,
            bool Manifestacion, bool Oficio_Subdivision, bool Oficio_Fusion, bool Plano_Subdivision,
            int Id_Estado_Licencia, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado) :
            base(Numero, Folio, Fecha, Uso, Mts_Terreno, Mts_Construccion, Costo_Neto, Pago_Derechos, Fecha_Recepcion,
            Observacion_Recepcion, Fecha_Entrega, Observacion_Entrega, Escrituras, Manifestacion, Oficio_Subdivision, 
            Oficio_Fusion, Plano_Subdivision, Id_Estado_Licencia, Id_Cliente, Clave_Inmueble, Clave_Empleado)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Avaluo_Pericial";
            }
        }

        public int Insertar(string Folio, DateTime Fecha, string Uso, decimal Mts_Terreno,
            decimal Mts_Construccion, decimal Costo_Neto, decimal Pago_Derechos, DateTime Fecha_Recepcion,
            string Observacion_Recepcion, DateTime Fecha_Entrega, string Observacion_Entrega, bool Escrituras,
            bool Manifestacion, bool Oficio_Subdivision, bool Oficio_Fusion, bool Plano_Subdivision,
            int Id_Estado_Licencia, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Avaluo Pericial, es posible que no se haya insertado"
                    + " correctamente";
                res = dtsInsertar(Folio, Fecha, Uso, Mts_Terreno,Mts_Construccion, Costo_Neto, Pago_Derechos, 
                    Fecha_Recepcion, Observacion_Recepcion, Fecha_Entrega, Observacion_Entrega, Escrituras,
                    Manifestacion, Oficio_Subdivision, Oficio_Fusion, Plano_Subdivision, Id_Estado_Licencia, 
                    Id_Cliente, Clave_Inmueble, Clave_Empleado);
                if (res > 0)
                    Mensaje = "El Avaluo Pericial fue registrado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Avaluo Pericial, es posible que no se haya insertado"
                    + " correctamente";
                return 0;
            }
        }

        public bool Actualizar(int Numero, string Folio, DateTime Fecha, string Uso, decimal Mts_Terreno,
            decimal Mts_Construccion, decimal Costo_Neto, decimal Pago_Derechos, DateTime Fecha_Recepcion,
            string Observacion_Recepcion, DateTime Fecha_Entrega, string Observacion_Entrega, bool Escrituras,
            bool Manifestacion, bool Oficio_Subdivision, bool Oficio_Fusion, bool Plano_Subdivision,
            int Id_Estado_Licencia, int Id_Cliente, int Clave_Inmueble)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Avaluo Pericial, es posible"
                   + " que no se hayan modificado los datos correctamente";
                res = dtsActualizar(Numero, Folio, Fecha, Uso, Mts_Terreno, Mts_Construccion, Costo_Neto, Pago_Derechos,
                    Fecha_Recepcion, Observacion_Recepcion, Fecha_Entrega, Observacion_Entrega, Escrituras, 
                    Manifestacion, Oficio_Subdivision, Oficio_Fusion, Plano_Subdivision, Id_Estado_Licencia,
                    Id_Cliente, Clave_Inmueble);
                if (res)
                    Mensaje = "Los datos del Avaluo Pericial fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Avaluo Pericial, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public DataTable SelTodos()
        {
            try
            {
                return dtsSelTodos();
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales";
                return null;
            }
        }

        public DataTable SelLikeNomCliente(string Nombre = "", int Id_Estado_Licencia = 0)
        {
            try
            {
                return dtsSelLikeNomCliente(Nombre, Id_Estado_Licencia);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales X Nombre del cliente";
                return null;
            }
        }

        public DataTable SelLikeCatastral(string Clave_Catastral = "", int Id_Estado_Licencia = 0)
        {
            try
            {
                return dtsSelLikeCatastral(Clave_Catastral, Id_Estado_Licencia);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales X Clave catastral";
                return null;
            }
        }

        public DataTable SelLikeNomPropietario(string Nombre_Propietario = "", int Id_Estado_Licencia = 0)
        {
            try
            {
                return dtsSelLikeNomPropietario(Nombre_Propietario, Id_Estado_Licencia);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales X Nombre del propietario";
                return null;
            }
        }

        public DataTable SelLikeColonia(string Colonia = "", int Id_Estado_Licencia = 0)
        {
            try
            {
                return dtsSelLikeColonia(Colonia, Id_Estado_Licencia);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales X Colonia";
                return null;
            }
        }
        public Avaluo_Pericial[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Avaluo_Pericial[] avaluos = new Avaluo_Pericial[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Avaluo_Pericial avaluo = new Avaluo_Pericial();
                    if (Dt.Columns.Contains("Numero"))
                        avaluo.Numero = Convert.ToInt16(renglon["Numero"]);
                    if (Dt.Columns.Contains("Folio"))
                        avaluo.Folio = renglon["Folio"].ToString();
                    if (Dt.Columns.Contains("Fecha"))
                        avaluo.Fecha = Convert.ToDateTime(renglon["Fecha"]);
                    if (Dt.Columns.Contains("Uso"))
                        avaluo.Uso = renglon["Uso"].ToString();
                    if (Dt.Columns.Contains("Mts_Terreno"))
                        avaluo.Mts_Terreno = Convert.ToDecimal(renglon["Mts_Terreno"]);
                    if (Dt.Columns.Contains("Mts_Construccion"))
                        avaluo.Mts_Construccion = Convert.ToDecimal(renglon["Mts_Construccion"]);
                    if (Dt.Columns.Contains("Costo_Neto"))
                        avaluo.Costo_Neto = Convert.ToDecimal(renglon["Costo_Neto"]);
                    if (Dt.Columns.Contains("Pago_Derechos"))
                        avaluo.Pago_Derechos = Convert.ToDecimal(renglon["Pago_Derechos"]);
                    if (Dt.Columns.Contains("Fecha_Recepcion"))
                        avaluo.Fecha_Recepcion = Convert.ToDateTime(renglon["Fecha_Recepcion"]);
                    if (Dt.Columns.Contains("Observacion_Recepcion"))
                        avaluo.Observacion_Recepcion = renglon["Observacion_Recepcion"].ToString();
                    if (Dt.Columns.Contains("Fecha_Entrega"))
                        avaluo.Fecha_Entrega = Convert.ToDateTime(renglon["Fecha_Entrega"]);
                    if (Dt.Columns.Contains("Observacion_Entrega"))
                        avaluo.Observacion_Entrega = renglon["Observacion_Entrega"].ToString();
                    if (Dt.Columns.Contains("Escrituras"))
                        avaluo.Escrituras = Convert.ToBoolean(renglon["Escrituras"]);
                    if (Dt.Columns.Contains("Manifestacion"))
                        avaluo.Manifestacion = Convert.ToBoolean(renglon["Manifestacion"]);
                    if (Dt.Columns.Contains("Oficio_Subdivision"))
                        avaluo.Oficio_Subdivision = Convert.ToBoolean(renglon["Oficio_Subdivision"]);
                    if (Dt.Columns.Contains("Oficio_Fusion"))
                        avaluo.Oficio_Fusion = Convert.ToBoolean(renglon["Oficio_Fusion"]);
                    if (Dt.Columns.Contains("Plano_Subdivision"))
                        avaluo.Plano_Subdivision = Convert.ToBoolean(renglon["Plano_Subdivision"]);
                    if (Dt.Columns.Contains("Id_Estado_Licencia"))
                        avaluo.Id_Estado_Licencia = Convert.ToInt16(renglon["Id_Estado_Licencia"]);
                    if (Dt.Columns.Contains("Id_Cliente"))
                        avaluo.Id_Cliente = Convert.ToInt16(renglon["Id_Cliente"]);
                    if (Dt.Columns.Contains("Clave_Inmueble"))
                        avaluo.Clave_Inmueble = Convert.ToInt16(renglon["Clave_Inmueble"]);
                    if (Dt.Columns.Contains("Clave_Empleado"))
                        avaluo.Clave_Empleado = Convert.ToInt16(renglon["Clave_Empleado"]);
                    if (Dt.Columns.Contains("Eliminado"))
                        avaluo.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    avaluo.Existe = true;
                    avaluos[i] = avaluo;
                    i++;
                }
                return avaluos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Avaluos Periciales";
                return new Avaluo_Pericial[0];
            }
        }

        #endregion Metodos

    }
}

using System;
using System.Data;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class Dictamen_Estimacion : dtsDictamen_Estimacion
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Dictamen_Estimacion() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Dictamen/Estimación";
            }
        }

        public Dictamen_Estimacion(int Numero) : base(Numero)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Dictamen/Estimación";
            }
        }

        public Dictamen_Estimacion(int Numero, string Etiqueta, bool Tipo, DateTime Fecha_Registro, DateTime Visita_Programada,
            bool Elaboracion, string Observacion_Elaboracion, bool Entregado, bool Manifestacion,
            bool Oficio_Subdivision, bool Escrituras, bool Licencia_Construccion, bool Otra,
            string Otra_Nombre, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado) :
            base(Numero, Etiqueta, Tipo, Fecha_Registro, Visita_Programada, Elaboracion, Observacion_Elaboracion, Entregado,
                Manifestacion, Oficio_Subdivision, Escrituras, Licencia_Construccion, Otra, Otra_Nombre, Id_Cliente, 
                Clave_Inmueble, Clave_Empleado)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Dictamen/Estimación";
            }
        }

        public int Insertar(string Etiqueta, bool Tipo, DateTime Fecha_Registro, DateTime Visita_Programada,
            bool Elaboracion, string Observacion_Elaboracion, bool Entregado, bool Manifestacion,
            bool Oficio_Subdivision, bool Escrituras, bool Licencia_Construccion, bool Otra,
            string Otra_Nombre, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Dictamen/Estimación, es posible que no se haya insertado"
                    + " correctamente";
                res = dtsInsertar(Etiqueta, Tipo, Fecha_Registro, Visita_Programada, Elaboracion, Observacion_Elaboracion, Entregado,
                Manifestacion, Oficio_Subdivision, Escrituras, Licencia_Construccion, Otra, Otra_Nombre, Id_Cliente,
                Clave_Inmueble, Clave_Empleado);
                if (res > 0)
                    Mensaje = "El Dictamen/Estimación fue registrado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Dictamen/Estimación, es posible que no se haya insertado"
                    + " correctamente";
                return 0;
            }
        }

        public bool Actualizar(int Numero, string Etiqueta, bool Tipo, DateTime Fecha_Registro, DateTime Visita_Programada,
            bool Elaboracion, string Observacion_Elaboracion, bool Entregado, bool Manifestacion,
            bool Oficio_Subdivision, bool Escrituras, bool Licencia_Construccion, bool Otra,
            string Otra_Nombre, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Dictamen/Estimación, es posible"
                   + " que no se hayan modificado los datos correctamente";
                res = dtsActualizar(Numero, Etiqueta, Tipo, Fecha_Registro, Visita_Programada, Elaboracion, Observacion_Elaboracion, Entregado,
                Manifestacion, Oficio_Subdivision, Escrituras, Licencia_Construccion, Otra, Otra_Nombre, Id_Cliente,
                Clave_Inmueble, Clave_Empleado);
                if (res)
                    Mensaje = "Los datos del Dictamen/Estimación fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Dictamen/Estimación, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }
        public bool Eliminar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Dictamen/Estimación, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero);
                if (res)
                    Mensaje = "El Dictamen/Estimación fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Dictamen/Estimación, es posible que no se haya borrado"
                   + " correctamente";
                return false;
            }
        }

        public bool Activar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Dictamen/Estimación, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero);
                if (res)
                    Mensaje = "El Dictamen/Estimación fue activado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Dictamen/Estimación, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public DataTable SelTodos(bool Eliminado = false)
        {
            try
            {
                return dtsSelTodos(Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Dictamenes/Estimaciones";
                return null;
            }
        }

        public DataTable SelXTipoLikeEtiqueta(bool Tipo = false, string Etiqueta = "", bool Eliminado = false)
        {
            try
            {
                return dtsSelXTipoLikeEtiqueta(Tipo, Etiqueta, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Dictamenes/Estimaciones X Tipo y Etiqueta";
                return null;
            }
        }

        public DataTable SelXTipoLikeCatastral(bool Tipo = false, string Clave_Catastral = "", bool Eliminado = false)
        {
            try
            {
                return dtsSelXTipoLikeCatastral(Tipo, Clave_Catastral, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Dictamenes/Estimaciones X Tipo y Clave catastral";
                return null;
            }
        }

        public DataTable SelXTipoLikePropietario(bool Tipo = false, string Nombre_Propietario = "", bool Eliminado = false)
        {
            try
            {
                return dtsSelXTipoLikePropietario(Tipo, Nombre_Propietario, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Dictamenes/Estimaciones X Tipo y Nombre del propietario";
                return null;
            }
        }

        public DataTable SelXEmpleado(bool Tipo, int Clave_Empleado)
        {
            try
            {
                return dtsSelXEmpleado(Tipo, Clave_Empleado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos(as) los(as) Dictamenes/Estimaciones X Empleado";
                return null;
            }
        }
        public Dictamen_Estimacion[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Dictamen_Estimacion[] dicests = new Dictamen_Estimacion[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Dictamen_Estimacion dicest = new Dictamen_Estimacion();
                    if (Dt.Columns.Contains("Numero"))
                        dicest.Numero = Convert.ToInt16(renglon["Numero"]);
                    if (Dt.Columns.Contains("Etiqueta"))
                        dicest.Etiqueta = renglon["Etiqueta"].ToString();
                    if (Dt.Columns.Contains("Tipo"))
                        dicest.Tipo = Convert.ToBoolean(renglon["Tipo"]);
                    if (Dt.Columns.Contains("Fecha_Registro"))
                        dicest.Fecha_Registro = Convert.ToDateTime(renglon["Fecha_Registro"]);
                    if (Dt.Columns.Contains("Visita_Programada"))
                        dicest.Visita_Programada = Convert.ToDateTime(renglon["Visita_Programada"]);
                    if (Dt.Columns.Contains("Elaboracion"))
                        dicest.Elaboracion = Convert.ToBoolean(renglon["Elaboracion"]);
                    if (Dt.Columns.Contains("Observacion_Elaboracion"))
                        dicest.Observacion_Elaboracion = renglon["Observacion_Elaboracion"].ToString();
                    if (Dt.Columns.Contains("Entregado"))
                        dicest.Entregado = Convert.ToBoolean(renglon["Entregado"]);
                    if (Dt.Columns.Contains("Manifestacion"))
                        dicest.Manifestacion = Convert.ToBoolean(renglon["Manifestacion"]);
                    if (Dt.Columns.Contains("Oficio_Subdivision"))
                        dicest.Oficio_Subdivision = Convert.ToBoolean(renglon["Oficio_Subdivision"]);
                    if (Dt.Columns.Contains("Escrituras"))
                        dicest.Escrituras = Convert.ToBoolean(renglon["Escrituras"]);
                    if (Dt.Columns.Contains("Licencia_Construccion"))
                        dicest.Licencia_Construccion = Convert.ToBoolean(renglon["Licencia_Construccion"]);
                    if (Dt.Columns.Contains("Otra"))
                        dicest.Otra = Convert.ToBoolean(renglon["Otra"]);
                    if (Dt.Columns.Contains("Otra_Nombre"))
                        dicest.Otra_Nombre = renglon["Otra_Nombre"].ToString(); ;
                    if (Dt.Columns.Contains("Id_Cliente"))
                        dicest.Id_Cliente = Convert.ToInt16(renglon["Id_Cliente"]);
                    if (Dt.Columns.Contains("Clave_Inmueble"))
                        dicest.Clave_Inmueble = Convert.ToInt16(renglon["Clave_Inmueble"]);
                    if (Dt.Columns.Contains("Clave_Empleado"))
                        dicest.Clave_Empleado = Convert.ToInt16(renglon["Clave_Empleado"]);
                    if (Dt.Columns.Contains("Eliminado"))
                        dicest.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    dicest.Existe = true;
                    dicests[i] = dicest;
                    i++;
                }
                return dicests;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Dictamen/Estimación";
                return new Dictamen_Estimacion[0];
            }
        }

        #endregion Metodos

    }
}

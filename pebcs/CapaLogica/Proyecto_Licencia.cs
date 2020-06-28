using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Proyecto_Licencia : dtsProyecto_Licencia
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Proyecto_Licencia() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Proyecto_Licencia";
            }
        }

        public Proyecto_Licencia(int Numero) : base(Numero)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Proyecto_Licencia";
            }
        }

        public Proyecto_Licencia(int Numero, string Folio, DateTime Fecha, string Numero_Licencia, DateTime Vigencia,
            bool Escrituras, bool Constancia_Alineamiento, bool Pago_Predial, bool Recibo_Agua, bool Planos_Arquitectonicos,
            bool Planos_Estructurales, bool Planos_Instalaciones, bool Memoria_Calculo, int Id_Estado_Licencia,
            int Numero_Presupuesto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado, int? Numero_Proyecto_Original) :
            base(Numero, Folio, Fecha, Numero_Licencia, Vigencia, Escrituras, Constancia_Alineamiento, Pago_Predial, 
                Recibo_Agua, Planos_Arquitectonicos, Planos_Estructurales, Planos_Instalaciones, Memoria_Calculo,
                Id_Estado_Licencia, Numero_Presupuesto, Id_Cliente, Clave_Inmueble, Clave_Empleado, Numero_Proyecto_Original)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Proyecto_Licencia";
            }
        }

        public int Insertar(bool Escrituras, bool Constancia_Alineamiento, bool Pago_Predial, bool Recibo_Agua,
            bool Planos_Arquitectonicos, bool Planos_Estructurales, bool Planos_Instalaciones, bool Memoria_Calculo,
            int Id_Estado_Licencia, int Numero_Presupuesto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Proyecto_Licencia, es posible que no se haya insertado"
                    + " correctamente";
                res = dtsInsertar(Escrituras, Constancia_Alineamiento, Pago_Predial, Recibo_Agua, Planos_Arquitectonicos, 
                    Planos_Estructurales, Planos_Instalaciones, Memoria_Calculo, Id_Estado_Licencia, 
                    Numero_Presupuesto, Id_Cliente, Clave_Inmueble, Clave_Empleado);
                if (res > 0)
                    Mensaje = "El Presupuesto fue registrado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Proyecto_Licencia, es posible que no se haya insertado"
                    + " correctamente";
                return 0;
            }
        }

        public bool Actualizar(int Numero, bool Escrituras, bool Constancia_Alineamiento, bool Pago_Predial,
            bool Recibo_Agua, bool Planos_Arquitectonicos, bool Planos_Estructurales, bool Planos_Instalaciones,
            bool Memoria_Calculo)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Proyecto_Licencia, es posible"
                   + " que no se hayan modificado los datos correctamente";
                res = dtsActualizar(Numero, Escrituras, Constancia_Alineamiento, Pago_Predial, Recibo_Agua, 
                    Planos_Arquitectonicos, Planos_Estructurales, Planos_Instalaciones, Memoria_Calculo);
                if (res)
                    Mensaje = "Los datos del Proyecto_Licencia fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Proyecto_Licencia, es posible"
                    + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool ActualizarSeguimiento(int Numero, string Folio, string Numero_Licencia, DateTime Vigencia,
            int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización del Estado de la licencia  del Proyecto_Licencia,"
                    + " es posible que no se hayan modificado los datos correctamente";
                res = dtsActualizarSeguimiento(Numero, Folio, Numero_Licencia, Vigencia, Id_Estado_Licencia);
                if (res)
                    Mensaje = "Los datos del Proyecto_Licencia fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización del Estado de la licencia  del Proyecto_Licencia,"
                    + " es posible que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool ActualizarIdEstadoLic(int Numero, int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización del Estado de la licencia  del Proyecto_Licencia,"
                    +" es posible que no se hayan modificado los datos correctamente";
                res = ActualizarIdEstadoLic(Numero, Id_Estado_Licencia);
                if (res)
                    Mensaje = "Los datos del Proyecto_Licencia fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización del Estado de la licencia  del Proyecto_Licencia,"
                    + " es posible que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool ActualizarNumProOriginal(int Numero, int? Numero_Proyecto_Original)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización del Numero_Proyecto_Original de la licencia  del Proyecto_Licencia,"
                    + " es posible que no se haya modificado correctamente";
                res = dtsActualizarNumProOriginal(Numero, Numero_Proyecto_Original);
                if (res)
                    Mensaje = "El campo Numero_Proyecto_Original del Proyecto_Licencia fue actualizado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización del Numero_Proyecto_Original de la licencia  del Proyecto_Licencia,"
                    + " es posible que no se haya modificado correctamente";
                return false;
            }
        }

        public bool Eliminar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Proyecto_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero);
                if (res)
                    Mensaje = "El Proyecto_Licencia fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Proyecto_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Proyecto_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero);
                if (res)
                    Mensaje = "El Proyecto_Licencia fue activado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Proyecto_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public DataTable SelActivos()
        {
            try
            {
                return dtsSelXCampoEliminado();
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos_Licencia activos";
                return null;
            }
        }

        public DataTable SelEliminados()
        {
            try
            {
                return dtsSelXCampoEliminado(true);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos_Licencia eliminados";
                return null;
            }
        }

        public DataTable SelPRES1XCampoEliminado(bool Eliminado = false)
        {
            try
            {
                return dtsSelPRES1XCampoEliminado(Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos_Licencia en Presentación"
                    +" 1 por el campo eliminado";
                return null;
            }
        }

        public Proyecto_Licencia[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Proyecto_Licencia[] proyectos = new Proyecto_Licencia[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Proyecto_Licencia proyecto = new Proyecto_Licencia();
                    if (Dt.Columns.Contains("Numero"))
                        proyecto.Numero = Convert.ToInt16(renglon["Numero"]);
                    if (Dt.Columns.Contains("Folio"))
                        proyecto.Folio = renglon["Folio"].ToString();
                    if (Dt.Columns.Contains("Fecha"))
                        proyecto.Fecha = Convert.ToDateTime(renglon["Fecha"]);
                    if (Dt.Columns.Contains("Numero_Licencia"))
                        proyecto.Numero_Licencia = renglon["Numero_Licencia"].ToString();
                    if (Dt.Columns.Contains("Vigencia"))
                        proyecto.Vigencia = Convert.ToDateTime(renglon["Vigencia"]);
                    if (Dt.Columns.Contains("Escrituras"))
                        proyecto.Escrituras = Convert.ToBoolean(renglon["Escrituras"]);
                    if (Dt.Columns.Contains("Constancia_Alineamiento"))
                        proyecto.Constancia_Alineamiento = Convert.ToBoolean(renglon["Constancia_Alineamiento"]);
                    if (Dt.Columns.Contains("Pago_Predial"))
                        proyecto.Pago_Predial = Convert.ToBoolean(renglon["Pago_Predial"]);
                    if (Dt.Columns.Contains("Recibo_Agua"))
                        proyecto.Recibo_Agua = Convert.ToBoolean(renglon["Recibo_Agua"]);
                    if (Dt.Columns.Contains("Planos_Arquitectonicos"))
                        proyecto.Planos_Arquitectonicos = Convert.ToBoolean(renglon["Planos_Arquitectonicos"]);
                    if (Dt.Columns.Contains("Planos_Estructurales"))
                        proyecto.Planos_Estructurales = Convert.ToBoolean(renglon["Planos_Estructurales"]);
                    if (Dt.Columns.Contains("Planos_Instalaciones"))
                        proyecto.Planos_Instalaciones = Convert.ToBoolean(renglon["Planos_Instalaciones"]);
                    if (Dt.Columns.Contains("Memoria_Calculo"))
                        proyecto.Memoria_Calculo = Convert.ToBoolean(renglon["Memoria_Calculo"]);
                    if (Dt.Columns.Contains("Id_Estado_Licencia"))
                        proyecto.Id_Estado_Licencia = Convert.ToInt16(renglon["Id_Estado_Licencia"]);
                    if (Dt.Columns.Contains("Numero_Presupuesto"))
                        proyecto.Numero_Presupuesto = Convert.ToInt16(renglon["Numero_Presupuesto"]);
                    if (Dt.Columns.Contains("Id_Cliente"))
                        proyecto.Id_Cliente = Convert.ToInt16(renglon["Id_Cliente"]);
                    if (Dt.Columns.Contains("Clave_Inmueble"))
                        proyecto.Clave_Inmueble = Convert.ToInt16(renglon["Clave_Inmueble"]);
                    if (Dt.Columns.Contains("Clave_Empleado"))
                        proyecto.Clave_Empleado = Convert.ToInt16(renglon["Clave_Empleado"]);
                    if (Dt.Columns.Contains("Numero_Proyecto_Original"))
                    {
                        if (renglon["Numero_Proyecto_Original"] == DBNull.Value)
                            proyecto.Numero_Proyecto_Original = null;
                        else
                            proyecto.Numero_Proyecto_Original = Convert.ToInt16(renglon["Numero_Proyecto_Original"]);
                    }
                    if (Dt.Columns.Contains("Eliminado"))
                        proyecto.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    proyecto.Existe = true;
                    proyectos[i] = proyecto;
                    i++;
                }
                return proyectos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Proyectos_Licencia";
                return new Proyecto_Licencia[0];
            }
        }

        #endregion Metodos

    }
}

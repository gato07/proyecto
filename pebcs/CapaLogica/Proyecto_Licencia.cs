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

        public Proyecto_Licencia(int Numero, string Folio, DateTime Fecha, string Numero_Licencia, int Escrituras,
            int Constancia_Alineamiento, int Pago_Predial, int Recibo_Agua, int Planos_Arquitectonicos,
            int Planos_Estructurales, int Planos_Instalaciones, int Memoria_Calculo, int Id_Estado_Licencia,
            int Id_Preproyecto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado) :
            base(Numero, Folio, Fecha, Numero_Licencia, Escrituras, Constancia_Alineamiento, Pago_Predial, 
                Recibo_Agua, Planos_Arquitectonicos, Planos_Estructurales, Planos_Instalaciones, 
                Memoria_Calculo, Id_Estado_Licencia, Id_Preproyecto, Id_Cliente, Clave_Inmueble, Clave_Empleado)
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

        public bool Insertar(string Folio, string Numero_Licencia, int Escrituras,
            int Constancia_Alineamiento, int Pago_Predial, int Recibo_Agua, int Planos_Arquitectonicos,
            int Planos_Estructurales, int Planos_Instalaciones, int Memoria_Calculo, int Id_Estado_Licencia,
            int Id_Preproyecto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Proyecto_Licencia, es posible que no se haya insertado"
                    + " correctamente";
                res = dtsInsertar(Folio, Numero_Licencia, Escrituras, Constancia_Alineamiento, Pago_Predial, 
                    Recibo_Agua, Planos_Arquitectonicos, Planos_Estructurales, Planos_Instalaciones, 
                    Memoria_Calculo, Id_Estado_Licencia, Id_Preproyecto, Id_Cliente, Clave_Inmueble, Clave_Empleado);
                if (res)
                    Mensaje = "El Proyecto_Licencia fue registrado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Proyecto_Licencia, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Numero, string Folio, string Numero_Licencia, int Escrituras,
            int Constancia_Alineamiento, int Pago_Predial, int Recibo_Agua, int Planos_Arquitectonicos,
            int Planos_Estructurales, int Planos_Instalaciones, int Memoria_Calculo, int Id_Estado_Licencia,
            int Id_Preproyecto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Proyecto_Licencia, es posible"
                   + " que no se hayan modificado los datos correctamente";
                res = dtsActualizar(Numero, Folio, Numero_Licencia, Escrituras, Constancia_Alineamiento, Pago_Predial,
                    Recibo_Agua, Planos_Arquitectonicos, Planos_Estructurales, Planos_Instalaciones,
                    Memoria_Calculo, Id_Estado_Licencia, Id_Preproyecto, Id_Cliente, Clave_Inmueble, Clave_Empleado);
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
                    if (Dt.Columns.Contains("Escrituras"))
                        proyecto.Escrituras = Convert.ToInt16(renglon["Escrituras"]);
                    if (Dt.Columns.Contains("Constancia_Alineamiento"))
                        proyecto.Constancia_Alineamiento = Convert.ToInt16(renglon["Constancia_Alineamiento"]);
                    if (Dt.Columns.Contains("Pago_Predial"))
                        proyecto.Pago_Predial = Convert.ToInt16(renglon["Pago_Predial"]);
                    if (Dt.Columns.Contains("Recibo_Agua"))
                        proyecto.Recibo_Agua = Convert.ToInt16(renglon["Recibo_Agua"]);
                    if (Dt.Columns.Contains("Planos_Arquitectonicos"))
                        proyecto.Planos_Arquitectonicos = Convert.ToInt16(renglon["Planos_Arquitectonicos"]);
                    if (Dt.Columns.Contains("Planos_Estructurales"))
                        proyecto.Planos_Estructurales = Convert.ToInt16(renglon["Planos_Estructurales"]);
                    if (Dt.Columns.Contains("Planos_Instalaciones"))
                        proyecto.Planos_Instalaciones = Convert.ToInt16(renglon["Planos_Instalaciones"]);
                    if (Dt.Columns.Contains("Memoria_Calculo"))
                        proyecto.Memoria_Calculo = Convert.ToInt16(renglon["Memoria_Calculo"]);
                    if (Dt.Columns.Contains("Id_Estado_Licencia"))
                        proyecto.Id_Estado_Licencia = Convert.ToInt16(renglon["Id_Estado_Licencia"]);
                    if (Dt.Columns.Contains("Id_Preproyecto"))
                        proyecto.Id_Preproyecto = Convert.ToInt16(renglon["Id_Preproyecto"]);
                    if (Dt.Columns.Contains("Id_Cliente"))
                        proyecto.Id_Cliente = Convert.ToInt16(renglon["Id_Cliente"]);
                    if (Dt.Columns.Contains("Clave_Inmueble"))
                        proyecto.Clave_Inmueble = Convert.ToInt16(renglon["Clave_Inmueble"]);
                    if (Dt.Columns.Contains("Clave_Empleado"))
                        proyecto.Clave_Empleado = Convert.ToInt16(renglon["Clave_Empleado"]);
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

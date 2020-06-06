using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Documentacion_Licencia : dtsDocumentacion_Licencia
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Documentacion_Licencia() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor de la Documentacion_Licencia";
            }
        }

        public Documentacion_Licencia(int Numero_Proyecto_Licencia, int Id_Estado_Licencia) : 
            base(Numero_Proyecto_Licencia, Id_Estado_Licencia)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor de la Documentacion_Licencia";
            }
        }

        public Documentacion_Licencia(int Numero_Proyecto_Licencia, int Id_Estado_Licencia, 
            string Nombre_Documento, DateTime Fecha, string Nota) : base(Numero_Proyecto_Licencia, 
                Id_Estado_Licencia, Nombre_Documento, Fecha, Nota)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor de la Documentacion_Licencia";
            }
        }

        public bool Insertar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia, string Nombre_Documento, 
            DateTime Fecha, string Nota)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta a la Documentacion_Licencia, es posible que no se haya insertado"
                    + " correctamente";
                res = dtsInsertar(Numero_Proyecto_Licencia, Id_Estado_Licencia, Nombre_Documento, Fecha, Nota);
                if (res)
                    Mensaje = "La Documentacion_Licencia fue registrada satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta a la Documentacion_Licencia, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia, string Nombre_Documento, 
            DateTime Fecha, string Nota)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos de la Documentacion_Licencia, es posible"
                   + " que no se hayan modificado los datos correctamente";
                res = dtsActualizar(Numero_Proyecto_Licencia, Id_Estado_Licencia, Nombre_Documento, Fecha, Nota);
                if (res)
                    Mensaje = "Los datos de la Documentacion_Licencia fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos de la Documentacion_Licencia, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación de la Documentacion_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero_Proyecto_Licencia, Id_Estado_Licencia);
                if (res)
                    Mensaje = "La Documentacion_Licencia fue eliminada satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación de la Documentacion_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación de la Documentacion_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero_Proyecto_Licencia, Id_Estado_Licencia);
                if (res)
                    Mensaje = "La Documentacion_Licencia fue activada satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación de la Documentacion_Licencia, es posible que no se haya borrado"
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todas las Documentaciones_Licencia activas";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todas las Documentaciones_Licencia eliminadas";
                return null;
            }
        }

        public Documentacion_Licencia[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Documentacion_Licencia[] documentaciones = new Documentacion_Licencia[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Documentacion_Licencia documentacion = new Documentacion_Licencia();
                    if (Dt.Columns.Contains("Numero_Proyecto_Licencia"))
                        documentacion.Numero_Proyecto_Licencia = Convert.ToInt16(renglon["Numero_Proyecto_Licencia"]);
                    if (Dt.Columns.Contains("Id_Estado_Licencia"))
                        documentacion.Id_Estado_Licencia = Convert.ToInt16(renglon["Id_Estado_Licencia"]);
                    if (Dt.Columns.Contains("Nombre_Documento"))
                        documentacion.Nombre_Documento = renglon["Nombre_Documento"].ToString();
                    if (Dt.Columns.Contains("Fecha"))
                        documentacion.Fecha = Convert.ToDateTime(renglon["Fecha"]);
                    if (Dt.Columns.Contains("Nota"))
                        documentacion.Nota = renglon["Nota"].ToString();
                    if (Dt.Columns.Contains("Eliminado"))
                        documentacion.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    documentacion.Existe = true;
                    documentaciones[i] = documentacion;
                    i++;
                }
                return documentaciones;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Documentaciones_Licencia";
                return new Documentacion_Licencia[0];
            }
        }

        #endregion Metodos

    }
}

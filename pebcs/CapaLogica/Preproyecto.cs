using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Preproyecto : dtsPreproyecto
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Preproyecto() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Preproyecto";
            }
        }

        public Preproyecto(int Id) : base(Id)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Preproyecto";
            }
        }

        public Preproyecto(int Id, string Etiqueta, string Nombre_Solicitante, string Nombre_Propietario, DateTime Fecha,
            Decimal Mts, bool Requiere_Presupuesto, int Id_Tipo_Proyecto)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Preproyecto";
            }
        }

        public bool Insertar(string Etiqueta, string Nombre_Solicitante, string Nombre_Propietario, Decimal Mts,
            bool Requiere_Presupuesto, int Id_Tipo_Proyecto)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Preproyecto, es posible que no se haya insertado"
                    + " correctamente";
                res = dtsInsertar(Etiqueta, Nombre_Solicitante, Nombre_Propietario, Mts, Requiere_Presupuesto, 
                    Id_Tipo_Proyecto);
                if (res)
                    Mensaje = "El Preproyecto fue registrado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Preproyecto, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Id, string Etiqueta, string Nombre_Solicitante, string Nombre_Propietario,
            Decimal Mts, bool Requiere_Presupuesto, int Id_Tipo_Proyecto)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Preproyecto, es posible"
                   + " que no se hayan modificado los datos correctamente";
                res = dtsActualizar(Id, Etiqueta, Nombre_Solicitante, Nombre_Propietario, Mts, Requiere_Presupuesto,
                    Id_Tipo_Proyecto);
                if (res)
                    Mensaje = "Los datos del Preproyecto fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Preproyecto, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Id)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Preproyecto, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Id);
                if (res)
                    Mensaje = "El Preproyecto fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Preproyecto, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Id)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Preproyecto, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Id);
                if (res)
                    Mensaje = "El Preproyecto fue activado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Preproyecto, es posible que no se haya borrado"
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Preproyectos activos";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Preproyectos eliminados";
                return null;
            }
        }

        public Preproyecto[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Preproyecto[] preproyectos = new Preproyecto[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Preproyecto preproyecto = new Preproyecto();
                    if (Dt.Columns.Contains("Id"))
                        preproyecto.Id = Convert.ToInt16(renglon["Id"]);
                    if (Dt.Columns.Contains("Etiqueta"))
                        preproyecto.Etiqueta = renglon["Etiqueta"].ToString();
                    if (Dt.Columns.Contains("Nombre_Solicitante"))
                        preproyecto.Nombre_Solicitante = renglon["Nombre_Solicitante"].ToString();
                    if (Dt.Columns.Contains("Nombre_Propietario"))
                        preproyecto.Nombre_Propietario = renglon["Nombre_Propietario"].ToString();
                    if (Dt.Columns.Contains("Fecha"))
                        preproyecto.Fecha = Convert.ToDateTime(renglon["Fecha"]);
                    if (Dt.Columns.Contains("Mts"))
                        preproyecto.Mts = Convert.ToDecimal(renglon["Mts"]);
                    if (Dt.Columns.Contains("Requiere_Presupuesto"))
                        preproyecto.Requiere_Presupuesto = Convert.ToBoolean(renglon["Requiere_Presupuesto"]);
                    if (Dt.Columns.Contains("Id_Tipo_Proyecto"))
                        preproyecto.Id_Tipo_Proyecto = Convert.ToInt16(renglon["Id_Tipo_Proyecto"]);
                    if (Dt.Columns.Contains("Eliminado"))
                        preproyecto.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    preproyecto.Existe = true;
                    preproyectos[i] = preproyecto;
                    i++;
                }
                return preproyectos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Preproyectos";
                return new Preproyecto[0];
            }
        }

        #endregion Metodos

    }
}

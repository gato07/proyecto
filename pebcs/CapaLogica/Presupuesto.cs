using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Presupuesto : dtsPresupuesto
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Presupuesto() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Presupuesto";
            }
        }

        public Presupuesto(int Numero) : base(Numero)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Presupuesto";
            }
        }

        public Presupuesto(int Numero, string Dirigido, decimal Total, int Aprobado, int Clave_Empleado, int Id_Preproyecto)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Presupuesto";
            }
        }

        public bool Insertar(string Dirigido, decimal Total, int Aprobado, int Clave_Empleado, int Id_Preproyecto)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Presupuesto, es posible que no se haya insertado"
                    + " correctamente";
                res = dtsInsertar(Dirigido, Total, Aprobado, Clave_Empleado, Id_Preproyecto);
                if (res)
                    Mensaje = "El Presupuesto fue registrado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Presupuesto, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Numero, string Dirigido, decimal Total, int Aprobado, int Clave_Empleado,
            int Id_Preproyecto)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Presupuesto, es posible"
                   + " que no se hayan modificado los datos correctamente";
                res = dtsActualizar(Numero, Dirigido, Total, Aprobado, Clave_Empleado, Id_Preproyecto);
                if (res)
                    Mensaje = "Los datos del Presupuesto fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Presupuesto, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero);
                if (res)
                    Mensaje = "El Presupuesto fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero);
                if (res)
                    Mensaje = "El Presupuesto fue activado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Presupuesto, es posible que no se haya borrado"
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Presupuestos activos";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Presupuestos eliminados";
                return null;
            }
        }

        public Presupuesto[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Presupuesto[] presupuestos = new Presupuesto[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Presupuesto presupuesto = new Presupuesto();
                    if (Dt.Columns.Contains("Numero"))
                        presupuesto.Numero = Convert.ToInt16(renglon["Numero"]);
                    if (Dt.Columns.Contains("Dirigido"))
                        presupuesto.Dirigido = renglon["Dirigido"].ToString();
                    if (Dt.Columns.Contains("Fecha"))
                        presupuesto.Fecha = Convert.ToDateTime(renglon["Fecha"]);
                    if (Dt.Columns.Contains("Total"))
                        presupuesto.Total = Convert.ToDecimal(renglon["Total"]);
                    if (Dt.Columns.Contains("Aprobado"))
                        presupuesto.Aprobado = Convert.ToInt16(renglon["Aprobado"]);
                    if (Dt.Columns.Contains("Clave_Empleado"))
                        presupuesto.Clave_Empleado = Convert.ToInt16(renglon["Clave_Empleado"]);
                    if (Dt.Columns.Contains("Id_Preproyecto"))
                        presupuesto.Id_Preproyecto = Convert.ToInt16(renglon["Id_Preproyecto"]);
                    if (Dt.Columns.Contains("Eliminado"))
                        presupuesto.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    presupuesto.Existe = true;
                    presupuestos[i] = presupuesto;
                    i++;
                }
                return presupuestos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Presupuestos";
                return new Presupuesto[0];
            }
        }

        #endregion Metodos

    }
}

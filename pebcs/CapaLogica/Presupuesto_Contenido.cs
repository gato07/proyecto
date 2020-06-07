using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Presupuesto_Contenido : dtsPresupuesto_Contenido
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Presupuesto_Contenido() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Presupuesto_Contenido";
            }
        }

        public Presupuesto_Contenido(int Numero_Presupuesto, int Numero_Concepto) : base(Numero_Presupuesto, Numero_Concepto)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Presupuesto_Contenido";
            }
        }

        public Presupuesto_Contenido(int Numero_Presupuesto, int Numero_Concepto, int Cantidad, decimal Total)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Presupuesto_Contenido";
            }
        }

        public bool Insertar(int Numero_Presupuesto, int Numero_Concepto, int Cantidad, decimal Total)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Presupuesto_Contenido, es posible que no se haya insertado"
                    + " correctamente";
                res = dtsInsertar(Numero_Presupuesto, Numero_Concepto, Cantidad, Total);
                if (res)
                    Mensaje = "El Presupuesto_Contenido fue registrado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Presupuesto_Contenido, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Numero_Presupuesto, int Numero_Concepto, int Cantidad, decimal Total)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Presupuesto_Contenido, es posible"
                   + " que no se hayan modificado los datos correctamente";
                res = dtsActualizar(Numero_Presupuesto, Numero_Concepto, Cantidad, Total);
                if (res)
                    Mensaje = "Los datos del Presupuesto_Contenido fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Presupuesto_Contenido, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Numero_Presupuesto, int Numero_Concepto)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Presupuesto_Contenido, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero_Presupuesto, Numero_Concepto);
                if (res)
                    Mensaje = "El Presupuesto_Contenido fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Presupuesto_Contenido, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Numero_Presupuesto, int Numero_Concepto)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Presupuesto_Contenido, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero_Presupuesto, Numero_Concepto);
                if (res)
                    Mensaje = "El Presupuesto_Contenido fue activado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Presupuesto_Contenido, es posible que no se haya borrado"
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Presupuestos_Contenido activos";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Presupuestos_Contenido eliminados";
                return null;
            }
        }

        public DataTable SelXNumPresupuesto(int Numero_Presupuesto)
        {
            try
            {
                return dtsSelXNumPresupuesto(Numero_Presupuesto);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Presupuestos_Contenido por Número del presupuesto";
                return null;
            }
        }

        public Presupuesto_Contenido[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Presupuesto_Contenido[] pre_conts = new Presupuesto_Contenido[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Presupuesto_Contenido pre_cont = new Presupuesto_Contenido();
                    if (Dt.Columns.Contains("Numero_Presupuesto"))
                        pre_cont.Numero_Presupuesto = Convert.ToInt16(renglon["Numero_Presupuesto"]);
                    if (Dt.Columns.Contains("Numero_Concepto"))
                        pre_cont.Numero_Concepto = Convert.ToInt16(renglon["Numero_Concepto"]);
                    if (Dt.Columns.Contains("Cantidad"))
                        pre_cont.Cantidad = Convert.ToInt16(renglon["Cantidad"]);
                    if (Dt.Columns.Contains("Total"))
                        pre_cont.Total = Convert.ToDecimal(renglon["Total"]);
                    if (Dt.Columns.Contains("Eliminado"))
                        pre_cont.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    pre_cont.Existe = true;
                    pre_conts[i] = pre_cont;
                    i++;
                }
                return pre_conts;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Presupuestos_Contenido";
                return new Presupuesto_Contenido[0];
            }
        }

        #endregion Metodos

    }
}

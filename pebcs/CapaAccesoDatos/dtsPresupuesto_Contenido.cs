using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsPresupuesto_Contenido
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades
        public int Numero_Presupuesto { get; set; }
        public int Numero_Concepto { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsPresupuesto_Contenido()
        {
            try
            {
                Numero_Presupuesto = 0;
                Numero_Concepto = 0;
                Costo = 0.00m;
                Cantidad = 0;
                Total = 0.00m;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsPresupuesto_Contenido(int Numero_Presupuesto, int Numero_Concepto)
        {
            try
            {
                this.Numero_Presupuesto = 0;
                this.Numero_Concepto = 0;
                Costo = 0.00m;
                Cantidad = 0;
                Total = 0.00m;
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_PresCont_SelXNumPreNumCon(" + Numero_Presupuesto
                    + "," + Numero_Concepto + ");").Tables[0];
                if (dt != null)
                {
                    this.Numero_Presupuesto = Convert.ToInt16(dt.Rows[0]["Numero_Presupuesto"]);
                    this.Numero_Concepto = Convert.ToInt16(dt.Rows[0]["Numero_Concepto"]);
                    Costo = Convert.ToDecimal(dt.Rows[0]["Costo"]);
                    Cantidad = Convert.ToInt16(dt.Rows[0]["Cantidad"]);
                    Total = Convert.ToDecimal(dt.Rows[0]["Total"]);
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsPresupuesto_Contenido(int Numero_Presupuesto, int Numero_Concepto, decimal Costo, int Cantidad, 
            decimal Total)
        {
            try
            {
                this.Numero_Presupuesto = Numero_Presupuesto;
                this.Numero_Concepto = Numero_Concepto;
                this.Costo = Costo;
                this.Cantidad = Cantidad;
                this.Total = Total;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(int Numero_Presupuesto, int Numero_Concepto, decimal Costo, int Cantidad, decimal Total)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_PresCont_Insertar(" + Numero_Presupuesto + ","
                    + Numero_Concepto + "," + Costo + "," + Cantidad + "," + Total + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Numero_Presupuesto, int Numero_Concepto, decimal Costo, int Cantidad, decimal Total)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_PresCont_Actualizar(" + Numero_Presupuesto + ","
                    + Numero_Concepto + "," + Costo + "," + Cantidad + "," + Total + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsEliminar(int Numero_Presupuesto, int Numero_Concepto)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_PresCont_Eliminar(" + Numero_Presupuesto + "," 
                    + Numero_Concepto + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActivar(int Numero_Presupuesto, int Numero_Concepto)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_PresCont_Activar(" + Numero_Presupuesto + ","
                    + Numero_Concepto + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable dtsSelXCampoEliminado(bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_PresCont_SelXCampoEliminado("
                    + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelXNumPresupuesto(int Numero_Presupuesto)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_PresCont_SelXNumPresupuesto("
                    + Numero_Presupuesto + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion Metodos

    }
}

using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsPresupuesto
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades
        public int Numero { get; set; }
        public string Dirigido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int Aprobado { get; set; }
        public int Clave_Empleado { get; set; }
        public int Id_Preproyecto { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsPresupuesto()
        {
            try
            {
                Numero = 0;
                Dirigido = "";
                Fecha = new DateTime();
                Total = 0.00m;
                Aprobado = 0;
                Clave_Empleado = 0;
                Id_Preproyecto = 0;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsPresupuesto(int Numero)
        {
            try
            {
                this.Numero = 0;
                Dirigido = "";
                Fecha = new DateTime();
                Total = 0.00m;
                Aprobado = 0;
                Clave_Empleado = 0;
                Id_Preproyecto = 0;
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Presupuesto_SelXNumero(" + Numero + ");").Tables[0];
                if (dt != null)
                {
                    this.Numero = Convert.ToInt16(dt.Rows[0]["Numero"]);
                    Dirigido = dt.Rows[0]["Dirigido"].ToString();
                    Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                    Total = Convert.ToDecimal(dt.Rows[0]["Total"]);
                    Aprobado = Convert.ToInt16(dt.Rows[0]["Aprobado"]);
                    Clave_Empleado = Convert.ToInt16(dt.Rows[0]["Clave_Empleado"]);
                    Id_Preproyecto = Convert.ToInt16(dt.Rows[0]["Id_Preproyecto"]);
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsPresupuesto(int Numero, string Dirigido, decimal Total, int Aprobado, int Clave_Empleado, int Id_Preproyecto)
        {
            try
            {
                this.Numero = Numero;
                this.Dirigido = Dirigido;
                this.Total = Total;
                this.Aprobado = Aprobado;
                this.Clave_Empleado = Clave_Empleado;
                this.Id_Preproyecto = Id_Preproyecto;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(string Dirigido, decimal Total, int Aprobado, int Clave_Empleado, int Id_Preproyecto)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Presupuesto_Insertar('" + Dirigido + "',"
                    + Total + "," + Aprobado + "," + Clave_Empleado + "," + Id_Preproyecto + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Numero, string Dirigido, decimal Total, int Aprobado, int Clave_Empleado, 
            int Id_Preproyecto)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Presupuesto_Actualizar(" + Numero + ",'" + Dirigido + "',"
                    + Total + "," + Aprobado + "," + Clave_Empleado + "," + Id_Preproyecto + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsEliminar(int Numero)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Presupuesto_Eliminar(" + Numero + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActivar(int Numero)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Presupuesto_Activar(" + Numero + ");");
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
                dt = conexion.Consulta_Seleccion("CALL SP_Presupuesto_SelXCampoEliminado("
                    + Eliminado + ");").Tables[0];
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

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
        public string Etiqueta { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre_Solicitante { get; set; }
        public string Nombre_Propietario { get; set; }
        public decimal Mts { get; set; }
        public decimal Total { get; set; }
        public int Aprobado { get; set; }
        public int Id_Tipo_Proyecto { get; set; }
        public int Clave_Empleado { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsPresupuesto()
        {
            try
            {
                Numero = 0;
                Etiqueta = "";
                Fecha = new DateTime();
                Nombre_Solicitante = "";
                Nombre_Propietario = "";
                Mts = 0.00m;
                Total = 0.00m;
                Aprobado = 0;
                Id_Tipo_Proyecto = 0;
                Clave_Empleado = 0;
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
                Etiqueta = "";
                Fecha = new DateTime();
                Nombre_Solicitante = "";
                Nombre_Propietario = "";
                Mts = 0.00m;
                Total = 0.00m;
                Aprobado = 0;
                Id_Tipo_Proyecto = 0;
                Clave_Empleado = 0;
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Presupuesto_SelXNumero(" 
                    + Numero + ");").Tables[0];
                if (dt != null)
                {
                    this.Numero = Convert.ToInt16(dt.Rows[0]["Numero"]);
                    Etiqueta = dt.Rows[0]["Etiqueta"].ToString();
                    Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                    Nombre_Solicitante = dt.Rows[0]["Nombre_Solicitante"].ToString();
                    Nombre_Propietario = dt.Rows[0]["Nombre_Propietario"].ToString();
                    Mts = Convert.ToDecimal(dt.Rows[0]["Mts"]);
                    Total = Convert.ToDecimal(dt.Rows[0]["Total"]);
                    Aprobado = Convert.ToInt16(dt.Rows[0]["Aprobado"]);
                    Id_Tipo_Proyecto = Convert.ToInt16(dt.Rows[0]["Id_Tipo_Proyecto"]);
                    Clave_Empleado = Convert.ToInt16(dt.Rows[0]["Clave_Empleado"]);
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsPresupuesto(int Numero, string Etiqueta, DateTime Fecha, string Nombre_Solicitante, 
            string Nombre_Propietario, decimal Mts, decimal Total, int Aprobado, int Id_Tipo_Proyecto, 
            int Clave_Empleado)
        {
            try
            {
                this.Numero = Numero;
                this.Etiqueta = Etiqueta;
                this.Fecha = Fecha;
                this.Nombre_Solicitante = Nombre_Solicitante;
                this.Nombre_Propietario = Nombre_Propietario;
                this.Mts = Mts;
                this.Total = Total;
                this.Aprobado = Aprobado;
                this.Id_Tipo_Proyecto = Id_Tipo_Proyecto;
                this.Clave_Empleado = Clave_Empleado;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public int dtsInsertar(string Etiqueta, string Nombre_Solicitante, string Nombre_Propietario, 
            decimal Mts, decimal Total, int Aprobado, int Id_Tipo_Proyecto, int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Presupuesto_Insertar('" + Etiqueta + "','"
                    + Nombre_Solicitante + "','" + Nombre_Propietario + "'," + Mts + "," + Total + "," + Aprobado
                    + "," + Id_Tipo_Proyecto + "," + Clave_Empleado + ");").Tables[0];
                if (dt != null)
                    res = Convert.ToInt16(dt.Rows[0]["Ultimo_Id"]);
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool dtsActualizar(int Numero, string Etiqueta, string Nombre_Solicitante,
            string Nombre_Propietario, decimal Mts, decimal Total, int Aprobado, int Id_Tipo_Proyecto)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Presupuesto_Actualizar(" + Numero + ",'" + Etiqueta + "','"
                    + Nombre_Solicitante + "','" + Nombre_Propietario + "'," + Mts + "," + Total + "," + Aprobado
                    + "," + Id_Tipo_Proyecto + ");");
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

        public bool dtsDepurar(int Numero)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Presupuesto_Depurar(" + Numero + ");");
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

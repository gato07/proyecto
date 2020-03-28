using System;
using System.Data;

namespace CapaAccesoDatos
{
    public class dtsConcepto
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Numero { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsConcepto()
        {
            try
            {
                Numero = 0;
                Tipo = "";
                Nombre = "";
                Descripcion = "";
                Costo = 0.00m;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsConcepto(int Numero)
        {
            try
            {
                this.Numero = 0;
                Tipo = "";
                Nombre = "";
                Descripcion = "";
                Costo = 0.00m;
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Concepto_SelXNumero(" + Numero + ");").Tables[0];
                if (dt != null)
                {
                    this.Numero = Convert.ToInt16(dt.Rows[0]["Numero"]);
                    Tipo = dt.Rows[0]["Tipo"].ToString();
                    Nombre = dt.Rows[0]["Nombre"].ToString();
                    Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    Costo = Convert.ToDecimal(dt.Rows[0]["Costo"]);
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsConcepto(int Numero, string Tipo, string Nombre, string Descripcion, decimal Costo)
        {
            try
            {
                this.Numero = Numero;
                this.Tipo = Tipo;
                this.Nombre = Nombre;
                this.Descripcion = Descripcion;
                this.Costo = Costo;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(string Tipo, string Nombre, string Descripcion, decimal Costo)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Concepto_Insert('" + Tipo + "','"
                    + Nombre + "','" + Descripcion + "'," + Costo + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Numero, string Tipo, string Nombre, string Descripcion, decimal Costo)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Concepto_Update(" + Numero +  ",'" + Tipo + "','"
                    + Nombre + "','" + Descripcion + "'," + Costo + ");");
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
                res = conexion.Consulta_Accion("CALL SP_Concepto_Eliminar(" + Numero + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable dtsSelTodos()
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_Concepto_Select();").Tables[0];
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

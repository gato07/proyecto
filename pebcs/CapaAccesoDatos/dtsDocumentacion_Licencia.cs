using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsDocumentacion_Licencia
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Numero_Proyecto_Licencia { get; set; }
        public int Tipo_Documento { get; set; }
        public string Nombre_Documento { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public string Nota_Fecha_Ingreso { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public string Nota_Fecha_Pago { get; set; }
        public DateTime Fecha_Recibido { get; set; }
        public string Nota_Fecha_Recibido { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsDocumentacion_Licencia()
        {
            try
            {
                Numero_Proyecto_Licencia = 0;
                Tipo_Documento = 0;
                Nombre_Documento = "";
                Fecha_Ingreso = new DateTime();
                Nota_Fecha_Ingreso = "";
                Fecha_Pago = new DateTime();
                Nota_Fecha_Pago = "";
                Fecha_Recibido = new DateTime();
                Nota_Fecha_Recibido = "";
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsDocumentacion_Licencia(int Numero_Proyecto_Licencia, int Tipo_Documento)
        {
            try
            {
                this.Numero_Proyecto_Licencia = 0;
                this.Tipo_Documento = 0;
                Nombre_Documento = "";
                Fecha_Ingreso = new DateTime();
                Nota_Fecha_Ingreso = "";
                Fecha_Pago = new DateTime();
                Nota_Fecha_Pago = "";
                Fecha_Recibido = new DateTime();
                Nota_Fecha_Recibido = "";
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_DocuLice_SelXNumProLicTipDoc(" + 
                    Numero_Proyecto_Licencia + "," + Tipo_Documento + ");").Tables[0];
                if (dt != null)
                {
                    this.Numero_Proyecto_Licencia = Convert.ToInt16(dt.Rows[0]["Numero_Proyecto_Licencia"]);
                    this.Tipo_Documento = Convert.ToInt16(dt.Rows[0]["Tipo_Documento"]);
                    Nombre_Documento = dt.Rows[0]["Nombre_Documento"].ToString();
                    Fecha_Ingreso = Convert.ToDateTime(dt.Rows[0]["Fecha_Ingreso"]);
                    Nota_Fecha_Ingreso = dt.Rows[0]["Nota_Fecha_Ingreso"].ToString();
                    Fecha_Pago = Convert.ToDateTime(dt.Rows[0]["Fecha_Pago"]);
                    Nota_Fecha_Pago = dt.Rows[0]["Nota_Fecha_Pago"].ToString();
                    Fecha_Recibido = Convert.ToDateTime(dt.Rows[0]["Fecha_Recibido"]);
                    Nota_Fecha_Recibido = dt.Rows[0]["Nota_Fecha_Recibido"].ToString();
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsDocumentacion_Licencia(int Numero_Proyecto_Licencia, int Tipo_Documento, string Nombre_Documento, 
            DateTime Fecha_Ingreso, string Nota_Fecha_Ingreso, DateTime Fecha_Pago, string Nota_Fecha_Pago, 
            DateTime Fecha_Recibido, string Nota_Fecha_Recibido)
        {
            try
            {
                this.Numero_Proyecto_Licencia = Numero_Proyecto_Licencia;
                this.Tipo_Documento = Tipo_Documento;
                this.Nombre_Documento = Nombre_Documento;
                this.Fecha_Ingreso = Fecha_Ingreso;
                this.Nota_Fecha_Ingreso = Nota_Fecha_Ingreso;
                this.Fecha_Pago = Fecha_Pago;
                this.Nota_Fecha_Pago = Nota_Fecha_Pago;
                this.Fecha_Recibido = Fecha_Recibido;
                this.Nota_Fecha_Recibido = Nota_Fecha_Recibido;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(int Numero_Proyecto_Licencia, int Tipo_Documento, string Nombre_Documento,
            DateTime Fecha_Ingreso, string Nota_Fecha_Ingreso, DateTime Fecha_Pago, string Nota_Fecha_Pago,
            DateTime Fecha_Recibido, string Nota_Fecha_Recibido)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DocuLice_Insertar(" + Numero_Proyecto_Licencia 
                    + "," + Tipo_Documento + ",'" + Nombre_Documento + "','" + Fecha_Ingreso.ToString("yyyy-MM-dd") 
                    + "','" + Nota_Fecha_Ingreso + "','" + Fecha_Pago.ToString("yyyy-MM-dd") + "','" 
                    + Nota_Fecha_Pago + "','" + Fecha_Recibido.ToString("yyyy-MM-dd") + "','" 
                    + Nota_Fecha_Recibido + "');");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Numero_Proyecto_Licencia, int Tipo_Documento, string Nombre_Documento,
            DateTime Fecha_Ingreso, string Nota_Fecha_Ingreso, DateTime Fecha_Pago, string Nota_Fecha_Pago,
            DateTime Fecha_Recibido, string Nota_Fecha_Recibido)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DocuLice_Actualizar(" + Numero_Proyecto_Licencia
                    + "," + Tipo_Documento + ",'" + Nombre_Documento + "','" + Fecha_Ingreso.ToString("yyyy-MM-dd")
                    + "','" + Nota_Fecha_Ingreso + "','" + Fecha_Pago.ToString("yyyy-MM-dd") + "','"
                    + Nota_Fecha_Pago + "','" + Fecha_Recibido.ToString("yyyy-MM-dd") + "','"
                    + Nota_Fecha_Recibido + "');");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsEliminar(int Numero_Proyecto_Licencia, int Tipo_Documento)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DocuLice_Eliminar(" + Numero_Proyecto_Licencia 
                    + "," + Tipo_Documento + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActivar(int Numero_Proyecto_Licencia, int Tipo_Documento)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DocuLice_Activar(" + Numero_Proyecto_Licencia
                    + "," + Tipo_Documento + ");");
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
                dt = conexion.Consulta_Seleccion("CALL SP_DocuLice_SelXCampoEliminado("
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

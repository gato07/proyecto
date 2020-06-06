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
        public int Id_Estado_Licencia { get; set; }
        public string Nombre_Documento { get; set; }
        public DateTime Fecha { get; set; }
        public string Nota { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsDocumentacion_Licencia()
        {
            try
            {
                Numero_Proyecto_Licencia = 0;
                Id_Estado_Licencia = 0;
                Nombre_Documento = "";
                Fecha = new DateTime();
                Nota = "";
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsDocumentacion_Licencia(int Numero_Proyecto_Licencia, int Id_Estado_Licencia)
        {
            try
            {
                this.Numero_Proyecto_Licencia = 0;
                this.Id_Estado_Licencia = 0;
                Nombre_Documento = "";
                Fecha = new DateTime();
                Nota = "";
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_DocuLice_SelXNumProLicIdEstLic(" + 
                    Numero_Proyecto_Licencia + "," + Id_Estado_Licencia + ");").Tables[0];
                if (dt != null)
                {
                    this.Numero_Proyecto_Licencia = Convert.ToInt16(dt.Rows[0]["Numero_Proyecto_Licencia"]);
                    this.Id_Estado_Licencia = Convert.ToInt16(dt.Rows[0]["Id_Estado_Licencia"]);
                    Nombre_Documento = dt.Rows[0]["Nombre_Documento"].ToString();
                    Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                    Nota = dt.Rows[0]["Nota"].ToString();
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsDocumentacion_Licencia(int Numero_Proyecto_Licencia, int Id_Estado_Licencia, 
            string Nombre_Documento, DateTime Fecha, string Nota)
        {
            try
            {
                this.Numero_Proyecto_Licencia = Numero_Proyecto_Licencia;
                this.Id_Estado_Licencia = Id_Estado_Licencia;
                this.Nombre_Documento = Nombre_Documento;
                this.Fecha = Fecha;
                this.Nota = Nota;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia,
            string Nombre_Documento, DateTime Fecha, string Nota)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DocuLice_Insertar(" + Numero_Proyecto_Licencia 
                    + "," + Id_Estado_Licencia + ",'" + Nombre_Documento + "','" + Fecha.ToString("yyyy-MM-dd")
                    + "','" + Nota + "');");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia,
            string Nombre_Documento, DateTime Fecha, string Nota)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DocuLice_Actualizar(" + Numero_Proyecto_Licencia
                    + "," + Id_Estado_Licencia + ",'" + Nombre_Documento + "','" + Fecha.ToString("yyyy-MM-dd")
                    + "','" + Nota + "');");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsEliminar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DocuLice_Eliminar(" + Numero_Proyecto_Licencia 
                    + "," + Id_Estado_Licencia + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActivar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DocuLice_Activar(" + Numero_Proyecto_Licencia
                    + "," + Id_Estado_Licencia + ");");
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

using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsPreproyecto
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Id { get; set; }
        public string Etiqueta { get; set; }
        public string Nombre_Solicitante { get; set; }
        public string Nombre_Propietario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Mts { get; set; }
        public bool Requiere_Presupuesto { get; set; }
        public int Id_Tipo_Proyecto { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsPreproyecto()
        {
            try
            {
                Id = 0;
                Etiqueta = "";
                Nombre_Solicitante = "";
                Nombre_Propietario = "";
                Fecha = new DateTime();
                Mts = 0.00m;
                Requiere_Presupuesto = true;
                Id_Tipo_Proyecto = 0;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsPreproyecto(int Id)
        {
            try
            {
                this.Id = 0;
                Etiqueta = "";
                Nombre_Solicitante = "";
                Nombre_Propietario = "";
                Fecha = new DateTime();
                Mts = 0.00m;
                Requiere_Presupuesto = true;
                Id_Tipo_Proyecto = 0;
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Preproyecto_SelXId(" + Id + ");").Tables[0];
                if (dt != null)
                {
                    this.Id = Convert.ToInt16(dt.Rows[0]["Id"]);
                    Etiqueta = dt.Rows[0]["Etiqueta"].ToString();
                    Nombre_Solicitante = dt.Rows[0]["Nombre_Solicitante"].ToString();
                    Nombre_Propietario = dt.Rows[0]["Nombre_Propietario"].ToString();
                    Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                    Mts = Convert.ToDecimal(dt.Rows[0]["Mts"]);
                    Requiere_Presupuesto = Convert.ToBoolean(dt.Rows[0]["Requiere_Presupuesto"]);
                    Id_Tipo_Proyecto = Convert.ToInt16(dt.Rows[0]["Id_Tipo_Proyecto"]);
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsPreproyecto(int Id, string Etiqueta, string Nombre_Solicitante, string Nombre_Propietario, DateTime Fecha,
            Decimal Mts, bool Requiere_Presupuesto, int Id_Tipo_Proyecto)
        {
            try
            {
                this.Id = Id;
                this.Etiqueta = Etiqueta;
                this.Nombre_Solicitante = Nombre_Solicitante;
                this.Nombre_Propietario = Nombre_Propietario;
                this.Fecha = Fecha;
                this.Mts = Mts;
                this.Requiere_Presupuesto = Requiere_Presupuesto;
                this.Id_Tipo_Proyecto = Id_Tipo_Proyecto;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(string Etiqueta, string Nombre_Solicitante, string Nombre_Propietario, Decimal Mts, 
            bool Requiere_Presupuesto, int Id_Tipo_Proyecto)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Preproyecto_Insertar('" + Etiqueta + "','"
                    + Nombre_Solicitante + "','" + Nombre_Propietario + "'," + Mts + "," + Requiere_Presupuesto +
                    "," + Id_Tipo_Proyecto + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Id, string Etiqueta, string Nombre_Solicitante, string Nombre_Propietario, 
            Decimal Mts, bool Requiere_Presupuesto, int Id_Tipo_Proyecto)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Preproyecto_Actualizar(" + Id + ",'" + Etiqueta + "','"
                    + Nombre_Solicitante + "','" + Nombre_Propietario + "'," + Mts + "," 
                    + Requiere_Presupuesto + "," + Id_Tipo_Proyecto + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsEliminar(int Id)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Preproyecto_Eliminar(" + Id + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActivar(int Id)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Preproyecto_Activar(" + Id + ");");
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
                dt = conexion.Consulta_Seleccion("CALL SP_Preproyecto_SelXCampoEliminado("
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

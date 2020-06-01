using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsEstado_Licencia
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Id { get; set; }
        public int Proceso { get; set; }
        public int Subproceso { get; set; }
        public string Nombre { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsEstado_Licencia()
        {
            try
            {
                Id = 0;
                Proceso = 0;
                Subproceso = 0;
                Nombre = "";
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsEstado_Licencia(int Id)
        {
            try
            {
                this.Id = 0;
                Proceso = 0;
                Subproceso = 0;
                Nombre = "";
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_EstadoLicencia_SelXId(" + Id + ");").Tables[0];
                if (dt != null)
                {
                    this.Id = Convert.ToInt16(dt.Rows[0]["Id"]);
                    Proceso = Convert.ToInt16(dt.Rows[0]["Proceso"]);
                    Subproceso = Convert.ToInt16(dt.Rows[0]["Subproceso"]);
                    Nombre = dt.Rows[0]["Nombre"].ToString();
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsEstado_Licencia(int Id, int Proceso, int Subproceso, string Nombre)
        {
            try
            {
                this.Id = Id;
                this.Proceso = Proceso;
                this.Subproceso = Subproceso;
                this.Nombre = Nombre;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(int Proceso, int Subproceso, string Nombre)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_EstadoLicencia_Insertar(" + Proceso + "," + Subproceso 
                    + ",'" + Nombre + "');");
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
                dt = conexion.Consulta_Seleccion("CALL SP_EstadoLicencia_SelTodos();").Tables[0];
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

using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsPermiso
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Perfil { get; set; }
        public string Proceso { get; set; }
        public string Subproceso { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsPermiso()
        {
            try
            {
                Perfil = 0;
                Proceso = "";
                Subproceso = "";
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsPermiso(int Perfil, string Proceso, string Subproceso)
        {
            try
            {
                this.Perfil = Perfil;
                this.Proceso = Proceso;
                this.Subproceso = Subproceso;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable dtsSelXPerfil(int Perfil)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_Permiso_SelXPerfil(" + Perfil + ");").Tables[0];
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

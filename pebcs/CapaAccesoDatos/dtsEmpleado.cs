using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsEmpleado
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public int Perfil { get; set; }
        public string Usuario { get; set; }
        /*public string Contrasena { get; set; }*/
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }
        public string Perfil_Texto
        {
            get
            {
                switch(Perfil)
                {
                    default: return "";
                    case 1: return "Administrador";
                    case 2: return "Arquitecto";
                    case 3: return "Ingeniero";
                    case 4: return "Recepcionista";
                }
            }
        }

        #endregion Propiedades

        #region Metodos

        public dtsEmpleado()
        {
            try
            {
                Clave = 0;
                Nombre = "";
                Domicilio = "";
                Telefono = "";
                Email = "";
                Foto = "";
                Perfil = 0;
                Usuario = "";
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsEmpleado(int Clave)
        {
            try
            {
                this.Clave = 0;
                Nombre = "";
                Domicilio = "";
                Telefono = "";
                Email = "";
                Foto = "";
                Perfil = 0;
                Usuario = "";
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Empleado_SelXClave(" + Clave + ");").Tables[0];
                if (dt != null)
                {
                    this.Clave = Convert.ToInt16(dt.Rows[0]["Clave"]);
                    Nombre = dt.Rows[0]["Nombre"].ToString();
                    Domicilio = dt.Rows[0]["Domicilio"].ToString();
                    Telefono = dt.Rows[0]["Telefono"].ToString();
                    Email = dt.Rows[0]["Email"].ToString();
                    Foto = dt.Rows[0]["Foto"].ToString();
                    Perfil = Convert.ToInt16(dt.Rows[0]["Perfil"]);
                    Usuario = dt.Rows[0]["Usuario"].ToString();
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsEmpleado(int Clave, string Nombre, string Domicilio, string Telefono, string Email,
            string Foto, int Perfil, string Usuario)
        {
            try
            {
                this.Clave = Clave;
                this.Nombre = Nombre;
                this.Domicilio = Domicilio;
                this.Telefono = Telefono;
                this.Email = Email;
                this.Foto = Foto;
                this.Perfil = Perfil;
                this.Usuario = Usuario;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(string Nombre, string Domicilio, string Telefono, string Email, 
            string Foto, int Perfil, string Usuario, string Contrasena)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Empleado_Insertar('" + Nombre + "','" 
                    + Domicilio + "','" + Telefono + "','" + Email + "','"  + Foto + "'," 
                    + Perfil + ",'" + Usuario + "','" + Contrasena + "');");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Clave, string Nombre, string Domicilio, string Telefono, string Email, 
            string Foto, int Perfil, string Usuario, string Contrasena)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Empleado_Actualizar(" + Clave + ",'" + Nombre + "','"
                    + Domicilio + "','" + Telefono + "','" + Email + "','" + Foto + "',"
                    + Perfil + ",'" + Usuario + "','" + Contrasena + "');");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsEliminar(int Clave)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Empleado_Eliminar(" + Clave + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActivar(int Clave)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Empleado_Activar(" + Clave + ");");
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
                dt = conexion.Consulta_Seleccion("CALL SP_Empleado_SelXCampoEliminado("+ Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string dtsSelContrasenaXClave(int Clave)
        {
            try
            {
                string contrasena = "";
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Empleado_SelConXClave(" 
                    + Clave + ");").Tables[0];
                if (dt != null)
                    contrasena = dt.Rows[0]["Contrasena"].ToString();
                conexion.Desconectar();
                return contrasena;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public void dtsSelXUsuario(string Usuario)
        {
            try
            {
                Clave = 0;
                Nombre = "";
                Domicilio = "";
                Telefono = "";
                Email = "";
                Foto = "";
                Perfil = 0;
                this.Usuario = "";
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Empleado_SelXUsuario('" + Usuario + "');").Tables[0];
                if (dt != null)
                {
                    Clave = Convert.ToInt16(dt.Rows[0]["Clave"].ToString());
                    Nombre = dt.Rows[0]["Nombre"].ToString();
                    Domicilio = dt.Rows[0]["Domicilio"].ToString();
                    Telefono = dt.Rows[0]["Telefono"].ToString();
                    Email = dt.Rows[0]["Email"].ToString();
                    Foto = dt.Rows[0]["Foto"].ToString();
                    Perfil = Convert.ToInt16(dt.Rows[0]["Perfil"].ToString());
                    this.Usuario = dt.Rows[0]["Usuario"].ToString();
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable dtsSelLikeUsuario(string Usuario, bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_Empleado_SelLikeUsuario('" + Usuario + "'," 
                    + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelLikeNombre(string Nombre, bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_Empleado_SelLikeNombre('" + Nombre + "',"
                    + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelLikeEmail(string Email, bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_Empleado_SelLikeEmail('" + Email + "',"
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

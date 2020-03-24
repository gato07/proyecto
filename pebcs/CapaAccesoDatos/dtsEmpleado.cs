using System;
using System.Data;

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
        public string Puesto { get; set; }
        public string Foto { get; set; }
        public int Perfil { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool Existe { get; set; }
        public string Perfil_Texto
        {
            get
            {
                switch(Perfil)
                {
                    default: return "";  break;
                    case 1: return "Administrador"; break;
                    case 2: return "Arquitecto"; break;
                    case 3: return "Ingeniero"; break;
                    case 4: return "Recepcionista"; break;
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
                Puesto = "";
                Foto = "";
                Perfil = 0;
                Usuario = "";
                Contrasena = "";
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
                Puesto = "";
                Foto = "";
                Perfil = 0;
                Usuario = "";
                Contrasena = "";
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Empleado_SelXClave(" + Clave + ");").Tables[0];
                if (dt != null)
                {
                    this.Clave = Convert.ToInt16(dt.Rows[0]["Clave"].ToString());
                    Nombre = dt.Rows[0]["Nombre"].ToString();
                    Domicilio = dt.Rows[0]["Domicilio"].ToString();
                    Telefono = dt.Rows[0]["Telefono"].ToString();
                    Email = dt.Rows[0]["Email"].ToString();
                    Puesto = dt.Rows[0]["Puesto"].ToString();
                    Foto = dt.Rows[0]["Foto"].ToString();
                    Perfil = Convert.ToInt16(dt.Rows[0]["Perfil"].ToString());
                    Usuario = dt.Rows[0]["Usuario"].ToString();
                    Contrasena = dt.Rows[0]["Contrasena"].ToString();
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsEmpleado(int Clave, string Nombre, string Domicilio, string Telefono, string Email, 
            string Puesto, string Foto, int Perfil, string Usuario, string Contrasena)
        {
            try
            {
                this.Clave = Clave;
                this.Nombre = Nombre;
                this.Domicilio = Domicilio;
                this.Telefono = Telefono;
                this.Email = Email;
                this.Puesto = Puesto;
                this.Foto = Foto;
                this.Perfil = Perfil;
                this.Usuario = Usuario;
                this.Contrasena = Contrasena;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(string Nombre, string Domicilio, string Telefono, string Email, 
            string Puesto, string Foto, int Perfil, string Usuario, string Contrasena)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Empleado_Insert('" + Nombre + "','" 
                    + Domicilio + "','" + Telefono + "','" + Email + "','" + Puesto + "','" + Foto + "'," 
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
            string Puesto, string Foto, int Perfil, string Usuario, string Contrasena)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Empleado_Update(" + Clave + ",'" + Nombre + "','"
                    + Domicilio + "','" + Telefono + "','" + Email + "','" + Puesto + "','" + Foto + "',"
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
                res = conexion.Consulta_Accion("CALL SP_Empleado_Delete(" + Clave + ");");
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
                dt = conexion.Consulta_Seleccion("CALL SP_Empleado_Select();").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
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
                Puesto = "";
                Foto = "";
                Perfil = 0;
                this.Usuario = "";
                Contrasena = "";
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
                    Puesto = dt.Rows[0]["Puesto"].ToString();
                    Foto = dt.Rows[0]["Foto"].ToString();
                    Perfil = Convert.ToInt16(dt.Rows[0]["Perfil"].ToString());
                    this.Usuario = dt.Rows[0]["Usuario"].ToString();
                    Contrasena = dt.Rows[0]["Contrasena"].ToString();
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Metodos

    }
}

using System;
using System.Data;
using System.Text;


namespace CapaAccesoDatos
{
    public class dtsCliente
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Id { get; set; }
        //public string Rfc { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsCliente()
        {
            try
            {
                Id = 0;
                //Rfc = "";
                Nombre = "";
                Apellido = "";
                Telefono = "";
                Email = "";
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsCliente(int Id)
        {
            try
            {
                this.Id = 0;
                //Rfc = "";
                Nombre = "";
                Apellido = "";
                Telefono = "";
                Email = "";
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Cliente_SelXId(" + Id + ");").Tables[0];
                if (dt != null)
                {
                    this.Id = Convert.ToInt16(dt.Rows[0]["Id"]);
                    //Rfc = dt.Rows[0]["Rfc"].ToString();
                    Nombre = dt.Rows[0]["Nombre"].ToString();
                    Apellido = dt.Rows[0]["Apellido"].ToString();
                    Telefono = dt.Rows[0]["Telefono"].ToString();
                    Email = dt.Rows[0]["Email"].ToString();
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsCliente(int Id/*, string Rfc*/, string Nombre, string Apellido, string Telefono, string Email)
        {
            try
            {
                this.Id = Id;
                //this.Rfc = Rfc;
                this.Nombre = Nombre;
                this.Apellido = Apellido;
                this.Telefono = Telefono;
                this.Email = Email;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(/*string Rfc,*/ string Nombre, string Apellido, string Telefono, string Email)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Cliente_Insertar('" + Nombre + "','"
                    + Apellido + "','" + Telefono + "','" + Email + "');");
                /*res = conexion.Consulta_Accion("CALL SP_Cliente_Insert('" + Rfc + "','" + Nombre + "','"
                    + Apellido + "','" + Telefono + "','" + Email + "');");*/
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Id, string Nombre, string Apellido, string Telefono, string Email)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Cliente_Actualizar(" + Id + ",'" + Nombre + "','"
                    + Apellido + "','" + Telefono + "','" + Email + "');");
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
                res = conexion.Consulta_Accion("CALL SP_Cliente_Eliminar(" + Id + ");");
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
                res = conexion.Consulta_Accion("CALL SP_Cliente_Activar(" + Id + ");");
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
                dt = conexion.Consulta_Seleccion("CALL SP_Cliente_SelXCampoEliminado(" + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /*public void dtsSelXRfc(string Rfc)
        {
            try
            {
                Id = 0;
                this.Rfc = "";
                Nombre = "";
                Apellido = "";
                Telefono = "";
                Email = "";
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Cliente_SelXRfc(" + Id + ");").Tables[0];
                if (dt != null)
                {
                    Id = Convert.ToInt16(dt.Rows[0]["Id"]);
                    this.Rfc = dt.Rows[0]["Rfc"].ToString();
                    Nombre = dt.Rows[0]["Nombre"].ToString();
                    Apellido = dt.Rows[0]["Apellido"].ToString();
                    Telefono = dt.Rows[0]["Telefono"].ToString();
                    Email = dt.Rows[0]["Email"].ToString();
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }*/

        #endregion Metodos
    }
}

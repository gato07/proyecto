using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsInmueble
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Clave { get; set; }
        public string Clave_Catastral { get; set; }
        public string Nombre_Propietario { get; set; }
        public string Telefono_Propietario { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string Entre_Calles { get; set; }
        public string Numero_Interior { get; set; }
        public string Numero_Exterior { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsInmueble()
        {
            try
            {
                Clave = 0;
                Clave_Catastral = "";
                Nombre_Propietario = "";
                Telefono_Propietario = "";
                Colonia = "";
                Calle = "";
                Entre_Calles = "";
                Numero_Interior = "";
                Numero_Exterior = "";
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsInmueble(int Clave)
        {
            try
            {
                this.Clave = 0;
                Clave_Catastral = "";
                Nombre_Propietario = "";
                Telefono_Propietario = "";
                Colonia = "";
                Calle = "";
                Entre_Calles = "";
                Numero_Interior = "";
                Numero_Exterior = "";
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Inmueble_SelXClave(" + Clave + ");").Tables[0];
                if (dt != null)
                {
                    this.Clave = Convert.ToInt16(dt.Rows[0]["Clave"]);
                    Clave_Catastral = dt.Rows[0]["Clave_Catastral"].ToString();
                    Nombre_Propietario = dt.Rows[0]["Nombre_Propietario"].ToString();
                    Telefono_Propietario = dt.Rows[0]["Telefono_Propietario"].ToString();
                    Colonia = dt.Rows[0]["Colonia"].ToString();
                    Calle = dt.Rows[0]["Calle"].ToString();
                    Entre_Calles = dt.Rows[0]["Entre_Calles"].ToString();
                    Numero_Interior = dt.Rows[0]["Numero_Interior"].ToString();
                    Numero_Exterior = dt.Rows[0]["Numero_Exterior"].ToString();
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsInmueble(int Clave, string Clave_Catastral, string Nombre_Propietario, string Telefono_Propietario, 
            string Colonia, string Calle, string Entre_Calles, string Numero_Interior, string Numero_Exterior)
        {
            try
            {
                this.Clave = Clave;
                this.Clave_Catastral = Clave_Catastral;
                this.Nombre_Propietario = Nombre_Propietario;
                this.Telefono_Propietario = Telefono_Propietario;
                this.Colonia = Colonia;
                this.Calle = Calle;
                this.Entre_Calles = Entre_Calles;
                this.Numero_Interior = Numero_Interior;
                this.Numero_Exterior = Numero_Exterior;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(string Clave_Catastral, string Nombre_Propietario, string Telefono_Propietario,
            string Colonia, string Calle, string Entre_Calles, string Numero_Interior, string Numero_Exterior)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Inmueble_Insertar('" + Clave_Catastral + "','"
                    + Nombre_Propietario + "','" + Telefono_Propietario + "','" + Colonia + "','" + Calle + 
                    "','" + Entre_Calles + "','" + Numero_Interior + "','" + Numero_Exterior + "');");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Clave, string Clave_Catastral, string Nombre_Propietario, 
            string Telefono_Propietario, string Colonia, string Calle, string Entre_Calles, 
            string Numero_Interior, string Numero_Exterior)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_Inmueble_Actualizar(" + Clave + ",'" + Clave_Catastral + "','"
                    + Nombre_Propietario + "','" + Telefono_Propietario + "','" + Colonia + "','" + Calle +
                    "','" + Entre_Calles + "','" + Numero_Interior + "','" + Numero_Exterior + "');");
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
                res = conexion.Consulta_Accion("CALL SP_Inmueble_Eliminar(" + Clave + ");");
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
                res = conexion.Consulta_Accion("CALL SP_Inmueble_Activar(" + Clave + ");");
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
                dt = conexion.Consulta_Seleccion("CALL SP_Inmueble_SelXCampoEliminado(" 
                    + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void dtsSelXClaveCatastral(string Clave_Catastral)
        {
            try
            {
                Clave = 0;
                this.Clave_Catastral = "";
                Nombre_Propietario = "";
                Telefono_Propietario = "";
                Colonia = "";
                Calle = "";
                Entre_Calles = "";
                Numero_Interior = "";
                Numero_Exterior = "";
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_Inmueble_SelXClaveCatastral('" + Clave_Catastral + "');").Tables[0];
                if (dt != null)
                {
                    Clave = Convert.ToInt16(dt.Rows[0]["Clave"]);
                    this.Clave_Catastral = dt.Rows[0]["Clave_Catastral"].ToString();
                    Nombre_Propietario = dt.Rows[0]["Nombre_Propietario"].ToString();
                    Telefono_Propietario = dt.Rows[0]["Telefono_Propietario"].ToString();
                    Colonia = dt.Rows[0]["Colonia"].ToString();
                    Calle = dt.Rows[0]["Calle"].ToString();
                    Entre_Calles = dt.Rows[0]["Entre_Calles"].ToString();
                    Numero_Interior = dt.Rows[0]["Numero_Interior"].ToString();
                    Numero_Exterior = dt.Rows[0]["Numero_Exterior"].ToString();
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable dtsSelLikeClaveCatastral(string Clave_Catastral, bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_Inmueble_SelLikeClaveCatastral('" + Clave_Catastral + "',"
                    + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelLikeNombrePropietario(string Nombre_Propietario, bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_Inmueble_SelLikeNombrePropietario('" + Nombre_Propietario + "',"
                    + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelLikeTelefonoPropietario(string Telefono_Propietario, bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_Inmueble_SelLikeTelefonoPropietario('" + Telefono_Propietario + "',"
                    + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelLikeColonia(string Colonia, bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_Inmueble_SelLikeColonia('" + Colonia + "',"
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

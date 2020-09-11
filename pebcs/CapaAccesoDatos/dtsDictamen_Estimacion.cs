using System;
using System.Data;

namespace CapaAccesoDatos
{
    public class dtsDictamen_Estimacion
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Numero { get; set; }
        public string Etiqueta { get; set; }
        public bool Tipo { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public DateTime Visita_Programada { get; set; }
        public bool Elaboracion { get; set; }
        public string Observacion_Elaboracion { get; set; }
        public bool Entregado { get; set; }
        public bool Manifestacion { get; set; }
        public bool Oficio_Subdivision { get; set; }
        public bool Escrituras { get; set; }
        public bool Licencia_Construccion { get; set; }
        public bool Otra { get; set; }
        public string Otra_Nombre { get; set; }
        public int Id_Cliente { get; set; }
        public int Clave_Inmueble { get; set; }
        public int Clave_Empleado { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsDictamen_Estimacion()
        {
            try
            {

                Numero = 0;
                Etiqueta = "";
                Tipo = false;
                Fecha_Registro = new DateTime();
                Visita_Programada = new DateTime();
                Elaboracion = false;
                Observacion_Elaboracion = "";
                Entregado = false;
                Manifestacion = false;
                Oficio_Subdivision = false;
                Escrituras = false;
                Licencia_Construccion = false;
                Otra = false;
                Otra_Nombre = "";
                Id_Cliente = 0;
                Clave_Inmueble = 0;
                Clave_Empleado = 0;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsDictamen_Estimacion(int Numero)
        {
            try
            {
                this.Numero = 0;
                Etiqueta = "";
                Tipo = false;
                Fecha_Registro = new DateTime();
                Visita_Programada = new DateTime();
                Elaboracion = false;
                Observacion_Elaboracion = "";
                Entregado = false;
                Manifestacion = false;
                Oficio_Subdivision = false;
                Escrituras = false;
                Licencia_Construccion = false;
                Otra = false;
                Otra_Nombre = "";
                Id_Cliente = 0;
                Clave_Inmueble = 0;
                Clave_Empleado = 0;
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_DictEsti_SelXNumero(" + Numero + ");").Tables[0];
                if (dt != null)
                {
                    this.Numero = Convert.ToInt16(dt.Rows[0]["Numero"]);
                    Etiqueta = dt.Rows[0]["Etiqueta"].ToString();
                    Tipo = Convert.ToBoolean(dt.Rows[0]["Tipo"]);
                    Fecha_Registro = Convert.ToDateTime(dt.Rows[0]["Fecha_Registro"]);
                    Visita_Programada = Convert.ToDateTime(dt.Rows[0]["Visita_Programada"]);
                    Elaboracion = Convert.ToBoolean(dt.Rows[0]["Elaboracion"]);
                    Observacion_Elaboracion = dt.Rows[0]["Observacion_Elaboracion"].ToString();
                    Entregado = Convert.ToBoolean(dt.Rows[0]["Entregado"]);
                    Manifestacion = Convert.ToBoolean(dt.Rows[0]["Manifestacion"]);
                    Oficio_Subdivision = Convert.ToBoolean(dt.Rows[0]["Oficio_Subdivision"]);
                    Escrituras = Convert.ToBoolean(dt.Rows[0]["Escrituras"]);
                    Licencia_Construccion = Convert.ToBoolean(dt.Rows[0]["Licencia_Construccion"]);
                    Otra = Convert.ToBoolean(dt.Rows[0]["Otra"]);
                    Otra_Nombre = dt.Rows[0]["Otra_Nombre"].ToString();
                    Id_Cliente = Convert.ToInt16(dt.Rows[0]["Id_Cliente"]);
                    Clave_Inmueble = Convert.ToInt16(dt.Rows[0]["Clave_Inmueble"]);
                    Clave_Empleado = Convert.ToInt16(dt.Rows[0]["Clave_Empleado"]);
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsDictamen_Estimacion(int Numero, string Etiqueta, bool Tipo, DateTime Fecha_Registro, DateTime Visita_Programada, 
            bool Elaboracion, string Observacion_Elaboracion, bool Entregado, bool Manifestacion, 
            bool Oficio_Subdivision, bool Escrituras, bool Licencia_Construccion, bool Otra, 
            string Otra_Nombre, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                this.Numero = Numero;
                this.Etiqueta = Etiqueta;
                this.Tipo = Tipo;
                this.Fecha_Registro = Fecha_Registro;
                this.Visita_Programada = Visita_Programada;
                this.Elaboracion = Elaboracion;
                this.Observacion_Elaboracion = Observacion_Elaboracion;
                this.Entregado = Entregado;
                this.Manifestacion = Manifestacion;
                this.Oficio_Subdivision = Oficio_Subdivision;
                this.Escrituras = Escrituras;
                this.Licencia_Construccion = Licencia_Construccion;
                this.Otra = Otra;
                this.Otra_Nombre = Otra_Nombre;
                this.Id_Cliente = Id_Cliente;
                this.Clave_Inmueble = Clave_Inmueble;
                this.Clave_Empleado = Clave_Empleado;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public int dtsInsertar(string Etiqueta, bool Tipo, DateTime Fecha_Registro, DateTime Visita_Programada,
            bool Elaboracion, string Observacion_Elaboracion, bool Entregado, bool Manifestacion,
            bool Oficio_Subdivision, bool Escrituras, bool Licencia_Construccion, bool Otra,
            string Otra_Nombre, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_DictEsti_Insertar('" + Etiqueta + "'," + Tipo + ",'"
                    + Fecha_Registro.ToString("yyyy-MM-dd") + "','" + Visita_Programada.ToString("yyyy-MM-dd") 
                    + "'," + Elaboracion + ",'" + Observacion_Elaboracion + "'," + Entregado + "," 
                    + Manifestacion + "," + Oficio_Subdivision + "," + Escrituras + "," + Licencia_Construccion 
                    + "," + Otra + ",'" + Otra_Nombre + "'," + Id_Cliente + "," + Clave_Inmueble + ","
                    + Clave_Empleado + ");").Tables[0];
                if (dt != null)
                    res = Convert.ToInt16(dt.Rows[0]["Ultimo_Id"]);
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool dtsActualizar(int Numero, string Etiqueta, bool Tipo, DateTime Fecha_Registro, DateTime Visita_Programada,
            bool Elaboracion, string Observacion_Elaboracion, bool Entregado, bool Manifestacion,
            bool Oficio_Subdivision, bool Escrituras, bool Licencia_Construccion, bool Otra,
            string Otra_Nombre, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DictEsti_Actualizar(" + Numero + ",'" + Etiqueta + "'," + Tipo + ",'"
                    + Fecha_Registro.ToString("yyyy-MM-dd") + "','" + Visita_Programada.ToString("yyyy-MM-dd")
                    + "'," + Elaboracion + ",'" + Observacion_Elaboracion + "'," + Entregado + ","
                    + Manifestacion + "," + Oficio_Subdivision + "," + Escrituras + "," + Licencia_Construccion
                    + "," + Otra + ",'" + Otra_Nombre + "'," + Id_Cliente + "," + Clave_Inmueble + ","
                    + Clave_Empleado + ");");
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
                res = conexion.Consulta_Accion("CALL SP_DictEsti_Eliminar(" + Numero + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActivar(int Numero)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_DictEsti_Activar(" + Numero + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable dtsSelXTipoLikeEtiqueta(bool Tipo = false, string Etiqueta = "", bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_DictEsti_XTipoLikeEtiqueta(" + Tipo + ",'" 
                    + Etiqueta + "'," + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelXTipoLikeCatastral(bool Tipo = false, string Clave_Catastral = "", bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_DictEsti_XTipoLikeCatastral(" + Tipo + ",'" 
                    + Clave_Catastral + "'," + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelXTipoLikePropietario(bool Tipo = false, string Nombre_Propietario = "", bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_DictEsti_XTipoLikePropietario(" + Tipo + ",'" 
                    + Nombre_Propietario + "'," + Eliminado + ");").Tables[0];
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

using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsProyecto_Licencia
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Numero { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero_Licencia { get; set; }
        public bool Escrituras { get; set; }
        public bool Constancia_Alineamiento { get; set; }
        public bool Pago_Predial { get; set; }
        public bool Recibo_Agua { get; set; }
        public bool Planos_Arquitectonicos { get; set; }
        public bool Planos_Estructurales { get; set; }
        public bool Planos_Instalaciones { get; set; }
        public bool Memoria_Calculo { get; set; }
        public int Id_Estado_Licencia { get; set; }
        public int Id_Preproyecto { get; set; }
        public int Id_Cliente { get; set; }
        public int Clave_Inmueble { get; set; }
        public int Clave_Empleado { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsProyecto_Licencia()
        {
            try
            {

                Numero = 0;
                Folio = "";
                Fecha = new DateTime();
                Numero_Licencia = "";
                Escrituras = false;
                Constancia_Alineamiento = false;
                Pago_Predial = false;
                Recibo_Agua = false;
                Planos_Arquitectonicos = false;
                Planos_Estructurales = false;
                Planos_Instalaciones = false;
                Memoria_Calculo = false;
                Id_Estado_Licencia = 0;
                Id_Preproyecto = 0;
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

        public dtsProyecto_Licencia(int Numero)
        {
            try
            {
                this.Numero = 0;
                Folio = "";
                Fecha = new DateTime();
                Numero_Licencia = "";
                Escrituras = false;
                Constancia_Alineamiento = false;
                Pago_Predial = false;
                Recibo_Agua = false;
                Planos_Arquitectonicos = false;
                Planos_Estructurales = false;
                Planos_Instalaciones = false;
                Memoria_Calculo = false;
                Id_Estado_Licencia = 0;
                Id_Preproyecto = 0;
                Id_Cliente = 0;
                Clave_Inmueble = 0;
                Clave_Empleado = 0;
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelXNumero(" + Numero + ");").Tables[0];
                if (dt != null)
                {
                    this.Numero = Convert.ToInt16(dt.Rows[0]["Numero"]);
                    Folio = dt.Rows[0]["Folio"].ToString();
                    Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                    Numero_Licencia = dt.Rows[0]["Numero_Licencia"].ToString();
                    Escrituras = Convert.ToBoolean(dt.Rows[0]["Escrituras"]);
                    Constancia_Alineamiento = Convert.ToBoolean(dt.Rows[0]["Constancia_Alineamiento"]);
                    Pago_Predial = Convert.ToBoolean(dt.Rows[0]["Pago_Predial"]);
                    Recibo_Agua = Convert.ToBoolean(dt.Rows[0]["Recibo_Agua"]);
                    Planos_Arquitectonicos = Convert.ToBoolean(dt.Rows[0]["Planos_Arquitectonicos"]);
                    Planos_Estructurales = Convert.ToBoolean(dt.Rows[0]["Planos_Estructurales"]);
                    Planos_Instalaciones = Convert.ToBoolean(dt.Rows[0]["Planos_Instalaciones"]);
                    Memoria_Calculo = Convert.ToBoolean(dt.Rows[0]["Memoria_Calculo"]);
                    Id_Estado_Licencia = Convert.ToInt16(dt.Rows[0]["Id_Estado_Licencia"]);
                    Id_Preproyecto = Convert.ToInt16(dt.Rows[0]["Id_Preproyecto"]);
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

        public dtsProyecto_Licencia(int Numero, string Folio, DateTime Fecha, string Numero_Licencia, bool Escrituras,
            bool Constancia_Alineamiento, bool Pago_Predial, bool Recibo_Agua, bool Planos_Arquitectonicos,
            bool Planos_Estructurales, bool Planos_Instalaciones, bool Memoria_Calculo, int Id_Estado_Licencia, 
            int Id_Preproyecto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                this.Numero = Numero;
                this.Folio =Folio;
                this.Fecha = Fecha;
                this.Numero_Licencia = Numero_Licencia;
                this.Escrituras = Escrituras;
                this.Constancia_Alineamiento = Constancia_Alineamiento;
                this.Pago_Predial = Pago_Predial;
                this.Recibo_Agua = Recibo_Agua;
                this.Planos_Arquitectonicos = Planos_Arquitectonicos;
                this.Planos_Estructurales = Planos_Estructurales;
                this.Planos_Instalaciones = Planos_Instalaciones;
                this.Memoria_Calculo = Memoria_Calculo;
                this.Id_Estado_Licencia = Id_Estado_Licencia;
                this.Id_Preproyecto = Id_Preproyecto;
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

        public bool dtsInsertar(string Folio, string Numero_Licencia, bool Escrituras,
            bool Constancia_Alineamiento, bool Pago_Predial, bool Recibo_Agua, bool Planos_Arquitectonicos,
            bool Planos_Estructurales, bool Planos_Instalaciones, bool Memoria_Calculo, int Id_Estado_Licencia,
            int Id_Preproyecto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_ProyLice_Insertar('" + Folio + "','" + Numero_Licencia
                    + "'," + Escrituras + "," + Constancia_Alineamiento + "," + Pago_Predial + "," + Recibo_Agua 
                    + "," + Planos_Arquitectonicos + "," + Planos_Estructurales + "," + Planos_Instalaciones 
                    + "," + Memoria_Calculo + "," + Id_Estado_Licencia + "," + Id_Preproyecto + "," 
                    + Id_Cliente + "," + Clave_Inmueble + "," + Clave_Empleado + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizar(int Numero, string Folio, string Numero_Licencia, bool Escrituras,
            bool Constancia_Alineamiento, bool Pago_Predial, bool Recibo_Agua, bool Planos_Arquitectonicos,
            bool Planos_Estructurales, bool Planos_Instalaciones, bool Memoria_Calculo)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_ProyLice_Actualizar(" + Numero + ",'" + Folio + "','" 
                    + Numero_Licencia + "'," + Escrituras + "," + Constancia_Alineamiento + "," + Pago_Predial 
                    + "," + Recibo_Agua + "," + Planos_Arquitectonicos + "," + Planos_Estructurales + "," 
                    + Planos_Instalaciones + "," + Memoria_Calculo + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizarIdEstadoLic(int Numero, int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_ProyLice_ActualizarIdEstadoLic(" + Numero + "," 
                    + Id_Estado_Licencia + ");");
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
                res = conexion.Consulta_Accion("CALL SP_ProyLice_Eliminar(" + Numero + ");");
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
                res = conexion.Consulta_Accion("CALL SP_ProyLice_Activar(" + Numero + ");");
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
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelXCampoEliminado("
                    + Eliminado + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelPRES1XCampoEliminado(bool Eliminado = false)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelPRES1XCampoEliminado("
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

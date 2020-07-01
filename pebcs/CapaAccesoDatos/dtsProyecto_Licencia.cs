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
        public DateTime Vigencia { get; set; }
        public bool Escrituras { get; set; }
        public bool Constancia_Alineamiento { get; set; }
        public bool Pago_Predial { get; set; }
        public bool Recibo_Agua { get; set; }
        public bool Planos_Arquitectonicos { get; set; }
        public bool Planos_Estructurales { get; set; }
        public bool Planos_Instalaciones { get; set; }
        public bool Memoria_Calculo { get; set; }
        public int Id_Estado_Licencia { get; set; }
        public int Numero_Presupuesto { get; set; }
        public int Id_Cliente { get; set; }
        public int Clave_Inmueble { get; set; }
        public int Clave_Empleado { get; set; }
        public int? Numero_Proyecto_Original { get; set; }
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
                Vigencia = new DateTime();
                Escrituras = false;
                Constancia_Alineamiento = false;
                Pago_Predial = false;
                Recibo_Agua = false;
                Planos_Arquitectonicos = false;
                Planos_Estructurales = false;
                Planos_Instalaciones = false;
                Memoria_Calculo = false;
                Id_Estado_Licencia = 0;
                Numero_Presupuesto = 0;
                Id_Cliente = 0;
                Clave_Inmueble = 0;
                Clave_Empleado = 0;
                Numero_Proyecto_Original = null;
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
                Vigencia = new DateTime();
                Escrituras = false;
                Constancia_Alineamiento = false;
                Pago_Predial = false;
                Recibo_Agua = false;
                Planos_Arquitectonicos = false;
                Planos_Estructurales = false;
                Planos_Instalaciones = false;
                Memoria_Calculo = false;
                Id_Estado_Licencia = 0;
                Numero_Presupuesto = 0;
                Id_Cliente = 0;
                Clave_Inmueble = 0;
                Clave_Empleado = 0;
                Numero_Proyecto_Original = null;
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
                    Vigencia = Convert.ToDateTime(dt.Rows[0]["Vigencia"]);
                    Escrituras = Convert.ToBoolean(dt.Rows[0]["Escrituras"]);
                    Constancia_Alineamiento = Convert.ToBoolean(dt.Rows[0]["Constancia_Alineamiento"]);
                    Pago_Predial = Convert.ToBoolean(dt.Rows[0]["Pago_Predial"]);
                    Recibo_Agua = Convert.ToBoolean(dt.Rows[0]["Recibo_Agua"]);
                    Planos_Arquitectonicos = Convert.ToBoolean(dt.Rows[0]["Planos_Arquitectonicos"]);
                    Planos_Estructurales = Convert.ToBoolean(dt.Rows[0]["Planos_Estructurales"]);
                    Planos_Instalaciones = Convert.ToBoolean(dt.Rows[0]["Planos_Instalaciones"]);
                    Memoria_Calculo = Convert.ToBoolean(dt.Rows[0]["Memoria_Calculo"]);
                    Id_Estado_Licencia = Convert.ToInt16(dt.Rows[0]["Id_Estado_Licencia"]);
                    Numero_Presupuesto = Convert.ToInt16(dt.Rows[0]["Numero_Presupuesto"]);
                    Id_Cliente = Convert.ToInt16(dt.Rows[0]["Id_Cliente"]);
                    Clave_Inmueble = Convert.ToInt16(dt.Rows[0]["Clave_Inmueble"]);
                    Clave_Empleado = Convert.ToInt16(dt.Rows[0]["Clave_Empleado"]);
                    if(dt.Rows[0]["Numero_Proyecto_Original"] == DBNull.Value)
                        Numero_Proyecto_Original = null;
                    else
                        Numero_Proyecto_Original = Convert.ToInt16(dt.Rows[0]["Numero_Proyecto_Original"]);
                    Eliminado = Convert.ToBoolean(dt.Rows[0]["Eliminado"]);
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsProyecto_Licencia(int Numero, string Folio, DateTime Fecha, string Numero_Licencia, DateTime Vigencia, 
            bool Escrituras, bool Constancia_Alineamiento, bool Pago_Predial, bool Recibo_Agua, bool Planos_Arquitectonicos,
            bool Planos_Estructurales, bool Planos_Instalaciones, bool Memoria_Calculo, int Id_Estado_Licencia, 
            int Numero_Presupuesto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado, int? Numero_Proyecto_Original)
        {
            try
            {
                this.Numero = Numero;
                this.Folio =Folio;
                this.Fecha = Fecha;
                this.Numero_Licencia = Numero_Licencia;
                this.Vigencia = Vigencia;
                this.Escrituras = Escrituras;
                this.Constancia_Alineamiento = Constancia_Alineamiento;
                this.Pago_Predial = Pago_Predial;
                this.Recibo_Agua = Recibo_Agua;
                this.Planos_Arquitectonicos = Planos_Arquitectonicos;
                this.Planos_Estructurales = Planos_Estructurales;
                this.Planos_Instalaciones = Planos_Instalaciones;
                this.Memoria_Calculo = Memoria_Calculo;
                this.Id_Estado_Licencia = Id_Estado_Licencia;
                this.Numero_Presupuesto = Numero_Presupuesto;
                this.Id_Cliente = Id_Cliente;
                this.Clave_Inmueble = Clave_Inmueble;
                this.Clave_Empleado = Clave_Empleado;
                this.Numero_Proyecto_Original = Numero_Proyecto_Original;
                Eliminado = false;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public int dtsInsertar(bool Escrituras, bool Constancia_Alineamiento, bool Pago_Predial, bool Recibo_Agua, 
            bool Planos_Arquitectonicos, bool Planos_Estructurales, bool Planos_Instalaciones, bool Memoria_Calculo, 
            int Id_Estado_Licencia, int Numero_Presupuesto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_Insertar(" +  Escrituras + "," 
                    + Constancia_Alineamiento + "," + Pago_Predial + "," + Recibo_Agua + "," + Planos_Arquitectonicos 
                    + "," + Planos_Estructurales + "," + Planos_Instalaciones + "," + Memoria_Calculo + "," 
                    + Id_Estado_Licencia + "," + Numero_Presupuesto + "," + Id_Cliente + "," + Clave_Inmueble + "," 
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

        public bool dtsActualizar(int Numero, bool Escrituras, bool Constancia_Alineamiento, bool Pago_Predial, 
            bool Recibo_Agua, bool Planos_Arquitectonicos, bool Planos_Estructurales, bool Planos_Instalaciones, 
            bool Memoria_Calculo)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_ProyLice_Actualizar(" + Numero +  "," + Escrituras + "," 
                    + Constancia_Alineamiento + "," + Pago_Predial + "," + Recibo_Agua + "," + Planos_Arquitectonicos 
                    + "," + Planos_Estructurales + "," + Planos_Instalaciones + "," + Memoria_Calculo + ");");
                conexion.Desconectar();
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool dtsActualizarSeguimiento(int Numero, string Folio, string Numero_Licencia, DateTime Vigencia,
            int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_ProyLice_ActualizarSeguimiento(" + Numero + ",'" + Folio + "','"
                    + Numero_Licencia + "','" + Vigencia.ToString("yyyy-MM-dd") + "'," + Id_Estado_Licencia + ");");
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

        public bool dtsActualizarNumProOriginal(int Numero, int? Numero_Proyecto_Original)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                if(Numero_Proyecto_Original == null)
                    res = conexion.Consulta_Accion("CALL SP_ProyLice_ActualizarNumProOriginal(" + Numero + ",NULL);");
                else
                    res = conexion.Consulta_Accion("CALL SP_ProyLice_ActualizarNumProOriginal(" + Numero + "," 
                           + Numero_Proyecto_Original + ");");
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

        public DataTable dtsSelNoTerminados()
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelNoTerminados();").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelTerminados()
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelTerminados();").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelNoTerLikeEtiqueta(string Etiqueta)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelNoTerLikeEtiqueta('"
                    + Etiqueta + "');").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelTerLikeEtiqueta(string Etiqueta)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelTerLikeEtiqueta('"
                    + Etiqueta + "');").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelNoTerLikeCatastral(string Clave_Catastral)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelNoTerLikeCatastral('"
                    + Clave_Catastral + "');").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelTerLikeCatastral(string Clave_Catastral)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelTerLikeCatastral('"
                    + Clave_Catastral + "');").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelNoTerLikePropietario(string Nombre_Propietario)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelNoTerLikePropietario('"
                    + Nombre_Propietario + "');").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelTerLikePropietario(string Nombre_Propietario)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_ProyLice_SelTerLikePropietario('"
                    + Nombre_Propietario + "');").Tables[0];
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

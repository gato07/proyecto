using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsAvaluo_Pericial
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Numero { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string Uso { get; set; }
        public decimal Mts_Terreno { get; set; }
        public decimal Mts_Construccion { get; set; }
        public decimal Costo_Neto { get; set; }
        public decimal Pago_Derechos { get; set; }
        public bool Escrituras { get; set; }
        public bool Manifestacion { get; set; }
        public bool Oficio_Subdivision { get; set; }
        public bool Oficio_Fusion { get; set; }
        public int Id_Estado_Licencia { get; set; }
        public int Id_Cliente { get; set; }
        public int Clave_Inmueble { get; set; }
        public int Clave_Empleado { get; set; }
        public bool Eliminado { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsAvaluo_Pericial()
        {
            try
            {
                Numero = 0;
                Folio = "";
                Fecha = new DateTime();
                Uso = "";
                Mts_Terreno = 0.00m;
                Mts_Construccion = 0.00m;
                Costo_Neto = 0.00m;
                Pago_Derechos = 0.00m;
                Escrituras = false;
                Manifestacion = false;
                Oficio_Subdivision = false;
                Oficio_Fusion = false;
                Id_Estado_Licencia = 0;
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

        public dtsAvaluo_Pericial(int Numero)
        {
            try
            {
                this.Numero = 0;
                Folio = "";
                Fecha = new DateTime();
                Uso = "";
                Mts_Terreno = 0.00m;
                Mts_Construccion = 0.00m;
                Costo_Neto = 0.00m;
                Pago_Derechos = 0.00m;
                Escrituras = false;
                Manifestacion = false;
                Oficio_Subdivision = false;
                Oficio_Fusion = false;
                Id_Estado_Licencia = 0;
                Id_Cliente = 0;
                Clave_Inmueble = 0;
                Clave_Empleado = 0;
                Eliminado = false;
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_AvalPeri_SelXNumero(" + Numero + ");").Tables[0];
                if (dt != null)
                {
                    this.Numero = Convert.ToInt16(dt.Rows[0]["Numero"]);
                    Folio = dt.Rows[0]["Folio"].ToString();
                    Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                    Uso = dt.Rows[0]["Uso"].ToString();
                    Mts_Terreno = Convert.ToDecimal(dt.Rows[0]["Mts_Terreno"]);
                    Mts_Construccion = Convert.ToDecimal(dt.Rows[0]["Mts_Construccion"]);
                    Costo_Neto = Convert.ToDecimal(dt.Rows[0]["Costo_Neto"]);
                    Pago_Derechos = Convert.ToDecimal(dt.Rows[0]["Pago_Derechos"]);
                    Escrituras = Convert.ToBoolean(dt.Rows[0]["Escrituras"]);
                    Manifestacion = Convert.ToBoolean(dt.Rows[0]["Manifestacion"]);
                    Oficio_Subdivision = Convert.ToBoolean(dt.Rows[0]["Oficio_Subdivision"]);
                    Oficio_Fusion = Convert.ToBoolean(dt.Rows[0]["Oficio_Fusion"]);
                    Id_Estado_Licencia = Convert.ToInt16(dt.Rows[0]["Id_Estado_Licencia"]);
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

        public dtsAvaluo_Pericial(int Numero, string Folio, DateTime Fecha, string Uso, decimal Mts_Terreno,
            decimal Mts_Construccion, decimal Costo_Neto, decimal Pago_Derechos, bool Escrituras, bool Manifestacion, 
            bool Oficio_Subdivision, bool Oficio_Fusion, int Id_Estado_Licencia, int Id_Cliente, int Clave_Inmueble, 
            int Clave_Empleado)
        {
            try
            {
                this.Numero = Numero;
                this.Folio = Folio;
                this.Fecha = Fecha;
                this.Uso = Uso;
                this.Mts_Terreno = Mts_Terreno;
                this.Mts_Construccion = Mts_Construccion;
                this.Costo_Neto = Costo_Neto;
                this.Pago_Derechos = Pago_Derechos;
                this.Escrituras = Escrituras;
                this.Manifestacion = Manifestacion;
                this.Oficio_Subdivision = Oficio_Subdivision;
                this.Oficio_Fusion = Oficio_Fusion;
                this.Id_Estado_Licencia = Id_Estado_Licencia;
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

        public int dtsInsertar(string Folio, DateTime Fecha, string Uso, decimal Mts_Terreno,
            decimal Mts_Construccion, decimal Costo_Neto, decimal Pago_Derechos, bool Escrituras, bool Manifestacion,
            bool Oficio_Subdivision, bool Oficio_Fusion, int Id_Estado_Licencia, int Id_Cliente, int Clave_Inmueble,
            int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_AvalPeri_Insertar('" + Folio + "','"
                    + Fecha.ToString("yyyy-MM-dd") + "','" + Uso + "'," + Mts_Terreno + "," + Mts_Construccion
                    + "," + Costo_Neto + "," + Pago_Derechos + "," + Escrituras + "," + Manifestacion + ","
                    + Oficio_Subdivision + "," + Oficio_Fusion + "," + Id_Estado_Licencia + "," + Id_Cliente + "," 
                    + Clave_Inmueble + "," + Clave_Empleado + ");").Tables[0];
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

        public bool dtsActualizar(int Numero, string Folio, DateTime Fecha, string Uso, decimal Mts_Terreno,
            decimal Mts_Construccion, decimal Costo_Neto, decimal Pago_Derechos, bool Escrituras, bool Manifestacion,
            bool Oficio_Subdivision, bool Oficio_Fusion, int Id_Estado_Licencia, int Id_Cliente, int Clave_Inmueble)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_AvalPeri_Actualizar(" + Numero + ",'" + Folio + "','"
                    + Fecha.ToString("yyyy-MM-dd") + "','" + Uso + "'," + Mts_Terreno + "," + Mts_Construccion
                    + "," + Costo_Neto + "," + Pago_Derechos + "," + Escrituras + "," + Manifestacion + ","
                    + Oficio_Subdivision + "," + Oficio_Fusion + "," + Id_Estado_Licencia + "," + Id_Cliente + ","
                    + Clave_Inmueble + ");");
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
                dt = conexion.Consulta_Seleccion("CALL SP_AvalPeri_SelTodos();").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelLikeNomCliente(string Nombre = "", int Id_Estado_Licencia = 0)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_AvalPeri_SelLikeNomCliente('" + Nombre + "'," 
                    + Id_Estado_Licencia + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelLikeCatastral(string Clave_Catastral = "", int Id_Estado_Licencia = 0)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_AvalPeri_SelLikeCatastral('" + Clave_Catastral + "',"
                    + Id_Estado_Licencia + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelLikeNomPropietario(string Nombre_Propietario = "", int Id_Estado_Licencia = 0)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_AvalPeri_SelLikeNomPropietario('" + Nombre_Propietario + "',"
                    + Id_Estado_Licencia + ");").Tables[0];
                conexion.Desconectar();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable dtsSelLikeColonia(string Colonia = "", int Id_Estado_Licencia = 0)
        {
            try
            {
                DataTable dt = null;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                dt = conexion.Consulta_Seleccion("CALL SP_AvalPeri_SelLikeColonia('" + Colonia + "',"
                    + Id_Estado_Licencia + ");").Tables[0];
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

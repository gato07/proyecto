using System;
using System.Data;
using System.Text;

namespace CapaAccesoDatos
{
    public class dtsTipo_Proyecto
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public int Id { get; set; }
        public int Id_Tipo_Obra { get; set; }
        public string Tipo_Obra { get; set; }
        public int Id_Uso { get; set; }
        public string Uso { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsTipo_Proyecto()
        {
            try
            {
                Id = 0;
                Id_Tipo_Obra = 0;
                Tipo_Obra = "";
                Id_Uso = 0;
                Uso = "";
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public dtsTipo_Proyecto(int Id)
        {
            try
            {
                this.Id = 0;
                Id_Tipo_Obra = 0;
                Tipo_Obra = "";
                Id_Uso = 0;
                Uso = "";
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_TipoProyecto_SelXId(" + Id + ");").Tables[0];
                if (dt != null)
                {
                    this.Id = Convert.ToInt16(dt.Rows[0]["Id"]);
                    Id_Tipo_Obra = Convert.ToInt16(dt.Rows[0]["Id_Tipo_Obra"]);
                    Tipo_Obra = dt.Rows[0]["Tipo_Obra"].ToString();
                    Id_Uso = Convert.ToInt16(dt.Rows[0]["Id_Uso"]);
                    Uso = dt.Rows[0]["Uso"].ToString();
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsTipo_Proyecto(int Id, int Id_Tipo_Obra, string Tipo_Obra, int Id_Uso, string Uso)
        {
            try
            {
                this.Id = Id;
                this.Id_Tipo_Obra = Id_Tipo_Obra;
                this.Tipo_Obra = Tipo_Obra;
                this.Id_Uso = Id_Uso;
                this.Uso = Uso;
                Existe = false;
            }
            catch (Exception ex)
            {

            }
        }

        public bool dtsInsertar(int Id_Tipo_Obra, string Tipo_Obra, int Id_Uso, string Uso)
        {
            try
            {
                bool res = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                res = conexion.Consulta_Accion("CALL SP_TipoProyecto_Insertar(" + Id_Tipo_Obra + ",'" + Tipo_Obra 
                    + "'," + Id_Uso + ",'" + Uso + "');");
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
                dt = conexion.Consulta_Seleccion("CALL SP_TipoProyecto_SelTodos();").Tables[0];
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

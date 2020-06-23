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
        public string Tipo_Obra { get; set; }
        public string Uso { get; set; }
        public bool Existe { get; set; }

        #endregion Propiedades

        #region Metodos

        public dtsTipo_Proyecto()
        {
            try
            {
                Id = 0;
                Tipo_Obra = "";
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
                Tipo_Obra = "";
                Uso = "";
                Existe = false;
                Conexion conexion = new Conexion();
                conexion.Conectar();
                DataTable dt = conexion.Consulta_Seleccion("CALL SP_TipoProyecto_SelXId(" + Id + ");").Tables[0];
                if (dt != null)
                {
                    this.Id = Convert.ToInt16(dt.Rows[0]["Id"]);
                    Tipo_Obra = dt.Rows[0]["Tipo_Obra"].ToString();
                    Uso = dt.Rows[0]["Uso"].ToString();
                    Existe = true;
                }
                conexion.Desconectar();
            }
            catch (Exception ex)
            {

            }
        }

        public dtsTipo_Proyecto(int Id, string Tipo_Obra, string Uso)
        {
            try
            {
                this.Id = Id;
                this.Tipo_Obra = Tipo_Obra;
                this.Uso = Uso;
                Existe = false;
            }
            catch (Exception ex)
            {

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

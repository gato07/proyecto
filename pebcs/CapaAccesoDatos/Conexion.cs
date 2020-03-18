using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CapaAccesoDatos
{
    class Conexion
    {

        private MySqlConnection Conector;

        public Conexion()
        {
            try
            {
                //string constr = "Server=localhost;Port=3306;Database=bd_control_avaluos;Uid=admin;Password=C0ntrase#a;";
                string constr = "Server=sql3.freemysqlhosting.net;Port=3306;Database=sql3328549;Uid=sql3328549;Password=NMeUbCLpIr;";
                Conector = new MySqlConnection(constr);
            }
            catch (Exception ex)
            {

            }
        }

        public void Conectar()
        {
            try
            {
                Conector.Open();
            }
            catch (Exception ex)
            {

            }
        }

        public void Desconectar()
        {
            try
            {
                Conector.Close();
                Conector.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        public DataSet Consulta_Seleccion(string Consulta)
        {
            try
            {
                MySqlDataAdapter adaptador = new MySqlDataAdapter(Consulta, Conector);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                adaptador.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Consulta_Accion(string Consulta)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand(Consulta, Conector);
                int afectados = comando.ExecuteNonQuery();
                comando.Dispose();
                if (afectados > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

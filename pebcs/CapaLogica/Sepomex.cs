using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace CapaLogica
{
    public class Sepomex
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        /*public bool Error { get; set; }

        public int Code_Error { get; set; }

        public string Error_Message { get; set; }*/

        #endregion Propiedades

        #region Metodos

        /*public Sepomex()
        {
            try
            {
                Error = false;
                Code_Error = 0;
                Error_Message = "";
            }
            catch (Exception ex)
            {

            }
        }*/

        public string[] BuscarColoniaXCodigoPostal(string Codigo_Postal)
        {
            try
            {
                string[] colonias = new string[] {"Centro" };
                string url = "https://api-sepomex.hckdrk.mx/query/get_colonia_por_cp/" + Codigo_Postal;
                var response = new WebClient().DownloadData(url);
                var responseutf8 = Encoding.UTF8.GetString(response);
                dynamic json = JsonConvert.DeserializeObject(responseutf8);
                /*Error = Convert.ToBoolean(json.error);
                Code_Error = Convert.ToInt16(json.code_error);
                Error_Message = Convert.ToString(json.error_message);*/
                string resultado = Convert.ToString(json.response.colonia);
                colonias = JsonConvert.DeserializeObject<string[]>(resultado);
                return colonias;
            }
            catch (Exception ex)
            {
                return new string[]{ "Centro" };
            }
        }

        #endregion Metodos

    }
}

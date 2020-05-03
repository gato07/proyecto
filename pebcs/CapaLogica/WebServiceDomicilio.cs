using System;
using System.Net;
using Newtonsoft.Json;

namespace CapaLogica
{
    class WebServiceDomicilio
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public WebServiceDomicilio()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        #endregion Metodos

        public void BuscarColoniaXCP()
        {
            try
            {
                string endpoint_sepomex = "https://api-sepomex.hckdrk.mx/query/get_colonia_por_cp/09810";
                string method_sepomex = "info_cp/";
                string variable_string = "?type=simplified";
                string url = endpoint_sepomex + method_sepomex + variable_string;

                var response = new WebClient().DownloadString(url);
                dynamic json = JsonConvert.DeserializeObject(response);

                foreach (var i in json)
                {
                    if (i.error)
                    {
                        Console.WriteLine("Algo salio mal");
                    }
                    else
                    {
                        Console.WriteLine("Todo salio bien");
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}

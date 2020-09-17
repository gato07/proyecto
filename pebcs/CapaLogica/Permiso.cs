using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Permiso : dtsPermiso
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Permiso() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Permiso";
            }
        }

        public Permiso(int Perfil, string Proceso, string Subproceso) : base(Perfil, Proceso, Subproceso)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Permiso";
            }
        }

        public string[] SelXPerfil(int Perfil)
        {
            try
            {
                DataTable dt = null;
                dt = dtsSelXPerfil(Perfil);
                string[] permisos = new string[dt.Rows.Count];
                int i = 0;
                foreach (DataRow renglon in dt.Rows)
                {
                    permisos[i] = renglon["Subproceso"].ToString();
                    i++;
                }
                return permisos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Permisos X Perfil";
                return new string[0];
            }
        }

        #endregion Metodos

    }
}

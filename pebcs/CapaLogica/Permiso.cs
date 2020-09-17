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

        public DataTable SelXPerfil(int Perfil)
        {
            try
            {
                return dtsSelXPerfil(Perfil);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Permisos X Perfil";
                return null;
            }
        }

        public Permiso[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Permiso[] permisos = new Permiso[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Permiso permiso = new Permiso();
                    if (Dt.Columns.Contains("Perfil"))
                        permiso.Perfil = Convert.ToInt16(renglon["Perfil"]);
                    if (Dt.Columns.Contains("Proceso"))
                        permiso.Proceso = renglon["Proceso"].ToString();
                    if (Dt.Columns.Contains("Subproceso"))
                        permiso.Subproceso = renglon["Subproceso"].ToString();
                    permiso.Existe = true;
                    permisos[i] = permiso;
                    i++;
                }
                return permisos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Permisos";
                return new Permiso[0];
            }
        }

        #endregion Metodos

    }
}

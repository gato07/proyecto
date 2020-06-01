using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Estado_Licencia : dtsEstado_Licencia
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Estado_Licencia() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Estado_Licencia";
            }
        }

        public Estado_Licencia(int Id) : base(Id)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Estado_Licencia";
            }
        }

        public Estado_Licencia(int Id, int Proceso, int Subproceso, string Nombre)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Estado_Licencia";
            }
        }

        public bool Insertar(int Proceso, int Subproceso, string Nombre)
        {
            try
            {
                return dtsInsertar(Proceso, Subproceso, Nombre);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable SelTodos()
        {
            try
            {
                return dtsSelTodos();
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Estados_Licencia";
                return null;
            }
        }

        public Estado_Licencia[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Estado_Licencia[] estados_licencia = new Estado_Licencia[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Estado_Licencia estado_licencia = new Estado_Licencia();
                    if (Dt.Columns.Contains("Id"))
                        estado_licencia.Id = Convert.ToInt16(renglon["Id"]);
                    if (Dt.Columns.Contains("Proceso"))
                        estado_licencia.Proceso = Convert.ToInt16(renglon["Proceso"]);
                    if (Dt.Columns.Contains("Subproceso"))
                        estado_licencia.Subproceso = Convert.ToInt16(renglon["Subproceso"]);
                    if (Dt.Columns.Contains("Nombre"))
                        estado_licencia.Nombre = renglon["Nombre"].ToString();
                    estado_licencia.Existe = true;
                    estados_licencia[i] = estado_licencia;
                    i++;
                }
                return estados_licencia;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Estados_Licencia";
                return new Estado_Licencia[0];
            }
        }

        #endregion Metodos

    }
}

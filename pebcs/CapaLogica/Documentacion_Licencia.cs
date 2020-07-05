using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Documentacion_Licencia : dtsDocumentacion_Licencia
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Documentacion_Licencia() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor de la Documentacion_Licencia";
            }
        }

        public Documentacion_Licencia(int Numero_Proyecto_Licencia, int Id_Estado_Licencia) : 
            base(Numero_Proyecto_Licencia, Id_Estado_Licencia)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor de la Documentacion_Licencia";
            }
        }

        public Documentacion_Licencia(int Numero_Proyecto_Licencia, int Id_Estado_Licencia, 
            string Nombre_Documento, DateTime Fecha, string Nota) : base(Numero_Proyecto_Licencia, 
                Id_Estado_Licencia, Nombre_Documento, Fecha, Nota)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor de la Documentacion_Licencia";
            }
        }

        public bool Insertar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia, string Nombre_Documento, 
            DateTime Fecha, string Nota)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta a la Documentacion_Licencia, es posible que no se haya insertado"
                    + " correctamente";
                Proyecto_Licencia prolic = new Proyecto_Licencia(Numero_Proyecto_Licencia);
                if(prolic.Existe)
                {
                    Estado_Licencia estlic = new Estado_Licencia(Id_Estado_Licencia);
                    if(estlic.Existe)
                    {
                        Documentacion_Licencia doclic = new Documentacion_Licencia(Numero_Proyecto_Licencia, 
                            Id_Estado_Licencia);
                        if (doclic.Existe == false)
                        {
                            if (validacion.Val_Texto1(Nombre_Documento, 1, 50))
                            {
                                if (validacion.Val_Texto3(Nota, 0, 255))
                                {
                                    res = dtsInsertar(Numero_Proyecto_Licencia, Id_Estado_Licencia, Nombre_Documento, Fecha, Nota);
                                    if (res)
                                        Mensaje = "La Documentacion_Licencia fue registrada satisfactoriamente";
                                }
                                else
                                    Mensaje = "El campo de Nota debe cumplir:\n\n- Solo puede contener caracteres"
                                        + " alfabéticos, númericos, los simbolos °¡!#$%&/=¿?,;.:- y espacios en"
                                        + " blanco.\n- El tamaño valido del campo es de 0 hasta 255 caracteres.";
                            }
                            else
                                Mensaje = "El campo de Nombre del Documento debe cumplir:\n\n- No puede quedar vacío."
                                    + "\n- Solo puede contener caracteres alfabéticos y espacios en blanco.\n- El tamaño"
                                    + " valido del campo es de 1 hasta 50 caracteres.";
                        }
                        else
                            Mensaje = "Ya existe esta documentación del Proyecto Licencia en la base de datos, por lo tanto no se puede volver"
                                + " a reingresar, intente con otra documentación diferente";
                    }
                    else
                        Mensaje = "El Id indicado no corresponde al de un Estado de Proyecto Licencia existente,"
                            + " intente con el número de uno real";
                }
                else
                    Mensaje = "El Numero indicado no corresponde al de un Proyecto Licencia existente, intente con"
                        + " el numero de uno real";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta a la Documentacion_Licencia, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia, string Nombre_Documento, 
            DateTime Fecha, string Nota)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos de la Documentacion_Licencia, es posible"
                   + " que no se hayan modificado los datos correctamente";
                Documentacion_Licencia doclic = new Documentacion_Licencia(Numero_Proyecto_Licencia,
                            Id_Estado_Licencia);
                if (doclic.Existe)
                {
                    if (validacion.Val_Texto1(Nombre_Documento, 1, 50))
                    {
                        if (validacion.Val_Texto3(Nota, 0, 255))
                        {
                            res = dtsActualizar(Numero_Proyecto_Licencia, Id_Estado_Licencia, Nombre_Documento, Fecha, Nota);
                            if (res)
                                Mensaje = "Los datos de la Documentacion_Licencia fueron actualizados satisfactoriamente";
                        }
                        else
                            Mensaje = "El campo de Nota debe cumplir:\n\n- Solo puede contener caracteres"
                                + " alfabéticos, númericos, los simbolos °¡!#$%&/=¿?,;.:- y espacios en"
                                + " blanco.\n- El tamaño valido del campo es de 0 hasta 255 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Nombre del Documento debe cumplir:\n\n- No puede quedar vacío."
                            + "\n- Solo puede contener caracteres alfabéticos y espacios en blanco.\n- El tamaño"
                            + " valido del campo es de 1 hasta 50 caracteres.";
                }
                else
                    Mensaje = "No existe una documentación del Proyecto Licencia con ese Id, por lo cual no se actualizara,"
                        + " ingrese un Id real";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos de la Documentacion_Licencia, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        /* NO SE UTILIZA */
        public bool Eliminar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación de la Documentacion_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero_Proyecto_Licencia, Id_Estado_Licencia);
                if (res)
                    Mensaje = "La Documentacion_Licencia fue eliminada satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación de la Documentacion_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        /* NO SE UTILIZA */

        /* NO SE UTILIZA */

        public bool Activar(int Numero_Proyecto_Licencia, int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación de la Documentacion_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero_Proyecto_Licencia, Id_Estado_Licencia);
                if (res)
                    Mensaje = "La Documentacion_Licencia fue activada satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación de la Documentacion_Licencia, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        /* NO SE UTILIZA */

        /* NO SE UTILIZA */
        public DataTable SelActivos()
        {
            try
            {
                return dtsSelXCampoEliminado();
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todas las Documentaciones_Licencia activas";
                return null;
            }
        }

        /* NO SE UTILIZA */

        /* NO SE UTILIZA */
        public DataTable SelEliminados()
        {
            try
            {
                return dtsSelXCampoEliminado(true);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todas las Documentaciones_Licencia eliminadas";
                return null;
            }
        }

        /* NO SE UTILIZA */

        public DataTable SelXNumeroProLic(int Numero_Proyecto_Licencia)
        {
            try
            {
                return dtsSelXNumeroProLic(Numero_Proyecto_Licencia);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todas las Documentaciones_Licencia X Numero"
                    + " de proyecto de licencia";
                return null;
            }
        }

        public Documentacion_Licencia[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Documentacion_Licencia[] documentaciones = new Documentacion_Licencia[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Documentacion_Licencia documentacion = new Documentacion_Licencia();
                    if (Dt.Columns.Contains("Numero_Proyecto_Licencia"))
                        documentacion.Numero_Proyecto_Licencia = Convert.ToInt16(renglon["Numero_Proyecto_Licencia"]);
                    if (Dt.Columns.Contains("Id_Estado_Licencia"))
                        documentacion.Id_Estado_Licencia = Convert.ToInt16(renglon["Id_Estado_Licencia"]);
                    if (Dt.Columns.Contains("Nombre_Documento"))
                        documentacion.Nombre_Documento = renglon["Nombre_Documento"].ToString();
                    if (Dt.Columns.Contains("Fecha"))
                        documentacion.Fecha = Convert.ToDateTime(renglon["Fecha"]);
                    if (Dt.Columns.Contains("Nota"))
                        documentacion.Nota = renglon["Nota"].ToString();
                    if (Dt.Columns.Contains("Eliminado"))
                        documentacion.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    documentacion.Existe = true;
                    documentaciones[i] = documentacion;
                    i++;
                }
                return documentaciones;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Documentaciones_Licencia";
                return new Documentacion_Licencia[0];
            }
        }

        #endregion Metodos

    }
}

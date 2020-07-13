using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Proyecto_Licencia : dtsProyecto_Licencia
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Proyecto_Licencia() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Proyecto de Licencia";
            }
        }

        public Proyecto_Licencia(int Numero) : base(Numero)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Proyecto de Licencia";
            }
        }

        public Proyecto_Licencia(int Numero, string Folio, DateTime Fecha, string Numero_Licencia, DateTime Vigencia,
            bool Escrituras, bool Constancia_Alineamiento, bool Pago_Predial, bool Recibo_Agua, bool Planos_Arquitectonicos,
            bool Planos_Estructurales, bool Planos_Instalaciones, bool Memoria_Calculo, int Id_Estado_Licencia,
            int Numero_Presupuesto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado, int? Numero_Proyecto_Original) :
            base(Numero, Folio, Fecha, Numero_Licencia, Vigencia, Escrituras, Constancia_Alineamiento, Pago_Predial, 
                Recibo_Agua, Planos_Arquitectonicos, Planos_Estructurales, Planos_Instalaciones, Memoria_Calculo,
                Id_Estado_Licencia, Numero_Presupuesto, Id_Cliente, Clave_Inmueble, Clave_Empleado, Numero_Proyecto_Original)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Proyecto de Licencia";
            }
        }

        public int Insertar(bool Escrituras, bool Constancia_Alineamiento, bool Pago_Predial, bool Recibo_Agua,
            bool Planos_Arquitectonicos, bool Planos_Estructurales, bool Planos_Instalaciones, bool Memoria_Calculo,
            int Id_Estado_Licencia, int Numero_Presupuesto, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Proyecto de Licencia, es posible que no se haya insertado"
                    + " correctamente";
                Estado_Licencia estlic = new Estado_Licencia(Id_Estado_Licencia);
                if(estlic.Existe)
                {
                    Presupuesto presupuesto = new Presupuesto(Numero_Presupuesto);
                    if(presupuesto.Existe)
                    {
                        Cliente cliente = new Cliente(Id_Cliente);
                        if(cliente.Existe)
                        {
                            Inmueble inmueble = new Inmueble(Clave_Inmueble);
                            if(inmueble.Existe)
                            {
                                Empleado empleado = new Empleado(Clave_Empleado);
                                if(empleado.Existe)
                                {
                                    res = dtsInsertar(Escrituras, Constancia_Alineamiento, Pago_Predial, Recibo_Agua, 
                                        Planos_Arquitectonicos, Planos_Estructurales, Planos_Instalaciones, Memoria_Calculo, 
                                        Id_Estado_Licencia, Numero_Presupuesto, Id_Cliente, Clave_Inmueble, Clave_Empleado);
                                    if (res > 0)
                                        Mensaje = "El Proyecto de Licencia fue registrado satisfactoriamente";
                                }
                                else
                                    Mensaje = "No existe algún Empleado con la Clave indicada, ingrese una Clave real";
                            }
                            else
                                Mensaje = "No existe algún Inmueble con la Clave indicada, ingrese una Clave real";
                        }
                        else
                            Mensaje = "No existe algún Cliente con el Id indicado, ingrese un Id real";
                    }
                    else
                        Mensaje = "No existe algún Presupuesto con el Numero indicado, ingrese un Número real";
                }
                else
                    Mensaje = "No existe algún Estado de Proyecto de Licencia con el Id indicado, ingrese un Id real";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Proyecto de Licencia, es posible que no se haya insertado"
                    + " correctamente";
                return 0;
            }
        }

        public bool Actualizar(int Numero, bool Escrituras, bool Constancia_Alineamiento, bool Pago_Predial,
            bool Recibo_Agua, bool Planos_Arquitectonicos, bool Planos_Estructurales, bool Planos_Instalaciones,
            bool Memoria_Calculo)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Proyecto de Licencia, es posible"
                   + " que no se hayan modificado los datos correctamente";
                Proyecto_Licencia prolic = new Proyecto_Licencia(Numero);
                if (prolic.Existe)
                {
                    res = dtsActualizar(Numero, Escrituras, Constancia_Alineamiento, Pago_Predial, Recibo_Agua, 
                        Planos_Arquitectonicos, Planos_Estructurales, Planos_Instalaciones, Memoria_Calculo);
                    if (res)
                        Mensaje = "Los datos de la documentación del Proyecto de Licencia fueron actualizados satisfactoriamente";
                }
                else
                    Mensaje = "No existe algún Proyecto de Licencia con el Número indicado, por lo cual no se actualizara";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Proyecto de Licencia, es posible"
                    + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool ActualizarSeguimiento(int Numero, string Folio, string Numero_Licencia, DateTime Vigencia,
            int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización del Seguimiento del Proyecto de Licencia,"
                    + " es posible que no se hayan modificado los datos correctamente";
                Proyecto_Licencia prolic = new Proyecto_Licencia(Numero);
                if (prolic.Existe)
                {
                    if(validacion.Val_FolioLicencia(Folio) || Folio == "")
                    {
                        if (validacion.Val_NoLicencia(Numero_Licencia) || Numero_Licencia == "")
                        {
                            Estado_Licencia estlic = new Estado_Licencia(Id_Estado_Licencia);
                            if(estlic.Existe)
                            {
                                res = dtsActualizarSeguimiento(Numero, Folio, Numero_Licencia, Vigencia, Id_Estado_Licencia);
                                if (res)
                                    Mensaje = "Los datos del Seguimiento del Proyecto de Licencia fueron actualizados satisfactoriamente";
                            }
                            else
                                Mensaje = "No existe algún Estado de Proyecto de Licencia con el Id indicado, ingrese un Id real";
                        }
                        else
                            Mensaje = "El campo de Número de licencia debe cumplir:\n- El formato del campo es ####/##."
                            + "\n- El unico tamaño permitido del campo es de 7 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Folio debe cumplir:\n- El formato del campo es (###)#/##."
                        + "\n- El tamaño permitido del campo es de 4 hasta 7 caracteres.";
                }
                else
                    Mensaje = "No existe algún Proyecto de Licencia con el Número indicado, por lo cual no se actualizara";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización del Seguimiento del Proyecto de Licencia,"
                    + " es posible que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool ActualizarIdEstadoLic(int Numero, int Id_Estado_Licencia)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización del Estado de la licencia del Proyecto de Licencia,"
                    + " es posible que no se hayan modificado los datos correctamente";
                Proyecto_Licencia prolic = new Proyecto_Licencia(Numero);
                if (prolic.Existe)
                {
                    Estado_Licencia estlic = new Estado_Licencia(Id_Estado_Licencia);
                    if (estlic.Existe)
                    {
                        res = dtsActualizarIdEstadoLic(Numero, Id_Estado_Licencia);
                        if (res)
                            Mensaje = "El Estado del Proyecto de Licencia fue actualizado satisfactoriamente";
                    }
                    else
                        Mensaje = "No existe algún Estado de Proyecto de Licencia con el Id indicado, ingrese un Id real";
                }
                else
                    Mensaje = "No existe algún Proyecto de Licencia con el Número indicado, por lo cual no se actualizara";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización del Estado de la licencia del Proyecto de Licencia,"
                    + " es posible que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool ActualizarNumProOriginal(int Numero, int? Numero_Proyecto_Original)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización del Numero de Proyecto Original de la Licencia  del Proyecto de Licencia,"
                    + " es posible que no se haya modificado correctamente";
                Proyecto_Licencia prolic = new Proyecto_Licencia(Numero);
                if (prolic.Existe)
                {
                    Proyecto_Licencia prolicori = new Proyecto_Licencia((int)(Numero_Proyecto_Original ?? 0));
                    if (prolicori.Existe || Numero_Proyecto_Original == null)
                    {
                        res = dtsActualizarNumProOriginal(Numero, Numero_Proyecto_Original);
                        if (res)
                            Mensaje = "Se ha agregado la prórroga al Proyecto de Licencia satisfactoriamente";
                    }
                    else
                        Mensaje = "El Proyecto Licencia que sera la prórroga no existe";
                }
                else
                    Mensaje = "El Proyecto de Licencia al que se le quiere agregar la prórroga no existe";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización del Numero de Proyecto Original de la Licencia  del Proyecto de Licencia,"
                    + " es posible que no se haya modificado correctamente";
                return false;
            }
        }

        public bool Eliminar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Proyecto de Licencia, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero);
                if (res)
                    Mensaje = "El Proyecto de Licencia fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Proyecto de Licencia, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Proyecto de Licencia, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero);
                if (res)
                    Mensaje = "El Proyecto de Licencia fue activado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Proyecto de Licencia, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public void SelXNumPresupuesto(int Numero_Presupuesto)
        {
            try
            {
                dtsSelXNumPresupuesto(Numero_Presupuesto);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos de Licencia X Numero de Presupuesto";
            }
        }

        public DataTable SelNoTerminados()
        {
            try
            {
                return dtsSelNoTerminados();
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos de Licencia No Terminados";
                return null;
            }
        }

        public DataTable SelTerminados()
        {
            try
            {
                return dtsSelTerminados();
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos de Licencia Terminados";
                return null;
            }
        }

        public DataTable SelNoTerLikeEtiqueta(string Etiqueta)
        {
            try
            {
                return dtsSelNoTerLikeEtiqueta(Etiqueta);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos de Licencia No Terminados X Etiqueta";
                return null;
            }
        }

        public DataTable SelTerLikeEtiqueta(string Etiqueta)
        {
            try
            {
                return dtsSelTerLikeEtiqueta(Etiqueta);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos de Licencia Terminados X Etiqueta";
                return null;
            }
        }

        public DataTable SelNoTerLikeCatastral(string Clave_Catastral)
        {
            try
            {
                return dtsSelNoTerLikeCatastral(Clave_Catastral);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos de Licencia No Terminados X Clave Catastral";
                return null;
            }
        }

        public DataTable SelTerLikeCatastral(string Clave_Catastral)
        {
            try
            {
                return dtsSelTerLikeCatastral(Clave_Catastral);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos de Licencia Terminados X Clave Catastral";
                return null;
            }
        }

        public DataTable SelNoTerLikePropietario(string Nombre_Propietario)
        {
            try
            {
                return dtsSelNoTerLikePropietario(Nombre_Propietario);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos de Licencia No Terminados X Nombre del Propietario";
                return null;
            }
        }

        public DataTable SelTerLikePropietario(string Nombre_Propietario)
        {
            try
            {
                return dtsSelTerLikePropietario(Nombre_Propietario);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Proyectos de Licencia Terminados X Nombre del Propietario";
                return null;
            }
        }

        public Proyecto_Licencia[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Proyecto_Licencia[] proyectos = new Proyecto_Licencia[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Proyecto_Licencia proyecto = new Proyecto_Licencia();
                    if (Dt.Columns.Contains("Numero"))
                        proyecto.Numero = Convert.ToInt16(renglon["Numero"]);
                    if (Dt.Columns.Contains("Folio"))
                        proyecto.Folio = renglon["Folio"].ToString();
                    if (Dt.Columns.Contains("Fecha"))
                        proyecto.Fecha = Convert.ToDateTime(renglon["Fecha"]);
                    if (Dt.Columns.Contains("Numero_Licencia"))
                        proyecto.Numero_Licencia = renglon["Numero_Licencia"].ToString();
                    if (Dt.Columns.Contains("Vigencia"))
                        proyecto.Vigencia = Convert.ToDateTime(renglon["Vigencia"]);
                    if (Dt.Columns.Contains("Escrituras"))
                        proyecto.Escrituras = Convert.ToBoolean(renglon["Escrituras"]);
                    if (Dt.Columns.Contains("Constancia_Alineamiento"))
                        proyecto.Constancia_Alineamiento = Convert.ToBoolean(renglon["Constancia_Alineamiento"]);
                    if (Dt.Columns.Contains("Pago_Predial"))
                        proyecto.Pago_Predial = Convert.ToBoolean(renglon["Pago_Predial"]);
                    if (Dt.Columns.Contains("Recibo_Agua"))
                        proyecto.Recibo_Agua = Convert.ToBoolean(renglon["Recibo_Agua"]);
                    if (Dt.Columns.Contains("Planos_Arquitectonicos"))
                        proyecto.Planos_Arquitectonicos = Convert.ToBoolean(renglon["Planos_Arquitectonicos"]);
                    if (Dt.Columns.Contains("Planos_Estructurales"))
                        proyecto.Planos_Estructurales = Convert.ToBoolean(renglon["Planos_Estructurales"]);
                    if (Dt.Columns.Contains("Planos_Instalaciones"))
                        proyecto.Planos_Instalaciones = Convert.ToBoolean(renglon["Planos_Instalaciones"]);
                    if (Dt.Columns.Contains("Memoria_Calculo"))
                        proyecto.Memoria_Calculo = Convert.ToBoolean(renglon["Memoria_Calculo"]);
                    if (Dt.Columns.Contains("Id_Estado_Licencia"))
                        proyecto.Id_Estado_Licencia = Convert.ToInt16(renglon["Id_Estado_Licencia"]);
                    if (Dt.Columns.Contains("Numero_Presupuesto"))
                        proyecto.Numero_Presupuesto = Convert.ToInt16(renglon["Numero_Presupuesto"]);
                    if (Dt.Columns.Contains("Id_Cliente"))
                        proyecto.Id_Cliente = Convert.ToInt16(renglon["Id_Cliente"]);
                    if (Dt.Columns.Contains("Clave_Inmueble"))
                        proyecto.Clave_Inmueble = Convert.ToInt16(renglon["Clave_Inmueble"]);
                    if (Dt.Columns.Contains("Clave_Empleado"))
                        proyecto.Clave_Empleado = Convert.ToInt16(renglon["Clave_Empleado"]);
                    if (Dt.Columns.Contains("Numero_Proyecto_Original"))
                    {
                        if (renglon["Numero_Proyecto_Original"] == DBNull.Value)
                            proyecto.Numero_Proyecto_Original = null;
                        else
                            proyecto.Numero_Proyecto_Original = Convert.ToInt16(renglon["Numero_Proyecto_Original"]);
                    }
                    if (Dt.Columns.Contains("Eliminado"))
                        proyecto.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    proyecto.Existe = true;
                    proyectos[i] = proyecto;
                    i++;
                }
                return proyectos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Proyectos de Licencia";
                return new Proyecto_Licencia[0];
            }
        }

        #endregion Metodos

    }
}

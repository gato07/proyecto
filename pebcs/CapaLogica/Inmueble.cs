﻿using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Inmueble:dtsInmueble
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Inmueble() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Inmueble";
            }
        }

        public Inmueble(int Clave) : base(Clave)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Inmueble";
            }
        }

        public Inmueble(int Clave, string Clave_Catastral, string Nombre_Propietario, string Telefono_Propietario,
            string Colonia, string Calle, string Entre_Calles, string Numero_Interior, string Numero_Exterior):
            base(Clave, Clave_Catastral, Nombre_Propietario, Telefono_Propietario, Colonia, Calle, Entre_Calles, 
                Numero_Interior, Numero_Exterior)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Inmueble";
            }
        }

        public bool Insertar(string Clave_Catastral, string Nombre_Propietario, string Telefono_Propietario,
            string Colonia, string Calle, string Entre_Calles, string Numero_Interior, string Numero_Exterior)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Inmueble, es posible que no se haya insertado"
                    + " correctamente";
                if (validacion.Val_ClaveCatastral(Clave_Catastral))
                {
                    if (validacion.Val_Texto2(Nombre_Propietario, 1, 60))
                    {
                        if (validacion.Val_Numero(Telefono_Propietario, 1, 10) || Telefono_Propietario == "")
                        {
                            if (validacion.Val_Domicilio(Colonia,1,50) || Colonia == "")
                            {
                                if (validacion.Val_Domicilio(Calle, 1, 50) || Calle == "")
                                {
                                    if (validacion.Val_Domicilio(Entre_Calles, 0, 100) || Entre_Calles == "")
                                    {
                                        if (validacion.Val_Domicilio(Numero_Interior, 0, 10) || Numero_Interior == "")
                                        {
                                            if (validacion.Val_Domicilio(Numero_Exterior, 1, 10) || Numero_Exterior == "")
                                            {
                                                Inmueble inmueble = new Inmueble();
                                                inmueble.dtsSelXClaveCatastral(Clave_Catastral);
                                                if (inmueble.Existe == false)
                                                {
                                                    res = dtsInsertar(Clave_Catastral, Nombre_Propietario, Telefono_Propietario,
                                                     Colonia, Calle, Entre_Calles, Numero_Interior, Numero_Exterior);
                                                    if (res)
                                                        Mensaje = "El Inmueble fue registrado satisfactoriamente";
                                                }
                                                else
                                                    Mensaje = "No es posible dar de alta al Inmueble con esa Clave catastral ya que"
                                                        +" hay otro Inmueble que la tiene asignada, escriba otra diferente.";
                                            }
                                            else
                                                Mensaje = "El campo de Número exterior debe cumplir:\n\n- Solo puede"
                                                    + " contener caracteres alfabeticos, numericos, los simbolos .:,;-/#"
                                                    + " y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                                                    + " 10 caracteres.";
                                        }
                                        else
                                            Mensaje = "El campo de Número interior debe cumplir:\n\n- Solo puede contener"
                                            + " caracteres alfabeticos, numericos, los simbolos .:,;-/# y espacios en blanco."
                                            + "\n- El tamaño valido del campo es de 0 hasta 10 caracteres.";
                                    }
                                    else
                                        Mensaje = "El campo de Entre calles debe cumplir:\n\n- Solo puede contener"
                                    + " caracteres alfabeticos, numericos, los simbolos .:,;-/# y espacios en blanco."
                                    + " \n- El tamaño valido del campo es de 0 hasta 100 caracteres.";
                                }
                                else
                                    Mensaje = "El campo de Calle debe cumplir:\n\n- Solo puede contener caracteres"
                                    + " alfabeticos, numericos, los simbolos .:,;-/# y espacios en blanco.\n- El tamaño"
                                    + " valido del campo es de 1 hasta 50 caracteres.";
                            }
                            else
                                Mensaje = "El campo de Colonia debe cumplir:\n\n- Solo puede contener caracteres"
                                    + " alfabeticos, numericos, los simbolos .:,;-/# y espacios en blanco.\n- El"
                                    + " tamaño valido del campo es de 1 hasta 50 caracteres.";
                        }
                        else
                            Mensaje = "El campo de Teléfono del propietario debe cumplir:\n\n- Solo puede contener"
                                + " caracteres numéricos.\n- El tamaño valido del campo es de 1 hasta 10 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Nombre del propietario debe cumplir:\n\n- No puede quedar vacío."
                            + "\n- Solo puede contener caracteres alfabéticos, los simbolos .,- y espacios"
                            + " en blanco.\n- El tamaño valido del campo es de 1 hasta 60 caracteres.";
                }
                else
                    Mensaje = "El campo de Clave catastral debe cumplir:\n\n- No puede quedar vacío."
                        + "\n- Su formato correcto es ###-###-###-### ó #-##-###-####.\n- El tamaño valido del campo"
                        + " es de 13 hasta 15 caracteres.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Inmueble, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Clave, string Clave_Catastral, string Nombre_Propietario, string Telefono_Propietario,
            string Colonia, string Calle, string Entre_Calles, string Numero_Interior, string Numero_Exterior)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Inmueble, es posible"
                   + " que no se hayan modificado los datos correctamente";
                if (validacion.Val_ClaveCatastral(Clave_Catastral))
                {
                    if (validacion.Val_Texto2(Nombre_Propietario, 1, 60))
                    {
                        if (validacion.Val_Numero(Telefono_Propietario, 1, 10) || Telefono_Propietario == "")
                        {
                            if (validacion.Val_Domicilio(Colonia, 1, 50) || Colonia == "")
                            {
                                if (validacion.Val_Domicilio(Calle, 1, 50) || Calle == "")
                                {
                                    if (validacion.Val_Domicilio(Entre_Calles, 0, 100) || Entre_Calles == "")
                                    {
                                        if (validacion.Val_Domicilio(Numero_Interior, 0, 10) || Numero_Interior == "")
                                        {
                                            if (validacion.Val_Domicilio(Numero_Exterior, 1, 10) || Numero_Exterior == "")
                                            {
                                                Inmueble inmcatastral = new Inmueble();
                                                inmcatastral.SelXClaveCatastral(Clave_Catastral);
                                                if (inmcatastral.Existe == false || (inmcatastral.Existe && 
                                                    inmcatastral.Clave == Clave))
                                                {
                                                    Inmueble inmueble = new Inmueble(Clave);
                                                    if (inmueble.Existe)
                                                    {
                                                        res = dtsActualizar(Clave, Clave_Catastral, Nombre_Propietario,
                                                            Telefono_Propietario, Colonia, Calle, Entre_Calles,
                                                            Numero_Interior, Numero_Exterior);
                                                        if (res)
                                                            Mensaje = "Los datos del Inmueble fueron actualizados satisfactoriamente";
                                                    }
                                                    else
                                                        Mensaje = "No existe algún Inmueble con esa Clave, escoja un"
                                                            + " Inmueble existente para que sus datos sean actualizados";
                                                }
                                                else
                                                    Mensaje = "No es posible actualizar la Clave catastral del Inmueble al valor"
                                                        + " que introdujo ya que hay otro Inmueble la tiene asiganada, escriba"
                                                        + " otro diferente.";
                                            }
                                            else
                                                Mensaje = "El campo de Número exterior debe cumplir:\n\n- Solo puede"
                                                    + " contener caracteres alfabeticos, numericos, los simbolos .:,;-/#"
                                                    + " y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                                                    + " 10 caracteres.";
                                        }
                                        else
                                            Mensaje = "El campo de Número interior debe cumplir:\n\n- Solo puede contener"
                                            + " caracteres alfabeticos, numericos, los simbolos .:,;-/# y espacios en blanco."
                                            + "\n- El tamaño valido del campo es de 0 hasta 10 caracteres.";
                                    }
                                    else
                                        Mensaje = "El campo de Entre calles debe cumplir:\n\n- Solo puede contener"
                                    + " caracteres alfabeticos, numericos, los simbolos .:,;-/# y espacios en blanco."
                                    + " \n- El tamaño valido del campo es de 0 hasta 100 caracteres.";
                                }
                                else
                                    Mensaje = "El campo de Calle debe cumplir:\n\n- Solo puede contener caracteres"
                                    + " alfabeticos, numericos, los simbolos .:,;-/# y espacios en blanco.\n- El tamaño"
                                    + " valido del campo es de 1 hasta 50 caracteres.";
                            }
                            else
                                Mensaje = "El campo de Colonia debe cumplir:\n\n- Solo puede contener caracteres"
                                    + " alfabeticos, numericos, los simbolos .:,;-/# y espacios en blanco.\n- El"
                                    + " tamaño valido del campo es de 1 hasta 50 caracteres.";
                        }
                        else
                            Mensaje = "El campo de Teléfono del propietario debe cumplir:\n\n- Solo puede contener"
                                + " caracteres numéricos.\n- El tamaño valido del campo es de 1 hasta 10 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Nombre del propietario debe cumplir:\n\n- No puede quedar vacío."
                            + "\n- Solo puede contener caracteres alfabéticos, los simbolos .,- y espacios"
                            + " en blanco.\n- El tamaño valido del campo es de 1 hasta 60 caracteres.";
                }
                else
                    Mensaje = "El campo de Clave catastral debe cumplir:\n\n- No puede quedar vacío."
                        + "\n- Su formato correcto es ###-###-###-### ó #-##-###-####.\n- El tamaño valido del campo"
                        + " es de 13 hasta 15 caracteres.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Inmueble, es posible"
                    + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Clave)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Inmueble, es posible que no se haya borrado"
                    + " correctamente";
                Inmueble inmueble = new Inmueble(Clave);
                if (inmueble.Existe)
                {
                    res = dtsEliminar(Clave);
                    if (res)
                        Mensaje = "El Inmueble fue eliminado satisfactoriamente";
                }
                else
                    Mensaje = "No existe algún Inmueble con esa Clave, escoja un Inmueble existente"
                            + " para que sea depurado.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Inmueble, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Clave)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Inmueble, es posible que no se haya borrado"
                    + " correctamente";
                Inmueble inmueble = new Inmueble(Clave);
                if (inmueble.Existe)
                {
                    res = dtsActivar(Clave);
                    if (res)
                        Mensaje = "El Inmueble fue activado satisfactoriamente";
                }
                else
                    Mensaje = "No existe algún Inmueble con esa Clave, escoja un Inmueble existente"
                            + " para que sea activado.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Inmueble, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public DataTable SelActivos()
        {
            try
            {
                return dtsSelXCampoEliminado();
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Inmuebles activos";
                return null;
            }
        }

        public DataTable SelEliminados()
        {
            try
            {
                return dtsSelXCampoEliminado(true);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Inmuebles eliminados";
                return null;
            }
        }

        public void SelXClaveCatastral(string Clave_Catastral)
        {
            try
            {
                dtsSelXClaveCatastral(Clave_Catastral);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error al querer consultar a los Inmuebles por Clave catastral";
            }
        }

        public DataTable SelLikeClaveCatastral(string Clave_Catastral, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeClaveCatastral(Clave_Catastral, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Inmuebles por Clave Catastral";
                return null;
            }
        }

        public DataTable SelLikeNombrePropietario(string Nombre_Propietario, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeNombrePropietario(Nombre_Propietario, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Inmuebles por Nombre del Propietario";
                return null;
            }
        }

        public DataTable SelLikeTelefonoPropietario(string Telefono_Propietario, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeTelefonoPropietario(Telefono_Propietario, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Inmuebles por Telefono del Propietario";
                return null;
            }
        }

        public DataTable SelLikeColonia(string Colonia, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeColonia(Colonia, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Inmuebles por Colonia";
                return null;
            }
        }

        public Inmueble[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Inmueble[] inmuebles = new Inmueble[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Inmueble inmueble = new Inmueble();
                    if (Dt.Columns.Contains("Clave"))
                        inmueble.Clave = Convert.ToInt16(renglon["Clave"]);
                    if (Dt.Columns.Contains("Clave_Catastral"))
                        inmueble.Clave_Catastral =  renglon["Clave_Catastral"].ToString();
                    if (Dt.Columns.Contains("Nombre_Propietario"))
                        inmueble.Nombre_Propietario = renglon["Nombre_Propietario"].ToString();
                    if (Dt.Columns.Contains("Telefono_Propietario"))
                        inmueble.Telefono_Propietario = renglon["Telefono_Propietario"].ToString();
                    if (Dt.Columns.Contains("Colonia"))
                        inmueble.Colonia = renglon["Colonia"].ToString();
                    if (Dt.Columns.Contains("Calle"))
                        inmueble.Calle = renglon["Calle"].ToString();
                    if (Dt.Columns.Contains("Entre_Calles"))
                        inmueble.Entre_Calles = renglon["Entre_Calles"].ToString();
                    if (Dt.Columns.Contains("Numero_Interior"))
                        inmueble.Numero_Interior = renglon["Numero_Interior"].ToString();
                    if (Dt.Columns.Contains("Numero_Exterior"))
                        inmueble.Numero_Exterior = renglon["Numero_Exterior"].ToString();
                    if (Dt.Columns.Contains("Eliminado"))
                        inmueble.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    inmueble.Existe = true;
                    inmuebles[i] = inmueble;
                    i++;
                }
                return inmuebles;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Inmuebles";
                return new Inmueble[0];
            }
        }

        #endregion Metodos

    }
}

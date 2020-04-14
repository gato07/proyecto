using System;
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
                        if (validacion.Val_Numero(Telefono_Propietario, 1, 10))
                        {
                            if (validacion.Val_Domicilio(Colonia,1,50))
                            {
                                if (validacion.Val_Domicilio(Calle, 1, 50))
                                {
                                    if (validacion.Val_Domicilio(Entre_Calles, 0, 100))
                                    {
                                        if (validacion.Val_Domicilio(Numero_Interior, 0, 10))
                                        {
                                            if (validacion.Val_Domicilio(Numero_Exterior, 1, 10))
                                            {
                                                res = dtsInsertar(Clave_Catastral, Nombre_Propietario, 
                                                    Telefono_Propietario, Colonia, Calle, Entre_Calles, 
                                                    Numero_Interior, Numero_Exterior);
                                                if (res)
                                                    Mensaje = "El Inmueble fue registrado satisfactoriamente";
                                            }
                                            else
                                                Mensaje = "El campo de Número exterior debe cumplir:\n\n- No puede"
                                                    + " quedar vacío.\n- Solo puede contener caracteres alfabeticos,"
                                                    + " numericos, los simbolos .:,;-/# y espacios en blanco."
                                                    + " \n- El tamaño valido del campo es de 1 hasta 10 caracteres.";
                                        }
                                        else
                                            Mensaje = "El campo de Número interior debe cumplir:\n\n- Puede quedar"
                                            + " vacío.\n- Solo puede contener caracteres alfabeticos, numericos,"
                                            + " los simbolos .:,;-/# y espacios en blanco.\n- El tamaño valido del"
                                            + " campo es de 0 hasta 10 caracteres.";
                                    }
                                    else
                                        Mensaje = "El campo de Entre calles debe cumplir:\n\n- Puede quedar"
                                    + " vacío.\n- Solo puede contener caracteres alfabeticos, numericos,"
                                    + " los simbolos .:,;-/# y espacios en blanco.\n- El tamaño valido del"
                                    + " campo es de 0 hasta 100 caracteres.";
                                }
                                else
                                    Mensaje = "El campo de Calle debe cumplir:\n\n- No puede quedar"
                                    + " vacío.\n- Solo puede contener caracteres alfabeticos, numericos,"
                                    + " los simbolos .:,;-/# y espacios en blanco.\n- El tamaño valido del"
                                    + " campo es de 1 hasta 50 caracteres.";
                            }
                            else
                                Mensaje = "El campo de Colonia debe cumplir:\n\n- No puede quedar"
                                    + " vacío.\n- Solo puede contener caracteres alfabeticos, numericos,"
                                    + " los simbolos .:,;-/# y espacios en blanco.\n- El tamaño valido del"
                                    + " campo es de 1 hasta 50 caracteres.";
                        }
                        else
                            Mensaje = "El campo de Teléfono del propietario debe cumplir:\n\n- No puede quedar"
                                + " vacío.\n- Solo puede contener caracteres numéricos.\n- El tamaño valido del"
                                + " campo es de 1 hasta 10 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Nombre del propietario debe cumplir:\n\n- No puede quedar vacío."
                            + "\n- Solo puede contener caracteres alfabéticos, los simbolos .,- y espacios"
                            + " en blanco.\n- El tamaño valido del campo es de 1 hasta 60 caracteres.";
                }
                else
                    Mensaje = "El campo de Clave catastral debe cumplir:\n\n- No puede quedar vacío.\n- Solo"
                        + " puede contener el símbolo - y caracteres numéricos.\n- El tamaño valido del campo"
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
                        if (validacion.Val_Numero(Telefono_Propietario, 1, 10))
                        {
                            if (validacion.Val_Domicilio(Colonia, 1, 50))
                            {
                                if (validacion.Val_Domicilio(Calle, 1, 50))
                                {
                                    if (validacion.Val_Domicilio(Entre_Calles, 0, 100))
                                    {
                                        if (validacion.Val_Domicilio(Numero_Interior, 0, 10))
                                        {
                                            if (validacion.Val_Domicilio(Numero_Exterior, 1, 10))
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
                                                Mensaje = "El campo de Número exterior debe cumplir:\n\n- No puede"
                                                    + " quedar vacío.\n- Solo puede contener caracteres alfabeticos,"
                                                    + " numericos, los simbolos .:,;-/# y espacios en blanco."
                                                    + " \n- El tamaño valido del campo es de 1 hasta 10 caracteres.";
                                        }
                                        else
                                            Mensaje = "El campo de Número interior debe cumplir:\n\n- Puede quedar"
                                            + " vacío.\n- Solo puede contener caracteres alfabeticos, numericos,"
                                            + " los simbolos .:,;-/# y espacios en blanco.\n- El tamaño valido del"
                                            + " campo es de 0 hasta 10 caracteres.";
                                    }
                                    else
                                        Mensaje = "El campo de Entre calles debe cumplir:\n\n- Puede quedar"
                                    + " vacío.\n- Solo puede contener caracteres alfabeticos, numericos,"
                                    + " los simbolos .:,;-/# y espacios en blanco.\n- El tamaño valido del"
                                    + " campo es de 0 hasta 100 caracteres.";
                                }
                                else
                                    Mensaje = "El campo de Calle debe cumplir:\n\n- No puede quedar"
                                    + " vacío.\n- Solo puede contener caracteres alfabeticos, numericos,"
                                    + " los simbolos .:,;-/# y espacios en blanco.\n- El tamaño valido del"
                                    + " campo es de 1 hasta 50 caracteres.";
                            }
                            else
                                Mensaje = "El campo de Colonia debe cumplir:\n\n- No puede quedar"
                                    + " vacío.\n- Solo puede contener caracteres alfabeticos, numericos,"
                                    + " los simbolos .:,;-/# y espacios en blanco.\n- El tamaño valido del"
                                    + " campo es de 1 hasta 50 caracteres.";
                        }
                        else
                            Mensaje = "El campo de Teléfono del propietario debe cumplir:\n\n- No puede quedar"
                                + " vacío.\n- Solo puede contener caracteres numéricos.\n- El tamaño valido del"
                                + " campo es de 1 hasta 10 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Nombre del propietario debe cumplir:\n\n- No puede quedar vacío."
                            + "\n- Solo puede contener caracteres alfabéticos, los simbolos .,- y espacios"
                            + " en blanco.\n- El tamaño valido del campo es de 1 hasta 60 caracteres.";
                }
                else
                    Mensaje = "El campo de Clave catastral debe cumplir:\n\n- No puede quedar vacío.\n- Solo"
                        + " puede contener el símbolo - y caracteres numéricos.\n- El tamaño valido del campo"
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

        public DataTable SelActivos()
        {
            try
            {
                return dtsSelActivos();
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
                return dtsSelEliminados();
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Inmuebles eliminados";
                return null;
            }
        }

        public Inmueble[] Inmuebles(DataTable Dt)
        {
            try
            {
                int i = 0;
                Inmueble[] inmuebles = new Inmueble[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Inmueble inmueble = new Inmueble(
                        Convert.ToInt16(renglon["Clave"]),
                        renglon["Clave_Catastral"].ToString(),
                        renglon["Nombre_Propietario"].ToString(),
                        renglon["Telefono_Propietario"].ToString(),
                        renglon["Colonia"].ToString(),
                        renglon["Calle"].ToString(),
                        renglon["Entre_Calles"].ToString(),
                        renglon["Numero_Interior"].ToString(),
                        renglon["Numero_Exterior"].ToString());
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

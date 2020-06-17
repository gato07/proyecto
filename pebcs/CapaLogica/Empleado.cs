using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Empleado:dtsEmpleado
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Empleado() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Empleado";
            }
        }

        public Empleado(int Clave) : base(Clave)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Empleado";
            }
        }

        public Empleado(int Clave, string Nombre, string Domicilio, string Telefono, string Email,
            string Foto, int Perfil, string Usuario, string Contrasena) : base(Clave, Nombre, 
                Domicilio, Telefono, Email, Foto, Perfil, Usuario, Contrasena)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Empleado";
            }
        }

        public bool Insertar(string Nombre, string Domicilio, string Telefono, string Email, 
            string Foto, int Perfil, string Usuario, string Contrasena)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Empleado, es posible que no se haya insertado"
                    + " correctamente";
                if (validacion.Val_Texto1(Nombre, 1, 60))
                {
                    if (validacion.Val_Domicilio(Domicilio, 1, 255))
                    {
                        if (validacion.Val_Numero(Telefono, 1, 10))
                        {
                            if (validacion.Val_Email(Email))
                            {
                                if (validacion.Val_RutaArchivo(Foto))
                                {
                                    if (Perfil >= 1 && Perfil <= 4)
                                    {
                                        if (validacion.Val_Usuario(Usuario))
                                        {
                                            if (validacion.Val_Contrasena(Contrasena))
                                            {
                                                Empleado usuario = new Empleado();
                                                usuario.SelXUsuario(Usuario);
                                                if (usuario.Existe == false)
                                                {
                                                    res = dtsInsertar(Nombre, Domicilio, Telefono, Email, Foto, Perfil, Usuario, Contrasena);
                                                    if (res)
                                                        Mensaje = "El Empleado fue registrado satisfactoriamente";
                                                }
                                                else
                                                    Mensaje = "No es posible dar de alta al Empleado con ese nombre de Usuario ya que hay otro Empleado que"
                                                    + " lo esta usando, escriba otro diferente.";
                                            }
                                            else
                                                Mensaje = "El campo de Contraseña debe cumplir:\n\n- No puede quedar vacío."
                                                + "\n- Debe contener al menos una letra mayúscula, una minúscula, un simbolo"
                                                + " -,.+*#$%&/¡!¿? y un número. \n- El tamaño valido del campo es de 8 hasta 16 caracteres.";
                                        }
                                        else
                                            Mensaje = "El campo de Usuario debe cumplir:\n\n- No puede quedar vacío.\n- Solo"
                                                + " puede contener caracteres alfabéticos en minúscula y numéricos.\n- El"
                                                + " tamaño valido del campo es de 4 hasta 15 caracteres.";
                                    }
                                    else
                                        Mensaje = "El campo de Perfil solo puede tener los valores de 1, 2, 3 o 4.";
                                }
                                else
                                    Mensaje = "El campo de Foto debe cumplir:\n\n- No puede quedar vacío."
                                        + "\n- El tamaño valido del campo es de 1 hasta 255 caracteres.";
                            }
                            else
                                Mensaje = "El campo de Email debe cumplir:\n\n- No puede quedar vacío.\n- Debe ser una"
                                + " dirección de correo valida.\n- El tamaño valido del campo es de 1 hasta 255 caracteres.";
                        }
                        else
                            Mensaje = "El campo de Teléfono debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                                + " caracteres numéricos.\n- El tamaño valido del campo es de 1 hasta 10 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Domicilio debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                            + " caracteres alfabéticos, numéricos, los símbolos #:.-;,/ y espacios en blanco."
                            + "\n- Debe tener solo un espacio en blanco entre palabras.\n- El tamaño valido"
                            + " del campo es de 1 hasta 255 caracteres.";
                }
                else
                    Mensaje = "El campo de Nombre debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                        + " caracteres alfabéticos y espacios en blanco.\n- Debe tener solo un espacio en blanco"
                        + " entre palabras.\n- El tamaño valido del campo es de 1 hasta 60 caracteres.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Empleado, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Clave, string Nombre, string Domicilio, string Telefono, string Email, 
            string Foto, int Perfil, string Usuario, string Contrasena)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Empleado, es posible"
                   + " que no se hayan modificado los datos correctamente";
                if (validacion.Val_Texto1(Nombre, 1, 60))
                {
                    if (validacion.Val_Domicilio(Domicilio, 1, 255))
                    {
                        if (validacion.Val_Numero(Telefono, 1, 10))
                        {
                            if (validacion.Val_Email(Email))
                            {
                                if (validacion.Val_RutaArchivo(Foto))
                                {
                                    if (Perfil >= 1 && Perfil <= 4)
                                    {
                                        if (validacion.Val_Usuario(Usuario))
                                        {
                                            if (validacion.Val_Contrasena(Contrasena))
                                            {
                                                Empleado usuario = new Empleado();
                                                usuario.SelXUsuario(Usuario);
                                                if (usuario.Existe == false || (usuario.Existe && usuario.Clave == Clave))
                                                {
                                                    Empleado empleado = new Empleado(Clave);
                                                    if (empleado.Existe)
                                                    {
                                                        res = dtsActualizar(Clave, Nombre, Domicilio, Telefono, Email, Foto, Perfil, Usuario, Contrasena);
                                                        if (res)
                                                            Mensaje = "Los datos del Empleado fueron actualizados satisfactoriamente";
                                                    }
                                                    else
                                                        Mensaje = "No existe algún Empleado con esa Clave, escoja un Empleado"
                                                            + " existente para que sus datos sean actualizados";
                                                }
                                                else
                                                    Mensaje = "No es posible actualizar el nombre de Usuario del Empleado al valor"
                                                        + " que introdujo ya que hay otro Empleado que lo esta usando, escriba otro diferente.";
                                            }
                                            else
                                                Mensaje = "El campo de Contraseña debe cumplir:\n\n- No puede quedar vacío."
                                                + "\n- Debe contener al menos una letra mayúscula, una minúscula, un simbolo"
                                                + " -,.+*#$%&/¡!¿? y un número. \n- El tamaño valido del campo es de 8 hasta 16 caracteres.";
                                        }
                                        else
                                            Mensaje = "El campo de Usuario debe cumplir:\n\n- No puede quedar vacío.\n- Solo"
                                                + " puede contener caracteres alfabéticos en minúscula y numéricos.\n- El"
                                                + " tamaño valido del campo es de 4 hasta 15 caracteres.";
                                    }
                                    else
                                        Mensaje = "El campo de Perfil solo puede tener los valores de 1, 2, 3 o 4.";
                                }
                                else
                                    Mensaje = "El campo de Foto debe cumplir:\n\n- No puede quedar vacío."
                                            + "\n- El tamaño valido del campo es de 1 hasta 255 caracteres.";
                            }
                            else
                                Mensaje = "El campo de Email debe cumplir:\n\n- No puede quedar vacío.\n- Debe ser una"
                                + " dirección de correo valida.\n- El tamaño valido del campo es de 1 hasta 255 caracteres.";
                        }
                        else
                            Mensaje = "El campo de Teléfono debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                                + " caracteres numéricos.\n- El tamaño valido del campo es de 1 hasta 10 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Domicilio debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                            + " caracteres alfabéticos, numéricos, los símbolos #:.-;,/ y espacios en blanco."
                            + "\n- Debe tener solo un espacio en blanco entre palabras.\n- El tamaño valido"
                            + " del campo es de 1 hasta 255 caracteres.";
                }
                else
                    Mensaje = "El campo de Nombre debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                        + " caracteres alfabéticos y espacios en blanco.\n- Debe tener solo un espacio en blanco"
                        + " entre palabras.\n- El tamaño valido del campo es de 1 hasta 60 caracteres.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Empleado, es posible"
                    + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Clave)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Empleado, es posible que no se haya borrado"
                    + " correctamente";
                Empleado empleado = new Empleado(Clave);
                if (empleado.Existe)
                {
                    res = dtsEliminar(Clave);
                    if (res)
                        Mensaje = "El Empleado fue eliminado satisfactoriamente";
                }
                else
                    Mensaje = "No existe algún Empleado con esa Clave, escoja un Empleado existente"
                            + " para que sea depurado.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Empleado, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Clave)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de Activación del Empleado, es posible que no se haya borrado"
                    + " correctamente";
                Empleado empleado = new Empleado(Clave);
                if (empleado.Existe)
                {
                    res = dtsActivar(Clave);
                    if (res)
                        Mensaje = "El Empleado fue activado satisfactoriamente";
                }
                else
                    Mensaje = "No existe algún Empleado con esa Clave, escoja un Empleado existente"
                            + " para que sea activado.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Activación del Empleado, es posible que no se haya borrado"
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Empleados activos";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Empleados eliminados";
                return null;
            }
        }

        public void SelXUsuario(string Usuario)
        {
            try
            {
                dtsSelXUsuario(Usuario);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a los Empleados por Usuario";
            }
        }

        public DataTable SelLikeUsuario(string Usuario, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeUsuario(Usuario, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Empleados por Usuario";
                return null;
            }
        }

        public DataTable SelLikeNombre(string Nombre, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeNombre(Nombre, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Empleados por Nombre";
                return null;
            }
        }

        public DataTable SelLikeEmail(string Email, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeEmail(Email, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Empleados por Email";
                return null;
            }
        }

        public Empleado[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Empleado[] empleados = new Empleado[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Empleado empleado = new Empleado();
                    if(Dt.Columns.Contains("Clave"))
                        empleado.Clave = Convert.ToInt16(renglon["Clave"]);
                    if(Dt.Columns.Contains("Nombre"))
                        empleado.Nombre = renglon["Nombre"].ToString();
                    if(Dt.Columns.Contains("Domicilio"))
                        empleado.Domicilio = renglon["Domicilio"].ToString();
                    if(Dt.Columns.Contains("Telefono"))
                        empleado.Telefono = renglon["Telefono"].ToString();
                    if(Dt.Columns.Contains("Email"))
                        empleado.Email = renglon["Email"].ToString();
                    if(Dt.Columns.Contains("Foto"))
                        empleado.Foto = renglon["Foto"].ToString();
                    if (Dt.Columns.Contains("Perfil"))
                        empleado.Perfil = Convert.ToInt16(renglon["Perfil"]);
                    if (Dt.Columns.Contains("Usuario"))
                        empleado.Usuario = renglon["Usuario"].ToString();
                    if (Dt.Columns.Contains("Contrasena"))
                        empleado.Contrasena = renglon["Contrasena"].ToString();
                    if (Dt.Columns.Contains("Eliminado"))
                        empleado.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    empleado.Existe = true;
                    empleados[i] = empleado;
                    i++;
                }
                return empleados;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Empleados";
                return new Empleado[0];
            }
        }

        #endregion Metodos

    }
}

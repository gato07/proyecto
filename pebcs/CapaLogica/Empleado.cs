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
            string Puesto, string Foto, int Perfil, string Usuario, string Contrasena) : base(Clave, Nombre, 
                Domicilio, Telefono, Email, Puesto, Foto, Perfil, Usuario, Contrasena)
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
            string Puesto, string Foto, int Perfil, string Usuario, string Contrasena)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Empleado, es posible que no se haya insertado"
                    + " correctamente";
                if (validacion.Val_Texto1(Nombre, 1, 60))
                {
                    if (validacion.Val_Domicilio(Domicilio,1,255))
                    {
                        if (validacion.Val_Numero(Telefono,1,10))
                        {
                            if (validacion.Val_Email(Email))
                            {
                                if (validacion.Val_Texto1(Puesto, 1, 50))
                                {
                                    if (validacion.Val_RutaArchivo(Foto))
                                    {
                                        if (validacion.Val_Perfil(Perfil))
                                        {
                                            if (validacion.Val_Usuario(Usuario))
                                            {
                                                if (validacion.Val_Contrasena(Contrasena))
                                                {
                                                    Empleado usuario = new Empleado();
                                                    usuario.SelXUsuario(Usuario);
                                                    if (usuario.Existe == false)
                                                    {
                                                        res = dtsInsertar(Nombre, Domicilio, Telefono, Email, Puesto, Foto, Perfil, Usuario, Contrasena);
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
                                    Mensaje = "El campo de Puesto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                                        + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                                        + " 50 caracteres.";
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
                            + " caracteres alfabéticos, numéricos, los símbolos #.-,/ y espacios en blanco."
                            + "\n- El tamaño valido del campo es de 1 hasta 255 caracteres.";
                }
                else
                    Mensaje = "El campo de Nombre debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                        + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                        + " 60 caracteres.";
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
             string Puesto, string Foto, int Perfil, string Usuario, string Contrasena)
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
                                if (validacion.Val_Texto1(Puesto, 1, 50))
                                {
                                    if (validacion.Val_RutaArchivo(Foto))
                                    {
                                        if (validacion.Val_Perfil(Perfil))
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
                                                            res = dtsActualizar(Clave, Nombre, Domicilio, Telefono, Email, Puesto, Foto, Perfil, Usuario, Contrasena);
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
                                    Mensaje = "El campo de Puesto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                                        + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                                        + " 50 caracteres.";
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
                            + " caracteres alfabéticos, numéricos, los símbolos #.-,/ y espacios en blanco."
                            + "\n- El tamaño valido del campo es de 1 hasta 255 caracteres.";
                }
                else
                    Mensaje = "El campo de Nombre debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                        + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                        + " 60 caracteres.";
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
                return dtsSelActivos();
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
                return dtsSelEliminados();
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Empleados deshabilitados";
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

        public Empleado[] Empleados(DataTable Dt)
        {
            try
            {
                int i = 0;
                Empleado[] empleados = new Empleado[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Empleado empleado = new Empleado(
                        Convert.ToInt16(renglon["Clave"]),
                        renglon["Nombre"].ToString(),
                        renglon["Domicilio"].ToString(),
                        renglon["Telefono"].ToString(),
                        renglon["Email"].ToString(),
                        renglon["Puesto"].ToString(),
                        renglon["Foto"].ToString(),
                        Convert.ToInt16(renglon["Perfil"]),
                        renglon["Usuario"].ToString(),
                        renglon["Contrasena"].ToString());
                    if(Dt.Columns.Contains("Eliminado"))
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

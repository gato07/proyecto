using System;
using System.Data;
using CapaAccesoDatos;

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
            string Puesto, string Foto, string Perfil, string Usuario, string Contrasena) : base(Clave, Nombre, 
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
            string Puesto, string Foto, string Perfil, string Usuario, string Contrasena)
        {
            try
            {
                bool res = false;
                res = dtsInsertar(Nombre, Domicilio, Telefono, Email, Puesto, Foto, Perfil, 
                    Usuario, Contrasena);
                Mensaje = "El Empleado fue registrado satisfactoriamente";
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
             string Puesto, string Foto, string Perfil, string Usuario, string Contrasena)
        {
            try
            {
                bool res = false;
                res = dtsActualizar(Clave, Nombre, Domicilio, Telefono, Email, Puesto, Foto, Perfil,
                    Usuario, Contrasena);
                Mensaje = "Los datos del Empleado fueron actualizados satisfactoriamente";
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
                res = dtsEliminar(Clave);
                Mensaje = "El Empleado fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Empleado, es posible que no se haya borrado"
                    + " correctamente";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Empleados";
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

        public Empleado[] Empleados()
        {
            try
            {
                int i = 0;
                DataTable dt = SelTodos();
                Empleado[] empleados = new Empleado[dt.Rows.Count];
                foreach (DataRow renglon in dt.Rows)
                {
                    Empleado empleado = new Empleado(
                        Convert.ToInt16(renglon["Clave"].ToString()),
                        renglon["Nombre"].ToString(),
                        renglon["Domicilio"].ToString(),
                        renglon["Telefono"].ToString(),
                        renglon["Email"].ToString(),
                        renglon["Puesto"].ToString(),
                        renglon["Foto"].ToString(),
                        renglon["Perfil"].ToString(),
                        renglon["Usuario"].ToString(),
                        renglon["Contrasena"].ToString());
                    empleado.Existe = true;
                    empleados[i] = empleado;
                    i++;
                }
                return empleados;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Empleados";
                return null;
            }
        }

        #endregion Metodos

    }
}

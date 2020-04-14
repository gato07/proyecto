using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Cliente:dtsCliente
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Cliente() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Cliente";
            }
        }

        public Cliente(int Id) : base(Id)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Cliente";
            }
        }

        public Cliente(int Id, string Nombre, string Apellido, string Telefono, string Email):
            base(Id, Nombre, Apellido, Telefono, Email)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Cliente";
            }
        }

        public bool Insertar(string Nombre, string Apellido, string Telefono, string Email)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Cliente, es posible que no se haya insertado"
                    + " correctamente";
                if (validacion.Val_Texto1(Nombre, 1, 30))
                {
                    if (validacion.Val_Texto1(Apellido, 1, 30))
                    {
                        if (validacion.Val_Numero(Telefono, 1, 10))
                        {
                            if (validacion.Val_Email(Email))
                            {
                                res = dtsInsertar(Nombre, Apellido, Telefono, Email);
                                if (res)
                                    Mensaje = "El Cliente fue registrado satisfactoriamente";                
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
                        Mensaje = "El campo de Apellido debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                        + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                        + " 30 caracteres.";
                }
                else
                    Mensaje = "El campo de Nombre debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                        + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                        + " 30 caracteres.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Cliente, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Id, string Nombre, string Apellido, string Telefono, string Email)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Cliente, es posible"
                   + " que no se hayan modificado los datos correctamente";
                if (validacion.Val_Texto1(Nombre, 1, 30))
                {
                    if (validacion.Val_Texto1(Apellido, 1, 30))
                    {
                        if (validacion.Val_Numero(Telefono, 1, 10))
                        {
                            if (validacion.Val_Email(Email))
                            {
                                Cliente cliente = new Cliente(Id);
                                if (cliente.Existe)
                                {
                                    res = dtsActualizar(Id, Nombre, Apellido, Telefono, Email);
                                    if (res)
                                        Mensaje = "Los datos del Cliente fueron actualizados satisfactoriamente.";
                                }
                                else
                                    Mensaje = "No existe algún Cliente con esa Id, escoja un Cliente"
                                        + " existente para que sus datos sean actualizados.";
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
                        Mensaje = "El campo de Apellido debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                        + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                        + " 30 caracteres.";
                }
                else
                    Mensaje = "El campo de Nombre debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                        + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1 hasta"
                        + " 30 caracteres.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Cliente, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Id)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Cliente, es posible que no"
                    + " se haya borrado correctamente";
                Cliente cliente = new Cliente(Id);
                if (cliente.Existe)
                {
                    res = dtsEliminar(Id);
                    if (res)
                        Mensaje = "El Cliente fue eliminado satisfactoriamente";
                }
                else
                    Mensaje = "No existe algún Cliente con ese Id, escoja un Cliente existente"
                        + " para que sea depurado.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Cliente, es posible que no"
                    + " se haya borrado correctamente";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Clientes activos";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Clientes eliminados";
                return null;
            }
        }

        public Cliente[] Clientes(DataTable Dt)
        {
            try
            {
                int i = 0;
                Cliente[] clientes = new Cliente[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Cliente cliente = new Cliente(
                        Convert.ToInt16(renglon["Id"]),
                        renglon["Nombre"].ToString(),
                        renglon["Apellido"].ToString(),
                        renglon["Telefono"].ToString(),
                        renglon["Email"].ToString());
                    if (Dt.Columns.Contains("Eliminado"))
                        cliente.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    cliente.Existe = true;
                    clientes[i] = cliente;
                    i++;
                }
                return clientes;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Clientes";
                return new Cliente[0];
            }
        }

        #endregion Metodos

    }
}

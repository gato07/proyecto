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

        public Cliente(int Id, string Rfc, string Nombre, string Apellido, string Telefono, string Email) :
            base(Id, Rfc, Nombre, Apellido, Telefono, Email)
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

        public bool Insertar(string Rfc, string Nombre, string Apellido, string Telefono, string Email)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Cliente, es posible que no se haya insertado"
                    + " correctamente";
                if (validacion.Val_Rfc(Rfc))
                {
                    if (validacion.Val_Texto1(Nombre, 1, 30))
                    {
                        if (validacion.Val_Texto1(Apellido, 1, 30))
                        {
                            if (validacion.Val_Numero(Telefono, 1, 10))
                            {
                                if (validacion.Val_Email(Email))
                                {
                                    Cliente cliente = new Cliente();
                                    cliente.SelXRfc(Rfc);
                                    if (cliente.Existe == false)
                                    {
                                        res = dtsInsertar(Rfc, Nombre, Apellido, Telefono, Email);
                                        if (res)
                                            Mensaje = "El Cliente fue registrado satisfactoriamente";
                                    }
                                    else
                                        Mensaje = "No es posible dar de alta al Cliente con ese Rfc ya que hay otro Cliente que"
                                        + " lo tiene asignado, escriba otro diferente.";
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
                            + " caracteres alfabéticos y espacios en blanco.\n- Debe tener solo un espacio en blanco entre"
                            + " palabras.\n- El tamaño valido del campo es de 1 hasta 30 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Nombre debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                            + " caracteres alfabéticos y espacios en blanco.\n- Debe tener solo un espacio en blanco entre"
                            + " palabras.\n- El tamaño valido del campo es de 1 hasta 30 caracteres.";
                }
                else
                    Mensaje = "El campo de RFC debe cumplir:\n\n- No puede quedar vacío."
                        + "\n- Su formato correcto es AAA000000### ó AAAA000000###.\n- El tamaño valido del campo"
                        + " es de 12 hasta 13 caracteres.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Cliente, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Id, string Rfc, string Nombre, string Apellido, string Telefono, string Email)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Cliente, es posible"
                   + " que no se hayan modificado los datos correctamente";
                if (validacion.Val_Rfc(Rfc))
                {
                    if (validacion.Val_Texto1(Nombre, 1, 30))
                    {
                        if (validacion.Val_Texto1(Apellido, 1, 30))
                        {
                            if (validacion.Val_Numero(Telefono, 1, 10))
                            {
                                if (validacion.Val_Email(Email))
                                {
                                    Cliente rfc = new Cliente();
                                    rfc.SelXRfc(Rfc);
                                    if (rfc.Existe == false || (rfc.Existe && rfc.Id == Id))
                                    {
                                        Cliente cliente = new Cliente(Id);
                                        if (cliente.Existe)
                                        {
                                            res = dtsActualizar(Id, Rfc, Nombre, Apellido, Telefono, Email);
                                            if (res)
                                                Mensaje = "Los datos del Cliente fueron actualizados satisfactoriamente.";
                                        }
                                        else
                                            Mensaje = "No existe algún Cliente con esa Id, escoja un Cliente"
                                                + " existente para que sus datos sean actualizados.";
                                    }
                                    else
                                        Mensaje = "No es posible actualizar el nombre de Usuario del Empleado al valor"
                                            + " que introdujo ya que hay otro Empleado que lo esta usando, escriba otro diferente.";
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
                            + " caracteres alfabéticos y espacios en blanco.\n- Debe tener solo un espacio en blanco entre"
                            + " palabras.\n- El tamaño valido del campo es de 1 hasta 30 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Nombre debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                            + " caracteres alfabéticos y espacios en blanco.\n- Debe tener solo un espacio en blanco entre"
                            + " palabras.\n- El tamaño valido del campo es de 1 hasta 30 caracteres.";
                }
                else
                    Mensaje = "El campo de RFC debe cumplir:\n\n- No puede quedar vacío."
                        + "\n- Su formato correcto es AAA000000### ó AAAA000000###.\n- El tamaño valido del campo"
                        + " es de 12 hasta 13 caracteres.";
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

        public bool Activar(int Id)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de Activación del Cliente, es posible que no"
                    + " se haya activado correctamente";
                Cliente cliente = new Cliente(Id);
                if (cliente.Existe)
                {
                    res = dtsActivar(Id);
                    if (res)
                        Mensaje = "El Cliente fue activado satisfactoriamente";
                }
                else
                    Mensaje = "No existe algún Cliente con ese Id, escoja un Cliente existente"
                        + " para que sea activado.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Activación del Cliente, es posible que no"
                    + " se haya activado correctamente";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Clientes activos";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Clientes eliminados";
                return null;
            }
        }

        public void SelXRfc(string Rfc)
        {
            try
            {
                dtsSelXRfc(Rfc);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error al querer consultar a los Clientes por RFC";
            }
        }

        public DataTable SelLikeRfc(string Rfc, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeRfc(Rfc, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Clientes por RFC";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Clientes por Nombre";
                return null;
            }
        }

        public DataTable SelLikeTelefono(string Telefono, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeTelefono(Telefono, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Clientes por Telefono";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Clientes por Email";
                return null;
            }
        }

        public Cliente[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Cliente[] clientes = new Cliente[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Cliente cliente = new Cliente();
                    if(Dt.Columns.Contains("Id"))
                        cliente.Id = Convert.ToInt16(renglon["Id"]);
                    if (Dt.Columns.Contains("Rfc"))
                        cliente.Rfc = renglon["Rfc"].ToString();
                    if (Dt.Columns.Contains("Nombre"))
                        cliente.Nombre = renglon["Nombre"].ToString();
                    if (Dt.Columns.Contains("Apellido"))
                        cliente.Apellido = renglon["Apellido"].ToString();
                    if (Dt.Columns.Contains("Telefono"))
                        cliente.Telefono = renglon["Telefono"].ToString();
                    if (Dt.Columns.Contains("Email"))
                        cliente.Email = renglon["Email"].ToString();
                    if(Dt.Columns.Contains("Eliminado"))
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

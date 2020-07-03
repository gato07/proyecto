using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Presupuesto : dtsPresupuesto
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Presupuesto() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Presupuesto";
            }
        }

        public Presupuesto(int Numero) : base(Numero)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Presupuesto";
            }
        }

        public Presupuesto(int Numero, string Etiqueta, DateTime Fecha, string Nombre_Solicitante,
            string Nombre_Propietario, string Genero, decimal Mts, decimal Total, int Aprobado, int Id_Tipo_Proyecto,
            int Clave_Empleado):base(Numero, Etiqueta, Fecha, Nombre_Solicitante, Nombre_Propietario, Genero, Mts, Total, 
        Aprobado, Id_Tipo_Proyecto, Clave_Empleado)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Presupuesto";
            }
        }

        public int Insertar(string Etiqueta, string Nombre_Solicitante, string Nombre_Propietario, string Genero,
            decimal Mts, decimal Total, int Aprobado, int Id_Tipo_Proyecto, int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Presupuesto, es posible que no se haya insertado"
                    + " correctamente";
                if (validacion.Val_Texto4(Etiqueta, 1, 30))
                {
                    if (validacion.Val_Texto1(Nombre_Solicitante, 1, 60))
                    {
                        if (validacion.Val_Texto1(Nombre_Propietario, 1, 60))
                        {
                            if (validacion.Val_Texto2(Genero, 1, 30))
                            {
                                if(Mts >= 0m && Mts <= 999999.99m)
                                {
                                    if (Total >= 0.00m && Total <= 9999999.99m)
                                    {
                                        if (Aprobado >= 0 && Aprobado <= 2)
                                        {
                                            Tipo_Proyecto tipopro = new Tipo_Proyecto(Id_Tipo_Proyecto);
                                            if(tipopro.Existe)
                                            {
                                                Empleado empleado = new Empleado(Clave_Empleado);
                                                if(empleado.Existe)
                                                {
                                                    res = dtsInsertar(Etiqueta, Nombre_Solicitante, Nombre_Propietario, 
                                                        Genero, Mts, Total, Aprobado, Id_Tipo_Proyecto, Clave_Empleado);
                                                    if (res > 0)
                                                        Mensaje = "El Presupuesto fue registrado satisfactoriamente";
                                                }
                                                else
                                                    Mensaje = "No existe algún Empleado con la Clave indicada, ingrese una real";
                                            }
                                            else
                                                Mensaje = "No existe algún Tipo de proyecto con el Id indicado, ingrese uno real";
                                        }
                                        else
                                            Mensaje = "El campo Aprobado:\n\n- No puede quedar vacío.\n- Solo puede"
                                                + " contener valores númericos.\n- El intervalo de valores permitidos en el"
                                                + " campo va desde 0 hasta 2";
                                    }
                                    else
                                        Mensaje = "El campo Total del Presupuesto:\n\n- No puede quedar vacío.\n- Solo puede"
                                            + " contener valores númericos con dos puntos decimales.\n- El intervalo de"
                                            + " valores permitidos en el campo va desde $0.00 hasta $9,999,999.99";
                                }
                                else
                                    Mensaje = "El campo de Mts debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                + " contener valores númericos con dos puntos decimales.\n- El intervalo de valores"
                                + " permitidos en el campo va desde 0.00 hasta 999,999.99";
                            }
                            else
                                Mensaje = "El campo de Género debe cumplir:\n\n- No puede quedar vacío."
                                + "\n- Solo puede contener caracteres alfabéticos, los símbolos ,.- y espacios"
                                + " en blanco.\n- El tamaño valido del campo es de 1 hasta 30 caracteres.";
                        }
                        else
                            Mensaje = "El campo de Nombre del propietario debe cumplir:\n\n- No puede quedar vacío."
                            + "\n- Solo puede contener caracteres alfabéticos y espacios en blanco.\n- El tamaño valido"
                            + " del campo es de 1 hasta 60 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Nombre del solicitante debe cumplir:\n\n- No puede quedar vacío."
                        + "\n- Solo puede contener caracteres alfabéticos y espacios en blanco.\n- El tamaño valido"
                        + " del campo es de 1 hasta 60 caracteres.";
                }
                else
                    Mensaje = "El campo de Etiqueta debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                            + " caracteres alfabéticos, numéricos, los símbolos ,.- y espacios en blanco."
                            + "\n- El tamaño valido del campo es de 1 hasta 30 caracteres.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Presupuesto, es posible que no se haya insertado"
                    + " correctamente";
                return 0;
            }
        }

        public bool Actualizar(int Numero, string Etiqueta, string Nombre_Solicitante,
            string Nombre_Propietario, string Genero, decimal Mts, decimal Total, int Aprobado, int Id_Tipo_Proyecto)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Presupuesto, es posible"
                   + " que no se hayan modificado los datos correctamente";
                Presupuesto presupuesto = new Presupuesto(Numero);
                if (presupuesto.Existe)
                {
                    if (validacion.Val_Texto4(Etiqueta, 1, 30))
                    {
                        if (validacion.Val_Texto1(Nombre_Solicitante, 1, 60))
                        {
                            if (validacion.Val_Texto1(Nombre_Propietario, 1, 60))
                            {
                                if (validacion.Val_Texto2(Genero, 1, 30))
                                {
                                    if (Mts >= 0m && Mts <= 999999.99m)
                                    {
                                        if (Total >= 0.00m && Total <= 9999999.99m)
                                        {
                                            if (Aprobado >= 0 && Aprobado <= 2)
                                            {
                                                Tipo_Proyecto tipopro = new Tipo_Proyecto(Id_Tipo_Proyecto);
                                                if (tipopro.Existe)
                                                {
                                                    res = dtsActualizar(Numero, Etiqueta, Nombre_Solicitante,
                                                            Nombre_Propietario, Genero, Mts, Total, Aprobado, Id_Tipo_Proyecto);
                                                    if (res)
                                                        Mensaje = "Los datos del Presupuesto fueron actualizados satisfactoriamente";
                                                }
                                                else
                                                    Mensaje = "No existe algún Tipo de proyecto con el Id indicado, ingrese uno real";
                                            }
                                            else
                                                Mensaje = "El campo Aprobado:\n\n- No puede quedar vacío.\n- Solo puede"
                                                    + " contener valores númericos.\n- El intervalo de valores permitidos en el"
                                                    + " campo va desde 0 hasta 2";
                                        }
                                        else
                                            Mensaje = "El campo Total del Presupuesto:\n\n- No puede quedar vacío.\n- Solo puede"
                                                + " contener valores númericos con dos puntos decimales.\n- El intervalo de"
                                                + " valores permitidos en el campo va desde $0.00 hasta $9,999,999.99";
                                    }
                                    else
                                        Mensaje = "El campo de Mts debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                    + " contener valores númericos con dos puntos decimales.\n- El intervalo de valores"
                                    + " permitidos en el campo va desde 0.00 hasta 999,999.99";
                                }
                                else
                                    Mensaje = "El campo de Género debe cumplir:\n\n- No puede quedar vacío."
                                    + "\n- Solo puede contener caracteres alfabéticos, los símbolos ,.- y espacios"
                                    + " en blanco.\n- El tamaño valido del campo es de 1 hasta 30 caracteres.";
                            }
                            else
                                Mensaje = "El campo de Nombre del propietario debe cumplir:\n\n- No puede quedar vacío."
                                + "\n- Solo puede contener caracteres alfabéticos y espacios en blanco.\n- El tamaño valido"
                                + " del campo es de 1 hasta 60 caracteres.";
                        }
                        else
                            Mensaje = "El campo de Nombre del solicitante debe cumplir:\n\n- No puede quedar vacío."
                            + "\n- Solo puede contener caracteres alfabéticos y espacios en blanco.\n- El tamaño valido"
                            + " del campo es de 1 hasta 60 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Etiqueta debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                                + " caracteres alfabéticos, numéricos, los símbolos ,.- y espacios en blanco."
                                + "\n- El tamaño valido del campo es de 1 hasta 30 caracteres.";
                }
                else
                    Mensaje = "No existe algún Presupuesto con el Número indicado, por lo cual no se puede actualizar";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Presupuesto, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero);
                if (res)
                    Mensaje = "El Presupuesto fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Depurar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de depuración del Presupuesto, es posible que no se haya depurado"
                    + " correctamente";
                res = dtsDepurar(Numero);
                if (res)
                    Mensaje = "El Presupuesto fue depurado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de depuración del Presupuesto, es posible que no se haya depurado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero);
                if (res)
                    Mensaje = "El Presupuesto fue activado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public DataTable SelLikeEtiqueta(string Etiqueta, int Aprobado)
        {
            try
            {
                return dtsSelLikeEtiqueta(Etiqueta, Aprobado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Presupuestos X Etiqueta";
                return null;
            }
        }

        public DataTable SelLikeCatastral(string Clave_Catastral, int Aprobado)
        {
            try
            {
                return dtsSelLikeCatastral(Clave_Catastral, Aprobado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Presupuestos X Clave catastral";
                return null;
            }
        }

        public DataTable SelLikePropietario(string Nombre_Propietario, int Aprobado)
        {
            try
            {
                return dtsSelLikePropietario(Nombre_Propietario, Aprobado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Presupuestos X Nombre del propietario";
                return null;
            }
        }

        public Presupuesto[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Presupuesto[] presupuestos = new Presupuesto[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Presupuesto presupuesto = new Presupuesto();
                    if (Dt.Columns.Contains("Numero"))
                        presupuesto.Numero = Convert.ToInt16(renglon["Numero"]);
                    if (Dt.Columns.Contains("Etiqueta"))
                        presupuesto.Etiqueta = renglon["Etiqueta"].ToString();
                    if (Dt.Columns.Contains("Fecha"))
                        presupuesto.Fecha = Convert.ToDateTime(renglon["Fecha"]);
                    if (Dt.Columns.Contains("Nombre_Solicitante"))
                        presupuesto.Nombre_Solicitante = renglon["Nombre_Solicitante"].ToString();
                    if (Dt.Columns.Contains("Nombre_Propietario"))
                        presupuesto.Nombre_Propietario = renglon["Nombre_Propietario"].ToString();
                    if (Dt.Columns.Contains("Genero"))
                        presupuesto.Genero = renglon["Genero"].ToString();
                    if (Dt.Columns.Contains("Mts"))
                        presupuesto.Mts = Convert.ToDecimal(renglon["Mts"]);
                    if (Dt.Columns.Contains("Total"))
                        presupuesto.Total = Convert.ToDecimal(renglon["Total"]);
                    if (Dt.Columns.Contains("Aprobado"))
                        presupuesto.Aprobado = Convert.ToInt16(renglon["Aprobado"]);
                    if (Dt.Columns.Contains("Id_Tipo_Proyecto"))
                        presupuesto.Id_Tipo_Proyecto = Convert.ToInt16(renglon["Id_Tipo_Proyecto"]);
                    if (Dt.Columns.Contains("Clave_Empleado"))
                        presupuesto.Clave_Empleado = Convert.ToInt16(renglon["Clave_Empleado"]);
                    if (Dt.Columns.Contains("Eliminado"))
                        presupuesto.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    presupuesto.Existe = true;
                    presupuestos[i] = presupuesto;
                    i++;
                }
                return presupuestos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Presupuestos";
                return new Presupuesto[0];
            }
        }

        #endregion Metodos

    }
}

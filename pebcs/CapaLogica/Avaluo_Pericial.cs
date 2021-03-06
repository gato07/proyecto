﻿using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Avaluo_Pericial : dtsAvaluo_Pericial
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Avaluo_Pericial() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Avaluo Pericial";
            }
        }

        public Avaluo_Pericial(int Numero) : base(Numero)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Avaluo Pericial";
            }
        }

        public Avaluo_Pericial(int Numero, string Folio, DateTime Fecha, string Uso, decimal Mts_Terreno,
            decimal Mts_Construccion, decimal Costo_Neto, decimal Pago_Derechos, DateTime Fecha_Recepcion,
            string Observacion_Recepcion, DateTime Fecha_Entrega, string Observacion_Entrega, bool Escrituras,
            bool Manifestacion, bool Oficio_Subdivision, bool Oficio_Fusion, bool Plano_Subdivision,
            int Id_Estado_Licencia, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado) :
            base(Numero, Folio, Fecha, Uso, Mts_Terreno, Mts_Construccion, Costo_Neto, Pago_Derechos, Fecha_Recepcion,
            Observacion_Recepcion, Fecha_Entrega, Observacion_Entrega, Escrituras, Manifestacion, Oficio_Subdivision, 
            Oficio_Fusion, Plano_Subdivision, Id_Estado_Licencia, Id_Cliente, Clave_Inmueble, Clave_Empleado)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Avaluo Pericial";
            }
        }

        public int Insertar(string Folio, DateTime Fecha, string Uso, decimal Mts_Terreno,
            decimal Mts_Construccion, decimal Costo_Neto, decimal Pago_Derechos, DateTime Fecha_Recepcion,
            string Observacion_Recepcion, DateTime Fecha_Entrega, string Observacion_Entrega, bool Escrituras,
            bool Manifestacion, bool Oficio_Subdivision, bool Oficio_Fusion, bool Plano_Subdivision,
            int Id_Estado_Licencia, int Id_Cliente, int Clave_Inmueble, int Clave_Empleado)
        {
            try
            {
                int res = 0;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Avaluo Pericial, es posible que no se haya insertado"
                    + " correctamente";
                Avaluo_Pericial avaper = new Avaluo_Pericial();
                avaper.SelXFolio(Folio);
                if (avaper.Existe == false)
                {
                    if (validacion.Val_FolioAvaluo(Folio))
                    {
                        if (validacion.Val_Texto1(Uso, 1, 30))
                        {
                            if (Mts_Terreno >= 0m && Mts_Terreno <= 999999.99m)
                            {
                                if (Mts_Construccion >= 0m && Mts_Construccion <= 999999.99m)
                                {
                                    if (Costo_Neto >= 0.00m && Costo_Neto <= 9999999.99m)
                                    {
                                        if (Pago_Derechos >= 0.00m && Pago_Derechos <= 9999999.99m)
                                        {
                                            if (validacion.Val_Texto3(Observacion_Recepcion, 0, 255))
                                            {
                                                if (validacion.Val_Texto3(Observacion_Entrega, 0, 255))
                                                {
                                                    Estado_Licencia estlic = new Estado_Licencia(Id_Estado_Licencia);
                                                    if (estlic.Existe)
                                                    {
                                                        Cliente cliente = new Cliente(Id_Cliente);
                                                        if (cliente.Existe)
                                                        {
                                                            Inmueble inmueble = new Inmueble(Clave_Inmueble);
                                                            if (inmueble.Existe)
                                                            {
                                                                Empleado empleado = new Empleado(Clave_Empleado);
                                                                if (empleado.Existe)
                                                                {
                                                                    res = dtsInsertar(Folio, Fecha, Uso, Mts_Terreno, Mts_Construccion,
                                                                        Costo_Neto, Pago_Derechos, Fecha_Recepcion, Observacion_Recepcion,
                                                                        Fecha_Entrega, Observacion_Entrega, Escrituras, Manifestacion,
                                                                        Oficio_Subdivision, Oficio_Fusion, Plano_Subdivision,
                                                                        Id_Estado_Licencia, Id_Cliente, Clave_Inmueble, Clave_Empleado);
                                                                    if (res > 0)
                                                                        Mensaje = "El Avaluo Pericial fue registrado satisfactoriamente";
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
                                                        Mensaje = "No existe algún Estado de Licencia con Id indicado, ingrese un Id real";
                                                }
                                                else
                                                    Mensaje = "El campo de Observación de Entrega debe cumplir:\n\n- Solo"
                                                        + " puede contener caracteres alfabéticos, númericos, los simbolos"
                                                        + " °¡!#$%&/=¿?,;.:- y espacios en blanco.\n- El tamaño valido del"
                                                        + " campo es de 0 hasta 255 caracteres.";
                                            }
                                            else
                                                Mensaje = "El campo de Observación de Recepción debe cumplir:\n\n- Solo"
                                                    + " puede contener caracteres alfabéticos, númericos, los simbolos"
                                                    + " °¡!#$%&/=¿?,;.:- y espacios en blanco.\n- El tamaño valido del"
                                                    + " campo es de 0 hasta 255 caracteres.";
                                        }
                                        else
                                            Mensaje = "El campo de Pago de Derechos debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                                + " contener valores númericos con dos puntos decimales.\n- El intervalo de"
                                                + " valores permitidos en el campo va desde $0.00 hasta $9,999,999.99";
                                    }
                                    else
                                        Mensaje = "El campo de Costo Neto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                            + " contener valores númericos con dos puntos decimales.\n- El intervalo de"
                                            + " valores permitidos en el campo va desde $0.00 hasta $9,999,999.99";
                                }
                                else
                                    Mensaje = "El campo de Mts. de Construcción debe cumplir:\n\n- No puede quedar vacío.\n- Solo"
                                        + " puede contener valores númericos con dos puntos decimales.\n- El intervalo de valores"
                                        + " permitidos en el campo va desde 0.00 hasta 999,999.99";
                            }
                            else
                                Mensaje = "El campo de Mts. de Terreno debe cumplir:\n\n- No puede quedar vacío.\n- Solo"
                                    + " puede contener valores númericos con dos puntos decimales.\n- El intervalo de valores"
                                    + " permitidos en el campo va desde 0.00 hasta 999,999.99";
                        }
                        else
                            Mensaje = "El campo de Uso debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                                + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1"
                                + " hasta 30 caracteres.";
                    }
                    else
                        Mensaje = "El campo de Folio debe cumplir:\n\n- No puede quedar vacío.\n- El formato valido de"
                            + " caracteres es LFGV/##-##/####.\n- El unico tamaño permitido del campo es de 15 caracteres.";
                }
                else
                    Mensaje = "No puede dar de alta este Avaluo Pericial con el Folio indicado ya que hay otro avaluo"
                        + " existente en la base de datos que lo tiene asignado.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Avaluo Pericial, es posible que no se haya insertado"
                    + " correctamente";
                return 0;
            }
        }

        public bool Actualizar(int Numero, DateTime Fecha, string Uso, decimal Mts_Terreno,
            decimal Mts_Construccion, decimal Costo_Neto, decimal Pago_Derechos, DateTime Fecha_Recepcion,
            string Observacion_Recepcion, DateTime Fecha_Entrega, string Observacion_Entrega, bool Escrituras,
            bool Manifestacion, bool Oficio_Subdivision, bool Oficio_Fusion, bool Plano_Subdivision,
            int Id_Estado_Licencia, int Id_Cliente, int Clave_Inmueble)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Avaluo Pericial, es posible"
                   + " que no se hayan modificado los datos correctamente";
                Avaluo_Pericial avaper = new Avaluo_Pericial(Numero);
                if(avaper.Existe)
                {
                    if (validacion.Val_Texto1(Uso, 1, 30))
                    {
                        if (Mts_Terreno >= 0m && Mts_Terreno <= 999999.99m)
                        {
                            if (Mts_Construccion >= 0m && Mts_Construccion <= 999999.99m)
                            {
                                if (Costo_Neto >= 0.00m && Costo_Neto <= 9999999.99m)
                                {
                                    if (Pago_Derechos >= 0.00m && Pago_Derechos <= 9999999.99m)
                                    {
                                        if (validacion.Val_Texto3(Observacion_Recepcion, 0, 255))
                                        {
                                            if (validacion.Val_Texto3(Observacion_Entrega, 0, 255))
                                            {
                                                Estado_Licencia estlic = new Estado_Licencia(Id_Estado_Licencia);
                                                if (estlic.Existe)
                                                {
                                                    Cliente cliente = new Cliente(Id_Cliente);
                                                    if (cliente.Existe)
                                                    {
                                                        Inmueble inmueble = new Inmueble(Clave_Inmueble);
                                                        if (inmueble.Existe)
                                                        {
                                                            res = dtsActualizar(Numero, Fecha, Uso, Mts_Terreno, 
                                                                Mts_Construccion, Costo_Neto, Pago_Derechos, Fecha_Recepcion, 
                                                                Observacion_Recepcion, Fecha_Entrega, Observacion_Entrega, 
                                                                Escrituras, Manifestacion, Oficio_Subdivision, Oficio_Fusion, 
                                                                Plano_Subdivision, Id_Estado_Licencia, Id_Cliente, Clave_Inmueble);
                                                            if (res)
                                                                Mensaje = "Los datos del Avaluo Pericial fueron actualizados satisfactoriamente";
                                                        }
                                                        else
                                                            Mensaje = "No existe algún Inmueble con la Clave indicada, ingrese una Clave real";
                                                    }
                                                    else
                                                        Mensaje = "No existe algún Cliente con el Id indicado, ingrese un Id real";
                                                }
                                                else
                                                    Mensaje = "No existe algún Estado de Licencia con Id indicado, ingrese un Id real";
                                            }
                                            else
                                                Mensaje = "El campo de Observación de Entrega debe cumplir:\n\n- Solo"
                                                    + " puede contener caracteres alfabéticos, númericos, los simbolos"
                                                    + " °¡!#$%&/=¿?,;.:- y espacios en blanco.\n- El tamaño valido del"
                                                    + " campo es de 0 hasta 255 caracteres.";
                                        }
                                        else
                                            Mensaje = "El campo de Observación de Recepción debe cumplir:\n\n- Solo"
                                                + " puede contener caracteres alfabéticos, númericos, los simbolos"
                                                + " °¡!#$%&/=¿?,;.:- y espacios en blanco.\n- El tamaño valido del"
                                                + " campo es de 0 hasta 255 caracteres.";
                                    }
                                    else
                                        Mensaje = "El campo de Pago de Derechos debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                            + " contener valores númericos con dos puntos decimales.\n- El intervalo de"
                                            + " valores permitidos en el campo va desde $0.00 hasta $9,999,999.99";
                                }
                                else
                                    Mensaje = "El campo de Costo Neto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                        + " contener valores númericos con dos puntos decimales.\n- El intervalo de"
                                        + " valores permitidos en el campo va desde $0.00 hasta $9,999,999.99";
                            }
                            else
                                Mensaje = "El campo de Mts. de Construcción debe cumplir:\n\n- No puede quedar vacío.\n- Solo"
                                    + " puede contener valores númericos con dos puntos decimales.\n- El intervalo de valores"
                                    + " permitidos en el campo va desde 0.00 hasta 999,999.99";
                        }
                        else
                            Mensaje = "El campo de Mts. de Terreno debe cumplir:\n\n- No puede quedar vacío.\n- Solo"
                                + " puede contener valores númericos con dos puntos decimales.\n- El intervalo de valores"
                                + " permitidos en el campo va desde 0.00 hasta 999,999.99";
                    }
                    else
                        Mensaje = "El campo de Uso debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede contener"
                            + " caracteres alfabéticos y espacios en blanco.\n- El tamaño valido del campo es de 1"
                            + " hasta 30 caracteres.";
                }
                else
                    Mensaje = "No existe algún Avaluo Pericial registrado en la base de datos con ese Número,"
                        + " por lo cual no se actualizará.";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Avaluo Pericial, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Avaluo Pericial, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero);
                if (res)
                    Mensaje = "El Avaluo Pericial fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Avaluo Pericial, es posible que no se haya borrado"
                   + " correctamente";
                return false;
            }
        }

        public bool Activar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Avaluo Pericial, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero);
                if (res)
                    Mensaje = "El Avaluo Pericial fue activado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Avaluo Pericial, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public void SelXFolio(string Folio)
        {
            try
            {
                dtsSelXFolio(Folio);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error al querer consultar a los Avaluos Periciales por Folio";
            }
        }

        public DataTable SelTodos(bool Eliminado = false)
        {
            try
            {
                return dtsSelTodos(Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales";
                return null;
            }
        }

        public DataTable SelLikeNomCliente(string Nombre = "", int Id_Estado_Licencia = 0, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeNomCliente(Nombre, Id_Estado_Licencia, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales X Nombre del cliente";
                return null;
            }
        }

        public DataTable SelLikeCatastral(string Clave_Catastral = "", int Id_Estado_Licencia = 0, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeCatastral(Clave_Catastral, Id_Estado_Licencia, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales X Clave catastral";
                return null;
            }
        }

        public DataTable SelLikeNomPropietario(string Nombre_Propietario = "", int Id_Estado_Licencia = 0, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeNomPropietario(Nombre_Propietario, Id_Estado_Licencia, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales X Nombre del propietario";
                return null;
            }
        }

        public DataTable SelLikeColonia(string Colonia = "", int Id_Estado_Licencia = 0, bool Eliminado = false)
        {
            try
            {
                return dtsSelLikeColonia(Colonia, Id_Estado_Licencia, Eliminado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales X Colonia";
                return null;
            }
        }

        public DataTable SelXEmpleado(int Clave_Empleado)
        {
            try
            {
                return dtsSelXEmpleado(Clave_Empleado);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Avaluos Periciales X Empleado";
                return null;
            }
        }
        public Avaluo_Pericial[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Avaluo_Pericial[] avaluos = new Avaluo_Pericial[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Avaluo_Pericial avaluo = new Avaluo_Pericial();
                    if (Dt.Columns.Contains("Numero"))
                        avaluo.Numero = Convert.ToInt16(renglon["Numero"]);
                    if (Dt.Columns.Contains("Folio"))
                        avaluo.Folio = renglon["Folio"].ToString();
                    if (Dt.Columns.Contains("Fecha"))
                        avaluo.Fecha = Convert.ToDateTime(renglon["Fecha"]);
                    if (Dt.Columns.Contains("Uso"))
                        avaluo.Uso = renglon["Uso"].ToString();
                    if (Dt.Columns.Contains("Mts_Terreno"))
                        avaluo.Mts_Terreno = Convert.ToDecimal(renglon["Mts_Terreno"]);
                    if (Dt.Columns.Contains("Mts_Construccion"))
                        avaluo.Mts_Construccion = Convert.ToDecimal(renglon["Mts_Construccion"]);
                    if (Dt.Columns.Contains("Costo_Neto"))
                        avaluo.Costo_Neto = Convert.ToDecimal(renglon["Costo_Neto"]);
                    if (Dt.Columns.Contains("Pago_Derechos"))
                        avaluo.Pago_Derechos = Convert.ToDecimal(renglon["Pago_Derechos"]);
                    if (Dt.Columns.Contains("Fecha_Recepcion"))
                        avaluo.Fecha_Recepcion = Convert.ToDateTime(renglon["Fecha_Recepcion"]);
                    if (Dt.Columns.Contains("Observacion_Recepcion"))
                        avaluo.Observacion_Recepcion = renglon["Observacion_Recepcion"].ToString();
                    if (Dt.Columns.Contains("Fecha_Entrega"))
                        avaluo.Fecha_Entrega = Convert.ToDateTime(renglon["Fecha_Entrega"]);
                    if (Dt.Columns.Contains("Observacion_Entrega"))
                        avaluo.Observacion_Entrega = renglon["Observacion_Entrega"].ToString();
                    if (Dt.Columns.Contains("Escrituras"))
                        avaluo.Escrituras = Convert.ToBoolean(renglon["Escrituras"]);
                    if (Dt.Columns.Contains("Manifestacion"))
                        avaluo.Manifestacion = Convert.ToBoolean(renglon["Manifestacion"]);
                    if (Dt.Columns.Contains("Oficio_Subdivision"))
                        avaluo.Oficio_Subdivision = Convert.ToBoolean(renglon["Oficio_Subdivision"]);
                    if (Dt.Columns.Contains("Oficio_Fusion"))
                        avaluo.Oficio_Fusion = Convert.ToBoolean(renglon["Oficio_Fusion"]);
                    if (Dt.Columns.Contains("Plano_Subdivision"))
                        avaluo.Plano_Subdivision = Convert.ToBoolean(renglon["Plano_Subdivision"]);
                    if (Dt.Columns.Contains("Id_Estado_Licencia"))
                        avaluo.Id_Estado_Licencia = Convert.ToInt16(renglon["Id_Estado_Licencia"]);
                    if (Dt.Columns.Contains("Id_Cliente"))
                        avaluo.Id_Cliente = Convert.ToInt16(renglon["Id_Cliente"]);
                    if (Dt.Columns.Contains("Clave_Inmueble"))
                        avaluo.Clave_Inmueble = Convert.ToInt16(renglon["Clave_Inmueble"]);
                    if (Dt.Columns.Contains("Clave_Empleado"))
                        avaluo.Clave_Empleado = Convert.ToInt16(renglon["Clave_Empleado"]);
                    if (Dt.Columns.Contains("Eliminado"))
                        avaluo.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    avaluo.Existe = true;
                    avaluos[i] = avaluo;
                    i++;
                }
                return avaluos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Avaluos Periciales";
                return new Avaluo_Pericial[0];
            }
        }

        #endregion Metodos

    }
}

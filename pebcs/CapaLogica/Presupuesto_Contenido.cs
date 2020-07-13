using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Presupuesto_Contenido : dtsPresupuesto_Contenido
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Presupuesto_Contenido() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Contenido del Presupuesto";
            }
        }

        public Presupuesto_Contenido(int Numero_Presupuesto, int Numero_Concepto) : base(Numero_Presupuesto, Numero_Concepto)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Contenido del Presupuesto";
            }
        }

        public Presupuesto_Contenido(int Numero_Presupuesto, int Numero_Concepto, decimal Costo, int Cantidad,
            decimal Total):base(Numero_Presupuesto, Numero_Concepto, Costo, Cantidad, Total)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Contenido del Presupuesto";
            }
        }

        public bool Insertar(int Numero_Presupuesto, int Numero_Concepto, decimal Costo, int Cantidad, decimal Total)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Contenido del Presupuesto, es posible que no se haya insertado"
                    + " correctamente";
                Presupuesto presupuesto = new Presupuesto(Numero_Presupuesto);
                if(presupuesto.Existe)
                {
                    Concepto concepto = new Concepto(Numero_Concepto);
                    if(concepto.Existe)
                    {
                        Presupuesto_Contenido precont = new Presupuesto_Contenido(Numero_Presupuesto,Numero_Concepto);
                        if (precont.Existe == false)
                        {
                            if (Costo >= 0.00m && Costo <= 9999999.99m)
                            {
                                if (Cantidad >= 1 && Cantidad <= 99)
                                {
                                    if (Total >= 0.00m && Total <= 9999999.99m)
                                    {
                                        res = dtsInsertar(Numero_Presupuesto, Numero_Concepto, Costo, Cantidad, Total);
                                        if (res)
                                            Mensaje = "El Contenido del Presupuesto fue registrado satisfactoriamente";
                                    }
                                    else
                                        Mensaje = "El campo de Total del Concepto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                            + " contener valores númericos con dos puntos decimales.\n- El intervalo de valores permitidos"
                                            + " en el campo va desde $0.00 hasta $9,999,999.99";
                                }
                                else
                                    Mensaje = "El campo de Cantidad del Concepto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                    + " contener valores númericos.\n- El intervalo de valores permitidos"
                                    + " en el campo va desde 1 hasta 99";
                            }
                            else
                                Mensaje = "El campo de Costo del Concepto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                    + " contener valores númericos con dos puntos decimales.\n- El intervalo de valores permitidos"
                                    + " en el campo va desde $0.00 hasta $9,999,999.99";
                        }
                        else
                            Mensaje = "Este Concepto ya se encuentra almacenado en dicho Presupuesto, por lo cual no se"
                                + " puede dar de alta de nuevo";
                    }
                    else
                        Mensaje = "No existe algún Concepto con el Numero indicado, ingrese uno real";
                }
                else
                    Mensaje = "El número de Presupuesto indicado para ingresar el concepto no existe, ingrese uno real";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Contenido del Presupuesto, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Numero_Presupuesto, int Numero_Concepto, decimal Costo, int Cantidad, decimal Total)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Contenido del Presupuesto, es posible"
                   + " que no se hayan modificado los datos correctamente";
                Presupuesto_Contenido precont = new Presupuesto_Contenido(Numero_Presupuesto, Numero_Concepto);
                if (precont.Existe)
                {
                    if (Costo >= 0.00m && Costo <= 9999999.99m)
                    {
                        if (Cantidad >= 1 && Cantidad <= 99)
                        {
                            if (Total >= 0.00m && Total <= 9999999.99m)
                            {
                                res = dtsActualizar(Numero_Presupuesto, Numero_Concepto, Costo, Cantidad, Total);
                                if (res)
                                    Mensaje = "Los datos del Contenido del Presupuesto fueron actualizados satisfactoriamente";
                            }
                            else
                                Mensaje = "El campo de Total del Concepto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                                    + " contener valores númericos con dos puntos decimales.\n- El intervalo de valores permitidos"
                                    + " en el campo va desde $0.00 hasta $9,999,999.99";
                        }
                        else
                            Mensaje = "El campo de Cantidad del Concepto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                            + " contener valores númericos.\n- El intervalo de valores permitidos"
                            + " en el campo va desde 1 hasta 99";
                    }
                    else
                        Mensaje = "El campo de Costo del Concepto debe cumplir:\n\n- No puede quedar vacío.\n- Solo puede"
                            + " contener valores númericos con dos puntos decimales.\n- El intervalo de valores permitidos"
                            + " en el campo va desde $0.00 hasta $9,999,999.99";
                }
                else
                    Mensaje = "El Concepto indicado no esta registrado como contenido del Presupuesto, por lo cual no se"
                        + " puede actualizar";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Contenido del Presupuesto, es posible"
                   + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Numero_Presupuesto, int Numero_Concepto)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Contenido del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero_Presupuesto, Numero_Concepto);
                if (res)
                    Mensaje = "El Contenido del Presupuesto fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Contenido del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                return false;
            }
        }

        public bool Activar(int Numero_Presupuesto, int Numero_Concepto)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de activación del Contenido del Presupuesto, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsActivar(Numero_Presupuesto, Numero_Concepto);
                if (res)
                    Mensaje = "El Contenido del Presupuestoo fue activado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de activación del Contenido del Presupuesto, es posible que no se haya borrado"
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Contenidos de Presupuesto activos";
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Contenido de Presupuesto eliminados";
                return null;
            }
        }

        public DataTable SelXNumPresupuesto(int Numero_Presupuesto)
        {
            try
            {
                return dtsSelXNumPresupuesto(Numero_Presupuesto);
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Contenidos del Presupuesto por Número del presupuesto";
                return null;
            }
        }

        public Presupuesto_Contenido[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Presupuesto_Contenido[] pre_conts = new Presupuesto_Contenido[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Presupuesto_Contenido pre_cont = new Presupuesto_Contenido();
                    if (Dt.Columns.Contains("Numero_Presupuesto"))
                        pre_cont.Numero_Presupuesto = Convert.ToInt16(renglon["Numero_Presupuesto"]);
                    if (Dt.Columns.Contains("Numero_Concepto"))
                        pre_cont.Numero_Concepto = Convert.ToInt16(renglon["Numero_Concepto"]);
                    if (Dt.Columns.Contains("Costo"))
                        pre_cont.Costo = Convert.ToDecimal(renglon["Costo"]);
                    if (Dt.Columns.Contains("Cantidad"))
                        pre_cont.Cantidad = Convert.ToInt16(renglon["Cantidad"]);
                    if (Dt.Columns.Contains("Total"))
                        pre_cont.Total = Convert.ToDecimal(renglon["Total"]);
                    if (Dt.Columns.Contains("Eliminado"))
                        pre_cont.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    pre_cont.Existe = true;
                    pre_conts[i] = pre_cont;
                    i++;
                }
                return pre_conts;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Contenidos del Presupuesto";
                return new Presupuesto_Contenido[0];
            }
        }

        #endregion Metodos

    }
}

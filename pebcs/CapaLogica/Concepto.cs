using System;
using System.Data;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class Concepto:dtsConcepto
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Concepto() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Concepto";
            }
        }

        public Concepto(int Numero) : base(Numero)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Concepto";
            }
        }

        public Concepto(int Numero, string Tipo, string Nombre, string Descripcion, decimal Costo) : 
            base(Numero, Tipo, Nombre, Descripcion, Costo)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Concepto";
            }
        }

        public bool Insertar(string Tipo, string Nombre, string Descripcion, decimal Costo)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Concepto, es posible que no se haya insertado"
                    + " correctamente";
                res = dtsInsertar(Tipo, Nombre, Descripcion, Costo);
                if (res)
                    Mensaje = "El Concepto fue registrado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de dar de alta al Concepto, es posible que no se haya insertado"
                    + " correctamente";
                return false;
            }
        }

        public bool Actualizar(int Numero, string Tipo, string Nombre, string Descripcion, decimal Costo)
        {
            try
            {
                bool res = false;
                Validacion validacion = new Validacion();
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Concepto, es posible"
                    + " que no se hayan modificado los datos correctamente";
                res = dtsActualizar(Numero, Tipo, Nombre, Descripcion, Costo);
                if (res)
                    Mensaje = "Los datos del Concepto fueron actualizados satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de actualización de datos del Concepto, es posible"
                    + " que no se hayan modificado los datos correctamente";
                return false;
            }
        }

        public bool Eliminar(int Numero)
        {
            try
            {
                bool res = false;
                Mensaje = "Ocurrio un error en el proceso de eliminación del Concepto, es posible que no se haya borrado"
                    + " correctamente";
                res = dtsEliminar(Numero);
                if (res)
                    Mensaje = "El Concepto fue eliminado satisfactoriamente";
                return res;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el proceso de eliminación del Concepto, es posible que no se haya borrado"
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Conceptos";
                return null;
            }
        }

        public Concepto[] Conceptos()
        {
            try
            {
                int i = 0;
                DataTable dt = SelTodos();
                Concepto[] conceptos = new Concepto[dt.Rows.Count];
                foreach (DataRow renglon in dt.Rows)
                {
                    Concepto concepto = new Concepto(
                        Convert.ToInt16(renglon["Numero"]),
                        renglon["Tipo"].ToString(),
                        renglon["Nombre"].ToString(),
                        renglon["Descripcion"].ToString(),
                        Convert.ToDecimal(renglon["Costo"]));
                    concepto.Eliminado = Convert.ToBoolean(renglon["Eliminado"]);
                    concepto.Existe = true;
                    conceptos[i] = concepto;
                    i++;
                }
                return conceptos;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Conceptos";
                return null;
            }
        }

        #endregion Metodos

    }
}

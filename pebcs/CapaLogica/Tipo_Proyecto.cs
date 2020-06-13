﻿using System;
using System.Data;
using CapaAccesoDatos;
using System.Text;

namespace CapaLogica
{
    public class Tipo_Proyecto : dtsTipo_Proyecto
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        public string Mensaje { get; set; }

        #endregion Propiedades

        #region Metodos

        public Tipo_Proyecto() : base()
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Tipo_Proyecto";
            }
        }

        public Tipo_Proyecto(int Id) : base(Id)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Tipo_Proyecto";
            }
        }

        public Tipo_Proyecto(int Id, int Id_Tipo_Obra, string Tipo_Obra, int Id_Uso, string Uso) : 
            base(Id, Id_Tipo_Obra, Tipo_Obra, Id_Uso, Uso)
        {
            try
            {
                Mensaje = "";
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en el constructor del Tipo_Proyecto";
            }
        }

        public bool Insertar(int Id_Tipo_Obra, string Tipo_Obra, int Id_Uso, string Uso)
        {
            try
            {
               return dtsInsertar(Id_Tipo_Obra, Tipo_Obra, Id_Uso, Uso);
            }
            catch (Exception ex)
            {
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
                Mensaje = "Ocurrio un error en el proceso de Consultar a todos los Tipos_Proyecto";
                return null;
            }
        }

        public Tipo_Proyecto[] TableToArray(DataTable Dt)
        {
            try
            {
                int i = 0;
                Tipo_Proyecto[] tipos_proyecto = new Tipo_Proyecto[Dt.Rows.Count];
                foreach (DataRow renglon in Dt.Rows)
                {
                    Tipo_Proyecto tipo_proyecto = new Tipo_Proyecto();
                    if (Dt.Columns.Contains("Id"))
                        tipo_proyecto.Id = Convert.ToInt16(renglon["Id"]);
                    if (Dt.Columns.Contains("Id_Tipo_Obra"))
                        tipo_proyecto.Id_Tipo_Obra = Convert.ToInt16(renglon["Id_Tipo_Obra"]);
                    if (Dt.Columns.Contains("Tipo_Obra"))
                        tipo_proyecto.Tipo_Obra = renglon["Tipo_Obra"].ToString();
                    if (Dt.Columns.Contains("Id_Uso"))
                        tipo_proyecto.Id_Uso = Convert.ToInt16(renglon["Id_Uso"]);
                    if (Dt.Columns.Contains("Uso"))
                        tipo_proyecto.Uso = renglon["Uso"].ToString();
                    tipo_proyecto.Existe = true;
                    tipos_proyecto[i] = tipo_proyecto;
                    i++;
                }
                return tipos_proyecto;
            }
            catch (Exception ex)
            {
                Mensaje = "Ocurrio un error en la construcción del arreglo de Tipos_Proyecto";
                return new Tipo_Proyecto[0];
            }
        }

        #endregion Metodos

    }
}
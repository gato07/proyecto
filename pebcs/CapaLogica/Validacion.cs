﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace CapaLogica
{
    public class Validacion
    {

        #region Atributos

        #endregion Atributos

        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public Validacion()
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public bool Val_Texto1(string Valor, int Min, int Max)
        {
            try
            {
                Regex expreg = new Regex(@"^[A-Za-zÑñÁÉÍÓÚáéíóúÜü\s]{" + Min + "," + Max + "}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Domicilio(string Valor)
        {
            try
            {
                Regex expreg = new Regex(@"^[0-9A-Za-zÑñÁÉÍÓÚáéíóúÜü\s\.\,\-\#\/]{1,255}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Numero(string Valor,int Min, int Max)
        {
            try
            {
                Regex expreg = new Regex(@"^[0-9]{" + Min + "," + Max + "}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Email(string Valor)
        {
            try
            {
                var email = new MailAddress(Valor);
                return ((email.Address == Valor) && (Valor.Length <= 255));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Perfil(int Valor)
        {
            try
            {
                return ((Valor >= 1) && (Valor <= 4));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Usuario(string Valor)
        {
            try
            {
                Regex expreg = new Regex(@"^[0-9a-zñ]{4,15}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Contrasena(string Valor)
        {
            try
            {
                Regex expreg = new Regex(@"^(?=.*[0-9])(?=.*[a-zñ])(?=.*[A-ZÑ])(?=.*[\,\.\-\+\*\#\$\%\&\/\¡\!\¿\?])[0-9a-zA-ZñÑ\,\.\-\+\*\#\$\%\&\/\¡\!\¿\?]{8,16}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*public bool Val_IdUsuario(string Valor)
        {
            try
            {
                Regex expreg = new Regex("^[0-9A-Z]{3,8}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Contrasena(string Valor)
        {
            try
            {
                Regex expreg = new Regex(@"^[0-9a-zA-ZñÑ]{6,25}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_TipoUsuario(string Valor)
        {
            try
            {
                Regex expreg = new Regex("^(ALUMNO|MAESTRO|COORDINADOR){1}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_IdCarrera(string Valor)
        {
            try
            {
                Regex expreg = new Regex(@"^[0-9A-Z\-]{13}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_ClaveCoordinador(string Valor)
        {
            try
            {
                Regex expreg = new Regex("^[0-9A-Z]{3}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Numero(string Valor, int Min, int Max)
        {
            try
            {
                Regex expreg = new Regex("^[0-9]{" + Min + "," + Max + "}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Email(string Valor)
        {
            try
            {
                MailAddress email = new MailAddress(Valor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_ClaveMaestro(string Valor)
        {
            try
            {
                Regex expreg = new Regex("^[0-9A-Z]{5}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_IdMateria(string Valor)
        {
            try
            {
                Regex expreg = new Regex(@"^[0-9A-Z\-]{8}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }*/



        #endregion Metodos

    }
}
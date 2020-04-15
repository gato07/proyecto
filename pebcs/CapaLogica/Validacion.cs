using System;
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

        public bool Val_Texto2(string Valor, int Min, int Max)
        {
            try
            {
                Regex expreg = new Regex(@"^[A-Za-zÑñÁÉÍÓÚáéíóúÜü\s\.\,\-]{" + Min + "," + Max + "}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Texto3(string Valor, int Min, int Max)
        {
            try
            {
                Regex expreg = new Regex(@"^[0-9A-Za-zÑñÁÉÍÓÚáéíóúÜü\s\°\¡\!\#\$\%\&\/\=\¿\?\,\;\.\:\-]{" + Min + "," + Max + "}$");
                return expreg.IsMatch(Valor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_RutaArchivo(string Valor)
        {
            try
            {
                if (!string.IsNullOrEmpty(Valor))
                {
                    if (Valor.Length <= 255)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_Domicilio(string Valor, int Min, int Max)
        {
            try
            {
                Regex expreg = new Regex(@"^[0-9A-Za-zÑñÁÉÍÓÚáéíóúÜü\s\.\:\,\;\-\#\/]{" + Min + "," + Max + "}$");
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

        public bool Val_Decimal(decimal Valor, decimal Min, decimal Max, int Numero_Decimales)
        {
            try
            {
                string[] arreglo = Valor.ToString().Split('.');
                string decimales = "";
                if (arreglo.Length > 1)
                    decimales = arreglo[1];
                return ((Valor >= Min) && (Valor <= Max) && (decimales.Length <= Numero_Decimales));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Val_ClaveCatastral(string Valor)
        {
            try
            {
                Regex expreg1 = new Regex(@"^[0-9]{3}(\-)[0-9]{3}(\-)[0-9]{3}(\-)[0-9]{3}$");
                Regex expreg2 = new Regex(@"^[0-9]{1}(\-)[0-9]{2}(\-)[0-9]{3}(\-)[0-9]{3,4}$");
                return (expreg1.IsMatch(Valor) || expreg2.IsMatch(Valor));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*  
        
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
        
        */



        #endregion Metodos

    }
}

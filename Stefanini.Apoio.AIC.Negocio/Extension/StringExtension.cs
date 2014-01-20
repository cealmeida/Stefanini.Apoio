using System;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;

namespace System
{
    public static class StringExtension
    {
		/// <summary>
        /// Verifica se a string contem apenas números.
        /// </summary>
        /// <param name="num">string a ser verificada</param>
        /// <returns>boolean</returns>
        public static bool IsNumeric(this string valor)
       {
           Regex reNum = new Regex(@"^\d*[0-9](\.\d*[0-9])?$");
           bool isNumeric = reNum.Match(valor.ToString()).Success;
           return isNumeric;
       }
	   
        /// <summary>
        /// Converte a string de valor do registro em uma decimal, o calculo do decimal e feita verificando se do lado
        /// direito termina com 0 se terminar com 0 e um fracional.
        /// </summary>
        /// <param name="num">string de valor</param>
        /// <returns>valor decimal</returns>
        public static Decimal ParseDecimal(this string num)
        {
            decimal numTemp = 0;
            decimal result = 0;
            if (decimal.TryParse(num, out numTemp))
            {
                result = (num.EndsWith("0")) ? Decimal.Parse(num) / 100 : Decimal.Parse(num);
            }
           
            
            return result;
        }

        /// <summary>
        /// Convert um char para inteiro
        /// </summary>
        /// <param name="num">numero char</param>
        /// <returns></returns>
        public static int ParseCharInt(this string num)
        {
            int valor = 0;
            if (num.Length == 1)
            {
                char tempChar = char.Parse(num.Trim());
                valor = (int)tempChar;
            }
            else 
            {
                throw new Exception("String não é um Char");
            }
            return valor;
        }

        /// <summary>
        /// Verifica se a string possui algum caractere
        /// </summary>
        /// <param name="str">string a ser verificada</param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return (str.Trim().Length == 0) && String.IsNullOrEmpty(str);
        }

        /// <summary>
        ///  Método para gera um MD5 
        /// </summary>
        /// <param name="texto">texte base para o MD5</param>
        /// <returns></returns>
        public static string GerarMD5(this string texto)
        {  
            MD5 md5hasher = MD5.Create();
           StringBuilder gerarString = new StringBuilder();
            byte[] vetor = Encoding.Default.GetBytes(texto);
            vetor = md5hasher.ComputeHash(vetor);
            foreach (byte item in vetor)
            {
                gerarString.Append(item.ToString("x2"));
            }
            return gerarString.ToString().ToUpper();
        }

        /// <summary>
        ///Método para gera um SHA1 
        /// </summary>
        /// <param name="texto">texto base para o SHA1</param>
        /// <returns></returns>
        public static string GerarSHA1(this string texto)
        {
            SHA1 sha1hasher = SHA1.Create();
            StringBuilder gerarString = new StringBuilder();
            byte[] vetor = Encoding.Default.GetBytes(texto);
            vetor = sha1hasher.ComputeHash(vetor);
            foreach (byte item in vetor)
            {
                gerarString.Append(item.ToString("x2"));
            }
            return gerarString.ToString().ToUpper();

        }

        /// <summary>
        /// Formata uma string para CNPJ
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string FormataCNPJ(this string obj)
        {
            string cnpj = "";
            try
            {
                cnpj = string.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToDouble(obj.ToString()));
            }
            catch (Exception)
            {

                cnpj = obj.ToString();
            }

            return cnpj;
        }
        
        /// <summary>
        /// Formata uma string para CPF
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string FormataCPF(this string obj)
        {
            string cpf = "";
            try
            {
                cpf = string.Format(@"{0:000\.000\.000\-00}", Convert.ToDouble(obj.ToString()));
            }
            catch (Exception)
            {

                cpf = obj.ToString();
            }

            return cpf;
        }
		
		 /// <summary>
        /// Retrona um texto contendo somente numeros
        /// </summary>
        /// <param name="strNaoTratada">texto a ser tratado</param>
        /// <returns></returns>
        public static string SomenteNumeros(this string strNaoTratada) 
        {
            string strTratada = "";                       
            try
            {
                foreach (char c in strNaoTratada) 
                {
                    if (char.IsNumber(c)) 
                    {
                        strTratada += c;
                    }
                }

            }
            catch (Exception)
            {
                strTratada = strNaoTratada;
            }
            return strTratada;
        }
		
		 /// <summary>
        /// Capitaliza todas as palavras da string
        /// </summary>
        /// <param name="strNaoTratada">string a ser capitalizada</param>
        /// <returns></returns>
		 public static string ToCapitalize(this string text) 
       {           
          
           return  CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
       }
       

	    /// <summary>
        /// Deixa maiuscula apenas a primeira letra da string
        /// </summary>
        /// <param name="strNaoTratada">string a ser tratada</param>
        /// <returns></returns>
       public static string ToUpperFirstLetter(this string text)
       {
           char letraInicial = text[0];

           return string.Concat(letraInicial.ToString().ToUpper(), text.Substring(1).ToLower());
       }

    }
}

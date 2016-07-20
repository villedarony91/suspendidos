using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;


    public class EncryptUsuario
    {

        private const string MascaraDefault = "administraciondesistemasdeinformaciontribunalsupremoelectoraldirecciondeinformatica";

        private string m_Mascara="";

        //Funcion que verifica la mascara y la asigna al actual
        private string AsignaMascara()
        {
            string tempAsignaMascara = null;
            if (m_Mascara.Length <= 0)
            {
                tempAsignaMascara = MascaraDefault;
            }
            else
            {
                tempAsignaMascara = m_Mascara;
            }
            return tempAsignaMascara;
        }


        //Funcion de encriptamiento
        public string Encriptar(string Valor)
        {
            //Encripta una cadena de caracteres
            string Cadena = null;
            int i = 0;
            string Mascara = null;
            string Caracter = null;
            //la mascara se suma al string a encriptar
            Mascara = AsignaMascara();
            //Asigna un caracter entre 1 - 9
            Random rnd = new Random();
            Cadena = Convert.ToInt32((Convert.ToDouble((rnd.Next(1,10))))).ToString();
 
            int tempVar = Valor.Length;
            for (i = 1; i <= tempVar; i++)
            {
                //Caracter = Convert.ToString(Microsoft.VisualBasic.Strings.Asc(Valor.Substring(i - 1, 1)) + Microsoft.VisualBasic.Strings.Asc(Mascara.Substring(i - 1, 1)), 16).ToUpper();
                switch (Caracter.Length)
                {
                    case 3:
                        Cadena = Cadena + Caracter;
                        break;
                    case 2:
                        Cadena = Cadena + "0" + Caracter;
                        break;
                    case 1:
                        Cadena = Cadena + "00" + Caracter;
                        break;
                }
            }
            return Cadena;
        }

        //Funcion de Desencriptamiento
		public string DesEncriptar(string Valor="")
		{
			//Desencripta un string
			string Cadena = "";
			int i = 0;
			string Mascara = null;
			string CadenaOriginal = null;
			Mascara = AsignaMascara();
			CadenaOriginal = "";
            Cadena = strMid.Mid(Valor, 2, Valor.Length - 1);
			if ((Cadena.Length % 3) > 0) //Rastrea de 3 en 3 posiciones
			{
				return "ERROR";
			}
			int tempVar = Valor.Length;
			for (i = 1; i < tempVar; i += 3)
			{
               
                string val1 =  strMid.Mid(Mascara, CadenaOriginal.Length + 1, 1);
                char c = Convert.ToChar(val1);
                int val2 = (Convert.ToInt32(Cadena.Substring(i - 1, 3), 16));
                CadenaOriginal = CadenaOriginal + Convert.ToChar((Convert.ToInt32(Cadena.Substring(i - 1, 3), 16) - Convert.ToChar(strMid.Mid(Mascara, CadenaOriginal.Length + 1, 1))));
			}
			return CadenaOriginal;
		}

        public static class strMid
        {
            public static string Mid(string s, int a, int b)
            {
                string temp = s.Substring(a - 1, b);
                return temp;
            }

        }


    }


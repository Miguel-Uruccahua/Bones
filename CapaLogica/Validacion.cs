using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CapaLogica
{
    public  class Validacion
    {
        public bool ValidarDNI(string numero){
            try{
                Int32.Parse(numero);
                if (numero.Count() == 8)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
               //return true;
                
            }catch(Exception ex){
                return false;
            }
            
        }
        public bool ValidarLetras(String Letra) {
            Regex regex = new Regex("^[a-zA-Z ]*$");
            bool vr = regex.IsMatch(Letra);
            if (vr == true ) {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool Validarusu(String Letra)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]*$");
            bool vr = regex.IsMatch(Letra);
            if (vr == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ValidarCorreo(String correo) {

            Regex Correo = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            bool cr = Correo.IsMatch(correo);
            if (cr == true)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public bool ValidarNumero(String numero) {
            try {
                Convert.ToInt32(numero);
                return true;
            } catch (Exception ex) { 
                
                return false; }
        
        }
        
    }
}

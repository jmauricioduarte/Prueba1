using System;
using System.Net;
using System.Net.Mail;

namespace Entity
{
    public class Persona
    {

        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public MailAddress Correo { get; set; }
        public decimal Pulsaciones { get; set; }
        

        public void CalcularPulsaciones()
        {
            if (Sexo == "f")
            {
                Pulsaciones = (220 - Edad) / 10;
            }
            else if (Sexo == "m")
            {
                Pulsaciones = (210 - Edad) / 10;
            }
            else
            {
                Pulsaciones = 0;
            }
        }

        public override string ToString()
        {
            return $"Identificación:{Identificacion} --- Nombre:{Nombre} --- Edad:{Edad} --- Sexo:{Sexo} --- Pulsaciones:{Pulsaciones}------- Correo:{Correo}";
        }

        /*public void Add(Persona persona)
        {
            throw new NotImplementedException();
        }*/
    }
}

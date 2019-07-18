using System;
using Entity;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
namespace DAL
{
    public class PersonaRepository
    {
        string Filename = @"Persona.txt";
         List<Persona> Personas = new List<Persona>();
       // List<Persona> Personas;
        // private List<Persona> Persona;

        public void Guardar(Persona persona)
        {
            FileStream SourceStream = new FileStream(Filename, FileMode.Append);
            StreamWriter write = new StreamWriter(SourceStream);
            write.WriteLine(persona.Identificacion + ";" + persona.Nombre + ";" + persona.Edad + ";" + persona.Sexo + ";" +persona.Correo + ";" + persona.Pulsaciones+";");
            write.Close();
            SourceStream.Close();
           // Personas.Add(persona);
        }

        public void Eliminar(Persona persona)
        {
            Personas = Consultar();
            FileStream SourceStream = new FileStream(Filename, FileMode.Create);
            SourceStream.Close();
            foreach(var item in Personas)
            {
               if(persona.Identificacion!=item.Identificacion)
                {
                    Guardar(item);
                }
            }
           
        }

        public List<Persona> Consultar()
        {
            Personas.Clear();
            FileStream archivo = new FileStream(Filename, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(archivo);

            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {
                Persona persona;
                persona = Mapear(linea);
                Personas.Add(persona);
            }
            reader.Close();
            archivo.Close();
            return Personas;
            
        }
        public Persona Mapear(string linea)
        {
            char delimiter = ';';
            string[] datosPersona = linea.Split(delimiter);
          
            Persona persona = new Persona();
            persona.Identificacion = datosPersona[0];
            persona.Nombre = datosPersona[1];
            persona.Edad = int.Parse(datosPersona[2]);
            persona.Sexo = datosPersona[3];
            persona.Correo = new MailAddress (datosPersona[4]);
            persona.Pulsaciones = decimal.Parse(datosPersona[5]);

            return persona;

        }

        public void Modificar(Persona persona)
        {
            Personas = Consultar();
            FileStream SourceStream = new FileStream(Filename, FileMode.Create);
            SourceStream.Close();
            foreach (var item in Personas)
            {
                if (persona.Identificacion != item.Identificacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(persona);
                }
            }

     
        }

        public Persona Buscar(Persona persona)
        {
            List<Persona> Personas = Consultar();
            foreach (var item in Personas)
            {
                if (item.Equals(persona))
                {
                    return item;
                }
            }
            return null;
        }

        public Persona Buscar(string identificacion)
        {
         
           List<Persona> Persona = Consultar();
            foreach (var item in Personas)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }
       
    }
}

using System;
using Entity;
using DAL;
using System.Collections.Generic;


namespace BLL
{
    public class PersonaService
    {
        PersonaRepository personaRepositorio;

        public PersonaService()
        {
            personaRepositorio = new PersonaRepository();
        }

        public string Guardar(Persona persona)
        {
            if (personaRepositorio.Buscar(persona.Identificacion) == null)
            {
                personaRepositorio.Guardar(persona);
                return $"Se registro la persona {persona.Nombre} correctamente ";
            }
            else
            {
                return $"La persona Ya se encuentra registrada";
            }
        }

        public string Eliminar(Persona persona)
        {
            if (personaRepositorio.Buscar(persona.Identificacion) == null)
            {
                return $"La persona con identificacion no se encuentra registrada";
            }
            else
            {
                personaRepositorio.Eliminar(persona);
                return $"La persona {persona.Identificacion} fue eliminada";
            }
        }

        public List<Persona> Consultar()
        {
            return personaRepositorio.Consultar();
        }

        public string Modificar(Persona persona)
        {
            if (personaRepositorio.Buscar(persona.Identificacion) == null)
            {
                
                personaRepositorio.Guardar(persona);
                return $"Se registro la persona {persona.Identificacion} Satisfactoriamente";
            }
            else
            {
                return $"La persona Ya se encuentra registrada";
            }
        }

        public Persona Buscar(string identificacion)
        {
            return personaRepositorio.Buscar(identificacion);
        }
        
    }
}

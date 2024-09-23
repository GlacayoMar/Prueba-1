using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corte1.models
{
    internal class Regsistro
    {
        public Persona[] personas = new Persona[30];
        public int contador = 0;

        public void AgregarPersona(Persona persona)
        {
            if (contador < 30)
            {
                personas[contador] = persona;
                contador++;
            }
            else
            {
                throw new InvalidOperationException("No se pueden agregar más personas, el registro está lleno.");
            }
        }

        public Persona[] MostrarPersonas() 
        {
            return personas.Take(contador).ToArray();
        }
            
        
    }
}

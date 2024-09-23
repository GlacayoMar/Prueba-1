using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corte1.models
{
    internal class Operacion
    {
        public int CalcularEdad(Persona persona)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - persona.FechaNacimiento.Year;

            if (fechaActual < persona.FechaNacimiento.AddYears(edad))
            {
                edad--;
            }

            return edad;
        }

        public string EsMayorDeEdad(Persona persona)
        {
            int edad = CalcularEdad(persona);
            return edad >= 18 ? "Mayor de edad" : "Menor de edad";
        }
    }
}

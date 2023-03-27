using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1
{
    abstract class Monoplaza
    {
        public string Escuderia { get; set; }
        public string Nombre { get; set; }
        bool start, moving;

        public void Encender() 
        { 
            if (!start)
            {
                start = true;
                Console.WriteLine($"Vehiculo {Nombre} encendido.");
            }
            else
                Console.WriteLine($"El Vehiculo {Nombre} ya se encuentra encendido.");
        }

        public void Apagar() 
        {
            if (start)
            {
                if (!moving)
                {
                    start = false;
                    Console.WriteLine($"Vehiculo {Nombre} apagado.");
                }
                else
                    Console.WriteLine($"No se puede apagar el Vehiculo {Nombre}, está en movimiento.");
            }
            else
                Console.WriteLine($"El Vehiculo {Nombre} ya se encuentra apagado.");
        }

        public void Detener() 
        {
            if (start)
            {
                if (moving)
                {
                    moving = false;
                    Console.WriteLine($"Vehiculo {Nombre} detenido.");
                }
                else
                    Console.WriteLine($"El Vehiculo {Nombre}, NO está en movimiento.");
            }
            else
                Console.WriteLine($"El Vehiculo {Nombre} se encuentra apagado.");
        
        }

        public void Movimiento() 
        {
            if (start)
            {
                if (!moving)
                {
                    moving = true;
                    Console.WriteLine($"Vehiculo {Nombre} puesto en movimiento.");
                }
                else
                    Console.WriteLine($"El Vehiculo {Nombre}, Ya se encuentra en movimiento.");
            }
            else
                Console.WriteLine($"El Vehiculo {Nombre} se encuentra apagado.");
        
        }

    }
}

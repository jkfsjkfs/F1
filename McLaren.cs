using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1
{
    public class McLaren : Monoplaza
    {
        public McLaren() 
        {
            Escuderia = Escuderias.McLaren.ToString();
            while (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.Write("Nombre del monoplaza McLaren: ");
                Nombre = Console.ReadLine();
            }
        }

    }
}

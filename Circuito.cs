using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1
{
    class Circuito
    {
        string Nombre { get; set; }
        int Vueltas { get; set; }
        IMonoplaza Monoplaza { get; set; }

        Dictionary<IMonoplaza, long> Posiciones = new Dictionary<IMonoplaza, long>();     

        public Circuito(string cNombre, int nVueltas)
        {
            Nombre = cNombre;
            Vueltas = nVueltas;
        }

        public void AgregarMonoPlaza(IMonoplaza car)
        {
            if (this.Monoplaza == null)
                this.Monoplaza = car;
        }

        public void SacarMonoPlaza()
        {
            if (this.Monoplaza != null)
                this.Monoplaza = null;
        }


        public void RealizarPrueba() 
        {
            this.Monoplaza.Encender();
            long nBestTime = 0;
            Console.WriteLine($"Iniciando prueba Monoplaza {this.Monoplaza.Nombre} - {this.Monoplaza.Escuderia}");
            this.Monoplaza.Movimiento();
            for (int i = 1; i <= this.Vueltas; i++)
            {
                long nTime = new Random(i).Next(100000, 999999);
                Console.WriteLine($"Vuelta {i} - Tiempo: {nTime}");
                if(nTime < nBestTime)
                    nBestTime = nTime;
            }

            Console.WriteLine($"Finalizada prueba Monoplaza {this.Monoplaza.Nombre} - {this.Monoplaza.Escuderia}");
            Console.WriteLine($"Mejor tiempo: {nBestTime}");

            this.Monoplaza.Apagar();
            this.Posiciones.Add(this.Monoplaza, nBestTime);
        }


        public void Finalizar()
        {
            Console.WriteLine($"Circuito {this.Nombre} Finalizado.");
            Console.WriteLine($"Tabla de Posiciones:");

            this.Posiciones.OrderBy(p => p.Value);

            int nPos = 1;
            foreach (var item in this.Posiciones)
            {
                Console.WriteLine($"{nPos}. {item.Key.Nombre.Trim().PadRight(20)} Tiempo:{item.Value}");
                nPos++;
            }
        }
    }
}

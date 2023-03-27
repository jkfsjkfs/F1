using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1
{
    class Circuito
    {
        public string Nombre { get; set; }
        int Vueltas { get; set; }
        IMonoplaza? Monoplaza { get; set; }

        Dictionary<string, long> Posiciones = new Dictionary<string, long>();     

        public Circuito()
        {
            while (string.IsNullOrWhiteSpace(Nombre))
            {
                Console.Write("Nombre del circuito: ");
                Nombre = Console.ReadLine();
            }
            int nVueltas = 0;
            while (nVueltas == 0)
            {
                Console.Write("Cantidad de vueltas: ");
                int.TryParse(Console.ReadLine(), out nVueltas);
            }
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
            if (this.Monoplaza == null)
            {
                Console.WriteLine($"NO hay un Monoplaza en el circuito");
            }
            else
            {
                string nKeyMonoplaza = $"{this.Monoplaza.Escuderia} - {this.Monoplaza.Nombre}";
                if (this.Posiciones.Any(p => p.Key == nKeyMonoplaza))
                {
                    Console.WriteLine($"Ya se ha realizado la prueba para este monoplaza ({nKeyMonoplaza})");
                    return;
                } 
                

                this.Monoplaza.Encender();
                long nBestTime = 999999;
                Console.WriteLine($"Iniciando prueba Monoplaza {this.Monoplaza.Nombre} - {this.Monoplaza.Escuderia}");
                this.Monoplaza.Movimiento();
                for (int i = 1; i <= this.Vueltas; i++)
                {
                    long nTime = new Random(DateTime.Now.Second).Next(100000, 999999);
                    Console.WriteLine($"Vuelta {i} - Tiempo: {nTime}");
                    if (nTime < nBestTime)
                        nBestTime = nTime;
                }

                this.Monoplaza.Detener();
                Console.WriteLine($"Finalizada prueba Monoplaza {this.Monoplaza.Nombre} - {this.Monoplaza.Escuderia}");
                Console.WriteLine($"Mejor tiempo: {nBestTime}");

                this.Monoplaza.Apagar();
                this.Posiciones.Add(nKeyMonoplaza, nBestTime);
            }
        }


        public void Finalizar()
        {
            Console.WriteLine($"Circuito {this.Nombre} Finalizado.");
            Console.WriteLine($"Tabla de Posiciones:");

            this.Posiciones.OrderBy(p => p.Value);

            int nPos = 1;
            foreach (var item in this.Posiciones)
            {
                Console.WriteLine($"{nPos}. {item.Key.Trim().PadRight(30)} Tiempo:{item.Value}");
                nPos++;
            }
        }
    }
}

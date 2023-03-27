using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1
{
    public interface IMonoplaza
    {
        public string Escuderia { get; set; }
        public string Nombre { get; set; }
        public void Encender() {}

        public void Apagar() {}

        public void Detener() {}

        public void Movimiento(){}

    }
}

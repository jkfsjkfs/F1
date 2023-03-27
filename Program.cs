using System.ComponentModel.Design;

namespace F1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuPpal();

            /*McLaren mc = new McLaren();
            Circuito cr = new Circuito("Circ1", 4);
            cr.AgregarMonoPlaza(new McLaren());
            cr.RealizarPrueba();*/
        }


        static void MenuPpal()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine("PRUEBAS MONOPLAZA F1");
            Console.WriteLine("------------------------");
            Console.WriteLine("1. Nuevo Circuito");
            Console.WriteLine("2. Salir");
            Console.WriteLine();
            Console.Write("Selecione una opción: ");

            int nOpcion = 0;
            int.TryParse(Console.ReadLine(),out nOpcion);
            if (nOpcion == 0 || nOpcion > 2)
            {
                Console.WriteLine("         !!!***** Opción NO válida. *****!!!");
                MenuPpal();
            }
            else
            {
                switch (nOpcion)
                {
                    case 1:
                        MenuCircuito(new Circuito());
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }

        }

        static void MenuCircuito(Circuito pCircuito)
        {
            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine($"CIRCUITO: {pCircuito.Nombre} ({pCircuito.Vueltas} Vueltas)");
            Console.WriteLine("------------------------");
            Console.WriteLine("1. Agregar Monoplaza");
            Console.WriteLine("2. Retirar Monoplaza");
            Console.WriteLine("3. Realizar Prueba");
            Console.WriteLine("4. Finalizar Circuito");
            Console.WriteLine();
            Console.Write("Selecione una opción: ");

            int nOpcion = 0;
            int.TryParse(Console.ReadLine(), out nOpcion);
            if (nOpcion == 0 || nOpcion > 4)
            {
                Console.WriteLine("         !!!***** Opción NO válida. *****!!!");
                MenuCircuito(pCircuito);
            }
            else
            {
                switch (nOpcion)
                {
                    case 1:
                        pCircuito.AgregarMonoPlaza(MenuMonoplaza());
                        Console.Clear();
                        MenuCircuito(pCircuito);
                        break;
                    case 2:
                        pCircuito.SacarMonoPlaza();
                        MenuCircuito(pCircuito);
                        break;
                    case 3:
                        pCircuito.RealizarPrueba();
                        MenuCircuito(pCircuito);
                        break;
                    case 4:
                        if (pCircuito.Finalizar())
                            MenuPpal();
                        else
                            MenuCircuito(pCircuito);

                        break;
                }
            }

        }

        static IMonoplaza MenuMonoplaza()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("ESCUDERÍA: ");
            Console.WriteLine("1. McLaren");
            Console.WriteLine("2. Ferrari");
            Console.WriteLine("3. RedBull");
            Console.WriteLine();
            Console.Write("Selecione una escudería: ");

            int nOpcion = 0;
            int.TryParse(Console.ReadLine(), out nOpcion);
            if (nOpcion == 0 || nOpcion > 3)
            {
                Console.WriteLine("         !!!***** Opción NO válida. *****!!!");
                return MenuMonoplaza();
            }
            else
            {
                switch (nOpcion)
                {
                    case 1:
                        return new McLaren();
                    case 2:
                        return new Ferrari();
                    case 3:
                        return new RedBull();
                    default: 
                        return MenuMonoplaza();
                }
            }
        }



    }
}
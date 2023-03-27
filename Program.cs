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
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("************************");
            Console.WriteLine("1. Crear Circuito");
            Console.WriteLine("2. Salir");
            Console.WriteLine();
            Console.WriteLine("Selecione una opción: ");

            int nOpcion = 0;
            int.TryParse(Console.ReadLine(),out nOpcion);
            if (nOpcion == 0 || nOpcion > 2)
            { 
                Console.WriteLine("Opción NO válida. Presione una tecla para continuar... ");
                Console.ReadKey();
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
            Console.Clear();
            Console.WriteLine("********************************");
            Console.WriteLine("CIRCUITO: " + pCircuito.Nombre);
            Console.WriteLine("********************************");
            Console.WriteLine("1. Agregar Monoplaza");
            Console.WriteLine("2. Retirar Monoplaza");
            Console.WriteLine("3. Realizar Prueba");
            Console.WriteLine("4. Finalizar Circuito");
            Console.WriteLine();
            Console.WriteLine("Selecione una opción: ");

            int nOpcion = 0;
            int.TryParse(Console.ReadLine(), out nOpcion);
            if (nOpcion == 0 || nOpcion > 4)
            {
                Console.WriteLine("Opción NO válida. Presione una tecla para continuar... ");
                Console.ReadKey();
                MenuCircuito(pCircuito);
            }
            else
            {
                switch (nOpcion)
                {
                    case 1:
                        pCircuito.AgregarMonoPlaza(MenuMonoplaza());
                        MenuCircuito(pCircuito);
                        break;
                    case 2:
                        pCircuito.SacarMonoPlaza();
                        MenuCircuito(pCircuito);
                        break;
                    case 3:
                        pCircuito.RealizarPrueba();
                        Console.WriteLine("Presione una tecla para volver al menu... ");
                        Console.ReadKey();
                        MenuCircuito(pCircuito);
                        break;
                    case 4:
                        pCircuito.Finalizar();
                        Console.WriteLine("Presione una tecla para ir al menu Principal... ");
                        Console.ReadKey();
                        MenuPpal();
                        break;
                }
            }

        }

        static IMonoplaza MenuMonoplaza()
        {
            Console.Clear();
            Console.WriteLine("ESCUDERÍA: ");
            Console.WriteLine("1. McLaren");
            Console.WriteLine("2. Ferrari");
            Console.WriteLine("3. RedBull");
            Console.WriteLine();

            int nOpcion = 0;
            int.TryParse(Console.ReadLine(), out nOpcion);
            if (nOpcion == 0 || nOpcion > 3)
            {
                Console.WriteLine("Opción NO válida. Presione una tecla para continuar... ");
                Console.ReadKey();
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
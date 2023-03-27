namespace F1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            McLaren mc = new McLaren();
            Circuito cr = new Circuito("Circ1", 4);
            cr.AgregarMonoPlaza(new McLaren());
            cr.RealizarPrueba();

            Console.WriteLine("Hello, World!");
        }
    }
}
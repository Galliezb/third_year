using System;

namespace type_nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            string str = null;
            int? b = null;

            // opérateur binaire
            // a = (int)b; => b n'est pas instancié !!! les opérations binaire restent ce qui se fait de mieux et évitent tout soucis
            // a = (int)b;
            // si b != null je copie b dans a
            // si b == null, je copie 0 dans a
            a = b ?? 0;

            //a = (int)b;
            Console.WriteLine( "a => " + a );
            Console.ReadKey();
        }
    }
}

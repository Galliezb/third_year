using System;

namespace Exo01
{
    class Program
    {
        static void Main(string[] args)
        {
            Pile<int> maPile1 = new Pile<int>();
            Pile<string> maPile2 = new Pile<string>();
            maPile1.AddElement( 10 );
            maPile2.AddElement( "20" );
            maPile1.DeletePile();
            // survol de la méthode montrera bien un type string
            Console.WriteLine( maPile2.GetLastElement() );
            Console.WriteLine("Hello World!");
        }
    }
}

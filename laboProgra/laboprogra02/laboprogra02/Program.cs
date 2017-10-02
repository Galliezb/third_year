using System;


namespace laboprogra02
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage G1 = new Garage(10,"Tournai");
            Utilitaire ut = new Utilitaire( "toyota", 150, "123456789", 1250 );
            Utilitaire ut2;
            ut2 = ut;

            Vehicule v1 = new Vehicule( "toyota", 150, "123456789" );
            Console.WriteLine( "v1 " + v1.GetNumeroChassis() );
            Console.WriteLine( "v1 " + ut2.GetNumeroChassis() );
            Console.WriteLine("Hello World!");

            // Array.sort() ne fonctionnera sur un tableau que si notre classe
            // hérite de Icomparable

            G1.AddVehicule( v1 );
            G1.AddVehicule( ut2 );

            Console.ReadKey();
        }
    }
}

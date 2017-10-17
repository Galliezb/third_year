using System;

namespace methodes_extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Pile<int> st1 = new Pile<int>();
            st1.Empilement( 10 );
            st1.Empilement( 20 );
            Console.WriteLine(st1.Depilement());
            Console.WriteLine(st1.Depilement());
            Console.WriteLine(st1.Depilement());

            // le premier argument qu'on est censé envoyer est st1 
            // qui est automatiquement envoyé.
            // pour l'utilisateur, il lui suffit d'utiliser ça comme
            // si c'était une méthode de la classe
            // disponible en version 3.0 du c#
            st1.Empiler( 15 );

            Console.ReadKey();
        }
    }
}

using System;

namespace param_valeur_reference
{
    class Program
    {
        static void Main(string[] args)
        {
            int data = 10;
            int data2;
            Personne p1 = new Personne();
            p1.nom = "dupond";
            p1.prenom = "toto";
            Console.WriteLine( p1 );
            //Console.WriteLine( " data => " +data );
            PassageRef( p1 );
            PassageValeur( data );
            Console.WriteLine( " data => " + data );
            passageValeurByRef( ref data );
            Console.WriteLine( " data => " + data );
            Console.WriteLine( p1 );

            passageValeurByRefWithoutInitialisation( out data2 );
            Console.WriteLine( " data2 => " + data2 );

            Console.ReadKey();
        }

        // on envoie un type ref, donc forcément on modifie l'original
        static void PassageRef( Personne pers) {
            pers.prenom = "dudule";
        }

        // on envoie un type valeur qui sera donc copié et modifié dans la méthode
        // avant d'être supprimé à la }
        static void PassageValeur (int data) {
            data = 20;
        }

        // on demande d'envoyer une référence du type valeur
        // qu'on veut modifier pour éviter de manipuler une copie temporaire
        static void passageValeurByRef( ref int data) {
            data = 30;
        }

        // Avec out, on passe par référence à la différence qu'il n'est pas
        // obligatoire d'avoir initialisé la variable avant.
        static void passageValeurByRefWithoutInitialisation(out int data2) {
            data2 = 30;
        }

        // avec le mot clé params, on va pouvoir envoyer une liste de type valeur
        // sans connaitre à l'avance combien de paramètre il y aura
        // !!! Attention, ces valeurs restent du type valeur !!!
        static void xxxx ( params int[] xxx) {

        }
    }
}

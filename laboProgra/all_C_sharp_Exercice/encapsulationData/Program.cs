using System;

namespace encapsulationData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Article art1 = new Article();
            art1.Nom = "veste";
            art1.Prix = 0.2f;

            // arguments nommés
            Article art2 = new Article { Nom = "veste", Prix = 0.2f };

            // objet anonyme
            var art3 = new { Nom = "veste" };
            // pas possible, ce n'est pas le même objet pour lui
            art3 = new { Nom = "veste", Prix = 0.2f };
            art3 = new { Nom = "veste" };

            var art4 = new { nom = "veste", prix = 0.2f };
            // pas possible ( > C# 5 )
            // ce n'est que de l'organisation de datas, l'ordre est donc important ici
            art4 = new { prix = 0.2f, nom = "veste" };

        }
    }
}

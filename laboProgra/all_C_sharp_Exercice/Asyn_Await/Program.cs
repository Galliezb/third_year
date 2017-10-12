using System;
using System.IO;
using System.Threading.Tasks;

namespace Asyn_Await
{
    class Program
    {
        // Async pour déclencher une méthode asynchronne
        // contenant un await qui lui sera synchronne 
        // exemple : contacter une BDD qui mets du temps à répondre
        // par rapport au multiThreading, simplicité d'écriture ?
        // plus rapide et simple pour des choses simples demandant du temps
        // mais pas forcément des ressources processeur par exemple.
        // Async type de retor => void ou Task<T>
        // pas besoin de return Task
        // Task<string> 
        // { 
        //  return string; => suffisant
        // }

        // la base
        //static void Main(string[] args) {
        //    byte[] readBuffer;
        //    var MyStream = File.OpenRead( @"c:\data\data.pdf" );
        //    readBuffer = new byte[MyStream.Length];
        //    // continueWith va retourner une tâche
        //    MyStream.ReadAsync( readBuffer, 0, (int)MyStream.Length ).ContinueWith( task =>
        //    {
        //        if (task.Status == TaskStatus.RanToCompletion) {
        //            Console.WriteLine( "{0} bytes lus avec succès", task.Result );
        //        }
        //        MyStream.Dispose();
        //    } );
        //    Console.WriteLine( "Suite du traitement en attendant le chargement" );
        //    Console.ReadKey();
        //}


        // transformer tout ceci avec notre propre méthode.
        static void Main(string[] args) {
            ReadFileAsync( @"c:\data\data.pdf" );
            Console.WriteLine( "Suite du traitement en attendant le chargement" );
            Console.ReadKey();
        }
        static async Task<int> ReadFileAsync(string FilePath) {
            byte[] readBuffer;
            var MyStream = File.OpenRead( FilePath );
            readBuffer = new byte[MyStream.Length];
            // renvoie le type de retour prévu dans la tache
            var ReadCount = await MyStream.ReadAsync( readBuffer, 0, (int)MyStream.Length );
            Console.WriteLine( "{0} bytes lus avec succès", ReadCount );
            // oui on renvoie que le nombre de byte lu, mais on s'en fou
            // c'est que pour l'exemple
            return ReadCount;
        }
    }
}

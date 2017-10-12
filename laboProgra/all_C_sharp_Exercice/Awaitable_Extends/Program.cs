using System;

namespace Awaitable_Extends
{
    class Program
    {
        // et si dans un new, on devait attendre que l'objet puisse être créé ?
        // Et si le constructeur de l'instance devait par exemple prendre 10 sec ?
        // Awaitable va permettre de mettre en place le mécanisme qui 
        // évitera de devoir attendre
        // La méthode GetAwaiter () doit renvoyer un objet implémentant l'interface
        // INotifyCompletion.
        //L'objet doit également exposer les propriétés et les méthodes suivantes:
        //bool IsCompleted { get; }
        //void OnCompleted(Action continuation)
        //TResult GetResult()
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

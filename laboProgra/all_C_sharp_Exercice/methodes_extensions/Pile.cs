using System;
using System.Collections.Generic;
using System.Text;

namespace methodes_extensions {

    static class MesExtensions {

        // le mot clé this indique que c'est une méthode d'extension
        // le Pile permet d'accéder à l'objet qui a permis d'utiliser la méthode d'extension
        public static void Empiler<T>(this List<T> Pile, T element) {
            Pile.Add( element );
            // qui remplace le this.add présent dans Empilement
        }

    }

    class Pile<T> : List<T> {

        public void Empilement(T element) {
            this.Add( element );
        }

        public T Depilement() {
            if (this.Count < 0) {
                throw new StackEmptyException();
            } else {
                T element =  this[this.Count - 1];
                this.RemoveAt( this.Count - 1 );
                return element;
            }
        }

        // et si on voulait supprimer une méthode disponible ? genre removeAt par exemple ?
        // le mot clé "sealed" permet d'empêcher l'héritage de class, et de méthode
        // https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/keywords/sealed

        // les méthodes d'extensions sont forcément des classes statiques

    }
}

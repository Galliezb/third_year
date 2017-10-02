using System;
using System.Collections.Generic;
using System.Text;

namespace Exo01
{
    class Pile<T>
    {

        List<T> _conteneur = new List<T>();

        public Pile () {

        }

        public Pile( T variable) {

        }

        public void AddElement( T variable) {
            _conteneur.Add( variable );
        }

        public T GetLastElement() {

            // vérifier que la pile > 0 element
            // sinon throw exception
            // c'est a l'autre a faire du try catch et à se démmerder

            _conteneur.RemoveAt( _conteneur.Count - 1 );
            return _conteneur[_conteneur.Count-1];
        }

        public void DeletePile() {
            _conteneur.Clear();
        }


    }
}

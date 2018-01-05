using System;

namespace ClassLibrary1
{
    public class Personne{
        private string nom;
        private string prenom;

        public Personne(string nom, string prenom) {
            this.nom = nom;
            this.prenom = prenom;
        }

        public override string ToString() {
            return string.Format( "{0] {1}", this.nom, this.prenom );
        }
    }
}

using System;

namespace laboProgra01 {
    class Program {
        static void Main(string[] args) {
            Personne p = new Personne();
            // polymorphisme
            Object test = p;
            Console.WriteLine( p.GetType().ToString() );
            Console.WriteLine( p.ToString() );
            // p.ToString() = p car Writeline appelle ToString automatiquement si un objet lui est donné

            // placement de variable dans un writeligne avec des {x}
            //Console.WriteLine("test{1}, blabla : {0}", variable1, variable2);
            //donne: "testvariable2, blabla : variable1" 

        }
    }

    class Personne {

        string _nom;
        string _prenom;

        // constructeur par défaut avec le mot clé this
        public Personne(): this ("aucunNom", "aucunPrenom" ){
        }

        //public Personne(string nom = "aucun", string prenom = "aucun") { > a V4.5
        public Personne(string nom, string prenom) {

            this._nom = nom;
            this._prenom = prenom;
        }

        public string nom {
            get {
                return this._nom;
            }
            set {

                try {
                    this._nom = value;
                }
                catch (Exception ex) {
                    Console.WriteLine( "Tu as fait une connerie" );
                }
                finally {

                }

            }
        }


        // surcharge
        public override string ToString() {
            //return base.ToString();
            return this._nom + " " + this._prenom;
        }

    }



}

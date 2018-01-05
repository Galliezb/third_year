using System;
using System.Collections.Generic;
using System.Text;

namespace Test_C_sharp {

    class Image:IDisposable {
        static private int nbrImageInstance = 0;
        public Image () {
            nbrImageInstance++;
        }
        ~Image () {
            Dispose(false);
        }

        public virtual void Dispose(bool b ) {


            nbrImageInstance--;

        }

        public void Dispose () {
            Dispose(false);
            GC.SuppressFinalize( this );
        }
    }

    class GestionImage : IDisposable {
        Image picture = null;
        protected bool disposed = false;
        public string Picture {
            set {
                picture = Image.FromFile( value );
            }
        }
        public GestionImage () {
            Console.WriteLine( "appel constructeur" );
        }
        public void Dispose () {
            Console.WriteLine( "Appel explicite de libération" );
            Dispose( true );
            GC.SuppressFinalize( this );

        }
        protected virtual void Dispose ( bool disposing ) {
            if ( !disposed ) {
                Console.WriteLine( "ressources pas encore libérées" );

                if ( disposing == true ) {
                    Console.WriteLine( "libération ressources managées" );

                    if ( picture != null ) {
                        picture.Dispose();
                        picture = null;
                    }
                }
                Console.WriteLine( "libération ressources non managées" );
                disposed = true;
            } else {
                Console.WriteLine( "ressources déjà libérées" );
            }
        }
        ~GestionImage () {
            Console.WriteLine( "appel destructeur" );
            Dispose( false );
        }
    }

    class Class1 {
        static void Main ( string[] args ) {
            GestionImage temp1 = new GestionImage();
            temp1.Picture = "c:\\image.jpg";
            GestionImage temp2 = new GestionImage();
            temp2.Picture = "c:\\image.jpg";
            GestionImage temp3 = new GestionImage();
            temp3.Picture = "c:\\image.jpg";
            Console.ReadLine();
            temp1.Dispose();
            Console.ReadLine();
            Console.WriteLine( "fin du programme" );
        }

    }
}

using System;

namespace Enumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "START : " );
            Console.ReadKey();

            Garage G1 = new Garage( 10 );
            try {
                // possibilité de passé un param directement avec la propriété
                G1.Add( new Vehicule { Marque = "Ford" } );
                G1.Add( new Vehicule() );
                G1.Add( new Vehicule() );

                foreach (var v in G1) {
                    Console.WriteLine( "Vehicule : " + v.Marque );
                }

            } catch (NotImplementedException ex) {
                throw new Exception( ex.Message.ToString() );
            } catch (GaragePleinException ex) {
                throw new Exception( ex.Message.ToString() );
            } catch (Exception ex) {
                throw new Exception( ex.Message.ToString() );
            }

            Console.ReadKey();
        }
    }
}

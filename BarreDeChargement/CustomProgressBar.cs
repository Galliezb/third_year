using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BarreDeChargement {

    // dans xaml il fauda utiliser <local:customProgressBar>
    class CustomProgressBar:ProgressBar {

        private int _AlertLevel { get; set; }
        // on ajoute l'abonnement possible à cet évènement
        // donc AlertEvent += est désormais possible dans ce code
        public static readonly RoutedEvent AlertEvent = EventManager.RegisterRoutedEvent("monEventProgressBar",RoutingStrategy.Direct,typeof(RoutedEventHandler),typeof(CustomProgressBar));
        public int AlertLevel {
            get { return this._AlertLevel; }
            set {
                if (this._AlertLevel >= this.Minimum && this._AlertLevel <= this.Maximum) {
                    this._AlertLevel = value;
                } else {
                    throw new Exception( "Out of range" );
                }
            }
        }

        // Alert="" est désormais disponible dans le Xaml
        public event RoutedEventHandler Alert {
            // pas de get set mais des add et remove !
            add {
                // ( routed event, délégué )
                this.AddHandler( CustomProgressBar.AlertEvent, value );
            }
            remove {
                this.AddHandler( CustomProgressBar.AlertEvent, value );
            }
        }

        // ovverride la méthode de range qui est la classe de base de ProgressBar
        // ainsi quand on change la valeur on passe par ici et on pourra y soulever notre
        // event
        public new double Value {
            get {
                return base.Value;
            }
            set {
                if ( value > this.AlertLevel) {
                    // soulève l'évènement au travers du RaiseEvent
                    RaiseEvent(new RoutedEventArgs( AlertEvent ) );
                    // on pourra donc ensuite dans le XAML y mettre un 
                    // AlertEvent ="monDelgue"
                    // celui-ci sera soulevé quand l'alert dépassera la valeur configuré
                }
                base.Value = value;
            }
        }



    }
}

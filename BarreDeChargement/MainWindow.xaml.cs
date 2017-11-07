using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarreDeChargement {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            maProgressBar.AlertLevel = 50;
        }

        private void Button_Plus(object sender, RoutedEventArgs e) {
            maProgressBar.Value += 5;
        }

        private void Button_Moins(object sender, RoutedEventArgs e) {
            maProgressBar.Value -= 5;
        }

        // exemple d'evenement soulevé
        public void TestDepassementSeuil(object sender, RoutedEventArgs e) {

            CustomProgressBar pb = ( (CustomProgressBar)sender );
            MessageBox.Show( "Event soulevé, AlertLevel : " + pb.AlertLevel
                                             +"value: " + pb.Value);

        }
    }
}

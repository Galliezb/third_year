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

namespace LesCommandes {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            CommandManager.RegisterClassCommandBinding( typeof( MainWindow ), new CommandBinding( ApplicationCommands.Close, new ExecutedRoutedEventHandler( CommandBinding_Executed ) , new CanExecuteRoutedEventHandler( CommandeBinding_CanExecute ) ) );
        }

        private void CommandeBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {

            // ischecked ou false si null
            e.CanExecute = Valider.IsChecked??false;

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
            // ce gene de concept est merdique. On doit délégué l'évènement vers le responsable de la
            // fermeture. Si avant la fermeture, on execute différentes chose,
            // ici on ne fera rien, en soulevant l'évènement, ce sera fait.
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            MessageBox.Show( "On tente de fermer l'application" );
        }
    }
}

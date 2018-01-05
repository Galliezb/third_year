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
using Microsoft.Win32;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;
using System.Diagnostics;

namespace registry_privilege {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            //System.AppDomain.CurrentDomain.SetPrincipalPolicy( PrincipalPolicy.WindowsPrincipal );
            //WindowsIdentity curIdentity = WindowsIdentity.GetCurrent();
            //WindowsPrincipal myPrincipal = new WindowsPrincipal( curIdentity );  
            //List<string> groups = new List<string>();

            // partager des infos entre process via des pipes 
            http://www.codingvision.net/tips-and-tricks/c-send-data-between-processes-w-memory-mapped-file
            // on créé done unc classe librairy et on ajoute la référence vers cette classe pour l'utiliser et partager
            // des informations

            // pour savoir ou est stocké l'exe et lance l'autre avec de meilleurs privilèges
            //MessageBox.Show( System.Reflection.Assembly.GetExecutingAssembly().Location );
            MessageBox.Show( System.AppDomain.CurrentDomain.BaseDirectory );
            

            // avec ce système seul les actions voulus recupère les droits nécessaire, et évite en cas de hack
            // de se faire niquer un .exe qui possède les droits admins sur tout

            // voir aussi le DECOM qui permet de communiquer avec des applications d'autres machines
        }

        //[PrincipalPermission( SecurityAction.Demand, Role = @"DESKTP-T7DD6PN\\super" )]
        private void Write_hkcu(object sender, RoutedEventArgs e) {

            //RegistryKey key = Registry.CurrentUser.OpenSubKey(hkcu_name.Text);

            //registry_privilege.MainWindow.

            // on est dans CURRENT USER, on ouvre SOFTWARE
            RegistryKey soft = Registry.CurrentUser.OpenSubKey( "SOFTWARE" );
            // on est dans SOFTWARE on ouvre monlogiciel ( true = writable )
            RegistryKey rep = soft.CreateSubKey( "monLogiciel", true );
            // ecrire une clé dans ce répetoire ( écrase si existante )
            rep.SetValue( hkcu_name.Text, hkcu_value.Text, RegistryValueKind.String );

            // démarrer un nouveau process
            //ProcessStartInfo startInfo = new ProcessStartInfo( m_strInstallUtil, strExePath );
            //startInfo.Verb = "runas";
            //System.Diagnostics.Process.Start( startInfo );


        }
        private void Read_hkcu(object sender, RoutedEventArgs e) {

            // on est dans CURRENT USER, on ouvre SOFTWARE
            RegistryKey soft = Registry.CurrentUser.OpenSubKey( "SOFTWARE" );
            // on est dans SOFTWARE on ouvre monlogiciel ( true = writable )
            RegistryKey rep = soft.CreateSubKey( "monLogiciel", true );
            // ecrire une clé dans ce répetoire ( écrase si existante )
           MessageBox.Show( "valeur : " + rep.GetValue( hkcu_name.Text ).ToString() );

        }
        private void Write_hklm(object sender, RoutedEventArgs e) {

        }
        private void Read_hklm(object sender, RoutedEventArgs e) {

        }

    }
}

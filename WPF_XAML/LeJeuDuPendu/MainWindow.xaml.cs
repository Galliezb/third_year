using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Threading;

namespace LeJeuDuPendu {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public int gameDifficulty = 5;
        List<MenuItem> LMI = new List<MenuItem>();
        List<TextBlock> listTB = new List<TextBlock>();
        int TimerForPlay;
        int etatImage = 0;
        private DispatcherTimer dispatcherTimer;
        string motATrouver;

        public MainWindow () {
            InitializeComponent();

            LMI.Add( difficulty0 );
            LMI.Add( difficulty1 );
            LMI.Add( difficulty2 );
            LMI.Add( difficulty3 );
            LMI.Add( difficulty4 );
            LMI.Add( difficulty5 );
            LMI.Add( difficulty6 );
            LMI.Add( difficulty7 );

            // Ajoute le dispatcher qui va gérer le décompte des secondes
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            // a chaque temps atteint il déclenche le delegate
            dispatcherTimer.Tick += new EventHandler( DisplayTimerInStatusBar );
            // réglé sur 1 sec ( Heure, minute, seconde )
            dispatcherTimer.Interval = new TimeSpan( 0 , 0 , 1 );

        }

        private string DBGiveMeAWord () {

            string strToReturn = "Default";

            try {

                //string connectionStr = @"Server=127.0.0.1\SQLEXPRESS; Database = WPF_XAML; Uid = labo; Password = 123";
                string connectionStr = @"Server=127.0.0.1\SELOCALPORTABLE; Database = WPF_XAML; Uid = labo; Password = 123";
                SqlConnection myConnection = new SqlConnection( connectionStr );
                myConnection.Open();

                SqlCommand myCmd = new SqlCommand {
                    Connection = myConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetWord"
                };
                myCmd.Parameters.AddWithValue( "@difficulty", gameDifficulty );

                SqlDataReader myRd = myCmd.ExecuteReader();
                myRd.Read();
                strToReturn = myRd[0].ToString();

                myRd.Close();
                myConnection.Close();

            } catch( SqlException sqlExc) {

            }

            return strToReturn;

        }

        private Border GetButton ( int ID , string character ) {


            Border borderToReturn = new Border {
                BorderThickness = new Thickness( 1 ) ,
                BorderBrush = Brushes.Black ,
                Margin = new Thickness( 0 , 10 , 10 , 0 )
            };

            TextBlock textInBorder = new TextBlock {
                Name = "TextBlock" + ID ,
                Width = 30 ,
                FontWeight = FontWeights.Bold ,
                FontSize = 20 ,
                TextAlignment = TextAlignment.Center ,
                Text = character
            };
            listTB.Add( textInBorder );

            borderToReturn.Child = textInBorder;

            return borderToReturn;

        }

        private void SaveDifficulty ( object sender , RoutedEventArgs e ) {

            MessageBox.Show( "saveDifficulty" + sender.ToString() );

            // Stop la propagation
            //e.Handled = true;

            // En travaillant sur le click plutot que sur le checked on ne soulevera pas 
            // l'evènement checked. De ce fait pas de stackOverflow.
            // Il suffit ensuite de sauvegarder quel element est Ischecked="true"
            // pour eviter de parcourir tous les items
            // isCheckable permet juste faire changer l'etat du IsCHecked au click de l'utilisateur

            // récupère le numéro de difficulté cliqué
            MenuItem clicked = (MenuItem) sender;
            int whoIsClicked = int.Parse( clicked.Name.Substring( 10 ) );

            // checked = false pour les autres
            // On évite les multi-choix en difficulté ;)
            // pour éviter le LMI.count, on peut charger tout ceci après que l'évènement loaded
            // du Windows ai été soulevé. Qui assure que tout le Xaml est prêt ( comme le DOMContentReady )
            if ( LMI.Count > 0 ) {
                foreach ( MenuItem mi in LMI ) {

                    // voir au dessus comment changer ceci
                    //mi.Checked -= SaveDifficulty; // supprimé par e.Handled = false;
                    if ( whoIsClicked != int.Parse( mi.Name.Substring( 10 ) ) ) {
                        mi.IsChecked = false;
                    } else {
                        mi.IsChecked = true;
                    }
                    //mi.Checked += SaveDifficulty; // supprimé par e.Handled = false;

                }
            }



            // mets à jour la difficulté du jeu
            switch ( whoIsClicked ) {
                case 0:gameDifficulty = 5;break;
                case 1:gameDifficulty = 7;break;
                case 2:gameDifficulty = 9;break;
                case 3:gameDifficulty = 11;break;
                case 4:gameDifficulty = 13;break;
                case 5:gameDifficulty = 15;break;
                case 6:gameDifficulty = 17;break;
                case 7:gameDifficulty = 18;break;
            }

        }

        private int GetTimerForDifficulty () {
            switch ( gameDifficulty ) {
                case 5: return 30;
                case 7: return 25;
                case 9: return 20;
                case 11: return 15;
                case 13: return 10;
                case 15: return 8;
                case 17: return 6;
                case 19: return 4;
                default:return 60;
            }
        }

        private ImageSource SourceOfImage ( int number ) {

            //string strTest = "pack://application:,,,/LeJeuDuPendu;component/img/etat" + number + ".jpg";
            //Uri monUri = new Uri( strTest );
            //Image imgNewSource = new Image {
            //    Source = new BitmapImage( monUri )
            //};
            //return imgNewSource.Source;

            // Méthode MR Wilfart
            // via les chemins relatifs
            string name = "img/etat" + number + ".jpg";
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(name,UriKind.Relative);
            img.EndInit();
            return img;
        }

        private void Demarrer_Click ( object sender , RoutedEventArgs e ) {

            // reinit la liste des textbox
            listTB.Clear();
            // récupère le mot dans la BDD
            motATrouver = DBGiveMeAWord();
            // enclenche le timer
            TimerForPlay = GetTimerForDifficulty();
            // démarre le dispatcher
            dispatcherTimer.Start();
            // reinit l'etat image
            etatImage = 0;
            // reinitialise l'image
            imgPendu.Source = SourceOfImage( etatImage );
            // memory letter
            tryedLetter.Content = "";

            // recupère le conteneur et vide les lettres
            StackPanel LeConteneur = (StackPanel) FindName( "ConteneurLettre" );
            LeConteneur.Children.Clear();

            // on ajoute par rapport au nombre de lettre
            for ( int i = 0; i < motATrouver.Length; i++ ) {
                if ( i == 0 || i == motATrouver.Length - 1 ) {
                    LeConteneur.Children.Add( GetButton( i , motATrouver[i].ToString() ) );
                } else {
                    LeConteneur.Children.Add( GetButton( i , "-" ) );
                }
            }

        }

        private void TryFailed () {
            etatImage++;
            // reinitialise l'image
            imgPendu.Source = SourceOfImage( etatImage );

            // One more time guys !
            if ( etatImage < 7 ) {

                // ré-enclenche le timer
                TimerForPlay = GetTimerForDifficulty();
                // re-démarre le dispatcher
                dispatcherTimer.Start();

            // Rooo dommage c'est perdu !
            } else {

                // on ajoute les lettre non trouvées
                for ( int i = 0; i < motATrouver.Length; i++ ) {

                    string str = motATrouver[i].ToString();

                    if ( listTB[i].Text != str ) {
                        listTB[i].Text = str;
                        listTB[i].Background = new SolidColorBrush(Color.FromRgb(0xFF,0x00,0x00));
                    }

                }

                // on stop le dispatcher
                dispatcherTimer.Stop();

                // on change la status barre
                lbSB.Content = "Dommage c'est perdu. Une autre partie ?";

            }

        }

        private void TryLetter (object sender, EventArgs e) {

            if ( LetterProposed.Text != "" && etatImage < 7 && motATrouver!=null ) {
                string letter = LetterProposed.Text.Substring( 0 , 1 );
                LetterProposed.Text = "";
                TrySucess( letter );
                LetterProposed.Focus();

                // ajoute la lettre à la liste si difficulty < 13
                if ( gameDifficulty < 13 ) {

                    if ( tryedLetter.Content.ToString().Length == 0 ) {
                        tryedLetter.Content = letter;
                    } else {
                        tryedLetter.Content = tryedLetter.Content.ToString() + " - " + letter;
                    }
                } else {
                    tryedLetter.Content = "¯\\_༼ ಥ ‿ ಥ ༽_/¯";
                }
            }

        }

        private void TrySucess ( string letter ) {

            int cpt = 0;
            bool loseLife = true;

            // on ajoute si une lettre correspond
            for ( int i = 0; i < motATrouver.Length; i++ ) {

                string str = motATrouver[i].ToString();

                if ( listTB[i].Text == "-" && str == letter ) {
                    listTB[i].Text = str;
                    listTB[i].Background = new SolidColorBrush( Color.FromRgb( 0x00 , 0xFF , 0x00 ) );
                    loseLife = false;
                }

                // cpt les lettre affichées
                if ( listTB[i].Text != "-" ) {
                    cpt++;
                }

            }

            // La partie est gagné !
            if ( cpt == motATrouver.Length ) {

                // Affiche l'image gagné
                etatImage = 8;
                imgPendu.Source = SourceOfImage( etatImage );
                // on change la status barre
                dispatcherTimer.Stop();
                lbSB.Content = "Félicitation ! Augmente le niveau de difficulté !";


                // si il reste encore des tentatives, -1 et on passse à la suite.
            } else if( loseLife ) {
                TryFailed();
            // on a découvert une lettre on remet du temps
            } else {
                TimerForPlay = GetTimerForDifficulty();
            }


        }

        private void DisplayTimerInStatusBar ( object sender , EventArgs e ) {

            if ( TimerForPlay > 0 ) {

                lbSB.Content = "Il reste " + TimerForPlay + " secondes";
                TimerForPlay--;

            } else {

                lbSB.Content = "Il reste " + TimerForPlay + " seconde";

                // stop le dispatcher ( relancé si tous les mauvais essais n'ont pas été atteind )
                dispatcherTimer.Stop();

                // raté
                TryFailed();

            }

        }
    }
}

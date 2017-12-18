using ClassLibrary1;
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

namespace Assemblys {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
    /*
    ajouter des dlls dans la cache global d'assemblage
     régéner la solution et voir le dll dans Debug
     on pourrait y stocker ce que l'on veut, voir même des ressource graphique pour nos applications WPF
     dans l'autre APP, ajouter une référence, donner le repertoire du dll et l'ajouter
     il existe dans les propriété une option "copie locale"

     dll globale => dans la cache globale d'assemblage et faire une référence => copie local = false;
     dll locale => il faudra indiquer ou se troue la dll => copie locale = true;

    a l'epoque dans system et system32
        => problem de dll de meme nom qui s'ecrase 
        => deux dll identique mais langue différente
        => comment gérer les versions des dlls
    depuis 95 elle peuvent se retrouver n'importe ou mais dans le même dossier que le .exe

    Puis on a changé dans la GAC le système, en indiquant directement le chemin vers la dll
        => probabilité de nom / repertoire / versions / langue identique faible
            => chemin : 
                => marque 
                => version 
                => langue / culture
    Comment garantir a l'application que le chemin vers la dll est bon ?
    La GAC sera informé des différents liens entre les dll et les chemins et c'est elle qui va gérer les accès
    quand le exe utilise une référence GAC

    pour les GAC il faudra donc créer un NOM FORT soit un certificat
    pour empecher les autres applications d'utiliser les dlls d'autres applications
    système de clé asymétrique

        https://msdn.microsoft.com/fr-fr/library/xc31ft41(v=vs.110).aspx

    Dans assemblyInfo.cs ( preperty ) on y retrouvera toutes les informations
    la clé devra être greffer à ce document
    L'install shield automatisera l'installation ou la desinstallation d'un assembly.
    en mode developpement, on utiliser les outils de cmd VS 2017 pour ajouter ou supprimer des assemblys à la GAC pour tester
    Ensuite cette référence devrait logiquement être présente dans les Assemblys 
    ( après redémarrage ? ou donné à la main s'il ne le trouve pas )


    GAL ( cache d'assemblage local ) le dll à côté de la dll

    En supprimant l'assembly dans le GAC on a une erreur au lancement de l'app sans perturber window
    */

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        public object ClassLibrary1 { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Personne pers = new Personne( "toto", "dudule" );
            test.Text = pers.ToString();
        }
    }
}

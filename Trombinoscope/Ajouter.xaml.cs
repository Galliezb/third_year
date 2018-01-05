﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Windows.Shapes;

namespace Trombinoscope {
    /// <summary>
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public partial class Ajouter : Window {

        public Users UserToAdd = new Users();
        private MonObservableCollection<Users> UsersList;

        public Ajouter( MonObservableCollection<Users> lu ) {
            InitializeComponent();

            UsersList = lu;

            DataContext = this.UserToAdd;
            UserToAdd.Nom = "Nom";
            UserToAdd.Prenom = "Prenom";
            UserToAdd.Email = "Email";
            UserToAdd.Tel = "056/123456";
        }


        private void AjouterUserToDB(object sender, RoutedEventArgs e) {

            //User2DataContext tmp = new User2DataContext();
            //int succes = tmp.AddUser( UserToAdd.Nom , UserToAdd.Prenom, UserToAdd.Email, UserToAdd.Tel, UserToAdd.Adresse, UserToAdd.CodePostal, UserToAdd.Ville );
            //MainWindow.user

            UsersList.Add( UserToAdd );

            // ferme la fenêtre
            this.DialogResult = true;

        }
    }
}

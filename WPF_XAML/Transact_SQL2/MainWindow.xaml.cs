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
using Transact_SQL2;

namespace Transact_SQL2 {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            System.Data.Common.DbTransaction MyTrans = null;
            TransactUserDataContext dataContext = new TransactUserDataContext();
            dataContext.Connection.Open();
            MyTrans = dataContext.Connection.BeginTransaction();
            dataContext.Transaction = MyTrans;


            // en soulevant une exception sur la 500e itération
            // on peut s'apercevoir que les requêtes ont bien rollback les enregistrements
            // et qu'aucun insert n'as été effectué tant que les 1000 ne passe pas

            try {
                for (int i = 0; i < 1000; i++) {
                    dataContext.AddUserTransact( "name" + i );
                    //if (i == 500) { throw new Exception( "Ho zut" ); }
                }
                MyTrans.Commit();
                MessageBox.Show( "Fin du try" );
            } catch (Exception ex) {
                if (MyTrans != null) { MyTrans.Rollback(); }
                MessageBox.Show( "Exception" );
            } finally {
                if ( dataContext.Connection.State == System.Data.ConnectionState.Open) {
                    dataContext.Connection.Close();
                }
                MessageBox.Show( "Terminé" );
            }

        }
    }
}

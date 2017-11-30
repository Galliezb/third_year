using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trombinoscope {
    class ObservableCollection : INotifyCollectionChanged {

        public event NotifyCollectionChangedEventHandler CollectionChanged;
   
        public List<Users> UsersList { get; set; }

        public void Add(Users u) {

            UsersList.Add( u );
            CollectionChanged( this, new NotifyCollectionChangedEventArgs( NotifyCollectionChangedAction.Add ) );

        }

        public void Remove(Users u) {

            UsersList.Remove( u );
            CollectionChanged( this, new NotifyCollectionChangedEventArgs( NotifyCollectionChangedAction.Remove ) );

        }

    }
}

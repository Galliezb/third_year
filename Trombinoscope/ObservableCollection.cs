using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trombinoscope {
    public class MonObservableCollection<T> : INotifyCollectionChanged {

        public event NotifyCollectionChangedEventHandler CollectionChanged = new NotifyCollectionChangedEventHandler( ( x , y ) => { } );

        public List<T> UsersList { get; set; } = new List<T>();

        public void Add ( T u ) {

            UsersList.Add( u );
            OnCollectionChanged( new NotifyCollectionChangedEventArgs( NotifyCollectionChangedAction.Add , u ) );

        }

        public void Remove ( T u ) {

            UsersList.Remove( u );
            OnCollectionChanged( new NotifyCollectionChangedEventArgs( NotifyCollectionChangedAction.Remove ) );

        }

        protected virtual void OnCollectionChanged ( NotifyCollectionChangedEventArgs e ) {
            if ( CollectionChanged != null ) {
                CollectionChanged( this , e );
            }
        }
    }
}

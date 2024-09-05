﻿using Database_Example_Net80.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Example_Net80.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable, INotifyCollectionChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        //protected DatabaseContext DBContext;
        //protected ViewModelBase(DatabaseContext DBContext)
        //{
        //    this.DBContext = DBContext; 
        //}
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedAction action, object item)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, item));
            }
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }

    }
}

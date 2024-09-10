using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Example_Net80.Models
{
    public static class GlobalValues //: INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        private static string _schoolName = "TechCollege";

        public static string SchoolName 
        { 
            get
            {
                return (_schoolName);
            }
            set
            { 
                _schoolName = value;
                //PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(nameof(SchoolName)));
                //OnFilterStringChanged(EventArgs.Empty);
                OnPropertyChanged("SchoolName");
            }
        }

        //public static event EventHandler FilterStringChanged;

        //// Raise the change event through this static method
        //protected static void OnFilterStringChanged(EventArgs e)
        //{
        //    EventHandler handler = FilterStringChanged;

        //    if (handler != null)
        //    {
        //        handler(null, e);
        //    }
        //}

        public static event PropertyChangedEventHandler PropertyChanged;

        public static void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(null, new PropertyChangedEventArgs(propertyName));
            }
        }

        //static GlobalValues()
        //{
        //    FilterStringChanged += (sender, e) => { return; };
        //}
    }
}

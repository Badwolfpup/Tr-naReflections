using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TränaReflections.Testklasser.Childclass
{
    public class Klass1 : Parentclass, INotifyPropertyChanged
    {
        private int _property1; 
        private int _property2; 
        private int _property3;

        public int property1
                {
            get { return _property1; }
            set
            {
                if (_property1 != value)
                {
                    _property1 = value;
                    OnPropertyChanged(nameof(property1));
                }
            }
        }
        public int property2
        {
            get { return _property2; }
            set
            {
                if (_property2 != value)
                {
                    _property2 = value;
                    OnPropertyChanged(nameof(property2));
                }
            }
        }
        public int property3
        {
            get { return _property3; }
            set
            {
                if (_property3 != value)
                {
                    _property3 = value;
                    OnPropertyChanged(nameof(property3));
                }
            }
        }

        public Klass1()
        {
            property1 = 1;
            property2 = 2;
            property3 = 3;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) //Metoden skickar en signal till UI att propertyt man skickar med (propertyname) har uppdateras
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

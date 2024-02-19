using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TränaReflections.Testklasser;
using TränaReflections.Testklasser.Childclass;

namespace TränaReflections.Testklasser
{
    public class Parentclass : INotifyPropertyChanged
    {
        private string _namn;
        public string Namn
        {
            get { return _namn; }
            set
            {
                if (value != _namn)
                {
                    _namn = value;
                    OnPropertyChanged(nameof(Namn));

                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName) //Metoden skickar en signal till UI att propertyt man skickar med (propertyname) har uppdateras
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Parentclass()
        {
            Namn = "Property1";
        }
    }
}

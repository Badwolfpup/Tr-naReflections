using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TränaReflections.Testklasser;

namespace TränaReflections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        string[] klassnamn = { "klass1", "klass2", "klass3"};

        private ObservableCollection<Parentclass> _lista;

        public ObservableCollection<Parentclass> lista
        {
            get { return _lista; }
            set
            {
                if (_lista != value)
                {
                    _lista = value;
                    OnPropertyChanged(nameof(lista));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            lista = new ObservableCollection<Parentclass>()
            {
                new Testklasser.Childclass.Klass1(), new Testklasser.Childclass.Klass2(), new Testklasser.Childclass.Klass3()
            };
        }

        protected virtual void OnPropertyChanged(string propertyName) //Metoden skickar en signal till UI att propertyt man skickar med (propertyname) har uppdateras
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
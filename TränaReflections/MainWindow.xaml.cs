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
using System.Reflection;
using TränaReflections.Testklasser;
using TränaReflections.Testklasser.Childclass;

namespace TränaReflections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        string[] klassnamn = { "Klass1", "Klass2", "Klass3"};

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
                new Klass1(), new Klass2(), new Klass3()
            };
            DataContext = this;

            
        }

        protected virtual void OnPropertyChanged(string propertyName) //Metoden skickar en signal till UI att propertyt man skickar med (propertyname) har uppdateras
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            string namn = klassnamn[r.Next(klassnamn.Length)];
            Type type = Type.GetType("TränaReflections.Testklasser.Childclass." + namn);
            if (type != null)
            {
                var p = (Parentclass)Activator.CreateInstance(type);
                lista.Add(p);
            }

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int x = r.Next(klassnamn.Length); //Så att vi vet vilken av klasserna vi ska uppdatera
            string namn = klassnamn[x];
            Type type = Type.GetType("TränaReflections.Testklasser.Childclass." + namn);

            //var o = (Parentclass)Activator.CreateInstance(type);
            var o = lista[x];
            PropertyInfo p = type.GetProperty("property1");
            if (p != null)
            {
                int temp = (int)p.GetValue(o);
                temp *= 10;
                p.SetValue(o, temp, null);
            }
            //if (o is Klass1)
            //{
            //    Klass1 klass1 = (Klass1)o;
            //    MessageBox.Show(klass1.property1.ToString());
            //} else if (o is Klass2)
            //{
            //    Klass2 klass2 = (Klass2)o;
            //    MessageBox.Show(klass2.property1.ToString());
            //} else
            //{
            //    Klass3 klass3 = (Klass3)o;
            //    MessageBox.Show(klass3.property1.ToString());
            //}
            
        }
    }
}
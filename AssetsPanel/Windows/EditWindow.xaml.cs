using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
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
using AssetsDb.Entity;
using AssetsPanel.Annotations;
using AssetsPanel.Utilities;

namespace AssetsPanel.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window, INotifyPropertyChanged
    {
        private ICommand _editLocation;
        public ICommand EditLocation => _editLocation ?? (_editLocation = new Command(p =>
        {
            if (p==null) return;
            Location location = p as Location;
            //Location clone = location.Clone();
            EditLocationWindow elw = new EditLocationWindow {DataContext = location};
            if (elw.ShowDialog() == true)
            {
                (App.Current as App).AssetsDb.SaveChanges();
                //Locations = null;
                //(App.Current as App).AssetsDb.Locations.Load();
                
            }
            (App.Current as App).AssetsDb.Entry(location).Reload();

            OnPropertyChanged(nameof(Locations));
        }));
        private ICommand _addLocation;
        public ICommand AddLocation => _addLocation ?? (_addLocation = new Command(p =>
        {
            Location location = new Location();
            
            EditLocationWindow elw = new EditLocationWindow { DataContext = location };
            if (elw.ShowDialog() == true)
            {
                (App.Current as App).AssetsDb.Locations.Add(location);
                (App.Current as App).AssetsDb.SaveChanges();
                (App.Current as App).AssetsDb.Locations.Load();
                Locations = (App.Current as App).AssetsDb.Locations.Local;
            }
            (App.Current as App).AssetsDb.Entry(location).Reload();
            OnPropertyChanged(nameof(Locations));

        }));

        private ObservableCollection<Location> _locations;
        public ObservableCollection<Location> Locations
        {
            get => _locations ?? (_locations = new ObservableCollection<Location>());
            set
            {
                _locations = value;
                OnPropertyChanged();
            }

        }
        public EditWindow()
        {
            
            InitializeComponent();
            (App.Current as App).AssetsDb.Locations.Load();
            Locations = (App.Current as App).AssetsDb.Locations.Local;
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        
    }
}

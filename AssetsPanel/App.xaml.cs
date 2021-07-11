using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using AssetsPanel.Annotations;
using AssetsDb;

namespace AssetsPanel
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        private AssetsDatabase _assetsDb;

        public AssetsDatabase AssetsDb
        {
            get => _assetsDb ?? (_assetsDb = new AssetsDatabase());
            set
            {
                _assetsDb = value;
                OnPropertyChanged();
            }
        }
        public NavigationService NavigationService { get; set; }
        public App()
        {
            //AssetsDb.Companies.Load();
            //AssetsDb.Assets.Load();
            //AssetsDb.Locations.Load();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            AssetsDb.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

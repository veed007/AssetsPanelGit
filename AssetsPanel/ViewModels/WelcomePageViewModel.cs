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
using System.Windows.Input;
using System.Windows.Navigation;
using AssetsDb.Entity;
using AssetsPanel.Annotations;
using AssetsPanel.Utilities;
using AssetsPanel.Views;


namespace AssetsPanel.ViewModels
{
    public class WelcomePageViewModel:INotifyPropertyChanged
    {

        #region fields
        
        private static WelcomePageViewModel _viewModel;
        private ICommand _selectCompany;
        private ObservableCollection<Company> _companies;
        
        #endregion

        #region props
        /// <summary>
        /// Single ViewModel
        /// </summary>
        public static WelcomePageViewModel ViewModel => _viewModel ?? (_viewModel = new WelcomePageViewModel());


        public ObservableCollection<Company> Companies
        {
            get
            {
                if (_companies == null)
                {
                     (App.Current as App).AssetsDb.Companies.Load();
                    _companies = (App.Current as App).AssetsDb.Companies.Local;
                }
                    
                return _companies;
            }
            set
            {
                _companies = value;
                OnPropertyChanged();
            }
            
        }

        #endregion

        #region Commands

        public ICommand SelectCompany => _selectCompany ?? (_selectCompany = new Command(p =>
        {
            if (p == null)
                return;
            Company company  = p as Company;
            AssetsPageViewModel.ViewModel.Company = company;
            (App.Current as App).NavigationService.Navigate(new AssetsPage());
        }));
        

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

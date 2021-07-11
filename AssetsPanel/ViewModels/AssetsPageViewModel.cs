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
using AssetsDb.Entity;
using AssetsPanel.Annotations;
using AssetsPanel.Utilities;
using AssetsPanel.Windows;

namespace AssetsPanel.ViewModels
{
    public class AssetsPageViewModel:INotifyPropertyChanged
    {
        #region fields

        private static AssetsPageViewModel _viewModel;
        private Company _company;
        private ObservableCollection<Asset> _assets;
        private ICommand _save;
        private ICommand _edit;
        private ICommand _add;
        private ICommand _delete;
        private Asset _selectedAsset;
        #endregion

        #region props
        
        public static AssetsPageViewModel ViewModel => _viewModel ?? (_viewModel = new AssetsPageViewModel());

        public ObservableCollection<Asset> Assets
        {
            get => _assets ?? (_assets = new ObservableCollection<Asset>());
            set
            {
                _assets = value;
                OnPropertyChanged();
            }
        }
        public Company Company
        {
            get => _company;
            set
            {
                _company = value;
                Assets = new ObservableCollection<Asset>(_company.Assets);
                OnPropertyChanged();
            }
        }

        public Asset SelectedAsset
        {
            get => _selectedAsset;
            set
            {
                _selectedAsset = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region commands

        public ICommand Save => _save ?? (_save = new Command(p =>
        {
            (App.Current as App).AssetsDb.SaveChanges();
        }));
        public ICommand Edit => _edit ?? (_edit = new Command(p =>
        {
            if (SelectedAsset==null)
            {
                MessageBox.Show("Выберите актив для редактирования");
                return;
            }
            Asset asset = SelectedAsset.Clone();

            EditWindow ew = new EditWindow{ DataContext = asset };
            
            if (ew.ShowDialog() == true)
            {
                SelectedAsset.Id = asset.Id;
                SelectedAsset.Name = asset.Name;
                SelectedAsset.Amount = asset.Amount;
                SelectedAsset.Additional = asset.Additional;
                SelectedAsset.IsMonetary = asset.IsMonetary;
                SelectedAsset.Assessed_val = asset.Assessed_val;
                SelectedAsset.Residual_val = asset.Residual_val;
                SelectedAsset.Unit = asset.Unit;
                SelectedAsset.Count = asset.Count;
                SelectedAsset.Currency = asset.Currency;
                SelectedAsset.LocationId = asset.LocationId;
                SelectedAsset.Location = asset.Location;
                (App.Current as App).AssetsDb.SaveChanges();
                Company = _company;
            }
                
            
            
        }));
        public ICommand Add => _add ?? (_add = new Command(p =>
        {
            Asset asset = new Asset{Company = _company};
            EditWindow ew = new EditWindow { DataContext = asset };
            if (ew.ShowDialog() == true)
            {
                (App.Current as App).AssetsDb.Assets.Add(asset);
                (App.Current as App).AssetsDb.SaveChanges();
                Company = _company;
            }
        }));
        public ICommand Delete => _delete ?? (_delete = new Command(p =>
        {
            if (SelectedAsset == null)
            {
                MessageBox.Show("Выберите актив для удаления");
                return;
            }
            (App.Current as App).AssetsDb.Assets.Remove(SelectedAsset);
            (App.Current as App).AssetsDb.SaveChanges();
            Company = _company;
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

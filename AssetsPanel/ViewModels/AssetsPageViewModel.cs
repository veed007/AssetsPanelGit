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
        private ICommand _changeType;
        private Asset _selectedAsset;
        private AssetType _assetType;
        private bool _gridTypeVisible;

        #endregion

        #region props

        public bool GridTypeVisible
        {
            get => _gridTypeVisible;
            set
            {
                _gridTypeVisible = value;
                OnPropertyChanged();
            }
        }

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

       
        public ICommand ChangeType => _changeType ?? (_changeType = new Command(p =>
        {
            if (p != null) _assetType = (AssetType)int.Parse(p.ToString());
        }));
        public ICommand Edit => _edit ?? (_edit = new Command(p =>
        {
            if (SelectedAsset==null)
            {
                MessageBox.Show("Выберите актив для редактирования");
                return;
            }
            //Asset asset = SelectedAsset.Clone();
            
            EditWindow ew = new EditWindow{ DataContext = new ObservableCollection<object> {SelectedAsset}};
            
            if (ew.ShowDialog() == true)
            {
                (App.Current as App).AssetsDb.SaveChanges();
                
            }
            (App.Current as App).AssetsDb.Entry(SelectedAsset).Reload();
            Company = _company;
        }));
        public ICommand Add => _add ?? (_add = new Command(p =>
        {
            if (!GridTypeVisible)
            {
                GridTypeVisible = true;
                return;
            }
            Asset asset;
            switch (_assetType)
            {
                case AssetType.Asset: asset = new Asset {Company = _company}; break;
                case AssetType.MovablesAsset: asset = new MovablesAsset { Company = _company }; break;
                case AssetType.ImmovablesAsset: asset = new ImmovableAsset() { Company = _company }; break;
                default: return;
            }
            
            EditWindow ew = new EditWindow { DataContext = new ObservableCollection<object>{asset} };
            if (ew.ShowDialog() == true)
            {
                (App.Current as App).AssetsDb.Assets.Add(asset);
                (App.Current as App).AssetsDb.SaveChanges();
                Company = _company;
            }

            GridTypeVisible = false;
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

        public enum AssetType
        {
            Asset,
            ImmovablesAsset,
            MovablesAsset
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.View;
using Ninja.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ninja.Domain;
using System.Windows;

namespace Ninja.ViewModel
{
    public class NinjaListViewModel : ViewModelBase
    {
        private AddNinjaWindow _addNinjaWindow;
       // private CategoryListViewModel _shopViewModel;

        NinjaRepository ninjaRepository;

        public ObservableCollection<NinjaViewModel> Ninjas
        {
            get;
            set;
        }

        public ObservableCollection<GearViewModel> NinjasGear
        {
            get;
            set;
        }

        private NinjaViewModel _selectedNinja;

        public NinjaViewModel SelectedNinja
        {
            get
            {
                return _selectedNinja;
            }
            set
            {
                _selectedNinja = value;
                if (_selectedNinja != null)
                {
                    var ninjasGear = _selectedNinja.Gears.Select(s => new GearViewModel(s));
                    NinjasGear.Clear();
                    TotalStrength = 0;
                    TotalAgility = 0;
                    TotalIntelligence = 0;
                    foreach (GearViewModel g in ninjasGear)
                    {
                        NinjasGear.Add(g);
                        TotalStrength = TotalStrength + g.Strength ?? default(int);
                        TotalAgility = TotalAgility + g.Agility ?? default(int);
                        TotalIntelligence = TotalIntelligence + g.Intelligence ?? default(int);
                    }
                }
                else
                {
                    TotalStrength = 0;
                    TotalAgility = 0;
                    TotalIntelligence = 0;
                }

                base.RaisePropertyChanged();
            }
        }

        private GearViewModel _selectedGear;

        public GearViewModel SelectedGear
        {
            get
            {
                return _selectedGear;
            }
            set
            {
                _selectedGear = value;
                base.RaisePropertyChanged();
            }
        }

        private int _totalStrength;
        public int TotalStrength
        {
            get
            {
                return _totalStrength;
            }
            set
            {
                _totalStrength = value;
                base.RaisePropertyChanged();
            }
        }

        private int _totalAgility;
        public int TotalAgility
        {
            get
            {
                return _totalAgility;
            }
            set
            {
                _totalAgility = value;
                base.RaisePropertyChanged();
            }
        }

        private int _totalIntelligence;
        public int TotalIntelligence
        {
            get
            {
                return _totalIntelligence;
            }
            set
            {
                _totalIntelligence = value;
                base.RaisePropertyChanged();
            }
        }

        //Commands
        public ICommand ShowAddNinjaCommand
        {
            get; set;
        }
        public ICommand ShowViewNinjaCommand
        {
            get; set;
        }
        public ICommand DeleteNinjaCommand
        {
            get; set;
        }
        public ICommand ShowShopCommand
        {
            get; set;
        }
        public ICommand SellGearCommand
        {
            get; set;
        }

        public NinjaListViewModel()
        {
           // _shopViewModel = shopViewModel;
            ninjaRepository = new NinjaRepository();
            var ninjaList = ninjaRepository.GetNinjas().Select(s => new NinjaViewModel(s));
            Ninjas = new ObservableCollection<NinjaViewModel>(ninjaList);
            NinjasGear = new ObservableCollection<GearViewModel>();

            ShowAddNinjaCommand = new RelayCommand(ShowAddNinja, CanShowAddNinja);
            DeleteNinjaCommand = new RelayCommand(DeleteNinja);
            ShowViewNinjaCommand = new RelayCommand(ShowViewNinja);
            ShowShopCommand = new RelayCommand(ShowShop);
            SellGearCommand = new RelayCommand(SellGear);
        }

        public void ShowViewNinja()
        {
            var viewNinja = new ViewNinjaWindow();
            viewNinja.Show();
        }

        public void ShowShop()
        {
            var showShop = new ShopWindow();
            showShop.Show();
        }

        public void ShowAddNinja()
        {
            _addNinjaWindow = new AddNinjaWindow();
            _addNinjaWindow.Show();
        }

        public bool CanShowAddNinja()
        {
            return _addNinjaWindow != null ? !_addNinjaWindow.IsVisible : true;
        }

        public void HideAddNinja()
        {
            _addNinjaWindow.Close();
        }

        private void DeleteNinja()
        {
            ninjaRepository.RemoveNinja(SelectedNinja);
            Ninjas.Remove(SelectedNinja);
        }

        private void SellGear()
        {
            if (SelectedGear != null)
            {
                ninjaRepository.RemoveGearFromNinja(SelectedNinja, SelectedGear);
                SelectedNinja.Gold = SelectedNinja.Gold + SelectedGear.GoldValue;
                TotalStrength = TotalStrength - SelectedGear.Strength ?? default(int);
                TotalAgility = TotalAgility - SelectedGear.Agility ?? default(int);
                TotalIntelligence = TotalIntelligence - SelectedGear.Intelligence ?? default(int);
                NinjasGear.Remove(SelectedGear);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("No gear selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }              
        }
    }
}

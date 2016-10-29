using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ninja.Domain;
using Ninja.Model;
using Ninja.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ninja.ViewModel
{
    public class CategoryListViewModel : ViewModelBase
    {
        private CategoryRepository _categoryRepository;
        private GearRepository _gearRepository;
        private NinjaRepository _ninjaRepository;

        private NinjaListViewModel _ninjaListViewModel;

        private AddGearWindow _addGearWindow;
        private EditGearWindow _editGearWindow;

        public ObservableCollection<CategoryViewModel> Categories
        {
            get; set;
        }

        public ObservableCollection<GearViewModel> Gears
        {
            get; set;
        }

        private CategoryViewModel _selectedCategory;

        public CategoryViewModel SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                Gears.Clear();
                foreach (Gear gear in _selectedCategory.Gears)
                {
                    Gears.Add(new GearViewModel(gear));
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

        public NinjaViewModel SelectedNinja
        {
            get
            {
                return _ninjaListViewModel.SelectedNinja;
            }
            set
            {
                _ninjaListViewModel.SelectedNinja = value;
                base.RaisePropertyChanged();
            }
        }

        public ICommand ShowAddGearCommand
        {
            get; set;
        }
        public ICommand ShowEditGearCommand
        {
            get; set;
        }
        public ICommand DeleteGearCommand
        {
            get; set;
        }
        public ICommand BuyGearCommand
        {
            get; set;
        }

        public CategoryListViewModel(NinjaListViewModel ninjaListViewModel)
        {
            _categoryRepository = new CategoryRepository();
            _gearRepository = new GearRepository();
            _ninjaRepository = new NinjaRepository();
            _ninjaListViewModel = ninjaListViewModel;
            var categories = _categoryRepository.GetCategories().Select(s => new CategoryViewModel(s));
            Categories = new ObservableCollection<CategoryViewModel>(categories);
            Gears = new ObservableCollection<GearViewModel>();

            ShowAddGearCommand = new RelayCommand(ShowAddGear, CanShowAddGear);
            ShowEditGearCommand = new RelayCommand(ShowEditGear, CanShowEditGear);
            DeleteGearCommand = new RelayCommand(DeleteGear);
            BuyGearCommand = new RelayCommand(BuyGear);
        }

        public void ShowAddGear()
        {
            _addGearWindow = new AddGearWindow();
            _addGearWindow.Show();
        }

        public bool CanShowAddGear()
        {
            return _addGearWindow != null ? !_addGearWindow.IsVisible : true;
        }

        public void HideAddGear()
        {
            _addGearWindow.Close();
        }

        public void ShowEditGear()
        {
            if (_selectedGear != null)
            {
                _editGearWindow = new EditGearWindow();
                _editGearWindow.Show();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("No Gear Selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool CanShowEditGear()
        {
            return _editGearWindow != null ? !_editGearWindow.IsVisible : true;
        }

        public void HideEditGear()
        {
            _editGearWindow.Close();
        }

        private void DeleteGear()
        {
            if (SelectedGear != null)
            {
                _gearRepository.RemoveGear(SelectedGear);
                foreach (Gear gear in SelectedCategory.Gears.ToList<Gear>())
                {
                    if (gear.Id == _selectedGear.Id)
                    {
                        _selectedCategory.Gears.Remove(gear);
                    }
                }
                _ninjaListViewModel.NinjasGear.Remove(SelectedGear);
                Gears.Remove(SelectedGear);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("No Gear Selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BuyGear()
        {
            if (SelectedGear != null)
            {
                bool canbuy = true;
                foreach (GearViewModel g in _ninjaListViewModel.NinjasGear)
                {
                    if (g.CategoryId == SelectedGear.CategoryId)
                        canbuy = false;
                }
                if (canbuy && SelectedNinja.Gold >= SelectedGear.GoldValue)
                {
                    _ninjaRepository.BuyGear(SelectedNinja, SelectedGear);
                    SelectedNinja.Gold = SelectedNinja.Gold - SelectedGear.GoldValue;
                    _ninjaListViewModel.NinjasGear.Add(SelectedGear);
                    _ninjaListViewModel.TotalStrength = _ninjaListViewModel.TotalStrength + SelectedGear.Strength ?? default(int);
                    _ninjaListViewModel.TotalAgility = _ninjaListViewModel.TotalAgility + SelectedGear.Agility ?? default(int);
                    _ninjaListViewModel.TotalIntelligence = _ninjaListViewModel.TotalIntelligence + SelectedGear.Intelligence ?? default(int);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("You already have some gear from this category", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("No Gear Selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

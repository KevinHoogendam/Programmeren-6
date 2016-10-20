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

        public CategoryListViewModel()
        {
            _categoryRepository = new CategoryRepository();
            _gearRepository = new GearRepository();
            _ninjaRepository = new NinjaRepository();
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
            _gearRepository.RemoveGear(SelectedGear);
            Gears.Remove(SelectedGear);
        }

        private void BuyGear()
        {
            _ninjaRepository.BuyGear(SelectedNinja, SelectedGear);
            Gears.Remove(SelectedGear);
        }
    }
}

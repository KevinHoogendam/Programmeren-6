using GalaSoft.MvvmLight.Command;
using Ninja.Model;
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
    public class EditGearViewModel
    {
        private CategoryListViewModel _categoryList;
        private GearRepository _repo;

        public ObservableCollection<CategoryViewModel> Categories
        {
            get;
            set;
        }

        public GearViewModel Gear
        {
            get; set;
        }

        public ICommand EditGearCommand
        {
            get; set;
        }

        public EditGearViewModel(CategoryListViewModel categoryList)
        {
            this._categoryList = categoryList;
            if (categoryList.SelectedGear != null)
            {
                this.Gear = _categoryList.SelectedGear;
                this._repo = new GearRepository();
                Categories = _categoryList.Categories;
                EditGearCommand = new RelayCommand(EditGear, CanEditGear);
            }
        }

        private void EditGear()
        {
            if (Gear.Intelligence != null && Gear.Strength != null && Gear.Agility != null && Gear.Name != null && Gear.Name.Replace(" ", "") != String.Empty)
            {
                _repo.EditGear(Gear);

                foreach (GearViewModel g in _categoryList.Gears)
                {
                    if (g.Id == Gear.Id)
                    {
                        _categoryList.Gears.Remove(g);
                        break;
                    }
                }
                _categoryList.Gears.Add(Gear);
                _categoryList.HideEditGear();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Please fill in all fields correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public bool CanEditGear()
        {
            return true;
        }
    }
}

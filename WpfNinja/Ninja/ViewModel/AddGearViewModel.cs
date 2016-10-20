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
    public class AddGearViewModel
    {
        private CategoryListViewModel _categoryList;
        private GearRepository _GearRepo;
        private CategoryRepository _catRepo;

        public ObservableCollection<CategoryViewModel> Categories
        {
            get;
            set;
        }

        public GearViewModel Gear
        {
            get; set;
        }

        //public int CategoryId
        //{  
        //    set
        //    {
        //        Gear.CategoryId = value;
        //        Gear.Category = _catRepo.GetCategoryById(value);
        //    }
        //}

        public ICommand AddGearCommand
        {
            get; set;
        }

        public AddGearViewModel(CategoryListViewModel categoryList)
        {
            this._categoryList = categoryList;
            this.Gear = new GearViewModel();
            this._GearRepo = new GearRepository();
            this._catRepo = new CategoryRepository();
            Categories = _categoryList.Categories;
            AddGearCommand = new RelayCommand(AddGear, CanAddGear);
        }

        private void AddGear()
        {

            if (Gear.Intelligence != null && Gear.Strength != null && Gear.Agility != null && Gear.Name != null && Gear.Name.Replace(" ", "") != String.Empty)
            {
                _GearRepo.AddGear(Gear);
                _categoryList.Gears.Add(Gear);
                _categoryList.HideAddGear();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Please fill in all fields correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool CanAddGear()
        {
            return true;
        }
    }
}

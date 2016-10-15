using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Ninja.Model;
using Ninja.ViewModel;

namespace Ninja.ViewModel
{
    public class CategoryListViewModel : ViewModelBase
    {
        CategoryRepository categoryRepository;

        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        private CategoryViewModel _selectedCategory;

        public CategoryViewModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                base.RaisePropertyChanged();
            }
        }

        public CategoryListViewModel()
        {
            categoryRepository = new CategoryRepository();
            var categories = categoryRepository.GetCategories().Select(s => new CategoryViewModel(s));
            Categories = new ObservableCollection<CategoryViewModel>(categories);
        }
    }
}
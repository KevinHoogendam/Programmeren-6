using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Ninja.ViewModel
{
    public class CategoryViewModel : ViewModelBase
    {
       private Category _category;

        public CategoryViewModel()
        {
            this._category = new Category();
        }

        public CategoryViewModel(Category category)
        {
            this._category = category;
        }

        public int Id
        {
            get { return _category.Id; }
            set { _category.Id = value; RaisePropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _category.Name; }
            set { _category.Name = value; RaisePropertyChanged("Name"); }           
        }

       // public ICollection<Gear> Gears
       // {
        //    get { return _category.Gears; }
         //   set {_category.Gears = value; RaisePropertyChanged("Gears");}
        //}

        
    }
}

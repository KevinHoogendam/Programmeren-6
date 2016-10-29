using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja.ViewModel
{
    public class NinjaViewModel : ViewModelBase
    {
        public int Id
        {
            get
            {
                return _ninja.Id;
            }
            set
            {
                _ninja.Id = value;
                RaisePropertyChanged("Id");
            }
        }


        public string Name
        {
            get
            {
                return _ninja.Name;
            }
            set
            {
                _ninja.Name = value;
                RaisePropertyChanged("Name");
            }
        }


        public int? Gold
        {
            get
            {
                return _ninja.Gold;
            }
            set
            {
                _ninja.Gold = value;
                RaisePropertyChanged("Gold");
            }
        }

        public ICollection<Domain.Gear> Gears
        {
            get
            {
                return _ninja.Gears;
            }
            set
            {
                _ninja.Gears = value;
                RaisePropertyChanged("Id");
            }
        }

        private Domain.Ninja _ninja;

        public NinjaViewModel()
        {
            this._ninja = new Domain.Ninja();
        }

        public NinjaViewModel(Domain.Ninja ninja)
        {
            this._ninja = ninja;
        }
    }
}
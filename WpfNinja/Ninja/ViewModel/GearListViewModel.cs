using GalaSoft.MvvmLight;
using Ninja.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja.ViewModel
{
    public class GearListViewModel : ViewModelBase
    {
        GearRepository gearRepository;

        public ObservableCollection<GearViewModel> Gears { get; set; }

        private GearViewModel _selectedGear;

        public GearViewModel SelectedGear
        {
            get { return _selectedGear; }
            set
            {
                _selectedGear = value;
                base.RaisePropertyChanged();
            }
        }

        public GearListViewModel()
        {
            gearRepository = new GearRepository();
            var gears = gearRepository.GetGears().Select(s => new GearViewModel(s));
            Gears = new ObservableCollection<GearViewModel>(gears);
        }
    }
}

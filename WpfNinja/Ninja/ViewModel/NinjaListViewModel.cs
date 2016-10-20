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

namespace Ninja.ViewModel
{
    public class NinjaListViewModel : ViewModelBase
    {
        private AddNinjaWindow _addNinjaWindow;
        private CategoryListViewModel _shopViewModel;

        NinjaRepository ninjaRepository;

        public ObservableCollection<NinjaViewModel> Ninjas
        {
            get;
            set;
        }

        //Dit model heeft de waarde van het liedje dat geselecteerd is. 
        //Misschien kun je dit model wel gebruiken voor de opdracht?
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
                _shopViewModel.SelectedNinja = value;
                base.RaisePropertyChanged();
            }
        }

        private Gear _selectedGear;

        public Gear SelectedGear
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

        public NinjaListViewModel(CategoryListViewModel shopViewModel)
        {
            _shopViewModel = shopViewModel;
            ninjaRepository = new NinjaRepository();
            var ninjaList = ninjaRepository.GetNinjas().Select(s => new NinjaViewModel(s));
            Ninjas = new ObservableCollection<NinjaViewModel>(ninjaList);

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
            ninjaRepository.RemoveGearFromNinja(SelectedNinja, SelectedGear);
            //SelectedNinja.Gears.Remove(SelectedGear);
        }
    }
}

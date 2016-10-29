using GalaSoft.MvvmLight.Command;
using Ninja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ninja.ViewModel
{
    public class AddNinjaViewModel
    {
        private NinjaListViewModel _ninjaList;
        private NinjaRepository _repo;

        public NinjaViewModel Ninja
        {
            get; set;
        }

        public ICommand AddNinjaCommand
        {
            get; set;
        }

        public AddNinjaViewModel(NinjaListViewModel ninjaList)
        {
            this._ninjaList = ninjaList;
            this.Ninja = new NinjaViewModel();
            this._repo = new NinjaRepository();
            AddNinjaCommand = new RelayCommand(AddNinja, CanAddNinja);
        }

        private void AddNinja()
        {
            if (Ninja.Gold != null && Ninja.Name != null && Ninja.Name.Replace(" ", "") != string.Empty)
            {
                _repo.AddNinja(Ninja);
                _ninjaList.Ninjas.Add(Ninja);
                _ninjaList.HideAddNinja();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Please fill in all fields correctly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool CanAddNinja()
        {
            return true;
        }
    }
}

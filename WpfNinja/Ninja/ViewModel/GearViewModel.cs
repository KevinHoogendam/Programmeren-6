﻿using GalaSoft.MvvmLight;
using Ninja.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja.ViewModel
{
    public class GearViewModel : ViewModelBase
    {
        private Gear _gear;

        public GearViewModel()
        {
            this._gear = new Gear();
        }

        public GearViewModel(Gear gear)
        {
            this._gear = gear;
        }

        public int Id
        {
            get { return _gear.Id; }
            set { _gear.Id = value; RaisePropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _gear.Name; }
            set { _gear.Name = value; RaisePropertyChanged("Name"); }           
        }

        public int? Agility
        {
            get { return _gear.agility; }
            set { _gear.agility = value; RaisePropertyChanged("Agility"); }
        }

        public int? Intelligence
        {
            get { return _gear.Intelligence; }
            set { _gear.Intelligence = value; RaisePropertyChanged("Intelligence"); }
        }

        public int? Strength
        {
            get { return _gear.Strength; }
            set { _gear.Strength = value; RaisePropertyChanged("Strength"); }
        }
    }
}

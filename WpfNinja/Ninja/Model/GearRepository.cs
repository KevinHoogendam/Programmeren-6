using Ninja.Domain;
using Ninja.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja.Model
{
    class GearRepository
    {
        public void AddGear(GearViewModel g)
        {
            using (var context = new NinjaDbEntities())
            {
                Gear gear = new Gear();
                foreach (Gear x in context.Gears)
                {
                    if (x.Id >= gear.Id)
                    {
                        gear.Id = x.Id + 1;
                    }
                }
                gear.Name = g.Name;
                gear.GoldValue = g.GoldValue;
                gear.CategoryId = g.CategoryId;
                gear.Strength = g.Strength;
                gear.Intelligence = g.Intelligence;
                gear.Agility = g.Agility;
                context.Gears.Add(gear);
                context.SaveChanges();
            }
        }

        public void EditGear(GearViewModel g)
        {
            using (var context = new NinjaDbEntities())
            {
                foreach (Gear oldGear in context.Gears)
                {
                    if (oldGear.Id == g.Id)
                    {
                        context.Gears.Remove(oldGear);
                        break;
                    }
                }

                Gear gear = new Gear();
                gear.Id = g.Id;
                gear.Name = g.Name;
                gear.GoldValue = g.GoldValue;
                gear.CategoryId = g.CategoryId;
                gear.Strength = g.Strength;
                gear.Intelligence = g.Intelligence;
                gear.Agility = g.Agility;
                context.Gears.Add(gear);
                context.SaveChanges();
            }
        }

        public void RemoveGear(GearViewModel g)
        {
            using (var context = new NinjaDbEntities())
            {
                foreach (Gear gear in context.Gears)
                {
                    if (gear.Id == g.Id)
                    {
                        gear.Ninjas.Clear();
                        context.Gears.Remove(gear);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}

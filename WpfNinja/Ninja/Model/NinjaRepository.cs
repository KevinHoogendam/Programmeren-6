using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.Domain;
using System.Collections.ObjectModel;
using Ninja.ViewModel;

namespace Ninja.Model
{
    class NinjaRepository
    {
        public List<Domain.Ninja> GetNinjas()
        {
            List<Domain.Ninja> ninjas = new List<Domain.Ninja>();
            using (var context = new NinjaDbEntities())
            {
                ninjas = context.Ninjas.Include("Gears").ToList();
            }
            return ninjas;
        }

        public void AddNinja(NinjaViewModel n)
        {
            using (var context = new NinjaDbEntities())
            {
                Domain.Ninja ninja = new Domain.Ninja();
                ninja.Id = n.Id;
                ninja.Name = n.Name;
                ninja.Gold = n.Gold;
                ninja.Gears = n.Gears;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }

        public void RemoveNinja(NinjaViewModel n)
        {
            using (var context = new NinjaDbEntities())
            {
                foreach (Domain.Ninja ninja in context.Ninjas)
                {
                    if (ninja.Id == n.Id)
                    {
                        context.Ninjas.Remove(ninja);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }
        public void RemoveGearFromNinja(NinjaViewModel n, Gear g)
        {
            using (var context = new NinjaDbEntities())
            {
                foreach (Domain.Ninja ninja in context.Ninjas)
                {
                    if (n.Id == ninja.Id)
                    {
                        foreach (Gear gear in ninja.Gears)
                        {
                            if (gear.Id == g.Id)
                            {
                                ninja.Gold = ninja.Gold + gear.GoldValue;
                                ninja.Gears.Remove(gear);
                                break;
                            }
                        }
                    }
                }

                context.SaveChanges();
            }
        }

        public void BuyGear(NinjaViewModel n, GearViewModel g)
        {
            using (var context = new NinjaDbEntities())
            {
                foreach (Domain.Ninja ninja in context.Ninjas)
                {
                    if (n.Id == ninja.Id)
                    {
                        foreach (Gear gear in context.Gears)
                        {
                            if (gear.Id == g.Id)
                            {
                                ninja.Gold = ninja.Gold - gear.GoldValue;
                                ninja.Gears.Add(gear);
                                break;
                            }
                        }
                    }
                }

                context.SaveChanges();
            }
        }
    }
}

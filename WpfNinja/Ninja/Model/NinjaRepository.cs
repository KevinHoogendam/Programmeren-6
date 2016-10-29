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
                foreach (Domain.Ninja x in context.Ninjas)
                {
                    if (x.Id >= ninja.Id)
                    {
                        ninja.Id = x.Id + 1;
                    }
                }
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
                        ninja.Gears.Clear();
                        context.Ninjas.Remove(ninja);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }
        public void RemoveGearFromNinja(NinjaViewModel n, GearViewModel g)
        {
            if (n != null && g != null)
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
        public Domain.Ninja GetNinjaById(int id)
        {
            using (var context = new NinjaDbEntities())
            {
                foreach (Domain.Ninja n in context.Ninjas.Include("Gears"))
                {
                    if (n.Id == id)
                    {
                        return n;
                    }
                }
            }
            return null;
        }
    }
}

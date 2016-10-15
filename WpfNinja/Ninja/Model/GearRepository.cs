using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.Domain;

namespace Ninja.Model
{
    class GearRepository
    {
        public List<Gear> GetGears()
        {
            List<Gear> gears = new List<Gear>();
            using (var context = new NinjaDbEntities())
            {
                gears = context.Gears.ToList();
            }
            return gears;
        }
    }
}

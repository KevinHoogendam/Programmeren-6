using Ninja.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja.Model
{
    class CategoryRepository
    {
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (var context = new NinjaDbEntities())
            {
                categories = context.Categories.ToList();
            }
            return categories;
        }
    }
}

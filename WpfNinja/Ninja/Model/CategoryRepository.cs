using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninja.Domain;

namespace Ninja.Model
{
    class CategoryRepository
    {
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (var context = new NinjaDbEntities())
            {
                categories = context.Categories.Include("Gears").ToList();
            }
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            Category cat = null;
            using (var context = new NinjaDbEntities())
            {
                foreach (Category c in context.Categories)
                {
                    if (c.Id == id)
                    {
                        cat = c;
                    }
                }
            }
            return cat;
        }
    }
}

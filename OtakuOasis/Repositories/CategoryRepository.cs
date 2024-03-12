using DAL.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtakuOasis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtakuOasis.Repositories
{
    public class CategoryRepository :  ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context) 
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAllCategories() => context.Category.ToList();
        

        public IEnumerable<SelectListItem> GetSelectList()
        {
           return  GetAllCategories().
                  Select(c => new SelectListItem
                  {
                      Value = c.Id.ToString(),
                      Text = c.Name,
                  })
                  .OrderBy(c => c.Text)
                  .ToList();
        }
    }
}

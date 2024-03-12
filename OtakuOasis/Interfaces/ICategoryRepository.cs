using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace OtakuOasis.Interfaces
{
    public interface ICategoryRepository 
    {
        public IEnumerable<SelectListItem> GetSelectList();
        public IEnumerable<Category> GetAllCategories();   
    }
}

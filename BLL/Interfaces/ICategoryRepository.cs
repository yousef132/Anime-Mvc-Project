using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BLL.Interfaces
{
    public interface ICategoryRepository :IGenericRepository<Category>
    {
        //IEnumerable<SelectListItem> GetSelectList();
    }
}

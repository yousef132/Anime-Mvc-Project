using DAL.Entities;
using OtakuOasis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		public void Add(T Entity);
		public void Update(T Entity);
		public void Delete(T Entity);
		public T GetById(int id);
		public ICollection<T> GetAll();
	}
}

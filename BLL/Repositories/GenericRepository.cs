using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly AppDbContext context;

		public GenericRepository(AppDbContext context)
		{
			this.context = context;
		}
		public void Add(T Entity) => context.Set<T>().Add(Entity);

		public void Delete(T Entity) => context.Set<T>().Remove(Entity);

		public ICollection<T> GetAll() => context.Set<T>().ToList();


		public T GetById(int id) => context.Set<T>().Find(id);


		public void Update(T Entity) => context.Set<T>().Update(Entity);

	}
}
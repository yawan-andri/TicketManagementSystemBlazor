using Domain.Repository;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		internal readonly AppDbContext dbContext;

		public GenericRepository(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public T GetByIdAsync(int id)
		{
			return dbContext.Set<T>().Find(id);
		}

		public List<T> ListAll()
		{
			return dbContext.Set<T>().ToList();
		}

		public void Add(T entity)
		{
			dbContext.Set<T>().Add(entity);
		}

		public void Update(T entity)
		{
			dbContext.Set<T>().Attach(entity);
			dbContext.Entry(entity).State = EntityState.Modified;
		}

		public void Delete(T entity)
		{
			dbContext.Set<T>().Remove(entity);
		}

		public void SaveChanges()
		{
			dbContext.SaveChanges();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api.Libraries.Infrastructure.EntityFramework
{
	public abstract class BaseRepository<T, TId> : IRepository<T, TId>
		where T : class
	{
		public DbSet<T> DbSet { get; }

		protected BaseRepository(DbSet<T> dbSet)
		{
			DbSet = dbSet;
		}

		public virtual async ValueTask<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
			=> await DbSet.ToListAsync(cancellationToken);

		public virtual T GetById(TId id)
			=> DbSet.Find(id);

		public virtual ValueTask<T> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
			=> DbSet.FindAsync(id, cancellationToken);

		public abstract Task<bool> ExistsByIdAsync(TId id, CancellationToken cancellationToken = default);

		public virtual EntityEntry<T> Add(T item)
			=> DbSet.Add(item);

		public virtual ValueTask<EntityEntry<T>> AddAsync(T item, CancellationToken cancellationToken = default)
			=> DbSet.AddAsync(item, cancellationToken);

		public virtual EntityEntry<T> Update(T item)
			=> DbSet.Update(item);

		public virtual EntityEntry<T> Delete(T item)
			=> DbSet.Remove(item);

		public abstract int SaveChanges();
		public abstract Task SaveChangesAsync(CancellationToken cancellationToken = default);

		public virtual async Task ExecuteDefaultAsync(TId id, Action<T> action, CancellationToken cancellationToken = default)
		{
			var entity = await GetByIdAsync(id, cancellationToken);
			action(entity);
			Update(entity);
			await SaveChangesAsync(cancellationToken);
		}
	}
}

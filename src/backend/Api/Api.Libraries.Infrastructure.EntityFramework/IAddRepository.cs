using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api.Libraries.Infrastructure.EntityFramework
{
	public interface IAddRepository<T> : IWriteableRepository
		where T : class
	{
		EntityEntry<T> Add(T item);
		ValueTask<EntityEntry<T>> AddAsync(T item, CancellationToken cancellationToken = default);
	}
}

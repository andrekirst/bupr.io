using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api.Libraries.Infrastructure.EntityFramework
{
	public interface IDeleteRepository<T> : IWriteableRepository
		where T : class
	{
		EntityEntry<T> Delete(T item);
	}
}

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api.Libraries.Infrastructure.EntityFramework
{
	public interface IUpdateRepository<T> : IWriteableRepository
		where T : class
	{
		EntityEntry<T> Update(T item);
	}
}

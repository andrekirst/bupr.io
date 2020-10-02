using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Libraries.Infrastructure.EntityFramework
{
	public interface IRepository<T, in TId> :
		IGetRepository<T, TId>,
		IAddRepository<T>,
		IUpdateRepository<T>,
		IDeleteRepository<T>
		where T : class
	{
		Task ExecuteDefaultAsync(TId id, Action<T> action, CancellationToken cancellationToken = default);
	}
}

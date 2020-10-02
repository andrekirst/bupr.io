using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Libraries.Infrastructure.EntityFramework
{
	public interface IGetRepository<T, in TId>
	{
		ValueTask<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
		T GetById(TId id);
		ValueTask<T> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
		Task<bool> ExistsByIdAsync(TId id, CancellationToken cancellationToken = default);
	}
}

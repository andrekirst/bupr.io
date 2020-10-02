using System.Threading;
using System.Threading.Tasks;

namespace Api.Libraries.Infrastructure.EntityFramework
{
	public interface IWriteableRepository
	{
		Task SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}

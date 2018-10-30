using System.Threading.Tasks;
using Ordering.Domain.Model;

namespace Ordering.Domain.Repositories
{
    public interface IOderRepository
    {
        Task GetAsync(Order order);
        Task InsertAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
    }
}

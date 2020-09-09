using System.Threading.Tasks;

namespace Domain.Services.Contracts
{
    public interface IService<T>
    {
        Task AddAsync(T item);
        Task RemoveAsync(int itemId);
        Task UpdateAsync(int itemId, T newItem);
        T Get(int itemId);
    }
}
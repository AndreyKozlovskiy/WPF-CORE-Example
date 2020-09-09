using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Domain.Contexts
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class;
        Task SaveChangesAsync();
    }
}
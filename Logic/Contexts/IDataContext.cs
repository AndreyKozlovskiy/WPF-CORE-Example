using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Logic.Contexts
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class;
        Task SaveChangesAsync();
    }
}

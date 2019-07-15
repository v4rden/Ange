namespace Ange.Application.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAngeDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
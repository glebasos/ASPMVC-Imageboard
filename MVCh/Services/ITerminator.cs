using MVCh.Data;

namespace MVCh.Services
{
    public interface ITerminator
    {
        Task DeleteThreadCascadeAsync(int threadId, ChanDbContext context);
    }
}

using System.Threading.Tasks;
using es;

namespace api.snapshot.Services 
{
    public interface ISnapshotUpdateService 
    {
        Task Update(EventPayload evnt);
    }
}
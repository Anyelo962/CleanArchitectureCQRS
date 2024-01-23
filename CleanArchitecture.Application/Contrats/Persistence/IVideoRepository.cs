using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contrats.Persistence;

public interface IVideoRepository: IAsyncRepository<Video>
{
    Task<Video> GetVideoByName(string name);
    Task<IEnumerable<Video>> GetvideoByUserName(string username);
}
using MediatR;

namespace CleanArchitecture.Application.Feactures.Videos.Queries.GetVideoList;

public class GetVideoListQuery: IRequest<List<VideosVm>>
{
    public string UserName { get; set; } = String.Empty;

    public GetVideoListQuery(string userName)
    {
        this.UserName = userName ?? throw new ArgumentNullException(nameof(userName));
    }
    
}
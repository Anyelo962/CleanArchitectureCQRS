using AutoMapper;
using CleanArchitecture.Application.Contrats.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Feactures.Videos.Queries.GetVideoList;

public class GetVideoListQueryHandler: IRequestHandler<GetVideoListQuery, List<VideosVm>>
{
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;

    public GetVideoListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
    {
        this._videoRepository = videoRepository;
        this._mapper = mapper;
    }
    
    public async Task<List<VideosVm>> Handle(GetVideoListQuery request, CancellationToken cancellationToken)
    {
        var videoList = await this._videoRepository.GetvideoByUserName(request.UserName);

        return this._mapper.Map<List<VideosVm>>(videoList);
    }
}
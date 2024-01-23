using AutoMapper;
using CleanArchitecture.Application.Feactures.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Feactures.Videos.Queries.GetVideoList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Video, VideosVm>().ReverseMap();
        CreateMap<CreateStreamerCommand, Streamer>();
    }
}
using MediatR;

namespace CleanArchitecture.Application.Feactures.Streamers.Commands.DeleteStreamer;

public class DeleteStreamerCommand:IRequest
{
    public int Id { get; set; }
}
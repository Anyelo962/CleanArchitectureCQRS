using MediatR;

namespace CleanArchitecture.Application.Feactures.Streamers.Commands.UpdateStreamer;

public class UpdateStreamerCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = String.Empty;
}
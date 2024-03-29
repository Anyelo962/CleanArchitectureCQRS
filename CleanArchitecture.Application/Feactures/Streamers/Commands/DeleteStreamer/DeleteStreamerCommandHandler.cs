using AutoMapper;
using CleanArchitecture.Application.Contrats.Persistence;
using CleanArchitecture.Application.Exception;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Feactures.Streamers.Commands.DeleteStreamer;

public class DeleteStreamerCommandHandler: IRequestHandler<DeleteStreamerCommand>
{
    private readonly IStreamerRepository _streamerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteStreamerCommandHandler> _logger;


    public DeleteStreamerCommandHandler(IStreamerRepository streamerRepository, 
        IMapper mapper, ILogger<DeleteStreamerCommandHandler> logger)
    {
        _streamerRepository = streamerRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
    {
        var streamerToDelete = await _streamerRepository.GetById(request.Id);

        if (streamerToDelete == null)
        {
            _logger.LogError($"{request.Id} streamer no existe en el sistema");
            throw new NotFoundException(
                nameof(Streamer), request.Id);
        }
        
       await _streamerRepository.DeleteAsync(streamerToDelete);
        
      _logger.LogInformation($"{request.Id} streamer fue eliminado con exito.");

        
        return Unit.Value;
    }
}
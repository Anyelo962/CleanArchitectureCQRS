using AutoMapper;
using CleanArchitecture.Application.Contrats.Persistence;
using CleanArchitecture.Application.Exception;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Feactures.Streamers.Commands.UpdateStreamer;

public class UpdateStreamerCommandHandler: IRequestHandler<UpdateStreamerCommand>
{
    
    private readonly IStreamerRepository _IStreamerRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateStreamerCommandHandler> _logger;

    public UpdateStreamerCommandHandler(IStreamerRepository iStreamerRepository, IMapper mapper,
        ILogger<UpdateStreamerCommandHandler> logger)
    {
        _IStreamerRepository = iStreamerRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
    {
        var streamerToUpdate = await _IStreamerRepository.GetById(request.Id);

        if (streamerToUpdate == null)
        {
            _logger.LogError($"No se encontro el streamer id {request.Id}");
            throw new NotFoundException(nameof(Streamer), request.Id);
        }

        _mapper.Map(request, streamerToUpdate,
            typeof(UpdateStreamerCommand), typeof(Streamer));

       await _IStreamerRepository.UpdateAsync(streamerToUpdate);
       _logger.LogInformation($"La operacion fue exitosa actualizando el streamer {request.Id}");

       return Unit.Value;
    }
}
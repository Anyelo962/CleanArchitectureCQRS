using AutoMapper;
using CleanArchitecture.Application.Contrats.Infrastructure;
using CleanArchitecture.Application.Contrats.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Feactures.Streamers.Commands.CreateStreamer;

public class CreateStreamerCommandHandler: IRequestHandler<CreateStreamerCommand, int>
{
    private readonly IStreamerRepository _streamerRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateStreamerCommandHandler> _logger;

    public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper,
        IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
    {
        this._streamerRepository = streamerRepository;
        this._mapper = mapper;
        this._emailService = emailService;
        this._logger = logger;
    }
    
    public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
    {
        var streamerEntity = _mapper.Map<Streamer>(request);

       var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

       _logger.LogInformation($"The streamer with id {newStreamer.Id} was created succefully!");

       await SendEmail(newStreamer);
       return newStreamer.Id;
    }
    
    private async Task SendEmail(Streamer streamer)
    {
        var email = new Email()
        {
            To = "Anyelo962@gmail.com",
            Body = "The company of streamer",
            subject = "Streamer test"
        };

        await _emailService.SendEmail(email);
        // try
        // {
        //     await _emailService.SendEmail(email);
        // }
        // catch (Exception e)
        // {
        //     _logger.LogError($"There is a problem for send email to {streamer.Id}");
        // }
        
    }
}
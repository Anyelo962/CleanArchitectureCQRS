using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.Contrats.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}
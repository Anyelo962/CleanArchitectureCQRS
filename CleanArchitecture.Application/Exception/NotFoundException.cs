namespace CleanArchitecture.Application.Exception;

public class NotFoundException: ApplicationException
{
    public NotFoundException(string name, object key): base($"Enntity \"{name}\"({key}) no fue encontrado ")
    {
        
    }
    
}
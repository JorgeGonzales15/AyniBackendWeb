namespace AyniBackendWeb.Ayni.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();

}
namespace InMemoryCaching.RepositoryContracts
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
    }
}

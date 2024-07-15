namespace DistributedCachingWithRedis.RepositoryContracts
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
    }
}

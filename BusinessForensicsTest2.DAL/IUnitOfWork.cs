using BusinessForensicsTest2.DAL.Repositories;

namespace BusinessForensicsTest2.DAL
{
    public interface IUnitOfWork
    {
        IAnimalRepository AnimalRepository { get; }
    }
}
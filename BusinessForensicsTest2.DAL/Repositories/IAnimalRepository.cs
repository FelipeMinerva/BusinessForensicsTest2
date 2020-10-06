using System.Collections.Generic;
using BusinessForensicsTest2.Domain;

namespace BusinessForensicsTest2.DAL.Repositories
{
    public interface IAnimalRepository
    {
        ICollection<Animal> GetAll();
        ICollection<Animal> GetAllByFamily<T>() where T : Animal;
        ICollection<Animal> GetDangerous();
    }
}
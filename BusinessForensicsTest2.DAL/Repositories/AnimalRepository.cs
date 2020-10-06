using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BusinessForensicsTest2.Domain;
using BusinessForensicsTest2.Domain.Interfaces;

namespace BusinessForensicsTest2.DAL.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private ICollection<Animal> _cachedRepository;

        public ICollection<Animal> CachedRepository
        {
            get
            {
                if (_cachedRepository is null)
                    _cachedRepository = GetAll();

                return _cachedRepository;
            }
        }

        public ICollection<Animal> GetAll()
        {
            return Assembly.GetAssembly(typeof(Animal)).GetTypes()
                .Where(myType =>
                    myType.IsClass &&
                    !myType.IsAbstract &&
                    myType.IsSubclassOf(typeof(Animal)))
                .Select(animal => (Animal)Activator.CreateInstance(animal))
                .ToList();
        }

        public ICollection<Animal> GetAllByFamily<T>() where T : Animal
        {
            return CachedRepository.Where(z => z is T).ToList();
        }

        public ICollection<Animal> GetDangerous()
        {
            Type dangerousType = typeof(IDangerous);
            return CachedRepository.Where(animal => dangerousType.IsAssignableFrom(animal.GetType())).ToList();
        }
    }
}
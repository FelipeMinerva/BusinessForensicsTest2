using System;
using BusinessForensicsTest2.DAL.Repositories;

namespace BusinessForensicsTest2.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAnimalRepository _animalRepository;

        public IAnimalRepository AnimalRepository
        {
            get
            {
                if (_animalRepository is null)
                    _animalRepository = new AnimalRepository();

                return _animalRepository;
            }
        }
    }
}

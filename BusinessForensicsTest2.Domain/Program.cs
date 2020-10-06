using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BusinessForensicsTest2.Domain.Extensions;
using BusinessForensicsTest2.Domain.Interfaces;
using BusinessForensicsTest2.Domain;

namespace BusinessForensicsTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = GetAnimals();

            var dangerousAnimal = GetDangerousAnimals(animals);

            foreach (var animal in dangerousAnimal)
            {
                Console.WriteLine(animal.ToString());
            }

            foreach (var animal in animals)
            {
                animal.Feed();
                DisplayPicture(animal.Picture); 
            }
        }

        private static IEnumerable<Animal> GetAnimals()
        {
            return Assembly.GetAssembly(typeof(Animal)).GetTypes()
                .Where(myType =>
                    myType.IsClass &&
                    !myType.IsAbstract &&
                    myType.IsSubclassOf(typeof(Animal)))
                .Select(animal => (Animal)Activator.CreateInstance(animal));
        }

        private static IEnumerable<Animal> GetDangerousAnimals(IEnumerable<Animal> animals)
        {
            return animals.Where(animal => typeof(IDangerous).IsAssignableFrom(animal.GetType()));
        }

        private static void DisplayPicture(byte[] pic) => Console.WriteLine("Showing Picture");
    }
}

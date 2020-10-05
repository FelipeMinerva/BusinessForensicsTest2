using System;
using System.Collections.Generic;
using System.Linq;
using BusinessForensicsTest2.Extensions;
using BusinessForensicsTest2.Fish.Species;
using BusinessForensicsTest2.Insect.Species;
using BusinessForensicsTest2.Interfaces;
using BusinessForensicsTest2.Mammals;
using BusinessForensicsTest2.Mammals.Species;

namespace BusinessForensicsTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>
            {
                new Dog(),
                new Wolf(),
                new Tarantula(),
                new Shark(),
                new Dolphin()
            };

            var dangerousAnimal = GetDangerousAnimals(animals);

            foreach (var animal in dangerousAnimal)
            {
                Console.WriteLine(animal.ToString());
                animal.Feed();
            }
        }

        private static IEnumerable<Animal> GetDangerousAnimals(IEnumerable<Animal> animals)
        {
            return animals.Where(animal => typeof(IDangerous).IsAssignableFrom(animal.GetType()));
        }
    }
}

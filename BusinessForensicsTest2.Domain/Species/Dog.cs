
using BusinessForensicsTest2.Domain.Categories;
using BusinessForensicsTest2.Domain.Families;

namespace BusinessForensicsTest2.Domain.Species
{
    [Pet]
    public class Dog : Mammal
    {
        public override string Name => "Dog";

        public override string Picture { get; set; }
    }
}
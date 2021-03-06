using BusinessForensicsTest2.Domain.Categories;
using BusinessForensicsTest2.Domain.Families;
using BusinessForensicsTest2.Domain.Interfaces;

namespace BusinessForensicsTest2.Domain.Species
{
    [Predator]
    public class Wolf : Mammal, IDangerous
    {
        public override string Name { get => "Wolf"; }
        public override string Picture { get; set;  }
    }
}
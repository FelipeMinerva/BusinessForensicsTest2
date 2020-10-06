using BusinessForensicsTest2.Domain.Categories;
using BusinessForensicsTest2.Domain.Families;
using BusinessForensicsTest2.Domain.Interfaces;

namespace BusinessForensicsTest2.Domain.Species
{
    [Predator]
    public class Shark : Fish, IDangerous
    {
        public override string Name => "Shark";

        public override string Picture { get ;set; }
    }
}
using BusinessForensicsTest2.Domain.Categories;
using BusinessForensicsTest2.Domain.Families;

namespace BusinessForensicsTest2.Domain.Species
{
    [Marine]
    public class Dolphin : Mammal
    {
        public override string Name => "Dolphin";

        public override string Picture { get;set; }
    }
}
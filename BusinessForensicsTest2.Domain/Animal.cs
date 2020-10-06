using System;

namespace BusinessForensicsTest2.Domain
{
    public abstract partial class Animal
    {
        public abstract string Name { get; }
        public abstract string Picture { get; set; }
    }
}

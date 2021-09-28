using Mapster;
using System;

namespace TestingDtoMappings
{
    [AdaptTo("[name]CodeGenDto"), GenerateMapper]
    public class SampleNestedBusinessClass
    {
        public Guid Id { get; internal set; }
        public int Height { get; internal set; }
        public string Name { get; internal set; }
    }
}


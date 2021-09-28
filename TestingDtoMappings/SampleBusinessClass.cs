using System;
using System.Collections.Generic;
using Mapster;

namespace TestingDtoMappings
{
    [AdaptTo("[name]CodeGenDto"), GenerateMapper]
    public class SampleBusinessClass
    {
        public Guid Id { get; internal set; }
        public string Text { get; internal set; }
        public int Height { get; internal set; }
        public string Name { get; internal set; }
        public SampleNestedBusinessClass Nested { get; internal set; }
        public List<SampleNestedBusinessClass> NestedList { get; internal set; }
    }
}


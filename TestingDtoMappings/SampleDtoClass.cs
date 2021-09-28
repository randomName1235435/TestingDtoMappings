using System;
using System.Collections.Generic;

namespace TestingDtoMappings
{
    public class SampleDtoClass
    {
        public Guid Id { get; internal set; }
        public string Text { get; internal set; }
        public int Height { get; internal set; }
        public string Name { get; internal set; }
        public SampleNestedDtoClass Nested { get; internal set; }
        public List<SampleNestedDtoClass> NestedList { get; internal set; }
    }
}


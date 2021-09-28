using System;
using System.Collections.Generic;
using TestingDtoMappings;

namespace TestingDtoMappings
{
    public partial class SampleBusinessClassCodeGenDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public SampleNestedBusinessClassCodeGenDto Nested { get; set; }
        public List<SampleNestedBusinessClassCodeGenDto> NestedList { get; set; }
    }
}
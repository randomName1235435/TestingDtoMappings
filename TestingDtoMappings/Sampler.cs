using System;
using System.Collections.Generic;

namespace TestingDtoMappings
{
    public static class Sampler
    {
        public static readonly SampleBusinessClass CreateSample = new SampleBusinessClass()
        {
            Id = Guid.NewGuid(),
            Text = "sampleText",
            Height = int.MaxValue,
            Name = "sampleName",
            Nested = new SampleNestedBusinessClass
            {
                Id = Guid.NewGuid(),
                Height = int.MaxValue,
                Name = "sampleName"
            },
            NestedList = new List<SampleNestedBusinessClass> {
            new SampleNestedBusinessClass() {
                Id = Guid.NewGuid(),
                Height = int.MaxValue,
                Name = "sampleName"
            },
            new SampleNestedBusinessClass() {
                Id = Guid.NewGuid(),
                Height = int.MaxValue,
                Name = "sampleName"
            },}
        };

    }
}


using TestingDtoMappings;

namespace TestingDtoMappings
{
    public static partial class SampleNestedBusinessClassMapper
    {
        public static SampleNestedBusinessClassCodeGenDto AdaptToCodeGenDto(this SampleNestedBusinessClass p1)
        {
            return p1 == null ? null : new SampleNestedBusinessClassCodeGenDto()
            {
                Id = p1.Id,
                Height = p1.Height,
                Name = p1.Name
            };
        }
        public static SampleNestedBusinessClassCodeGenDto AdaptTo(this SampleNestedBusinessClass p2, SampleNestedBusinessClassCodeGenDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            SampleNestedBusinessClassCodeGenDto result = p3 ?? new SampleNestedBusinessClassCodeGenDto();
            
            result.Id = p2.Id;
            result.Height = p2.Height;
            result.Name = p2.Name;
            return result;
            
        }
    }
}
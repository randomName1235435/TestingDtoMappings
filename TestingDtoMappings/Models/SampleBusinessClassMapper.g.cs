using System.Collections.Generic;
using TestingDtoMappings;

namespace TestingDtoMappings
{
    public static partial class SampleBusinessClassMapper
    {
        public static SampleBusinessClassCodeGenDto AdaptToCodeGenDto(this SampleBusinessClass p1)
        {
            return p1 == null ? null : new SampleBusinessClassCodeGenDto()
            {
                Id = p1.Id,
                Text = p1.Text,
                Height = p1.Height,
                Name = p1.Name,
                Nested = p1.Nested == null ? null : new SampleNestedBusinessClassCodeGenDto()
                {
                    Id = p1.Nested.Id,
                    Height = p1.Nested.Height,
                    Name = p1.Nested.Name
                },
                NestedList = funcMain1(p1.NestedList)
            };
        }
        public static SampleBusinessClassCodeGenDto AdaptTo(this SampleBusinessClass p3, SampleBusinessClassCodeGenDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            SampleBusinessClassCodeGenDto result = p4 ?? new SampleBusinessClassCodeGenDto();
            
            result.Id = p3.Id;
            result.Text = p3.Text;
            result.Height = p3.Height;
            result.Name = p3.Name;
            result.Nested = funcMain2(p3.Nested, result.Nested);
            result.NestedList = funcMain3(p3.NestedList, result.NestedList);
            return result;
            
        }
        
        private static List<SampleNestedBusinessClassCodeGenDto> funcMain1(List<SampleNestedBusinessClass> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<SampleNestedBusinessClassCodeGenDto> result = new List<SampleNestedBusinessClassCodeGenDto>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                SampleNestedBusinessClass item = p2[i];
                result.Add(item == null ? null : new SampleNestedBusinessClassCodeGenDto()
                {
                    Id = item.Id,
                    Height = item.Height,
                    Name = item.Name
                });
                i++;
            }
            return result;
            
        }
        
        private static SampleNestedBusinessClassCodeGenDto funcMain2(SampleNestedBusinessClass p5, SampleNestedBusinessClassCodeGenDto p6)
        {
            if (p5 == null)
            {
                return null;
            }
            SampleNestedBusinessClassCodeGenDto result = p6 ?? new SampleNestedBusinessClassCodeGenDto();
            
            result.Id = p5.Id;
            result.Height = p5.Height;
            result.Name = p5.Name;
            return result;
            
        }
        
        private static List<SampleNestedBusinessClassCodeGenDto> funcMain3(List<SampleNestedBusinessClass> p7, List<SampleNestedBusinessClassCodeGenDto> p8)
        {
            if (p7 == null)
            {
                return null;
            }
            List<SampleNestedBusinessClassCodeGenDto> result = new List<SampleNestedBusinessClassCodeGenDto>(p7.Count);
            
            int i = 0;
            int len = p7.Count;
            
            while (i < len)
            {
                SampleNestedBusinessClass item = p7[i];
                result.Add(item == null ? null : new SampleNestedBusinessClassCodeGenDto()
                {
                    Id = item.Id,
                    Height = item.Height,
                    Name = item.Name
                });
                i++;
            }
            return result;
            
        }
    }
}
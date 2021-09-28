using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq;
using BenchmarkDotNet.Order;
using Mapster;
using AutoMapper;
using System.Collections.Generic;

namespace TestingDtoMappings
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();
            Console.ReadLine();
        }
    }

    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class BenchmarkClass
    {

        [Benchmark]
        public SampleDtoClass ManualLinq() => Mappings.ManualLinqMapping();

        [Benchmark]
        public SampleDtoClass ManualForLoop() => Mappings.ManualForLoopMapping();

        [Benchmark]
        public SampleDtoClass Express() => Mappings.ExpressMapping();

        [Benchmark]
        public SampleDtoClass AutoMapper() => Mappings.AutoMapper();

        [Benchmark]
        public SampleDtoClass MapsterDefaultAdapt() => Mappings.MapsterDefaultAdapt();

        [Benchmark]
        public SampleDtoClass MapsterWithConfigAdapt() => Mappings.MapsterWithConfigAdapt();

        [Benchmark]
        public SampleDtoClass MapsterAdaptToType() => Mappings.MapsterAdaptToType();
        
        [Benchmark]
        public SampleBusinessClassCodeGenDto MapsterCodeGen() => Mappings.MapsterCodeGen();
        
    }

    public static class Mappings
    {
        private static readonly IMapper autoMapper =
            new Mapper(new MapperConfiguration(ex => ex.AddProfile(new AutoMapperProfile())));
        private static readonly MapsterMapper.IMapper mapsterMapper = 
            new MapsterMapper.Mapper(GetTypeAdapterConfig());
        private static readonly TypeAdapterConfig typeAdapterConfig = GetTypeAdapterConfig();

        static Mappings()
        {
            ExpressMapper.Mapper.Register<SampleBusinessClass, SampleDtoClass>();
        }

        public static SampleDtoClass ManualLinqMapping()
        {

            var instance = Sampler.CreateSample;
            return new SampleDtoClass
            {
                Id = instance.Id,
                Text = instance.Text,
                Height = instance.Height,
                Name = instance.Name,
                Nested = new SampleNestedDtoClass
                {
                    Id = instance.Nested.Id,
                    Height = instance.Nested.Height,
                    Name = instance.Nested.Name
                },
                NestedList = instance.NestedList.Select(x => new SampleNestedDtoClass
                {
                    Id = x.Id,
                    Height = x.Height,
                    Name = x.Name
                }).ToList()
            };
        }
        public static SampleDtoClass ManualForLoopMapping()
        {
            var instance = Sampler.CreateSample;
            var ret = new SampleDtoClass
            {
                Id = instance.Id,
                Text = instance.Text,
                Height = instance.Height,
                Name = instance.Name,
                Nested = new SampleNestedDtoClass
                {
                    Id = instance.Nested.Id,
                    Height = instance.Nested.Height,
                    Name = instance.Nested.Name
                }
            };
            ret.NestedList = new List<SampleNestedDtoClass>();
            for (int i = 0; i < instance.NestedList.Count; i++)
            {
                ret.NestedList.Add(new SampleNestedDtoClass
                {
                    Id = instance.NestedList[i].Id,
                    Height = instance.NestedList[i].Height,
                    Name = instance.NestedList[i].Name
                });
            }

            return ret;
        }
        public static SampleDtoClass ExpressMapping()
        {
            return ExpressMapper.Mapper.Map<SampleBusinessClass, SampleDtoClass>(Sampler.CreateSample);
        }
        public static SampleDtoClass MapsterDefaultAdapt()
        {
            return Sampler.CreateSample.Adapt<SampleDtoClass>();
        }
        public static SampleDtoClass MapsterWithConfigAdapt()
        {
            return Sampler.CreateSample.Adapt<SampleDtoClass>(typeAdapterConfig);
        }
                public static SampleDtoClass AutoMapper()
        {
            return autoMapper.Map<SampleBusinessClass, SampleDtoClass>(Sampler.CreateSample);
        }
        public static TypeAdapterConfig GetTypeAdapterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<SampleBusinessClass, SampleDtoClass>();
            return config;
        }
        public static SampleDtoClass MapsterAdaptToType()
        {
            //fluent style
            return mapsterMapper.From(Sampler.CreateSample).AdaptToType<SampleDtoClass>();
        }
        public static SampleBusinessClassCodeGenDto MapsterCodeGen()
        {
            // cd to project folder
            //dotnet new tool-manifest
            //dotnet tool install Mapster.Tool
            //add generated and targets to project file
            return Sampler.CreateSample.AdaptToCodeGenDto();
        }
    }
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SampleBusinessClass, SampleDtoClass>();
            CreateMap<SampleNestedBusinessClass, SampleNestedDtoClass>();
        }
    }
}


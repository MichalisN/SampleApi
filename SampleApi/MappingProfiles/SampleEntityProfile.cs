using AutoMapper;
using SampleApi.Api.Models.SampleEntity;
using SampleApi.Data.Models.SampleEntity;

namespace SampleApi.Api.MappingProfiles;

public class SampleEntityProfile : Profile
{
    public SampleEntityProfile()
    {
        CreateMap<NewSampleEntityDetails, NewSampleEntityDetailsData>();
        CreateMap<UpdateSampleEntityDetails, UpdateSampleEntityDetailsData>();
        CreateMap<SampleEntity, SampleEntityDetails>();
    }
}
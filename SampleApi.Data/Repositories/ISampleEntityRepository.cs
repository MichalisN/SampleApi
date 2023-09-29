using SampleApi.Data.Models.SampleEntity;

namespace SampleApi.Data.Repositories;

public interface ISampleEntityRepository
{
    Task<IReadOnlyCollection<SampleEntity>> GetAll();

    Task<SampleEntity?> Find(long id);

    Task<long> Create(NewSampleEntityDetailsData sampleEntityDetails);

    Task<bool> Update(UpdateSampleEntityDetailsData sampleEntityDetails);

    Task<bool> Delete(long id);
}
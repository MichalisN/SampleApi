using Microsoft.EntityFrameworkCore;
using SampleApi.Data.Context;
using SampleApi.Data.Models.SampleEntity;

namespace SampleApi.Data.Repositories;

public class SampleEntityRepository : ISampleEntityRepository
{
    private readonly SampleApiContext _context;

    public SampleEntityRepository(SampleApiContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<SampleEntity>> GetAll()
    {
        return await _context.SampleEntities.ToArrayAsync();
    }

    public async Task<SampleEntity?> Find(long id)
    {
        return await _context.SampleEntities.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<long> Create(NewSampleEntityDetailsData sampleEntityDetails)
    {
        SampleEntity newEntity = new()
        {
            Name = sampleEntityDetails.Name,
            Code = sampleEntityDetails.Code
        };

        _context.SampleEntities.Add(newEntity);
        await _context.SaveChangesAsync();

        return newEntity.Id;
    }

    public async Task<bool> Update(UpdateSampleEntityDetailsData sampleEntityDetails)
    {
        var existingSampleEntity = await _context.SampleEntities.FindAsync(sampleEntityDetails.Id);
        if (existingSampleEntity is null)
        {
            return false;
        }

        existingSampleEntity.Name = sampleEntityDetails.Name;
        existingSampleEntity.Code = sampleEntityDetails.Code;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(long id)
    {
        var existingSampleEntity = await _context.SampleEntities.FindAsync(id);
        if (existingSampleEntity is null)
        {
            return false;
        }

        _context.SampleEntities.Remove(existingSampleEntity);
        await _context.SaveChangesAsync();
        return true;
    }

    private bool SampleEntityExists(long id)
    {
        return _context.SampleEntities.Any(e => e.Id == id);
    }
}
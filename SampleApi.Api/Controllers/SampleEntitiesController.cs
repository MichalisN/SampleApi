using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Api.Models.SampleEntity;
using SampleApi.Data.Models.SampleEntity;
using SampleApi.Data.Repositories;

namespace SampleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleEntitiesController : ControllerBase
{
    private readonly ISampleEntityRepository _sampleEntityRepository;
    private readonly IMapper _mapper;

    public SampleEntitiesController(ISampleEntityRepository sampleEntityRepository,
                                    IMapper mapper)
    {
        _sampleEntityRepository = sampleEntityRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<SampleEntityDetails>>> GetAll()
    {
        var dataEntities = await _sampleEntityRepository.GetAll();
        return _mapper.Map<SampleEntityDetails[]>(dataEntities);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SampleEntityDetails>> Get(long id)
    {
        var entity = await _sampleEntityRepository.Find(id);
        if (entity is null)
        {
            return NotFound();
        }

        return _mapper.Map<SampleEntityDetails>(entity);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] NewSampleEntityDetails entity)
    {
        var newEntityDetailsData = _mapper.Map<NewSampleEntityDetailsData>(entity);

        var createdId = await _sampleEntityRepository.Create(newEntityDetailsData);

        return Ok(createdId);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateSampleEntityDetails entity)
    {
        var updateEntityDetailsData = _mapper.Map<UpdateSampleEntityDetailsData>(entity);

        if (!await _sampleEntityRepository.Update(updateEntityDetailsData))
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(long id)
    {
        if (!await _sampleEntityRepository.Delete(id))
        {
            return NotFound();
        }

        return Ok();
    }
}
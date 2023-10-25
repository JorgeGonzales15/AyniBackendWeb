using AutoMapper;
using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Services;
using AyniBackendWeb.Ayni.Resources;
using AyniBackendWeb.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AyniBackendWeb.Ayni.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CostController : ControllerBase
{
    private readonly ICostService _costService;
    private readonly IMapper _mapper;

    public CostController(ICostService costService, IMapper mapper)
    {
        _costService = costService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CostResource>> GetAllAsync()
    {
        var costs = await _costService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Cost>, 
            IEnumerable<CostResource>>(costs);
        return resources;

    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveCostResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var cost = _mapper.Map<SaveCostResource, 
            Cost>(resource);
        var result = await _costService.SaveAsync(cost);
        if (!result.Success)
            return BadRequest(result.Message);
        var costResource = _mapper.Map<Cost, 
            CostResource>(result.Resource);
        return Ok(costResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveCostResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var cost = _mapper.Map<SaveCostResource, 
            Cost>(resource);
        var result = await _costService.UpdateAsync(id, cost);
        if (!result.Success)
            return BadRequest(result.Message);
        var costResource = _mapper.Map<Cost, 
            CostResource>(result.Resource);
        return Ok(costResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _costService.DeleteAsync(id);
 
        if (!result.Success)
            return BadRequest(result.Message);
        var costResource = _mapper.Map<Cost, 
            CostResource>(result.Resource);
        return Ok(costResource);
    }
}
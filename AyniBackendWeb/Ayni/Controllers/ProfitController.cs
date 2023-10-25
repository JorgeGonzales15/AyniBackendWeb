using AutoMapper;
using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Services;
using AyniBackendWeb.Ayni.Resources;
using AyniBackendWeb.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AyniBackendWeb.Ayni.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProfitController : ControllerBase
{
    private readonly IProfitService _profitService;
    private readonly IMapper _mapper;

    public ProfitController(IProfitService profitService, IMapper mapper)
    {
        _profitService = profitService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ProfitResource>> GetAllAsync()
    {
        var profits = await _profitService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Profit>, 
            IEnumerable<ProfitResource>>(profits);
        return resources;

    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveProfitResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var profit = _mapper.Map<SaveProfitResource, 
            Profit>(resource);
        var result = await _profitService.SaveAsync(profit);
        if (!result.Success)
            return BadRequest(result.Message);
        var profitResource = _mapper.Map<Profit, 
            ProfitResource>(result.Resource);
        return Ok(profitResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveProfitResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var profit = _mapper.Map<SaveProfitResource, 
            Profit>(resource);
        var result = await _profitService.UpdateAsync(id, profit);
        if (!result.Success)
            return BadRequest(result.Message);
        var profitResource = _mapper.Map<Profit, 
            ProfitResource>(result.Resource);
        return Ok(profitResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _profitService.DeleteAsync(id);
 
        if (!result.Success)
            return BadRequest(result.Message);
        var profitResource = _mapper.Map<Profit, 
            ProfitResource>(result.Resource);
        return Ok(profitResource);
    }
}
using AutoMapper;
using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Services;
using AyniBackendWeb.Ayni.Resources;
using Microsoft.AspNetCore.Mvc;

namespace AyniBackendWeb.Ayni.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UsersCostsController : ControllerBase
{
    private readonly ICostService _costService;
    private readonly IMapper _mapper;
    
    [HttpGet]
    public async Task<IEnumerable<CostResource>> 
        GetAllByUserIdAsync(int userId)
    {
        var costs = await 
            _costService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<Cost>, 
            IEnumerable<CostResource>>(costs);
        return resources;
    }
}
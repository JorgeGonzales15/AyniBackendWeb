using AutoMapper;
using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Services;
using AyniBackendWeb.Ayni.Resources;
using Microsoft.AspNetCore.Mvc;

namespace AyniBackendWeb.Ayni.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class UserCropsController : ControllerBase
{
    private readonly ICropService _cropService;
    private readonly IMapper _mapper;
    
    [HttpGet]
    public async Task<IEnumerable<CropResource>> 
        GetAllByUserIdAsync(int userId)
    {
        var crops = await 
            _cropService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<Crop>, 
            IEnumerable<CropResource>>(crops);
        return resources;
    }

}
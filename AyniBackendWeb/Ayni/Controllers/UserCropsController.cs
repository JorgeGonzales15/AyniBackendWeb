using AutoMapper;
using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Services;
using AyniBackendWeb.Ayni.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AyniBackendWeb.Ayni.Controllers;

[ApiController]
[Route("/api/v1/users/{userId}/crops")]
public class UserCropsController
{
    private readonly ICropService _cropService;
    private readonly IMapper _mapper;

    public UserCropsController(ICropService cropService, IMapper mapper)
    {
        _cropService = cropService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Crops for given User",
        Description = "Get existing Crop associated with the specified User",
        OperationId = "GetUserCrops",
        Tags = new[] { "UserCrops"}
    )]
    public async Task<IEnumerable<CropResource>> GetAllByUserIdAsync(int userId)
    {
        var crops = await _cropService.ListByUserIdAsync(userId);

        var resources = _mapper.Map<IEnumerable<Crop>, IEnumerable<CropResource>>(crops);

        return resources;
    }
    
}
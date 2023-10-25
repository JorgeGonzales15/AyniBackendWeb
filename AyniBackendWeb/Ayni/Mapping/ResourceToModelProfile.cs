using AutoMapper;
using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Resources;

namespace AyniBackendWeb.Ayni.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveUserResource, User>();
        CreateMap<SaveCropResource, Crop>();
        CreateMap<SaveCostResource, Cost>();
        CreateMap<SaveProfitResource, Profit>();
        CreateMap<SaveProductResource, Product>();
        CreateMap<SaveOrderResource, Order>();
    }
}
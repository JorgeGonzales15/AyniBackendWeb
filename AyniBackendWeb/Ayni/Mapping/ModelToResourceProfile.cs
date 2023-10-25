using AutoMapper;
using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Resources;

namespace AyniBackendWeb.Ayni.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<Crop, CropResource>();
        CreateMap<Cost, CostResource>();
        CreateMap<Profit, ProfitResource>();
        CreateMap<Product, ProductResource>();
        CreateMap<Order, OrderResource>();
    }
}
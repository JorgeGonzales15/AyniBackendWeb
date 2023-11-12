using AutoMapper;
using AyniBackendWeb.Security.Domain.Models;
using AyniBackendWeb.Security.Domain.Services.Communication;
using AyniBackendWeb.Security.Resources;

namespace AyniBackendWeb.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticationResponse>();
        CreateMap<User, UserResource>();
    }
}
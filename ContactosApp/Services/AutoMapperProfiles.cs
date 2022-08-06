using AutoMapper;
using ContactosApp.Models;

namespace ContactosApp.Services;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ExperienciaLaboral, ExperienciaLaboralViewModel>();
    }
}
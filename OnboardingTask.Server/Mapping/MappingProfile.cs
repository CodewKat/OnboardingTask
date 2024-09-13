using AutoMapper;
using OnboardingTask.Server.Models;
using OnboardingTask.Server.ViewModels;

namespace OnboardingTask.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}

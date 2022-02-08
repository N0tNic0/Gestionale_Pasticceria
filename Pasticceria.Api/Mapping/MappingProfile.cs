using AutoMapper;
using Pasticceria.Api.Resources;
using Pasticceria.Core.Models;

namespace Pasticceria.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ingrediente, IngredienteResource>();
            CreateMap<Dolce, DolceResource>();
            CreateMap<IngredientiOfDolce, IngredientiOfDolceResource>();
            CreateMap<IngredientiOfDolce, IngredientiOfDolceCompleteResource>();

            CreateMap<IngredienteResource, Ingrediente>();
            CreateMap<DolceResource, Dolce>();
            CreateMap<IngredientiOfDolceResource, IngredientiOfDolce>();
            CreateMap<IngredientiOfDolceCompleteResource, IngredientiOfDolce>();

            CreateMap<SaveIngredienteResource, Ingrediente>();
            CreateMap<SaveDolceResource, Dolce>();
            CreateMap<SaveIngredientiOfDolciResource, IngredientiOfDolce>();
        }
    }
}

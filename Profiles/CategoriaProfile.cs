using AutoMapper;
using EcommerceAPI.Data.Dtos;
using EcommerceAPI.Models;

namespace EcommerceAPI.Profiles
{
    public class CategoriaProfile: Profile
    {
        public CategoriaProfile()
        { //criar os maps importar 

            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadCategoriaDto>();
            CreateMap<UpDateCategoriaDto, Categoria>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Data;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class AppProfiles : Profile
    {
        public AppProfiles()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaCreateDto, Categoria>();
            CreateMap<CategoriaUpdateDto, Categoria>();

            CreateMap<Producto, ProductoDto>()
                .ForMember(x => x.Categoria, op => op.MapFrom(x => x.Categoria.Nombre));
            CreateMap<ProductoCreateDto, Producto>();
            CreateMap<ProductoUpdateDto, Producto>();
        }
    }
}
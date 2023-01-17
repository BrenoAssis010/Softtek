using AutoMapper;
using Questao5.Application.DTOs;
using Questao5.Domain.Entities;

namespace Questao5.Application.Mappings
{
    public class MovimentoProfile : Profile
    {
        public MovimentoProfile()
        {
            CreateMap<MovimentoDTO, MovimentoEntidade>();
            CreateMap<MovimentoBuscarDTO, MovimentoEntidade>();
        }
    }
}

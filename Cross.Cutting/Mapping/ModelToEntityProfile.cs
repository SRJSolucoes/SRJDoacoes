using AutoMapper;
using Domain.Entidades;
using Domain.Models;

namespace Cross.Cutting.Mapping 
{
    public class ModelToEntityProfile : Profile 
    { 
        public ModelToEntityProfile() 
        { 
            CreateMap<Caixa, CaixaModel>().ReverseMap(); 
            CreateMap<Controle, ControleModel>().ReverseMap(); 
            CreateMap<Grupo, GrupoModel>().ReverseMap(); 
            CreateMap<Loja, LojaModel>().ReverseMap(); 
            CreateMap<O2sicontrole, O2sicontroleModel>().ReverseMap(); 
            CreateMap<Parametro, ParametroModel>().ReverseMap(); 
            CreateMap<Venda, VendaModel>().ReverseMap(); 
        } 
    }      
} 

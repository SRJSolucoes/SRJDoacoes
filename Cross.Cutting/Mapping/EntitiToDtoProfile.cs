using AutoMapper;
using Domain.Entidades;
using Domain.DTOs.CaixaDTO;
using Domain.DTOs.ControleDTO;
using Domain.DTOs.GrupoDTO;
using Domain.DTOs.LojaDTO;
using Domain.DTOs.O2sicontroleDTO;
using Domain.DTOs.ParametroDTO;
using Domain.DTOs.VendaDTO;

namespace Cross.Cutting.Mapping 
{
    public class EntitiToDtoProfile : Profile 
    { 
        public EntitiToDtoProfile() 
        { 
            CreateMap<CaixaDTO, Caixa>().ReverseMap(); 
            CreateMap<CaixaDTOReference, Caixa>().ReverseMap(); 
            CreateMap<CaixaDTOCreate, Caixa>().ReverseMap(); 
            CreateMap<CaixaDTOUpdate, Caixa>().ReverseMap(); 
            CreateMap<CaixaDTOCreateReturn, Caixa>().ReverseMap(); 
            CreateMap<CaixaDTOUpdateReturn, Caixa>().ReverseMap(); 
   
            CreateMap<ControleDTO, Controle>().ReverseMap(); 
            CreateMap<ControleDTOReference, Controle>().ReverseMap(); 
            CreateMap<ControleDTOCreate, Controle>().ReverseMap(); 
            CreateMap<ControleDTOUpdate, Controle>().ReverseMap(); 
            CreateMap<ControleDTOCreateReturn, Controle>().ReverseMap(); 
            CreateMap<ControleDTOUpdateReturn, Controle>().ReverseMap(); 
   
            CreateMap<GrupoDTO, Grupo>().ReverseMap(); 
            CreateMap<GrupoDTOReference, Grupo>().ReverseMap(); 
            CreateMap<GrupoDTOCreate, Grupo>().ReverseMap(); 
            CreateMap<GrupoDTOUpdate, Grupo>().ReverseMap(); 
            CreateMap<GrupoDTOCreateReturn, Grupo>().ReverseMap(); 
            CreateMap<GrupoDTOUpdateReturn, Grupo>().ReverseMap(); 
   
            CreateMap<LojaDTO, Loja>().ReverseMap(); 
            CreateMap<LojaDTOReference, Loja>().ReverseMap(); 
            CreateMap<LojaDTOCreate, Loja>().ReverseMap(); 
            CreateMap<LojaDTOUpdate, Loja>().ReverseMap(); 
            CreateMap<LojaDTOCreateReturn, Loja>().ReverseMap(); 
            CreateMap<LojaDTOUpdateReturn, Loja>().ReverseMap(); 
   
            CreateMap<O2sicontroleDTO, O2sicontrole>().ReverseMap(); 
            CreateMap<O2sicontroleDTOReference, O2sicontrole>().ReverseMap(); 
            CreateMap<O2sicontroleDTOCreate, O2sicontrole>().ReverseMap(); 
            CreateMap<O2sicontroleDTOUpdate, O2sicontrole>().ReverseMap(); 
            CreateMap<O2sicontroleDTOCreateReturn, O2sicontrole>().ReverseMap(); 
            CreateMap<O2sicontroleDTOUpdateReturn, O2sicontrole>().ReverseMap(); 
   
            CreateMap<ParametroDTO, Parametro>().ReverseMap(); 
            CreateMap<ParametroDTOReference, Parametro>().ReverseMap(); 
            CreateMap<ParametroDTOCreate, Parametro>().ReverseMap(); 
            CreateMap<ParametroDTOUpdate, Parametro>().ReverseMap(); 
            CreateMap<ParametroDTOCreateReturn, Parametro>().ReverseMap(); 
            CreateMap<ParametroDTOUpdateReturn, Parametro>().ReverseMap(); 
   
            CreateMap<VendaDTO, Venda>().ReverseMap(); 
            CreateMap<VendaDTOReference, Venda>().ReverseMap(); 
            CreateMap<VendaDTOCreate, Venda>().ReverseMap(); 
            CreateMap<VendaDTOUpdate, Venda>().ReverseMap(); 
            CreateMap<VendaDTOCreateReturn, Venda>().ReverseMap(); 
            CreateMap<VendaDTOUpdateReturn, Venda>().ReverseMap(); 
   
        } 
    }      
} 

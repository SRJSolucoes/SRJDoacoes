using Domain.Models;
using AutoMapper;
using Domain.DTOs.CaixaDTO;
using Domain.DTOs.ControleDTO;
using Domain.DTOs.GrupoDTO;
using Domain.DTOs.LojaDTO;
using Domain.DTOs.O2sicontroleDTO;
using Domain.DTOs.ParametroDTO;
using Domain.DTOs.VendaDTO;

namespace Cross.Cutting.Mapping 
{
    public class DtoToModelProfile : Profile 
    { 
        public DtoToModelProfile() 
        { 
            CreateMap<CaixaModel, CaixaDTO>().ReverseMap(); 
            CreateMap<CaixaModel, CaixaDTOReference>().ReverseMap(); 
            CreateMap<CaixaModel, CaixaDTOCreate>().ReverseMap(); 
            CreateMap<CaixaModel, CaixaDTOUpdate>().ReverseMap(); 
            CreateMap<CaixaModel, CaixaDTOCreateReturn>().ReverseMap(); 
            CreateMap<CaixaModel, CaixaDTOUpdateReturn>().ReverseMap(); 
   
            CreateMap<ControleModel, ControleDTO>().ReverseMap(); 
            CreateMap<ControleModel, ControleDTOReference>().ReverseMap(); 
            CreateMap<ControleModel, ControleDTOCreate>().ReverseMap(); 
            CreateMap<ControleModel, ControleDTOUpdate>().ReverseMap(); 
            CreateMap<ControleModel, ControleDTOCreateReturn>().ReverseMap(); 
            CreateMap<ControleModel, ControleDTOUpdateReturn>().ReverseMap(); 
   
            CreateMap<GrupoModel, GrupoDTO>().ReverseMap(); 
            CreateMap<GrupoModel, GrupoDTOReference>().ReverseMap(); 
            CreateMap<GrupoModel, GrupoDTOCreate>().ReverseMap(); 
            CreateMap<GrupoModel, GrupoDTOUpdate>().ReverseMap(); 
            CreateMap<GrupoModel, GrupoDTOCreateReturn>().ReverseMap(); 
            CreateMap<GrupoModel, GrupoDTOUpdateReturn>().ReverseMap(); 
   
            CreateMap<LojaModel, LojaDTO>().ReverseMap(); 
            CreateMap<LojaModel, LojaDTOReference>().ReverseMap(); 
            CreateMap<LojaModel, LojaDTOCreate>().ReverseMap(); 
            CreateMap<LojaModel, LojaDTOUpdate>().ReverseMap(); 
            CreateMap<LojaModel, LojaDTOCreateReturn>().ReverseMap(); 
            CreateMap<LojaModel, LojaDTOUpdateReturn>().ReverseMap(); 
   
            CreateMap<O2sicontroleModel, O2sicontroleDTO>().ReverseMap(); 
            CreateMap<O2sicontroleModel, O2sicontroleDTOReference>().ReverseMap(); 
            CreateMap<O2sicontroleModel, O2sicontroleDTOCreate>().ReverseMap(); 
            CreateMap<O2sicontroleModel, O2sicontroleDTOUpdate>().ReverseMap(); 
            CreateMap<O2sicontroleModel, O2sicontroleDTOCreateReturn>().ReverseMap(); 
            CreateMap<O2sicontroleModel, O2sicontroleDTOUpdateReturn>().ReverseMap(); 
   
            CreateMap<ParametroModel, ParametroDTO>().ReverseMap(); 
            CreateMap<ParametroModel, ParametroDTOReference>().ReverseMap(); 
            CreateMap<ParametroModel, ParametroDTOCreate>().ReverseMap(); 
            CreateMap<ParametroModel, ParametroDTOUpdate>().ReverseMap(); 
            CreateMap<ParametroModel, ParametroDTOCreateReturn>().ReverseMap(); 
            CreateMap<ParametroModel, ParametroDTOUpdateReturn>().ReverseMap(); 
   
            CreateMap<VendaModel, VendaDTO>().ReverseMap(); 
            CreateMap<VendaModel, VendaDTOReference>().ReverseMap(); 
            CreateMap<VendaModel, VendaDTOCreate>().ReverseMap(); 
            CreateMap<VendaModel, VendaDTOUpdate>().ReverseMap(); 
            CreateMap<VendaModel, VendaDTOCreateReturn>().ReverseMap(); 
            CreateMap<VendaModel, VendaDTOUpdateReturn>().ReverseMap(); 
   
        } 
    }      
} 

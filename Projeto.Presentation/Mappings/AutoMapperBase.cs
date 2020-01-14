using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Entities;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Mappings
{
    public class AutoMapperBase : Profile
    {
        public AutoMapperBase()
        {
            CreateMap<Fisioterapeuta, FisioterapeutaConsultaViewModel>().ReverseMap();
            CreateMap<Fisioterapeuta, FisioterapeutaEdicaoViewModel>().ReverseMap();
            CreateMap<Fisioterapeuta, FisioterapeutaCadastroViewModel>().ReverseMap();

            CreateMap<Paciente, PacienteConsultaViewModel>().ReverseMap();
            CreateMap<Paciente, PacienteEdicaoViewModel>().ReverseMap();
            CreateMap<Paciente, PacienteCadastroViewModel>().ReverseMap();

            CreateMap<Atendimento, AtendimentoConsultaViewModel>().ReverseMap();
            CreateMap<Atendimento, AtendimentoEdicaoViewModel>().ReverseMap();
            CreateMap<Atendimento, AtendimentoCadastroViewModel>().ReverseMap();
        }
    }
}
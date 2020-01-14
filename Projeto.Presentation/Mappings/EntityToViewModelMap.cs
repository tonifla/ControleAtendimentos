using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Entities;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Mappings
{
    public class EntityToViewModelMap : Profile
    {
        public EntityToViewModelMap()
        {
            CreateMap<Atendimento, AtendimentoConsultaViewModel>();
            CreateMap<Atendimento, AtendimentoEdicaoViewModel>();

            CreateMap<Fisioterapeuta, FisioterapeutaConsultaViewModel>();
            CreateMap<Fisioterapeuta, FisioterapeutaEdicaoViewModel>();

            CreateMap<Paciente, PacienteConsultaViewModel>();
            CreateMap<Paciente, PacienteEdicaoViewModel>();
        }
    }
}
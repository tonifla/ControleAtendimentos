using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Entities;
using Projeto.Presentation.Models;

namespace Projeto.Presentation.Mappings
{
    public class ViewModelToEntityMap : Profile
    {
        public ViewModelToEntityMap()
        {
            CreateMap<AtendimentoCadastroViewModel, Atendimento>();
            CreateMap<AtendimentoEdicaoViewModel, Atendimento>();

            CreateMap<FisioterapeutaCadastroViewModel, Fisioterapeuta>();
            CreateMap<FisioterapeutaEdicaoViewModel, Fisioterapeuta>();

            CreateMap<PacienteCadastroViewModel, Paciente>();
            CreateMap<PacienteEdicaoViewModel, Paciente>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class AtendimentoConsultaViewModel
    {
        public int AtenIdentificador { get; set; }

        [Display(Name = "Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? AtenData { get; set; }

        [Display(Name = "Hora")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? AtenHora { get; set; }

        [Display(Name = "Conduta")]
        public string AtenConduta { get; set; }

        [Display(Name = "Paciente")]
        public int AtenPaciIdentificador { get; set; }

        [Display(Name = "Fisioterapeuta")]
        public int AtenFisiIdentificador { get; set; }

        [Display(Name = "Quantidade de atendimentos")]
        public int QuantidadeDeAtendimentos { get; set; }

        public PacienteConsultaViewModel Paciente { get; set; }
        public FisioterapeutaConsultaViewModel Fisioterapeuta { get; set; }
    }
}
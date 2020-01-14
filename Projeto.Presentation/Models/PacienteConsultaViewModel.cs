using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class PacienteConsultaViewModel
    {
        public int PaciIdentificador { get; set; }

        [Display(Name = "Paciente")]
        public string PaciNome { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string PaciCpfCnpj { get; set; }

        [Display(Name = "Endereço")]
        public string PaciEndereco { get; set; }

        [Display(Name = "Número")]
        public string PaciNumero { get; set; }

        [Display(Name = "Complemento")]
        public string PaciComplemento { get; set; }

        [Display(Name = "Bairro")]
        public string PaciBairro { get; set; }

        [Display(Name = "Município")]
        public string PaciMunicipio { get; set; }

        [Display(Name = "Estado")]
        public string PaciEstado { get; set; }

        [Display(Name = "CEP")]
        public string PaciCep { get; set; }

        [Display(Name = "Ponto de referência")]
        public string PaciPontoReferencia { get; set; }

        [Display(Name = "Celular")]
        public string PaciCelular { get; set; }

        [Display(Name = "Outro contato")]
        public string PaciTelefone { get; set; }

        [Display(Name = "Email")]
        public string PaciEmail { get; set; }

        [Display(Name = "Atendimento inicial")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? PaciDataInicioAtendimento { get; set; }

        [Display(Name = "Valor consulta")]
        public decimal PaciValorAtendimento { get; set; }

        [Display(Name = "Diagnóstico")]
        public string PaciDiagnostico { get; set; }

        [Display(Name = "Patologia")]
        public string PaciPatologia { get; set; }

        [Display(Name = "Observação")]
        public string PaciObservacao { get; set; }

        [Display(Name = "Quantidade de pacientes")]
        public int QuantidadeDePacientes { get; set; }
    }
}
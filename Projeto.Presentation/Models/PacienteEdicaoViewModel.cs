using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class PacienteEdicaoViewModel
    {
        public int PaciIdentificador { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "{0} precisa ter no mínimo {2} e no máximo {1} caracteres.")]
        public string PaciNome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "{0} precisa ter {1} caracteres.")]
        public string PaciCpfCnpj { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "{0} precisa ter no mínimo {2} e no máximo {1} caracteres.")]
        public string PaciEndereco { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [MaxLength(15, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string PaciNumero { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string PaciComplemento { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string PaciBairro { get; set; }

        [Display(Name = "Município")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string PaciMunicipio { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "{0} precisa ter {1} caracteres.")]
        [RegularExpression("^[[A-z]{2}$", ErrorMessage = "Informe um estado válido.")]
        public string PaciEstado { get; set; }

        [Display(Name = "CEP")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "{0} precisa ter {1} caracteres.")]
        public string PaciCep { get; set; }

        [Display(Name = "Ponto de referência")]
        [MaxLength(250, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string PaciPontoReferencia { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "{0} precisa ter {1} caracteres.")]
        public string PaciCelular { get; set; }

        [Display(Name = "Outro contato")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "{0} precisa ter {1} caracteres.")]
        public string PaciTelefone { get; set; }

        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public string PaciEmail { get; set; }

        [Display(Name = "Atendimento inicial")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? PaciDataInicioAtendimento { get; set; }

        [Display(Name = "Valor consulta")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [Range(0, 999.99)]
        public decimal PaciValorAtendimento { get; set; }

        [Display(Name = "Diagnóstico")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        public string PaciDiagnostico { get; set; }

        [Display(Name = "Patologia")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        public string PaciPatologia { get; set; }

        [Display(Name = "Observação")]
        public string PaciObservacao { get; set; }
    }
}
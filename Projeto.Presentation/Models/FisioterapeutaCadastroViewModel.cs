using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Models
{
    public class FisioterapeutaCadastroViewModel
    {
        [Display(Name = "Fisioterapeuta")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "{0} precisa ter no mínimo {2} e no máximo {1} caracteres.")]
        public string FisiNome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "{0} precisa ter {1} caracteres.")]
        public string FisiCpfCnpj { get; set; }

        [Display(Name = "Crefito 2")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string FisiCrefito { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "{0} precisa ter {1} caracteres.")]
        public string FisiCelular { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public string FisiEmail { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Presentation.Models
{
    public class FisioterapeutaConsultaViewModel
    {
        public int FisiIdentificador { get; set; }

        [Display(Name = "Fisioterapeuta")]
        public string FisiNome { get; set; }

        [Display(Name = "CPF")]
        public string FisiCpfCnpj { get; set; }

        [Display(Name = "Crefito 2")]
        public string FisiCrefito { get; set; }

        [Display(Name = "Celular")]
        public string FisiCelular { get; set; }

        [Display(Name = "Email")]
        public string FisiEmail { get; set; }

        [Display(Name = "Quantidade de fisioterapeutas")]
        public int QuantidadeDeFisioterapeutas { get; set; }
    }
}
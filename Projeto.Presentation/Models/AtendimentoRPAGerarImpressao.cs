using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Projeto.BLL;
using Projeto.Entities;

namespace Projeto.Presentation.Models
{
    public class AtendimentoRPAGerarImpressao
    {
        public string RPAQuantidade { get; set; }
        public string RPAQuantidadePorExtenso { get; set; }
        public string RPADatasAtendimento { get; set; }
        public string RPAPaciNome { get; set; }
        public string RPAPaciCpfCnpj { get; set; }
        public string RPAPaciValorAtendimento { get; set; }
        public string RPAPaciValorAtendimentoPorExtenso { get; set; }
        public string RPAPaciMunicipio { get; set; }
        public string RPAPaciEstado { get; set; }
        public string RPAFisiCpfCnpj { get; set; }
        public string RPAFisiNome { get; set; }
        public string RPAFisiCrefito { get; set; }
        public string RPADataAtual { get; set; }
    }
}
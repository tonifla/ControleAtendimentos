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
    public class AtendimentoRPAViewModel
    {
        [Display(Name = "Data inicial")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? AtenDataInicial { get; set; }

        [Display(Name = "Data final")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? AtenDataFinal { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        public int AtenPaciIdentificador { get; set; }

        [Display(Name = "Fisioterapeuta")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        public int AtenFisiIdentificador { get; set; }

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


        public List<SelectListItem> ListagemDeFisioterapeutas
        {
            get
            {
                FisioterapeutaBusiness business = new FisioterapeutaBusiness();
                List<Fisioterapeuta> consulta = business.ConsultarFisioterapeuta();

                List<SelectListItem> lista = new List<SelectListItem>();
                foreach (Fisioterapeuta fisioterapeuta in consulta)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = fisioterapeuta.FisiIdentificador.ToString();
                    item.Text = fisioterapeuta.FisiNome;
                    lista.Add(item);
                }
                return lista;
            }
        }

        public List<SelectListItem> ListagemDePacientes
        {
            get
            {
                PacienteBusiness business = new PacienteBusiness();
                List<Paciente> consulta = business.ConsultarPaciente();

                List<SelectListItem> lista = new List<SelectListItem>();
                foreach (Paciente paciente in consulta)
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = paciente.PaciIdentificador.ToString();
                    item.Text = paciente.PaciNome;
                    lista.Add(item);
                }
                return lista;
            }
        }
    }
}
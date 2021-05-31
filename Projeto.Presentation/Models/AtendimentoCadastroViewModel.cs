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
    public class AtendimentoCadastroViewModel
    {
        [Display(Name = "Data")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? AtenData { get; set; }

        [Display(Name = "Hora")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Hora em formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? AtenHora { get; set; }

        [Display(Name = "Conduta")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        public string AtenConduta { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        public int AtenPaciIdentificador { get; set; }

        [Display(Name = "Fisioterapeuta")]
        [Required(ErrorMessage = "{0} é campo obrigatório.")]
        public int AtenFisiIdentificador { get; set; }

        [Display(Name = "Enviar email de confirmação.")]
        public bool AtenEnviarEmail { get; set; }

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entities;
using Projeto.BLL;
using Projeto.Presentation.Models;
using AutoMapper;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web;

namespace Projeto.Presentation.Controllers
{
    public class PacienteController : Controller
    {
        private PacienteBusiness business;

        public PacienteController()
        {
            business = new PacienteBusiness();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(PacienteCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Paciente paciente = Mapper.Map<Paciente>(model);

                    business.CadastrarPaciente(paciente);

                    TempData["Mensagem"] = $"Paciente '{paciente.PaciNome}', cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View();
        }

        public ActionResult Consulta()
        {
            List<PacienteConsultaViewModel> lista = new List<PacienteConsultaViewModel>();

            try
            {
                lista = Mapper.Map<List<PacienteConsultaViewModel>>(business.ConsultarPaciente());
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(lista);
        }

        public ActionResult Exclusao(int id)
        {
            try
            {
                business.ExcluirPaciente(id);
                TempData["Mensagem"] = "Paciente excluído com sucesso.";
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return RedirectToAction("consulta");
        }

        public ActionResult Edicao(int id)
        {
            PacienteEdicaoViewModel model = new PacienteEdicaoViewModel();

            try
            {
                model = Mapper.Map<PacienteEdicaoViewModel>(business.ConsultarPacientePorId(id));
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(PacienteEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Paciente paciente = Mapper.Map<Paciente>(model);

                    business.AtualizarPaciente(paciente);

                    TempData["Mensagem"] = $"Paciente '{paciente.PaciNome}', atualizado com sucesso.";
                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View();
        }

        public void Relatorio()
        {
            try
            {
                PacienteBusiness business = new PacienteBusiness();
                List<Paciente> lista = business.ConsultarPaciente();

                StringBuilder conteudo = new StringBuilder();
                conteudo.Append("<h2>Relatório de paciente</h2>");
                conteudo.Append("<p>TM Sistemas</p>");
                conteudo.Append($"<p>Relatório gerado em: {DateTime.Now}</p>");
                conteudo.Append("<br/>");
                conteudo.Append("<br/>");
                conteudo.Append("<table border='1' style='width: 100%'>");
                conteudo.Append("<tr>");
                conteudo.Append("<th>Nome</th>");
                conteudo.Append("<th>CPF / CNPJ</th>");
                conteudo.Append("<th>Endereço completo</th>");
                conteudo.Append("<th>Celular</th>");
                conteudo.Append("<th>Telefone</th>");
                conteudo.Append("<th>Email</th>");
                conteudo.Append("<th>Atendimento inicial</th>");
                conteudo.Append("<th>Valor consulta</th>");
                conteudo.Append("<th>Diagnostico</th>");
                conteudo.Append("<th>Patologia</th>");
                conteudo.Append("<th>Observação</th>");
                conteudo.Append("</tr>");
                foreach (Paciente paciente in lista)
                {
                    conteudo.Append("<tr>");
                    conteudo.Append($"<td>{paciente.PaciNome}</td>");
                    conteudo.Append($"<td>{paciente.PaciCpfCnpj}</td>");
                    conteudo.Append($"<td>{paciente.PaciEndereco}</ td >");
                    conteudo.Append($"<td>{paciente.PaciCelular}</td>");
                    conteudo.Append($"<td>{paciente.PaciTelefone}</td>");
                    conteudo.Append($"<td>{paciente.PaciEmail}</td>");
                    conteudo.Append($"<td>{paciente.PaciDataInicioAtendimento.ToString("dd/MM/yyyy")}</td>");
                    conteudo.Append($"<td>{paciente.PaciValorAtendimento}</td>");
                    conteudo.Append($"<td>{paciente.PaciDiagnostico}</td>");
                    conteudo.Append($"<td>{paciente.PaciPatologia}</td>");
                    conteudo.Append($"<td>{paciente.PaciObservacao}</td>");
                    conteudo.Append("</tr>");
                }
                conteudo.Append("</table>");
                byte[] pdf = null;
                MemoryStream ms = new MemoryStream();
                TextReader reader = new StringReader(conteudo.ToString());
                Document doc = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                HTMLWorker html = new HTMLWorker(doc);
                doc.Open();
                html.StartDocument();
                html.Parse(reader);
                html.EndDocument();
                html.Close();
                doc.Close();
                pdf = ms.ToArray();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename=Pacientes.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(pdf);
                Response.End();
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }
        }
    }
}
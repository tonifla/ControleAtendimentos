using Projeto.BLL;
using Projeto.Entities;
using Projeto.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web;

namespace Projeto.Presentation.Controllers
{
    public class AtendimentoController : Controller
    {
        private AtendimentoBusiness business;

        public AtendimentoController()
        {
            business = new AtendimentoBusiness();
        }

        public ActionResult Cadastro()
        {
            return View(new AtendimentoCadastroViewModel());
        }

        [HttpPost]
        public ActionResult Cadastro(AtendimentoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Atendimento atendimento = Mapper.Map<Atendimento>(model);

                    business.CadastrarAtendimento(atendimento);

                    TempData["Mensagem"] = $"Atendimento {atendimento.AtenData}, cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View(new AtendimentoCadastroViewModel());
        }

        public ActionResult Consulta()
        {
            List<AtendimentoConsultaViewModel> lista = new List<AtendimentoConsultaViewModel>();

            try
            {
                lista = Mapper.Map<List<AtendimentoConsultaViewModel>>(business.ConsultarAtendimento());
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(lista);
        }

        public ActionResult Edicao(int id)
        {
            AtendimentoEdicaoViewModel model = new AtendimentoEdicaoViewModel();

            try
            {
                model = Mapper.Map<AtendimentoEdicaoViewModel>(business.ConsultarAtendimentoPorId(id));
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(AtendimentoEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Atendimento atendimento = Mapper.Map<Atendimento>(model);

                    business.AtualizarAtendimento(atendimento);

                    TempData["Mensagem"] = $"Atendimento {atendimento.AtenData}, atualizado com sucesso.";
                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = e.Message;
                }
            }

            return View(new AtendimentoEdicaoViewModel());
        }

        public ActionResult Exclusao(int id)
        {
            try
            {
                business.ExcluirAtendimento(id);
                TempData["Mensagem"] = "Atendimento excluído com sucesso.";
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return RedirectToAction("Consulta");
        }

        public ActionResult RPAConsultarDados()
        {
            return View(new AtendimentoRPAConsultarDados());
        }

        public ActionResult RPAGerarImpressao(int AtenPaciIdentificador,
                                              int AtenFisiIdentificador,
                                              DateTime AtenDataInicial,
                                              DateTime AtenDataFinal)
        {
            ViewBag.AtenPaciIdentificador = AtenPaciIdentificador;
            ViewBag.AtenFisiIdentificador = AtenFisiIdentificador;
            ViewBag.AtenDataInicial = AtenDataInicial;
            ViewBag.AtenDataFinal = AtenDataFinal;

            AtendimentoRPAGerarImpressao atendimento = new AtendimentoRPAGerarImpressao();
            try
            {
                atendimento = Mapper.Map<AtendimentoRPAGerarImpressao>(business.ConsultarDadosRPA(AtenPaciIdentificador,
                                                                                 AtenFisiIdentificador,
                                                                                 AtenDataInicial,
                                                                                 AtenDataFinal));
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(atendimento);
        }

        public void Relatorio()
        {
            try
            {
                AtendimentoBusiness business = new AtendimentoBusiness();
                List<Atendimento> lista = business.ConsultarAtendimento();

                StringBuilder conteudo = new StringBuilder();
                conteudo.Append("<h2>Relatório de atendimentos</h2>");
                conteudo.Append("<p>TM Sistemas</p>");
                conteudo.Append($"<p>Relatório gerado em: {DateTime.Now}</p>");
                conteudo.Append("<br/>");
                conteudo.Append("<br/>");
                conteudo.Append("<table border='1' style='width: 100%'>");
                conteudo.Append("<tr>");
                conteudo.Append("<th>Nome do paciente</th>");
                conteudo.Append("<th>Nome do fisioterapeuta</th>");
                conteudo.Append("<th>Data</th>");
                conteudo.Append("<th>Hora</th>");
                conteudo.Append("<th>Conduta</th>");
                conteudo.Append("</tr>");
                foreach (Atendimento atendimento in lista)
                {
                    conteudo.Append("<tr>");
                    conteudo.Append($"<td>{atendimento.Paciente.PaciNome}</td>");
                    conteudo.Append($"<td>{atendimento.Fisioterapeuta.FisiNome}</td>");
                    conteudo.Append($"<td>{atendimento.AtenData.ToString("dd/MM/yyyy")}</td>");
                    conteudo.Append($"<td>{atendimento.AtenHora.ToString("HH:mm")}</td>");
                    conteudo.Append($"<td>{atendimento.AtenConduta}</td>");
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
                Response.AddHeader("content-disposition", "attachment; filename=Atendimentos.pdf");
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
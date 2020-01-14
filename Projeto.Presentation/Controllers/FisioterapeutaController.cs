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
    public class FisioterapeutaController : Controller
    {
        private FisioterapeutaBusiness business;

        public FisioterapeutaController()
        {
            business = new FisioterapeutaBusiness();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(FisioterapeutaCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Fisioterapeuta fisioterapeuta = Mapper.Map<Fisioterapeuta>(model);

                    business.CadastrarFisioterapeuta(fisioterapeuta);

                    TempData["Mensagem"] = $"Fisioterapeuta '{fisioterapeuta.FisiNome}', cadastrado com sucesso.";
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
            List<FisioterapeutaConsultaViewModel> lista = new List<FisioterapeutaConsultaViewModel>();

            try
            {
                lista = Mapper.Map<List<FisioterapeutaConsultaViewModel>>(business.ConsultarFisioterapeuta());
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
                business.ExcluirFisioterapeuta(id);
                TempData["Mensagem"] = "Fisioterapeuta excluído com sucesso.";
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return RedirectToAction("consulta");
        }

        public ActionResult Edicao(int id)
        {
            FisioterapeutaEdicaoViewModel model = new FisioterapeutaEdicaoViewModel();

            try
            {
                model = Mapper.Map<FisioterapeutaEdicaoViewModel>(business.ConsultarFisioterapeutaPorId(id));
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(FisioterapeutaEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Fisioterapeuta fisioterapeuta = Mapper.Map<Fisioterapeuta>(model);

                    business.AtualizarFisioterapeuta(fisioterapeuta);

                    TempData["Mensagem"] = $"Fisioterapeuta '{fisioterapeuta.FisiNome}', atualizado com sucesso.";
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
                FisioterapeutaBusiness business = new FisioterapeutaBusiness();
                List<Fisioterapeuta> lista = business.ConsultarFisioterapeuta();

                StringBuilder conteudo = new StringBuilder();
                conteudo.Append("<h2>Relatório de fisioterapeutas</h2>");
                conteudo.Append("<p>TM Sistemas</p>");
                conteudo.Append($"<p>Relatório gerado em: {DateTime.Now}</p>");
                conteudo.Append("<br/>");
                conteudo.Append("<br/>");
                conteudo.Append("<table border='1' style='width: 100%'>");
                conteudo.Append("<tr>");
                conteudo.Append("<th>Nome</th>");
                conteudo.Append("<th>CPF / CNPJ</th>");
                conteudo.Append("<th>Crefito 2</th>");
                conteudo.Append("<th>Celular</th>");
                conteudo.Append("<th>Email</th>");
                conteudo.Append("</tr>");
                foreach (Fisioterapeuta fisioterapeuta in lista)
                {
                    conteudo.Append("<tr>");
                    conteudo.Append($"<td>{fisioterapeuta.FisiNome}</td>");
                    conteudo.Append($"<td>{fisioterapeuta.FisiCpfCnpj}</td>");
                    conteudo.Append($"<td>{fisioterapeuta.FisiCrefito}</td>");
                    conteudo.Append($"<td>{fisioterapeuta.FisiCelular}</td>");
                    conteudo.Append($"<td>{fisioterapeuta.FisiEmail}</td>");
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
                Response.AddHeader("content-disposition", "attachment; filename=Fisioterapeutas.pdf");
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
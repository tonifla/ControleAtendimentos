using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entities;
using Projeto.Util.Models;
using Projeto.Util.Services;

namespace Projeto.BLL
{
    public class AtendimentoBusiness
    {
        private AtendimentoRepository repository;
        private FisioterapeutaRepository repositoryFisioterapeuta;
        private PacienteRepository repositoryPaciente;

        public AtendimentoBusiness()
        {
            repository = new AtendimentoRepository();
            repositoryFisioterapeuta = new FisioterapeutaRepository();
            repositoryPaciente = new PacienteRepository();
        }

        public void CadastrarAtendimento(Atendimento atendimento)
        {
            repository.Insert(atendimento);
            if (atendimento.AtenEnviarEmail)
            {
                EnviarEmailDeNotificacao(atendimento);
            }
        }

        public void AtualizarAtendimento(Atendimento atendimento)
        {
            repository.Update(atendimento);
        }

        public void ExcluirAtendimento(int id)
        {
            repository.Delete(id);
        }

        public List<Atendimento> ConsultarAtendimento()
        {
            return repository.SelectAll();
        }

        public Atendimento ConsultarDadosRPA(int idPaciente,
                                             int idFisioterapeuta,
                                             DateTime dataInicial,
                                             DateTime dataFinal)
        {
            return repository.SelectByDadosRPA(idPaciente,
                                               idFisioterapeuta,
                                               dataInicial,
                                               dataFinal);
        }

        public Atendimento ConsultarAtendimentoPorId(int id)
        {
            return repository.SelectById(id);
        }

        private void EnviarEmailDeNotificacao(Atendimento atendimento)
        {
            var fisioterapeuta = repositoryFisioterapeuta.SelectById(atendimento.AtenFisiIdentificador);
            var paciente = repositoryPaciente.SelectById(atendimento.AtenPaciIdentificador);

            EmailModel model = new EmailModel();
            model.EmailTo = fisioterapeuta.FisiEmail;
            model.Subject = $@"Atendimento do Paciente ({paciente.PaciNome}) cadastrado com sucesso.";
            model.IsBodyHtml = true;
            model.Body = $"Olá {fisioterapeuta.FisiNome}," +
                         $"<br/><br>" +
                         $"Este é um e-mail automático, favor não responda." +
                         $"<br/><br>" +
                         $"Seu cadastro de atendimento foi realizado com sucesso." +
                         $"<br/><br>" +
                         $"Segue as informações deste cadastro:" +
                         $"<br/>" +
                         $"Data:  {String.Format("{0:d}", atendimento.AtenData)}" +
                         $"<br/>" +
                         $"Hora: {String.Format("{0:t}", atendimento.AtenHora)}" +
                         $"<br/>" +
                         $"Conduta: {atendimento.AtenConduta}" +
                         $"<br/><br>" +
                         $"<br/><br>" +
                         $"Atenciosamente," +
                         $"<br/>" +
                         $"<strong>TM Sistemas</strong>";

            EmailService service = new EmailService();
            service.SendMessage(model);
        }

    }
}

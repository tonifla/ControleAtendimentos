using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entities;

namespace Projeto.BLL
{
    public class FisioterapeutaBusiness
    {
        private FisioterapeutaRepository repository;

        public FisioterapeutaBusiness()
        {
            repository = new FisioterapeutaRepository();
        }

        public void CadastrarFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            repository.Insert(fisioterapeuta);
        }

        public void AtualizarFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            repository.Update(fisioterapeuta);
        }

        public void ExcluirFisioterapeuta(int id)
        {
            if (repository.SumQuantidadeAtendimentoFisioterapeutas(id) == 0)
            {
                repository.Delete(id);
            }
            else
            {
                throw new Exception("Não é permitido excluir um fisioterapeuta que contenha atendimentos.");
            }
        }

        public List<Fisioterapeuta> ConsultarFisioterapeuta()
        {
            return repository.SelectAll();
        }

        public Fisioterapeuta ConsultarFisioterapeutaPorId(int id)
        {
            return repository.SelectById(id);
        }

        public int ObterQuantidadeDeAtendimentosFisioterapeuta(int id)
        {
            return repository.SumQuantidadeAtendimentoFisioterapeutas(id);
        }
    }
}

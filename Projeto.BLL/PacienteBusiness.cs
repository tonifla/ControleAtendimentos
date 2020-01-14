using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL;
using Projeto.Entities;

namespace Projeto.BLL
{
    public class PacienteBusiness
    {
        private PacienteRepository repository;

        public PacienteBusiness()
        {
            repository = new PacienteRepository();
        }

        public void CadastrarPaciente(Paciente paciente)
        {
            repository.Insert(paciente);
        }

        public void AtualizarPaciente(Paciente paciente)
        {
            repository.Update(paciente);
        }

        public void ExcluirPaciente(int id)
        {
            if (repository.SumQuantidadeAtendimentoPacientes(id) == 0)
            {
                repository.Delete(id);
            }
            else
            {
                throw new Exception("Não é permitido excluir um paciente que contenha atendimentos.");
            }
        }

        public List<Paciente> ConsultarPaciente()
        {
            return repository.SelectAll();
        }

        public Paciente ConsultarPacientePorId(int id)
        {
            return repository.SelectById(id);
        }

        public int ObterQuantidadeDeAtendimentosPaciente(int id)
        {
            return repository.SumQuantidadeAtendimentoPacientes(id);
        }
    }
}

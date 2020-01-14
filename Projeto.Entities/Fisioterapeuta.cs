using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Fisioterapeuta
    {
        public int FisiIdentificador { get; set; }
        public string FisiNome { get; set; }
        public string FisiCpfCnpj { get; set; }
        public string FisiCrefito { get; set; }
        public string FisiCelular { get; set; }
        public string FisiEmail { get; set; }

        public List<Atendimento> Atendimentos { get; set; }

        public Fisioterapeuta()
        {

        }

        public Fisioterapeuta(int fisiIdentificador, string fisiNome, string fisiCpfCnpj, string fisiCrefito, string fisiCelular, string fisiEmail)
        {
            FisiIdentificador = fisiIdentificador;
            FisiNome = fisiNome;
            FisiCpfCnpj = fisiCpfCnpj;
            FisiCrefito = fisiCrefito;
            FisiCelular = fisiCelular;
            FisiEmail = fisiEmail;
        }

        public override string ToString()
        {
            return $"Id: {FisiIdentificador}, Nome: {FisiNome}, CpfCnpj: {FisiCpfCnpj}, Crefito: {FisiCrefito}, Celular: {FisiCelular}, Email: {FisiEmail}";
        }
    }
}

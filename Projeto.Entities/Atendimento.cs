using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Atendimento
    {
        public int AtenIdentificador { get; set; }
        public DateTime AtenData { get; set; }
        public DateTime AtenHora { get; set; }
        public string AtenConduta { get; set; }
        public int AtenPaciIdentificador { get; set; }
        public int AtenFisiIdentificador { get; set; }

        public bool AtenEnviarEmail { get; set; }


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
        public DateTime AtenDataInicial { get; set; }
        public DateTime AtenDataFinal { get; set; }

        public Paciente Paciente { get; set; }
        public Fisioterapeuta Fisioterapeuta { get; set; }


        public Atendimento()
        {
                
        }

        public Atendimento(int atenIdentificador, DateTime atenData, DateTime atenHora, string atenConduta)
        {
            AtenIdentificador = atenIdentificador;
            AtenData = atenData;
            AtenHora = atenHora;
            AtenConduta = atenConduta;
        }

        public override string ToString()
        {
            return $"Id: {AtenIdentificador}, Data: {AtenData}, Hora: {AtenHora}, Conduta: {AtenConduta}";
        }
    }
}

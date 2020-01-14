using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Paciente
    {
        public int PaciIdentificador { get; set; }
        public string PaciNome { get; set; }
        public string PaciCpfCnpj { get; set; }
        public string PaciEndereco { get; set; }
        public string PaciNumero { get; set; }
        public string PaciComplemento { get; set; }
        public string PaciBairro { get; set; }
        public string PaciMunicipio { get; set; }
        public string PaciEstado { get; set; }
        public string PaciCep { get; set; }
        public string PaciPontoReferencia { get; set; }
        public string PaciCelular { get; set; }
        public string PaciTelefone { get; set; }
        public string PaciEmail { get; set; }
        public DateTime PaciDataInicioAtendimento { get; set; }
        public decimal PaciValorAtendimento { get; set; }
        public string PaciDiagnostico { get; set; }
        public string PaciPatologia { get; set; }
        public string PaciObservacao { get; set; }

        public List<Atendimento> Atendimentos { get; set; }

        public Paciente()
        {

        }

        public Paciente(int paciIdentificador, string paciNome, string paciCpfCnpj, string paciEndereco, string paciNumero, string paciComplemento, string paciBairro, string paciMunicipio, string paciEstado, string paciCep, string paciPontoReferencia, string paciCelular, string paciTelefone, string paciEmail, DateTime paciDataInicioAtendimento, decimal paciValorAtendimento, string paciDiagnostico, string paciPatologia, string paciObservacao)
        {
            PaciIdentificador = paciIdentificador;
            PaciNome = paciNome;
            PaciCpfCnpj = paciCpfCnpj;
            PaciEndereco = paciEndereco;
            PaciNumero = paciNumero;
            PaciComplemento = paciComplemento;
            PaciBairro = paciBairro;
            PaciMunicipio = paciMunicipio;
            PaciEstado = paciEstado;
            PaciCep = paciCep;
            PaciPontoReferencia = paciPontoReferencia;
            PaciCelular = paciCelular;
            PaciTelefone = paciTelefone;
            PaciEmail = paciEmail;
            PaciDataInicioAtendimento = paciDataInicioAtendimento;
            PaciValorAtendimento = paciValorAtendimento;
            PaciDiagnostico = paciDiagnostico;
            PaciPatologia = paciPatologia;
            PaciObservacao = paciObservacao;
        }

        public override string ToString()
        {
            return $"Id: {PaciIdentificador}, Nome: {PaciNome}, CpfCnpj: {PaciCpfCnpj}, Endereço: {PaciEndereco}, Numero: {PaciNumero}, Complemento: {PaciComplemento}, Bairro: {PaciBairro}, Município: {PaciMunicipio}, Estado: {PaciEstado}, Cep: {PaciCep}, PontoReferencia: {PaciPontoReferencia}, Celular: {PaciCelular}, Telefone: {PaciTelefone}, Email: {PaciEmail}, DataInicioAtendimento: {PaciDataInicioAtendimento}, ValorAtendimento: {PaciValorAtendimento}, Diagnóstico: {PaciDiagnostico}, Patologia: {PaciPatologia}, Observação: {PaciObservacao}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Projeto.Entities;
using Dapper;

namespace Projeto.DAL
{
    public class PacienteRepository
    {

        private string connectionString;

        public PacienteRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["projetoFinal"].ConnectionString;
        }

        public void Insert(Paciente paciente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO PACIENTE(PaciNome,
                                 					  PaciCpfCnpj,
                                 					  PaciEndereco,
                                 					  PaciNumero,
                                 					  PaciComplemento,
                                 					  PaciBairro,
                                 					  PaciMunicipio,
                                 					  PaciEstado,
                                 					  PaciCep,
                                 					  PaciPontoReferencia,
                                 					  PaciCelular,
                                 					  PaciTelefone,
                                 					  PaciEmail,
                                 					  PaciDataInicioAtendimento,
                                 					  PaciValorAtendimento,
                                 					  PaciDiagnostico,
                                 					  PaciPatologia,
                                 					  PaciObservacao)
                                 VALUES(@PaciNome,
                                 	     @PaciCpfCnpj,
                                 	     @PaciEndereco,
                                 	     @PaciNumero,
                                 	     @PaciComplemento,
                                 	     @PaciBairro,
                                 	     @PaciMunicipio,
                                 	     @PaciEstado,
                                 	     @PaciCep,
                                 	     @PaciPontoReferencia,
                                 	     @PaciCelular,
                                 	     @PaciTelefone,
                                 	     @PaciEmail,
                                 	     @PaciDataInicioAtendimento,
                                 	     @PaciValorAtendimento,
                                 	     @PaciDiagnostico,
                                 	     @PaciPatologia,
                                 	     @PaciObservacao)";

                conn.Execute(query, paciente);
            }
        }

        public void Update(Paciente paciente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE PACIENTE
                                 SET PaciNome                   = @PaciNome,
                                 	 PaciCpfCnpj                = @PaciCpfCnpj,
                                 	 PaciEndereco               = @PaciEndereco,
                                 	 PaciNumero                 = @PaciNumero,
                                 	 PaciComplemento            = @PaciComplemento,
                                 	 PaciBairro                 = @PaciBairro,
                                 	 PaciMunicipio              = @PaciMunicipio,
                                 	 PaciEstado                 = @PaciEstado,
                                 	 PaciCep                    = @PaciCep,
                                 	 PaciPontoReferencia        = @PaciPontoReferencia,
                                 	 PaciCelular                = @PaciCelular,
                                 	 PaciTelefone               = @PaciTelefone,
                                 	 PaciEmail                  = @PaciEmail,
                                 	 PaciDataInicioAtendimento  = @PaciDataInicioAtendimento,
                                 	 PaciValorAtendimento       = @PaciValorAtendimento,
                                 	 PaciDiagnostico            = @PaciDiagnostico,
                                 	 PaciPatologia              = @PaciPatologia,
                                 	 PaciObservacao             = @PaciObservacao
                                WHERE PaciIdentificador = @PaciIdentificador";

                conn.Execute(query, paciente);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM PACIENTE
                                 WHERE PaciIdentificador = @PaciIdentificador";

                conn.Execute(query, new { PaciIdentificador = id });
            }
        }

        public List<Paciente> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT *
                                 FROM PACIENTE";

                return conn.Query<Paciente>(query).ToList();
            }
        }

        public Paciente SelectById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT *
                                 FROM PACIENTE
                                 WHERE PaciIdentificador = @PaciIdentificador";

                return conn.QuerySingleOrDefault<Paciente>(query, new { PaciIdentificador = id });
            }
        }

        public bool HasCpfCnpj(string cpfCnpj)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT PaciCpfCnpj
                                 FROM PACIENTE
                                 WHERE PaciCpfCnpj = @PaciCpfCnpj";

                return conn.QuerySingleOrDefault<bool>(query, new { PaciCpfCnpj = cpfCnpj });
            }
        }

        public int SumQuantidadeAtendimentoPacientes(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) quantidade
                                 FROM ATENDIMENTO
                                 WHERE AtenPaciIdentificador = @AtenPaciIdentificador";

                return conn.QuerySingleOrDefault<int?>(query, new { AtenPaciIdentificador = id }) ?? 0;
            }
        }
    }
}
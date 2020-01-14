using Dapper;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Projeto.DAL
{
    public class AtendimentoRepository
    {
        private string connectionString;

        public AtendimentoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["projetoFinal"].ConnectionString;
        }

        public void Insert(Atendimento atendimento)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ATENDIMENTO(AtenPaciIdentificador,
                                 					  	 AtenFisiIdentificador,
                                 					  	 AtenData,
                                 					  	 AtenHora,
                                 					  	 AtenConduta)
                                 VALUES(@AtenPaciIdentificador,
                                 	     @AtenFisiIdentificador,
                                 	     @AtenData,
                                 	     @AtenHora,
                                 	     @AtenConduta)";

                conn.Execute(query, atendimento);
            }
        }

        public void Update(Atendimento atendimento)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE ATENDIMENTO
                                 SET AtenPaciIdentificador  = @AtenPaciIdentificador,
                                 	 AtenFisiIdentificador  = @AtenFisiIdentificador,
                                 	 AtenData           	= @AtenData,
                                 	 AtenHora			    = @AtenHora,
                                 	 AtenConduta			= @AtenConduta
                                 WHERE AtenIdentificador = @AtenIdentificador";

                conn.Execute(query, atendimento);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM ATENDIMENTO
                                 WHERE AtenIdentificador = @AtenIdentificador";

                conn.Execute(query, new { AtenIdentificador = id });
            }
        }

        public List<Atendimento> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT *
                                 FROM ATENDIMENTO A
                                 INNER JOIN PACIENTE P          ON P.PaciIdentificador = A.AtenPaciIdentificador
                                 INNER JOIN FISIOTERAPEUTA F	ON F.FisiIdentificador = A.AtenFisiIdentificador";

                return conn.Query
                    (query, (Atendimento a, Paciente p, Fisioterapeuta f) =>
                    {
                        a.Paciente = p;
                        a.Fisioterapeuta = f;
                        return a;
                    },
                    splitOn: "PaciIdentificador, FisiIdentificador")
                    .ToList();
            }
        }

        public Atendimento SelectByDadosRPA(int idPaciente,
                                            int idFisioterapeuta,
                                            DateTime dataInicial,
                                            DateTime dataFinal)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $@"
                                    SELECT DISTINCT COUNT(A.AtenIdentificador) RPAQuantidade,
				                    RTRIM(LTRIM(REPLACE(REPLACE(dbo.ValorPorExtenso(COUNT(A.AtenIdentificador)), 'REAL', ''), 'REAIS', ''))) RPAQuantidadePorExtenso,

				                    (SELECT DISTINCT STUFF((SELECT ', ' + FORMAT(subA.AtenData, 'dd/MM/yyyy')
										                    FROM Atendimento subA
										                    WHERE subA.AtenPaciIdentificador = @AtenPaciIdentificador
										                      AND subA.AtenFisiIdentificador = @AtenFisiIdentificador
										                      AND subA.AtenData BETWEEN @AtenDataInicial AND @AtenDataFinal
										                    FOR XML PATH('')), 1, 2, '')) RPADatasAtendimento,

				                    UPPER(P.PaciNome) RPAPaciNome,
				                    P.PaciCpfCnpj RPAPaciCpfCnpj,
				                    FORMAT(SUM(P.PaciValorAtendimento), 'c', 'pt-br') RPAPaciValorAtendimento,
				                    RTRIM(LTRIM(dbo.ValorPorExtenso(SUM(P.PaciValorAtendimento)))) RPAPaciValorAtendimentoPorExtenso,
				                    UPPER(P.PaciMunicipio) RPAPaciMunicipio,
				                    UPPER(P.PaciEstado) RPAPaciEstado,

				                    F.FisiCpfCnpj RPAFisiCpfCnpj,
				                    UPPER(F.FisiNome) RPAFisiNome,
				                    UPPER(F.FisiCrefito) RPAFisiCrefito,
				                    FORMAT(GETDATE(), 'dd/MM/yyyy') RPADataAtual
				                    FROM ATENDIMENTO A
				                    INNER JOIN PACIENTE P       ON P.PaciIdentificador = A.AtenPaciIdentificador
				                    INNER JOIN FISIOTERAPEUTA F	ON F.FisiIdentificador = A.AtenFisiIdentificador
				                    WHERE A.AtenPaciIdentificador   = @AtenPaciIdentificador
				                      AND A.AtenFisiIdentificador   = @AtenFisiIdentificador
				                      AND A.AtenData BETWEEN @AtenDataInicial AND @AtenDataFinal
				                    GROUP BY P.PACINOME, P.PACICPFCNPJ, P.PACIMUNICIPIO, P.PACIESTADO,
						                        F.FISICPFCNPJ, F.FISINOME, F.FISICREFITO
                                ";

                return conn.QueryFirstOrDefault<Atendimento>(query, new
                {
                    AtenPaciIdentificador = idPaciente,
                    AtenFisiIdentificador = idFisioterapeuta,
                    AtenDataInicial       = dataInicial,
                    AtenDataFinal         = dataFinal
                });
            }
        }

        public Atendimento SelectById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT *
                                 FROM ATENDIMENTO A
                                 INNER JOIN PACIENTE P          ON P.PaciIdentificador = A.AtenPaciIdentificador
                                 INNER JOIN FISIOTERAPEUTA F	ON F.FisiIdentificador = A.AtenFisiIdentificador
                                 WHERE AtenIdentificador = @AtenIdentificador ";

                return conn.Query
                    (query, (Atendimento a, Paciente p, Fisioterapeuta f) =>
                    {
                        a.Paciente = p;
                        a.Fisioterapeuta = f;
                        return a;
                    },
                    new { AtenIdentificador = id },
                    splitOn: "PaciIdentificador, FisiIdentificador")
                    .SingleOrDefault();
            }
        }
    }
}

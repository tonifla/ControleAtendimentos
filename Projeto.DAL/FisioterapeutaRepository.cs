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
    public class FisioterapeutaRepository
    {
        private string connectionString;

        public FisioterapeutaRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["projetoFinal"].ConnectionString;
        }

        public void Insert(Fisioterapeuta fisioterapeuta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO FISIOTERAPEUTA(FisiNome,
                                                            FisiCpfCnpj,
                                                			FisiCrefito,
                                                			FisiCelular,
                                                			FisiEmail)
                                 VALUES(@FisiNome,
                                        @FisiCpfCnpj,
                                        @FisiCrefito,
                                        @FisiCelular,
                                        @FisiEmail)";

                conn.Execute(query, fisioterapeuta);
            }
        }

        public void Update(Fisioterapeuta fisioterapeuta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE FISIOTERAPEUTA
                                 SET FisiNome    = @FisiNome,
                                 	 FisiCpfCnpj = @FisiCpfCnpj,
                                 	 FisiCrefito = @FisiCrefito,
                                 	 FisiCelular = @FisiCelular,
                                 	 FisiEmail   = @FisiEmail
                                 WHERE FisiIdentificador = @FisiIdentificador";

                conn.Execute(query, fisioterapeuta);
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM FISIOTERAPEUTA
                                 WHERE FisiIdentificador = @FisiIdentificador";

                conn.Execute(query, new { FisiIdentificador = id });
            }
        }

        public List<Fisioterapeuta> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT *
                                 FROM FISIOTERAPEUTA";

                return conn.Query<Fisioterapeuta>(query).ToList();
            }
        }

        public Fisioterapeuta SelectById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT *
                                 FROM FISIOTERAPEUTA
                                 WHERE FisiIdentificador = @FisiIdentificador";

                return conn.QuerySingleOrDefault<Fisioterapeuta>(query, new { FisiIdentificador = id });
            }
        }

        public bool HasCpfCnpj(string cpfCnpj)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT FisiCpfCnpj
                                 FROM FISIOTERAPEUTA
                                 WHERE FisiCpfCnpj = @FisiCpfCnpj";

                return conn.QuerySingleOrDefault<bool>(query, new { FisiCpfCnpj = cpfCnpj });
            }
        }

        public int SumQuantidadeAtendimentoFisioterapeutas(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) quantidade
                                 FROM ATENDIMENTO
                                 WHERE AtenFisiIdentificador = @AtenFisiIdentificador";

                return conn.QuerySingleOrDefault<int?>(query, new { AtenFisiIdentificador = id }) ?? 0;
            }
        }
    }
}

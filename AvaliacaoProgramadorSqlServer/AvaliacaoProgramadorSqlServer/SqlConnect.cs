using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AvaliacaoProgramadorSqlServer
{
    public class SqlConnect
    {
        private readonly SqlConnectionStringBuilder _builder;
        
        public SqlConnect(string server, string userId, string password, string database)
        {
            _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = server;
            _builder.UserID = userId;
            _builder.Password = password;
            _builder.InitialCatalog = database;
            _builder.TrustServerCertificate = true;
        }

        public async Task<List<Tabela>> SelectTabela()
        {
            List<Tabela> list = new List<Tabela>();

            using (SqlConnection connect = new SqlConnection(_builder.ConnectionString))
            {
                connect.Open();       

                String sql = "select * from Tabela t WHERE descricao  in (select descricao  from Tabela t2  group by descricao  having count(*)>1)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Tabela
                            {
                                Codigo = reader.GetInt32(0).ToString(),
                                Descricao = reader.GetString(1)
                            });
                        }
                    }
                }                    
            }

            return list;
        }
    }
}
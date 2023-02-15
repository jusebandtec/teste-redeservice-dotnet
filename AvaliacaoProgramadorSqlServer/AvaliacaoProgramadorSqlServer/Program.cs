using System;
using System.Linq;
using System.Threading.Tasks;

namespace AvaliacaoProgramadorSqlServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sqlConnection = new SqlConnect("127.0.0.1", "sa", "@urubu100#", "db_teste_sqlserver");
            var lista = await sqlConnection.SelectTabela();
            if (!lista.Any())
                Console.WriteLine("Não encontramos nenhum registro igual");

            foreach (var item in lista)
            {
                Console.WriteLine($"Código: {item.Codigo}, Descrição: {item.Descricao}");
            }

            Console.WriteLine();
            Console.WriteLine($"Há {lista.Count} valores repetidos de descrição na tabela: Tabela");
        }
    }
}
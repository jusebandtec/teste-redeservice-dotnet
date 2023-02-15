using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AvalicaoProgramadorDotNet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string directoryPath = "/home/yoseph/Documentos/estudos/c#/AvalicaoProgramadorDotNet/arquivos_gerar/";

            // OrdenarNumerosSalvarArquivo(directoryPath, "numeros_ordenar.txt");
            // CriarListaSalvarArquivo(directoryPath + "data.json");
            // var lista = LerArquivoJson(directoryPath + "data.json");

            
            // table.PrintLine();
            // table.PrintRow("Numero", "Descrição");
            // table.PrintLine();
            // foreach (var clsTeste in lista)
            // {
            //     table.PrintRow(clsTeste.Numero.ToString(), clsTeste.Descricao);
            // }
            // table.PrintLine();
            // Console.ReadLine();

            var consultarApiViaCep = new ConsultarApiViaCep();
            var consultar = await consultarApiViaCep.ConsultarCep("09781220");
            consultarApiViaCep.FormarGrid(consultar);
           

            var consultarBancosBrasileiros = new ConsultarBancosBrasileiros();
            var listaBancos = await consultarBancosBrasileiros.Listar();
            consultarBancosBrasileiros.FormarGrid(listaBancos);

            var downloadImage = new DownloadImage();
            await downloadImage.Download("https://redeservice.com.br/wp-content/uploads/2020/07/redeservice-logo.png",
                @"/home/yoseph/Documentos/estudos/c#/AvalicaoProgramadorDotNet/arquivos_gerar/redeservice-logo.png");
        }
        
        private static void OrdenarNumerosSalvarArquivo(string directoryPath, string fileName)
        {
            var numerosAleatoriosStr = Console.ReadLine();
            var numerosAleatoriosArray = numerosAleatoriosStr?.ToCharArray();

            int[] numerosOrdenados = numerosAleatoriosArray?.Select(Char.ToString).Select(int.Parse).OrderBy(i => i).ToArray();

            using (StreamWriter writer = new StreamWriter($"{directoryPath}/{fileName}"))
            {
                foreach (var numerosOrdenado in numerosOrdenados)
                {
                    Console.Write(numerosOrdenado);
                    writer.WriteLine(numerosOrdenado);
                }
            }
        }

        private static void CriarListaSalvarArquivo(string path)
        {
            List<ClasseTeste> listaClasseTeste = new List<ClasseTeste>();

            for (int i = 1; i <= 100; i++)
            {
                listaClasseTeste.Add(new ClasseTeste
                {
                    Numero = i,
                    Descricao = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt")
                });
            }
            
            File.WriteAllText(path, JsonConvert.SerializeObject(listaClasseTeste));
        }

        private static List<ClasseTeste> LerArquivoJson(string path)
        {
            string text = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<ClasseTeste>>(text);
        }
        
    }
}
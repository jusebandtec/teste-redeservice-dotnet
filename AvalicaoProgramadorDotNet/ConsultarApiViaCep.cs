using System.Net.Http;
using System.Threading.Tasks;
using AvalicaoProgramadorDotNet.Response;
using Newtonsoft.Json;

namespace AvalicaoProgramadorDotNet
{
    public class ConsultarApiViaCep
    {
        private readonly HttpClient _httpClient;

        public ConsultarApiViaCep()
        {
            this._httpClient = new HttpClient();
        }

        public async Task<ConsultarApiViaCepResponseData> ConsultarCep(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ConsultarApiViaCepResponseData>(result);
        }

        public void FormarGrid(ConsultarApiViaCepResponseData consultar)
        {
            var table = new TableConsoleApplication(200);
            table.PrintLine();
            table.PrintRow("CEP", "Logradouro", "Complemento", "Bairro", "Localidade", "UF", "IBGE", "gia", "ddd", "siafi");
            table.PrintLine();
            table.PrintRow(consultar.Cep, consultar.Logradouro, consultar.Complemento, consultar.Bairro, consultar.Localidade, consultar.Uf, consultar.Ibge, consultar.Gia, consultar.Ddd, consultar.Siafi);
            table.PrintLine();
        }
    }
}
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AvalicaoProgramadorDotNet.Response;
using Newtonsoft.Json;

namespace AvalicaoProgramadorDotNet
{
    public class ConsultarBancosBrasileiros
    {
        private readonly HttpClient _httpClient;

        public ConsultarBancosBrasileiros()
        {
            this._httpClient = new HttpClient();
        }

        public async Task<List<ListarBancosBrasileirosResponseData>> Listar()
        {
            var response = await _httpClient.GetAsync("https://brasilapi.com.br/api/banks/v1");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ListarBancosBrasileirosResponseData>>(result);
        }

        public void FormarGrid(List<ListarBancosBrasileirosResponseData> listaBancos)
        {
            var tableGridBancos = new TableConsoleApplication(140);
            tableGridBancos.PrintLine();
            tableGridBancos.PrintRow("ISPB", "Name", "Code", "FullName");
            tableGridBancos.PrintLine();
            foreach (var banco in listaBancos)
            {
                tableGridBancos.PrintRow(banco.Ispb, banco.Name, banco.Code ?? "null" , banco.FullName);
            }
            tableGridBancos.PrintLine();
        }
    }
}
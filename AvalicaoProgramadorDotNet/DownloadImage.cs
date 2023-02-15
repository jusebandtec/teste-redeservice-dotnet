using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace AvalicaoProgramadorDotNet
{
    public class DownloadImage
    {
        private readonly HttpClient _httpClient;

        public DownloadImage()
        {
            this._httpClient = new HttpClient();
        }

        public async Task Download(string uri, string outputPath)
        {
            Uri uriResult;

            if (!Uri.TryCreate(uri, UriKind.Absolute, out uriResult))
                throw new InvalidOperationException("URI is invalid.");

            byte[] fileBytes = await _httpClient.GetByteArrayAsync(uri);
            File.WriteAllBytes(outputPath, fileBytes);

            Console.WriteLine("Imagem Baixada");
        }
    }
}
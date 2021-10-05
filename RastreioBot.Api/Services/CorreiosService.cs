using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RastreioBot.Api.Interfaces.Services;
using RastreioBot.Api.Models.Api.Response;
using RastreioBot.Api.Models.Correios;
using RastreioBot.Api.Utils;

namespace RastreioBot.Api.Services
{
    public class CorreiosService : ICorreiosService
    {
        public async Task<List<TrackingResponse>> GetTrackings(List<string> trackings)
        {
            try
            {
                var response = await ExecuteRequest(trackings.ToXmlRequest());

                if (response.IsNull())
                    return null;

                return response.ToResponse();
            }
            catch
            {
                return null;
            }
        }

        private async Task<CorreiosResponse> ExecuteRequest(string xmlRequest)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://webservice.correios.com.br/service/rest/rastro/rastroMobile");

                byte[] bytes;
                bytes = Encoding.ASCII.GetBytes(xmlRequest);

                request.ContentType = "text/xml; encoding='utf-8'";
                request.ContentLength = bytes.Length;
                request.Method = "POST";

                var requestStream = await request.GetRequestStreamAsync();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();

                var response = await request.GetResponseAsync();
                return JsonConvert.DeserializeObject<CorreiosResponse>(response.ReadToEnd());
            }
            catch
            {
                throw;
            }
        }
    }
}
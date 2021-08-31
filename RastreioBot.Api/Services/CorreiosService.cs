using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RastreioBot.Api.Interfaces.Services;
using RastreioBot.Api.Models.Errors;

namespace RastreioBot.Api.Services
{
    public class CorreiosService : ICorreiosService
    {
        public async Task<object> GetTrackings(string xmlRequest)
        {
            try
            {
                var response = await ExecuteRequest(xmlRequest);

                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var responseStream = response.GetResponseStream();
                    return await new StreamReader(responseStream).ReadToEndAsync();
                }

                return null;
            }
            catch (Exception ex)
            {
                return new ErrorResponse("Ocorreu um erro ao buscar os rastreamentos.", ex.Message);
            }
        }

        private async Task<HttpWebResponse> ExecuteRequest(string xmlRequest)
        {
            try
            {
                var url = $"http://webservice.correios.com.br/service/rest/rastro/rastroMobile";
                var request = (HttpWebRequest)WebRequest.Create(url);

                byte[] bytes;
                bytes = Encoding.ASCII.GetBytes(xmlRequest);

                request.ContentType = "text/xml; encoding='utf-8'";
                request.ContentLength = bytes.Length;
                request.Method = "POST";

                var requestStream = await request.GetRequestStreamAsync();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();

                return (HttpWebResponse)await request.GetResponseAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
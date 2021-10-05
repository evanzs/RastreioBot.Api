using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RastreioBot.Api.Interfaces;
using RastreioBot.Api.Interfaces.Services;
using RastreioBot.Api.Models.Api.Response;
using RastreioBot.Api.Models.Correios;
using RastreioBot.Api.Utils;

namespace RastreioBot.Api.Services
{
    public class CorreiosService : ICorreiosService
    {
        private readonly ITrackingService _trackingService;

        public CorreiosService(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        public async Task<List<TrackingResponse>> GetTrackings(List<string> trackings)
        {
            try
            {
                var response = await ExecuteRequest(trackings.ToXmlRequest());

                if (response.IsNull())
                    return null;

                return ToResponse(response);
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

        private List<TrackingResponse> ToResponse(CorreiosResponse correiosResponse)
        {
            var response = new List<TrackingResponse>();

            foreach (var obj in correiosResponse.Objeto)
            {
                var events = new List<Event>();

                foreach (var ev in obj.Evento)
                {
                    var date = ConvertStringDateToDateTime(ev.Data, ev.Hora);

                    if (ev.Destino.IsNullOrEmpty())
                    {
                        events.Add(new Event(date, ev.Descricao, ev.Unidade.Local,
                                                                 ev.Unidade.Tipounidade, ev.Unidade.Cidade,
                                                                 ev.Unidade.Uf));

                        continue;
                    }

                    var destiny = ev.Destino.FirstOrDefault();
                    events.Add(new Event(date, ev.Descricao, ev.Unidade.Local,
                                         ev.Unidade.Tipounidade, ev.Unidade.Cidade,
                                         ev.Unidade.Uf, destiny.Local,
                                         destiny.Cidade, destiny.Uf));
                }

                var description = GetTrackingDescriptionAsync(obj.Numero).Result;
                response.Add(new TrackingResponse(obj.Numero, description, events));
            }

            // return response.OrderByDate();
            return response;
        }

        private DateTime ConvertStringDateToDateTime(string date, string hour)
        {
            var dateArray = date.Split("/");
            var hourArray = hour.Split(":");

            var day = dateArray[0].ToInt32();
            var month = dateArray[1].ToInt32();
            var year = dateArray[2].ToInt32();
            var hours = hourArray[0].ToInt32();
            var minutes = hourArray[1].ToInt32();

            return new DateTime(year, month, day, hours, minutes, 0);
        }

        private async Task<string> GetTrackingDescriptionAsync(string trackingNumber)
        {
            var tracking = await _trackingService.GetTrackingRecordByNumberAsync(trackingNumber);
            return tracking.Description;
        }
    }
}
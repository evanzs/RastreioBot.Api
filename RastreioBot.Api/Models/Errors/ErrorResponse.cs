using System.Text.Json.Serialization;

namespace RastreioBot.Api.Models.Errors
{
    public class ErrorResponse
    {
        public ErrorResponse(string message, string error)
        {
            Message = message;
            Error = error;
        }

        [JsonPropertyName("message")]
        public string Message { get; private set; }

        [JsonPropertyName("error")]
        public string Error { get; private set; }
    }
}
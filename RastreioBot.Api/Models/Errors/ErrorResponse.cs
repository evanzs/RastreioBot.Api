using System.Text.Json.Serialization;

namespace RastreioBot.Api.Models.Errors
{
    public class ErrorResponse
    {
        public ErrorResponse(string message)
        {
            Message = message;
        }

        [JsonPropertyName("message")]
        public string Message { get; private set; }
    }
}
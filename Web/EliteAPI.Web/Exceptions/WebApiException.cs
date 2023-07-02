namespace EliteAPI.Web.Exceptions;

public class WebApiException : Exception
{
    public WebApiException(string error, HttpResponseMessage response) : base(BuildMessage(error, response))
    {
    }

    public WebApiException(string error, HttpResponseMessage response, Exception innerException) : base(
        BuildMessage(error, response), innerException)
    {
    }

    private static string BuildMessage(string error, HttpResponseMessage response)
    {
        return $"{(int) response.StatusCode} request failed ({response.StatusCode}). {response.ReasonPhrase}: {error}.";
    }
}
namespace SportsStore.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            return request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}

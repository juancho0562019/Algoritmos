
namespace Cliente.ConsultaAPI.Client
{
    public class LoggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
           
            try
            {
                var response = await base.SendAsync(request, cancellationToken);

               

                return response;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}

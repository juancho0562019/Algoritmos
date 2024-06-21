using Cliente.ConsultaAPI.Client;
using Cliente.ConsultaAPI.Client.Api.Algoritmos.Auth.Request;
using Cliente.ConsultaAPI.Commons;
using Cliente.ConsultaAPI.Commons.Abstracts;
using Cliente.ConsultaAPI.Commons.Results;

namespace Cliente.ConsultaAPI.Steps
{
    public class AuthenticateStep : Step
    {
        public AuthenticateStep(IApiClient apiClient, IProgress<string> progress)
            : base(apiClient, progress) { }

        protected override async Task<bool> AuthenticateIfNeeded(Context context)
        {
            return await Task.FromResult(true);
        }

        protected override async Task<StepResult> ExecuteStepAsync(Context context)
        {

            if (context.TokenExpiration > DateTime.Now) 
            {
                SendMessage("Token valido.");
                return StepResult.Ok();
            }
                

            var authRequest = new AuthRequest
            {
                Username = context.Usuario,
                Password = context.Clave
            };

            var response = await apiClient.AlgoritmoClient.Auth(authRequest);
            if (response != null && !string.IsNullOrEmpty(response.AccessToken))
            {
                SendMessage("Autenticación exitosa.");

                context.Token = response.AccessToken;
                context.TokenExpiration = response.ExpirationToken;
                context.Retry = true;
                return StepResult.Ok();
            }
            else
            {
                context.Retry = false;
                SendMessage("Fallo en la autenticación.");
                return StepResult.Fail("Fallo en la autenticación.");
            }

        }
        protected override bool ShouldRetry()
        {
            return false;
        }
    }

}

using Cliente.ConsultaAPI.Client;
using Cliente.ConsultaAPI.Client.Api.Algoritmos.Solucion.Request;
using Cliente.ConsultaAPI.Commons;
using Cliente.ConsultaAPI.Commons.Abstracts;
using Cliente.ConsultaAPI.Commons.Results;

namespace Cliente.ConsultaAPI.Steps
{
    public class ConsultaAlgoritmoStep : Step
    {
        private readonly AuthenticateStep authenticateStep;

        public ConsultaAlgoritmoStep(IApiClient apiClient, AuthenticateStep authenticateStep, IProgress<string> progress)
            : base(apiClient, progress)
        {
            this.authenticateStep = authenticateStep;
        }

        protected override async Task<bool> AuthenticateIfNeeded(Context context)
        {
            if (string.IsNullOrEmpty(context.Token) || DateTime.Now >= context.TokenExpiration.AddSeconds(-20))
            {
                var result = await authenticateStep.ExecuteAsync(context);
                return result.Equals(true);
            }
            return true;
        }

        protected override async Task<StepResult> ExecuteStepAsync(Context context)
        {
            if (context == null)
                throw new InvalidOperationException("Context must be not null");

            if (!await AuthenticateIfNeeded(context))
            {
                SendMessage("La autenticación es requerida antes de ejecutar la consulta.");
                return StepResult.Fail("La autenticación es requerida antes de ejecutar la consulta.");
            }

            //if (string.IsNullOrEmpty(context.Cadena))
            //{
            //    SendMessage("No se ha proporcionado una cadena para consultar.");
            //    return StepResult.Fail("No se ha proporcionado una cadena para consultar.");
            //}


            var searchRequest = new ConsultarPatronRequest
            {
                Token = context.Token,
                Cadena = context.Cadena
            };
           
                var response = await apiClient.AlgoritmoClient.ConsultarPatronAsync(searchRequest);
                if (response != null)
                {
                    SendMessage($"$$$$$$$$$$$$$$$$$$$$$$$$");
                    SendMessage($"{response.Respuesta}");
                    SendMessage($"$$$$$$$$$$$$$$$$$$$$$$$$");
                    SendMessage($"Paso ejecutado exitosamente");
                    return StepResult.Ok();
                }
                else
                {
                    SendMessage($"Status consulta no arrojo ningun resultado");
                    return StepResult.Fail($"Status consulta no arrojo ningun resultado");
                }
            
            

           

        }

        protected override bool ShouldRetry()
        {
            return false;
        }
    }

}

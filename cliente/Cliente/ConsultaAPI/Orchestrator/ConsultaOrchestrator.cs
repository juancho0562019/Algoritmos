using Cliente.ConsultaAPI.Client;
using Cliente.ConsultaAPI.Commons;
using Cliente.ConsultaAPI.Commons.Abstracts;
using Cliente.ConsultaAPI.Steps;


namespace Cliente.ConsultaAPI.Orchestrator
{
    public class ConsultaOrchestrator : OrquestadorBase
    {
        public ConsultaOrchestrator(IApiClient client, IProgress<string> progress, Context context) : base(progress, context)
        {
            var authStep = new AuthenticateStep(client, progress);
            steps.Add(authStep);
            steps.Add(new ConsultaAlgoritmoStep(client, authStep, progress));
        }
    }
}

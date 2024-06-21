using Cliente.ConsultaAPI.Client;
using Cliente.ConsultaAPI.Client.Exceptions;
using Cliente.ConsultaAPI.Commons.Interfaces;
using Cliente.ConsultaAPI.Commons.Results;
using System.Diagnostics;

namespace Cliente.ConsultaAPI.Commons.Abstracts
{
    public abstract class Step : IStep
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly IProgress<string> progress;
        protected readonly IApiClient apiClient;

        protected Step(IApiClient apiClient, IProgress<string> progress)
        {
            this.apiClient = apiClient;
            this.progress = progress;
        }
        public async Task<IStepResult> ExecuteAsync(Context context)
        {
            stopwatch.Start();
            SendMessage($"<------ Iniciando {GetType().Name} ------>");

            bool isAuthenticated = await AuthenticateIfNeeded(context);
            if (!isAuthenticated)
            {
                SendMessage("Token vencido o sin autenticación.");
                stopwatch.Stop();
                return StepResult.Fail("Token vencido o sin autenticación.");
            }

            var result = await ExecuteStepWithRetries(context);
            SendMessage($"[{stopwatch.ElapsedMilliseconds}ms] <------ Finalizando {GetType().Name} ------>");
            stopwatch.Stop();

            return result;
        }

        private async Task<StepResult> ExecuteStepWithRetries(Context context)
        {
            const int maxRetries = 3;
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    var result = await ExecuteStepAsync(context);
                    if (result.Success)
                    {
                        return result;
                    }
                    else if (retryCount < maxRetries - 1 && ShouldRetry())
                    {
                        SendMessage("Reintentando...");
                        await Task.Delay((int)Math.Pow(2, retryCount) * 1000);
                    }
                    else if (!ShouldRetry())
                    {
                        break;
                    }
                }
                catch (CustomException ex)
                {
                    SendMessage($"Excepción en {GetType().Name}: {ex.Message}");
                    if (retryCount == maxRetries - 1 || !ShouldRetry())
                    {
                        return StepResult.Fail($"{ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    SendMessage($"Excepción en {GetType().Name}: {ex.Message}");
                    if (retryCount == maxRetries - 1)
                    {
                        return StepResult.Fail($"Excepción no manejada: {ex.Message}");
                    }
                }
                retryCount++;
            }

            return StepResult.Fail("Falló después de reintentos.");
        }

        protected virtual bool ShouldRetry()
        {
            return true;
        }

        protected abstract Task<StepResult> ExecuteStepAsync(Context context);
        protected virtual async Task<bool> AuthenticateIfNeeded(Context context)
        {
            if (!string.IsNullOrEmpty(context.Token) && DateTime.UtcNow < context.TokenExpiration)
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }
        protected void SendMessage(string text)
        {
            progress.Report($" {text}");
        }

        protected static async Task DelayUntilNextMinuteIfNeeded(int remaining)
        {
            if (remaining == 0)
            {
                var currentTime = DateTime.UtcNow;
                var waitTime = 60 - currentTime.Second + (currentTime.Millisecond * 0.001);
                await Task.Delay((int)(waitTime * 1000));
            }
        }
      
      
    }

}

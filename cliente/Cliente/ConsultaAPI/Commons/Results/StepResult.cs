using Cliente.ConsultaAPI.Commons.Interfaces;

namespace Cliente.ConsultaAPI.Commons.Results
{
    
    public class StepResult : IStepResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public static StepResult Fail(string message) => new StepResult { Success = false, ErrorMessage = message };
        public static StepResult Ok() => new StepResult { Success = true };
    }
}

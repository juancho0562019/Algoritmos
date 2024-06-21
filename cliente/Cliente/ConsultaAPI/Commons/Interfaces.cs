

using Cliente.ConsultaAPI.Commons.Interfaces;

namespace Cliente.ConsultaAPI.Commons
{
    public interface IStep
    {
        Task<IStepResult> ExecuteAsync(Context context);
    }
}

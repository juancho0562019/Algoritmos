using Cliente.ConsultaAPI.Commons.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.ConsultaAPI.Commons.Interfaces
{
    public interface IStep
    {
        Task<IStepResult> ExecuteAsync(Context context);
    }
}

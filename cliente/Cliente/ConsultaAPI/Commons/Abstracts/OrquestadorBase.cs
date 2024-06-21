using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.ConsultaAPI.Commons.Abstracts
{
    public abstract class OrquestadorBase
    {
        protected readonly IProgress<string> _progress;
        protected readonly Context _context;
        protected List<IStep> steps = new List<IStep>();

        public OrquestadorBase(IProgress<string> progress, Context context)
        {
            _progress = progress;
            _context = context;
        }

        public virtual async Task ExecuteProcess()
        {
            foreach (var step in steps)
            {
                try
                {
                    var result = await step.ExecuteAsync(_context);
                    if (!result.Success)
                    {
                        _progress.Report($"Error en el paso: {step.GetType().Name}, Mensaje: {result.ErrorMessage}");
                        break;
                    }

                }
                catch (Exception e)
                {
                    _progress.Report($"Error inesperado en el paso: {step.GetType().Name}, Detalle: {e.Message}");
                    break;
                }
            }
        }

        protected void AddStep(IStep step)
        {
            steps.Add(step);
        }
    }
}

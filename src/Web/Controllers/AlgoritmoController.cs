using Application.Features.Algoritmos.GetSolucion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de pólizas
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AlgoritmoController : ApiControllerBase
    {
        

    
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [SpecialAuthorizeAttribute(Feature = "GetSolucionAlgoritmo")]
        public async Task<ActionResult> GetSolucionAlgoritmo([FromQuery] GetSolucionAlgoritmoRequest query)
        {
            return await base.Send<GetSolucionAlgoritmoRequest, GetSolucionAlgoritmoResponse>(query);
        }
    }
}

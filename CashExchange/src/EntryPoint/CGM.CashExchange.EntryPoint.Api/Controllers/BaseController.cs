using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CGM.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {

        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}

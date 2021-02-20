using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerVehicle.UI.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private IMediator _mediator;

        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

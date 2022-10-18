using CGM.CashExchange.Core.Application.Features.Cliente.Queries;
using CGM.CashExchange.Core.Application.Features.Operacion.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Features.Cliente.Validators
{
    public class GetBusquedaClienteMaccordQueryValidator : AbstractValidator<GetBusquedaClienteMaccordQuery>
    {
        public GetBusquedaClienteMaccordQueryValidator()
        {
            //RuleFor(x => x.Documento).MinimumLength(100).WithMessage("El valor del monto debe ser mayor a 1000 euros."); ;
        }
    }
}

using CGM.CashExchange.Core.Application.Features.Operacion.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Application.Features.Operacion.Validators
{
    public class CrearOperacionCommandValidator : AbstractValidator<CrearOperacionCommand>
    {
        public CrearOperacionCommandValidator()
        {

            RuleFor(x => x.IdCajero)
               .GreaterThan(0)
               .WithMessage("Ingrese un número de cajero valido.");
            RuleFor(x => x.Monto)
               .GreaterThanOrEqualTo(1000)
               .WithMessage("El valor del monto debe ser mayor a 1000 euros.");
        }
    }
}

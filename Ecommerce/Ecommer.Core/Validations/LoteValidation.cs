﻿using Ecommerce.Common.DataMembers.Input;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Validations
{
    public class LoteValidation : AbstractValidator<Lote>
    {
        public LoteValidation()
        {
            //RuleFor(x => x.Desde).Must(ValidationFechaActual).WithMessage("La fecha desde debe ser mayor que la fecha actual.");
        }
    }
}

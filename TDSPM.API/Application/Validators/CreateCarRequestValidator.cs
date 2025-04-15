﻿using FluentValidation;
using TDSPM.API.Application.DTOs;
using TDSPM.API.Domain.Entity;

namespace TDSPM.API.Application.Validators
{
    public class CreateCarRequestValidator : AbstractValidator<CreateCarRequest>
    {
        public CreateCarRequestValidator()
        {
            RuleFor(c => c.Plate)
                .NotEmpty()
                .WithMessage("A placa é obrigatória.")
                .Matches(@"^[A-Z]{3}\d{4}$|^[A-Z]{3}[0-9][A-Z][0-9]{2}$")
                .WithMessage("A placa deve estar no formato válido (ABC1234 ou ABC1D23).");

            RuleFor(c => c.Motorization)
                .NotEmpty()
                .WithMessage("Motorização é obrigatória.")
                .MaximumLength(50)
                .WithMessage("Motorização deve ter no máximo 50 caracteres.");

            RuleFor(c => c.March)
                .IsInEnum()
                .WithMessage("Marcha inválida.");

            RuleFor(c => c.BrandId)
                .NotEmpty()
                .WithMessage("Marca do carro é obrigatória.");
        }

        public void ValidateMessage(CreateCarRequest createCarRequest)
        {
            var result = Validate(createCarRequest);
            if (!result.IsValid)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }
        }
    }
}

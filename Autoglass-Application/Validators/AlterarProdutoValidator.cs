﻿using Autoglass_Application.Dtos;
using FluentValidation;

namespace Autoglass_Application.Validators
{
    public class AlterarProdutoValidator : AbstractValidator<AlterarProdutoDto>
    {
        public AlterarProdutoValidator()
        {
            RuleFor(c => c.Descricao)
                 .NotEmpty().WithMessage("Favor Inserir uma Descrição do produto.");
           
            RuleFor(c => c.DataFabricacao)
                .NotEqual(p => p.DataValidade).WithMessage("A data de Fabricação não pode ser igual a data de validade")
                .LessThan(p => p.DataFabricacao).WithMessage("A data de Fabricação não pode ser maior que a data de validade")
                .NotEmpty().WithMessage("Favor Inserir a data de fabricação.");
            RuleFor(c => c.DataValidade)
                .NotEmpty().WithMessage("Favor Inserir a data de validade.");
        }


    }
}

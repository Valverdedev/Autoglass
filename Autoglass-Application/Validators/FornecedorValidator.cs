using Autoglass_Application.Dtos;
using FluentValidation;
using System;

namespace Autoglass_Application.Validators
{
    public class FornecedorValidator : AbstractValidator<CriarFornecedortDto>
    {
        public FornecedorValidator()
        {
            RuleFor(c => c.DescricaoFornecedor)
                 .NotEmpty().WithMessage("Favor Inserir uma Descrição do fornecedor.");

            RuleFor(c => c.CnpjFornecedor)
                .Must(IsCnpJ).WithMessage("Favor Inserir um CNPJ Válido.");
        }

        private bool IsCnpJ(string arg)
        {
            return ValidaCnpj.IsCnpj(arg);
        }
    }
}

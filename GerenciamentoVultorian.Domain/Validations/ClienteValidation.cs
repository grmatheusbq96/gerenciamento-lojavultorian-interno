using FluentValidation;
using GerenciamentoVultorian.Domain.Models;

namespace GerenciamentoVultorian.Domain.Validations;

public class ClienteValidation : AbstractValidator<ClienteModel>
{
    public ClienteValidation()
    {
        RuleFor(c => c.Nome).Length(0, 100).WithErrorCode("403").WithMessage("O campo 'Nome' deve conter no máximo 100 caracteres.").NotNull().NotEmpty().WithMessage("O nome deve ser informado.");
        RuleFor(c => c.Documento).Must(d => Utils.ValidadorUtil.ValidarCpf(d)).WithMessage("O documento informado é inválido.");
        RuleFor(c => c.Endereco).Length(0, 200).WithMessage("O campo 'Endereço' deve conter no máximo 200 caracteres.");
        RuleFor(c => c.Celular).Length(0, 13).WithMessage("O celular informado é inválido").NotNull().NotEmpty().WithMessage("O celular deve ser informado.");
        RuleFor(c => c.Email).EmailAddress().WithMessage("O email informado é inválido.");
    }
}
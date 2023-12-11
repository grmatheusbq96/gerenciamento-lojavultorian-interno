using FluentValidation.Results;

namespace GerenciamentoVultorian.Domain.Validations;

public static class ValidationUtil
{
    public static List<string> AddErrorMessages(this ValidationResult result)
    {
        var retorno = new List<string>();

        if (!result.IsValid)
            result.Errors.ForEach(erro =>
            {
                retorno.Add(erro.ErrorMessage + (!erro.Equals(result.Errors.Last()) ? " " : ""));
            });

        return retorno;
    }
}
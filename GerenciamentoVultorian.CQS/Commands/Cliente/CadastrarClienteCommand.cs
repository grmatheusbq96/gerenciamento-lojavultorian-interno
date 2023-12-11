using GerenciamentoVultorian.CQS.Dtos.Cliente;
using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using MediatR;

namespace GerenciamentoVultorian.CQS.Commands.Cliente;

public class CadastrarClienteCommand : IRequest<ResultViewModel<ClienteViewModel>>
{
    public string Nome { get; set; }
    public string Documento { get; set; }
    public string Endereco { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }

    public CadastrarClienteCommand(CadastrarClienteDto dto)
    {
        Nome = dto.Nome;
        Documento = dto.Documento;
        Endereco = dto.Endereco;
        Celular = dto.Celular;
        Email = dto.Email;
    }
}
using GerenciamentoVultorian.CQS.Dtos.Cliente;
using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using MediatR;

namespace GerenciamentoVultorian.CQS.Commands.Cliente;

public class AlterarClienteCommand : IRequest<ResultViewModel<ClienteViewModel>>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Documento { get; set; }
    public string Endereco { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }

    public AlterarClienteCommand(int id, AlterarClienteDto dto)
    {
        Id = id;
        Nome = dto.Nome;
        Documento = dto.Documento;
        Endereco = dto.Endereco;
        Celular = dto.Celular;
        Email = dto.Email;
    }
}
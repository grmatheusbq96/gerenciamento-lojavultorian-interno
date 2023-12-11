using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using MediatR;

namespace GerenciamentoVultorian.CQS.Queries.Cliente;

public class BuscarClientePorIdQuery : IRequest<ResultViewModel<ClienteViewModel>>
{
    public int Id { get; set; }

    public BuscarClientePorIdQuery(int id)
    {
        Id = id;
    }
}
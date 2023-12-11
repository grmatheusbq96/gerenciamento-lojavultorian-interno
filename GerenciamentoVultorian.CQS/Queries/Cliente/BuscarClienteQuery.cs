using GerenciamentoVultorian.CQS.ViewModels;
using GerenciamentoVultorian.CQS.ViewModels.Result;
using MediatR;

namespace GerenciamentoVultorian.CQS.Queries.Cliente;

public class BuscarClienteQuery : IRequest<ResultViewModel<List<ClienteViewModel>>>
{
}